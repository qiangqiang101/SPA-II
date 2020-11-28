Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports iFruitAddon2
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM

Module Mechanic

    Public iFruit As CustomiFruit
    Public WithEvents MechanicContact, InsuranceContact, Dynasty8Contact As iFruitContact
    Public WithEvents MechanicMenu, MechanicAptMenu, InsuranceMenu, Dynasty8Menu, Dynasty8BuyMenu, Dynasty8TradeMenu As UIMenu

    Public Sub LoadContacts()
        iFruit = New CustomiFruit
        iFruit.Contacts.Clear()
        MechanicContact = New iFruitContact(Game.GetGXTEntry("CELL_E_MP0"))
        With MechanicContact
            .DialTimeout = 4000
            .Active = True
            .Icon = ContactIcon.LSCustoms
        End With
        iFruit.Contacts.Add(MechanicContact)

        InsuranceContact = New iFruitContact(Game.GetGXTEntry("CELL_E_275"))
        With InsuranceContact
            .DialTimeout = 4000
            .Active = True
            .Icon = ContactIcon.MP_MorsMutual
        End With
        iFruit.Contacts.Add(InsuranceContact)

        Dynasty8Contact = New iFruitContact(Game.GetGXTEntry("BLIP_267"))
        With Dynasty8Contact
            .DialTimeout = 4000
            .Active = True
            .Icon = ContactIcon.EstateAgent
        End With
        iFruit.Contacts.Add(Dynasty8Contact)

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        MechanicMenu = New UIMenu("", Game.GetGXTEntry("MPCT_MECHH"), New Point(0, -107))
        With MechanicMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(MechanicMenu)
        End With

        MechanicAptMenu = New UIMenu("", Game.GetGXTEntry("MPCT_PERVEH1"), New Point(0, -107))
        With MechanicAptMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(MechanicAptMenu)
        End With

        InsuranceMenu = New UIMenu("", Game.GetGXTEntry("MPCT_INSH"), New Point(0, -107))
        With InsuranceMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(InsuranceMenu)
        End With

        Dynasty8Menu = New UIMenu("", Game.GetGXTEntry("BLIP_267").ToUpper, New Point(0, -107))
        With Dynasty8Menu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .AddItem(New UIMenuItem(Game.GetGXTEntry("SC_MSC_PPY")) With {.Tag = "Buy"}) 'Property Purchase  SC_MSC_PPY
            .AddItem(New UIMenuItem(Game.GetGXTEntry("MP_REP_PROP_0")) With {.Tag = "Sell"}) 'Trade in Property
            .RefreshIndex()
            MenuPool.Add(Dynasty8Menu)
        End With

        Dynasty8BuyMenu = New UIMenu("", Game.GetGXTEntry("DEL_VEH_SEL0").ToUpper, New Point(0, -107))
        With Dynasty8BuyMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(Dynasty8BuyMenu)
        End With

        Dynasty8TradeMenu = New UIMenu("", Game.GetGXTEntry("DEL_VEH_SEL0").ToUpper, New Point(0, -107))
        With Dynasty8TradeMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(Dynasty8TradeMenu)
        End With
    End Sub

