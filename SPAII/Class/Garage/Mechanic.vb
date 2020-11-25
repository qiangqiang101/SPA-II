Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports iFruitAddon2
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM

Module Mechanic

    Public iFruit As CustomiFruit
    Public WithEvents MechanicContact, InsuranceContact As iFruitContact
    Public WithEvents MechanicMenu, AptMenu, InsuranceMenu As UIMenu

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

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        MechanicMenu = New UIMenu("", Game.GetGXTEntry("MPCT_MECHH"), New Point(0, -107))
        With MechanicMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(MechanicMenu)
        End With

        AptMenu = New UIMenu("", Game.GetGXTEntry("MPCT_PERVEH1"), New Point(0, -107))
        With AptMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(AptMenu)
        End With

        InsuranceMenu = New UIMenu("", Game.GetGXTEntry("MPCT_INSH"), New Point(0, -107))
        With InsuranceMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            .RefreshIndex()
            MenuPool.Add(InsuranceMenu)
        End With
    End Sub

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

    Public Sub RefreshMechanicApartmentMenu(apt As ApartmentClass)
        AptMenu.MenuItems.Clear()

        With AptMenu
            For Each veh As VehicleClass In apt.Vehicles
                Dim vehic = outVehicleList.Find(Function(x) x.GetInt(vehUidDecor) = veh.UniqueID AndAlso x.GetInt(vehIdDecor) = veh.ApartmentID)
                Dim temp As New VehDeliveryMenuItem(veh, IsGarageVehicleAlreadyExistInWorldMap(apt.ID, veh.UniqueID))
                Dim item As New UIMenuItem($"{veh.Make} {veh.Name} ({veh.PlateNumber})", Game.GetGXTEntry("MPCT_PERVEHC")) With {.Tag = temp}
                If vehic <> Nothing AndAlso vehic.IsDead Then
                    Dim text As String = Game.GetGXTEntry("MPCT_PVNAMEDES1").Replace("~a~", $"{veh.Make} {veh.Name} ({veh.PlateNumber})")
                    item = New UIMenuItem(text, Game.GetGXTEntry("MPCT_PERVEHC")) With {.Tag = temp, .Enabled = False}
                End If
                .AddItem(item)
                MechanicMenu.BindMenuToItem(AptMenu, item)
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

    Private Sub InsuranceContact_Answered(contact As iFruitContact) Handles InsuranceContact.Answered
        RefreshInsuranceMenu()
        InsuranceMenu.Visible = True

        iFruit.Close(5000)
    End Sub

    Private Sub MechanicMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MechanicMenu.OnItemSelect
        Dim apt As ApartmentClass = selectedItem.Tag
        RefreshMechanicApartmentMenu(apt)
        AptMenu.Visible = True
        sender.Visible = False
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

    Private Sub AptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles AptMenu.OnItemSelect
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
                'If temp.Vehicle.IsDead Then
                '    temp.Vehicle.Delete()
                '    If temp.Vehicle.IsCurrentVehicleExistInList Then outVehicleList.Remove(temp.Vehicle)

                '    Dim newVeh As Vehicle = CreateGarageVehicle(veh, nearestParkingSpot.ToQuaternion, veh.ApartmentID)
                '    With newVeh
                '        .AddBlip()
                '        .CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                '        Select Case GetPlayer()
                '            Case eOwner.Michael
                '                .CurrentBlip.Color = BlipColor.Michael
                '            Case eOwner.Franklin
                '                .CurrentBlip.Color = BlipColor.Franklin
                '            Case eOwner.Trevor
                '                .CurrentBlip.Color = BlipColor.Trevor
                '            Case eOwner.Others
                '                .CurrentBlip.Color = BlipColor.Yellow
                '        End Select
                '        .CurrentBlip.IsShortRange = True
                '        .CurrentBlip.Name = $"{newVeh.Make} {newVeh.FriendlyName}"
                '        .PlaceOnGround()
                '    End With
                '    outVehicleList.Add(newVeh)
                'Else

                'End If

                temp.Vehicle.Position = nearestParkingSpot.Vector3
                temp.Vehicle.Heading = nearestParkingSpot.ToQuaternion.W
            Else
                Dim newVeh As Vehicle = CreateGarageVehicle(veh, nearestParkingSpot.ToQuaternion, veh.ApartmentID)
                With newVeh
                    .AddBlip()
                    .CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
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

End Module