#Region "Mechanic Menu"
    Public Sub RefreshMechanicMenu()
        MechanicMenu.MenuItems.Clear()

        With MechanicMenu
            For Each apt As ApartmentClass In apartments
                If apt.Owner = GetPlayer() AndAlso Not apt.Vehicles.Count = 0 Then
                    Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name)) With {.Tag = apt, .Enabled = Not apt.Vehicles.Count = 0}
                    .AddItem(item)
                End If
            Next
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshMechanicApartmentMenu(apt As ApartmentClass)
        MechanicAptMenu.MenuItems.Clear()

        With MechanicAptMenu
            For Each veh As VehicleClass In apt.Vehicles
                Dim vehic = outVehicleList.Find(Function(x) x.GetInt(vehUidDecor) = veh.UniqueID AndAlso x.GetInt(vehIdDecor) = veh.ApartmentID)
                Dim temp As New VehDeliveryMenuItem(veh, IsGarageVehicleAlreadyExistInWorldMap(apt.ID, veh.UniqueID))
                Dim item As New UIMenuItem($"{veh.Make} {veh.Name} ({veh.PlateNumber})", Game.GetGXTEntry("MPCT_PERVEHC")) With {.Tag = temp}
                If vehic <> Nothing AndAlso vehic.IsDead Then
                    Dim text As String = Game.GetGXTEntry("MPCT_PVNAMEDES1").Replace("~a~", $"{veh.Make} {veh.Name} ({veh.PlateNumber})")
                    item = New UIMenuItem(text, Game.GetGXTEntry("MPCT_PERVEHC")) With {.Tag = temp, .Enabled = False}
                End If
                .AddItem(item)
                MechanicMenu.BindMenuToItem(MechanicAptMenu, item)
            Next
            .RefreshIndex()
        End With
    End Sub

    Private Sub MechanicContact_Answered(contact As iFruitContact) Handles MechanicContact.Answered
        RefreshMechanicMenu()
        MechanicMenu.Visible = True

        Dim r As New Random
        Dim rd As Integer = r.Next(1, 3)
        Select Case rd
            Case 1
                YouNeedSomething.Play
            Case Else
                OnTheClock.Play
        End Select

        iFruit.Close(5000)
    End Sub

    Private Sub MechanicMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MechanicMenu.OnItemSelect
        Dim apt As ApartmentClass = selectedItem.Tag
        RefreshMechanicApartmentMenu(apt)
        MechanicAptMenu.Visible = True
        sender.Visible = False
    End Sub

    Private Sub MechanicAptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MechanicAptMenu.OnItemSelect
        Dim temp As VehDeliveryMenuItem = selectedItem.Tag
        Dim veh As VehicleClass = temp.VehClass
        Dim exist = temp.IsAlreadyExistInWorldMap

        Dim nearestParkingSpot = PP.Position.GetNearestParkingSpot
        Dim distance = nearestParkingSpot.Vector3.DistanceTo(PP.Position)
        If distance >= 50.0F Then
            ICantGetYourRide.Play
        Else
            If nearestParkingSpot.Vector3.IsPositionOccupied(5.0F) Then
                Dim cv As Vehicle = World.GetClosestVehicle(nearestParkingSpot.Vector3, 5.0F)
                If Not cv = Nothing Then If Not cv.IsPersistent Then cv.Delete()
            End If

            If exist Then
                temp.Vehicle.Position = nearestParkingSpot.Vector3
                temp.Vehicle.Heading = nearestParkingSpot.ToQuaternion.W
            Else
                Dim newVeh As Vehicle = CreateGarageVehicle(veh, nearestParkingSpot.ToQuaternion, veh.ApartmentID)
                With newVeh
                    .AddBlip()
                    .CurrentBlip.Sprite = newVeh.Model.GetProperBlipSprite
                    Select Case GetPlayer()
                        Case eOwner.Michael
                            .CurrentBlip.Color = BlipColor.Michael
                        Case eOwner.Franklin
                            .CurrentBlip.Color = BlipColor.Franklin
                        Case eOwner.Trevor
                            .CurrentBlip.Color = BlipColor.Trevor
                        Case eOwner.Others
                            .CurrentBlip.Color = BlipColor.Yellow
                    End Select
                    .CurrentBlip.IsShortRange = True
                    .CurrentBlip.Name = $"{newVeh.Make} {newVeh.FriendlyName}"
                    .PlaceOnGround()
                End With
                outVehicleList.Add(newVeh)
            End If

            IllBeThere.Play
        End If
        sender.Visible = False
    End Sub

    Private Sub MechanicMenu_OnMenuClose(sender As UIMenu) Handles MechanicMenu.OnMenuClose
        IllGetBackToWork.Play
    End Sub
#End Region

#Region "Insurance Menu"
    Public Sub RefreshInsuranceMenu()
        InsuranceMenu.MenuItems.Clear()

        With InsuranceMenu
            For Each veh As Vehicle In outVehicleList
                If veh.Owner = GetPlayer() Then
                    Dim item As New UIMenuItem($"{veh.Make} {veh.FriendlyName}", Game.GetGXTEntry("MPCT_INSD"))
                    With item
                        .SetRightLabel("$500")
                        .Tag = veh
                    End With
                    .AddItem(item)
                End If
            Next
            .RefreshIndex()
        End With
    End Sub

    Private Sub InsuranceContact_Answered(contact As iFruitContact) Handles InsuranceContact.Answered
        RefreshInsuranceMenu()
        InsuranceMenu.Visible = True

        iFruit.Close(5000)
    End Sub

    Private Sub InsuranceMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles InsuranceMenu.OnItemSelect
        Dim veh As Vehicle = selectedItem.Tag

        Player.Money = (PM - 500)
        If veh.IsCurrentVehicleExistInList Then
            veh.CurrentBlip.Remove()
            outVehicleList.Remove(veh)
            veh.Delete()
        End If
        sender.Visible = False
    End Sub
#End Region

#Region "Dynasty8 Menu"
    Public Sub RefreshDynasty8BuyMenu()
        Dynasty8BuyMenu.MenuItems.Clear()

        With Dynasty8BuyMenu
            Dim vacant = (From a In apartments Where a.Owner = eOwner.Nobody)

            For Each apt As ApartmentClass In vacant
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
                With item
                    .Tag = apt
                    .SetRightLabel($"${apt.Price.ToString("0,0")}")
                End With
                .AddItem(item)
                Dynasty8Menu.BindMenuToItem(Dynasty8BuyMenu, item)
            Next
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshDynasty8TradeMenu()
        Dynasty8TradeMenu.MenuItems.Clear()

        With Dynasty8TradeMenu
            Dim playerApts = (From a In apartments Where a.Owner = GetPlayer())

            For Each apt As ApartmentClass In playerApts
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry("MP_REP_PROP_3"))
                With item
                    .Tag = apt
                    .SetRightLabel($"${(apt.Price - (apt.Price * 0.005)).ToString("0,0")}")
                End With
                .AddItem(item)
                Dynasty8Menu.BindMenuToItem(Dynasty8TradeMenu, item)
            Next
            .RefreshIndex()
        End With
    End Sub

    Private Sub Dynasty8Contact_Answered(contact As iFruitContact) Handles Dynasty8Contact.Answered
        Dynasty8Menu.Visible = True
    End Sub

    Private Sub Dynasty8Menu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles Dynasty8Menu.OnItemSelect
        Select Case selectedItem.Tag
            Case "Buy"
                RefreshDynasty8BuyMenu()
                Dynasty8BuyMenu.Visible = True
                sender.Visible = False
            Case "Sell"
                RefreshDynasty8TradeMenu()
                Dynasty8TradeMenu.Visible = True
                sender.Visible = False
        End Select
    End Sub

    Private Sub Dynasty8BuyMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles Dynasty8BuyMenu.OnItemSelect
        Dim apt As ApartmentClass = selectedItem.Tag
        Dim bld As BuildingClass = apt.Building

        Select Case GetPlayer()
            Case eOwner.Michael, eOwner.Franklin, eOwner.Trevor
                If PM > apt.Price Then
                    apt.UpdateApartmentOwner
                    Player.Money = (PM - apt.Price)
                    Dynasty8BuyMenu.Visible = False
                    iFruit.Close()
                    With bld
                        .BuildingBlip.Remove()
                        If Not .GarageBlip Is Nothing Then .GarageBlip.Remove()
                        .RefreshBuyMenu()
                        .RefreshAptMenu()
                        .RefreshGrgMenu()
                        .RefreshBlips()
                        PlayPropertyPurchase(apt.Name)
                    End With
                Else
                    UI.ShowSubtitle(Game.GetGXTEntry("MP_REP_PROP_4"))
                End If
            Case Else
                apt.UpdateApartmentOwner
                Player.Money = (PM - apt.Price)
                Dynasty8BuyMenu.Visible = False
                iFruit.Close()
                With bld
                    .BuildingBlip.Remove()
                    If Not .GarageBlip Is Nothing Then .GarageBlip.Remove()
                    .RefreshBuyMenu()
                    .RefreshAptMenu()
                    .RefreshGrgMenu()
                    .RefreshBlips()
                    PlayPropertyPurchase(apt.Name)
                End With
        End Select
    End Sub

    Private Sub Dynasty8TradeMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles Dynasty8TradeMenu.OnItemSelect
        Dim apt As ApartmentClass = selectedItem.Tag
        Dim bld As BuildingClass = apt.Building

        apt.UpdateApartmentOwner(True)
        Player.Money = (PM + apt.Price + (apt.Price * 0.005))
        Dynasty8TradeMenu.Visible = False
        iFruit.Close()
        With bld
            .BuildingBlip.Remove()
            If Not .GarageBlip Is Nothing Then .GarageBlip.Remove()
            .RefreshBuyMenu()
            .RefreshAptMenu()
            .RefreshGrgMenu()
            .RefreshBlips()
        End With
    End Sub
#End Region

End Module
