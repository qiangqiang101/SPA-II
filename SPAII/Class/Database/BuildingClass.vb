Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports SPAII.INM

Public Class BuildingClass

    Public Name As String
    ''' <summary>
    ''' a.k.a Entrance in SPA
    ''' </summary>
    Public BuildingInPos As Vector3
    ''' <summary>
    ''' a.k.a TeleportOutside in SPA
    ''' </summary>
    Public BuildingOutPos As Quaternion
    Public GarageInPos As Vector3
    Public GarageOutPos As Quaternion
    Public CameraPos As CameraPRH
    Public GarageType As eGarageType
    Public BuildingType As eBuildingType
    Public Apartments As List(Of ApartmentClass)
    Public HideObjects() As String
    Public SaleSign As EntityVector

    Public BuildingBlip As Blip
    Public GarageBlip As Blip

    Public WithEvents BuyMenu As UIMenu
    Public WithEvents AptMenu As UIMenu
    Public WithEvents GrgMenu As UIMenu

    Public Sub New()

    End Sub

    Public Function IsVacant() As Boolean
        Dim apt = (From a In Apartments Where a.Owner <> eOwner.Nobody Select a)
        Return apt.Count = 0
    End Function

    Public Function SaleSignProp() As Prop
        Return World.GetClosest(SaleSign.Position.ToVector3, World.GetNearbyProps(SaleSign.Position.ToVector3, 50.0F, SaleSign.Model))
    End Function

    Public Sub Load()
        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        BuildingBlip = World.CreateBlip(BuildingInPos)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If IsVacant() Then
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.SafehouseForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE1") 'Apartment For Sale
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.OfficeForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE2") 'Office For Sale
                    Case eBuildingType.ClubHouse, eBuildingType.NightClub, eBuildingType.Bunker
                        .Sprite = BlipSprite.BusinessForSale
                        .Name = Game.GetGXTEntry("BLIP_373") 'Property For Sale
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.GarageForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE0") 'Garage For Sale
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.HangarForSale
                        .Name = Game.GetGXTEntry("BLIP_372") 'Hangar For Sale
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.WarehouseForSale
                        .Name = Game.GetGXTEntry("BLIP_474") 'Warehouse For Sale
                End Select
            Else
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.Safehouse
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.Office
                    Case eBuildingType.ClubHouse
                        .Sprite = BlipSprite.BikerClubhouse
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.Garage
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.GTAOHangar
                    Case eBuildingType.NightClub
                        .Sprite = BlipSprite.NightclubProperty
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.Warehouse
                    Case eBuildingType.Bunker
                        .Sprite = BlipSprite.Bunker
                End Select
                .Name = Name
            End If
        End With

        If Not IsVacant() AndAlso Not BuildingType = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(GarageInPos)
            With GarageBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"Garage: {Name}"
            End With
        End If

        BuyMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN0"), New Point(0, -107))
        BuyMenu.SetBannerType(MenuBanner)
        BuyMenu.MouseEdgeEnabled = False
        MenuPool.Add(BuyMenu)
        With BuyMenu
            For Each apt As ApartmentClass In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                        Case eOwner.Nobody 'For Sale
                            .SetRightLabel($"${apt.Price.ToString("0,0")}")
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case eOwner.Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case eOwner.Franklin
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case eOwner.Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case eOwner.Others
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        AptMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2A"), New Point(0, -107))
        AptMenu.SetBannerType(MenuBanner)
        AptMenu.MouseEdgeEnabled = False
        MenuPool.Add(AptMenu)
        With AptMenu
            For Each apt As ApartmentClass In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                        Case eOwner.Nobody 'For Sale
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case eOwner.Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case eOwner.Franklin
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case eOwner.Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case eOwner.Others
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        GrgMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2B"), New Point(0, -107))
        GrgMenu.SetBannerType(MenuBanner)
        GrgMenu.MouseEdgeEnabled = False
        MenuPool.Add(GrgMenu)
        With GrgMenu
            For Each apt In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                        Case eOwner.Nobody 'For Sale
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case eOwner.Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case eOwner.Franklin
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case eOwner.Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case eOwner.Others
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        Dim ForSaleSign As Prop = World.CreateProp(SaleSign.Model, SaleSign.Position.ToVector3, New Vector3(0F, 0F, SaleSign.Position.W), False, False)
        With ForSaleSign
            .IsPersistent = True
        End With
    End Sub

    Public Sub RefreshBuyMenu()
        BuyMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
            With item
                Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                    Case eOwner.Nobody 'For Sale
                        .SetRightLabel($"${apt.Price.ToString("0,0")}")
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case eOwner.Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case eOwner.Franklin
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case eOwner.Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case eOwner.Others
                        .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                End Select
                .Tag = apt
            End With
            BuyMenu.AddItem(item)
        Next
        BuyMenu.RefreshIndex()
    End Sub

    Public Sub RefreshAptMenu()
        AptMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
            With item
                Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                    Case eOwner.Nobody 'For Sale
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case eOwner.Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case eOwner.Franklin
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case eOwner.Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case eOwner.Others
                        .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                End Select
                .Tag = apt
            End With
            AptMenu.AddItem(item)
        Next
        AptMenu.RefreshIndex()
    End Sub

    Public Sub RefreshGrgMenu()
        GrgMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
            With item
                Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                    Case eOwner.Nobody 'For Sale
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case eOwner.Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case eOwner.Franklin
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case eOwner.Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case eOwner.Others
                        .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                End Select
                .Tag = apt
            End With
            GrgMenu.AddItem(item)
        Next
        GrgMenu.RefreshIndex()
    End Sub

    Public Function GarageDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(GarageInPos)
    End Function

    Public Function EntranceDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(BuildingInPos)
    End Function

    Public Function SaleSignDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(SaleSign.Position.ToVector3)
    End Function

    Public Function IsForSale() As Boolean
        Return BuildingBlip.Sprite = BlipSprite.SafehouseForSale Or BlipSprite.OfficeForSale Or BlipSprite.GarageForSale
    End Function

    Public Function WardrobeDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.WardrobePos.Axis)
    End Function

    Public Function SaveDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.SavePos)
    End Function

    Public Function ExitDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.ApartmentOutPos)
    End Function

    Public Function GarageElevatorDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.GarageElevatorPos)
    End Function

    Public Function GarageMenuDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.GarageMenuPos)
    End Function

    Public Function IsAtHome() As Boolean
        Return Native.Function.Call(Of Boolean)(Hash.IS_INTERIOR_SCENE)
    End Function

    Public Sub HideExterior()
        If Not HideObjects Is Nothing Then
            If IsAtHome() AndAlso HideObjects.Count <> 0 Then
                Native.Function.Call(BEGIN_HIDE_MAP_OBJECT_THIS_FRAME)
                For Each obj In HideObjects
                    Native.Function.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, obj.GetHashKey)
                Next
                Native.Function.Call(DISABLE_OCCLUSION_THIS_FRAME)
            End If
        End If
    End Sub

    Private Sub RefreshBlips()
        BuildingBlip = World.CreateBlip(BuildingInPos)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If Apartments.Count = 0 Then
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.SafehouseForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE1") 'Apartment For Sale
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.OfficeForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE2") 'Office For Sale
                    Case eBuildingType.ClubHouse, eBuildingType.NightClub, eBuildingType.Bunker
                        .Sprite = BlipSprite.BusinessForSale
                        .Name = Game.GetGXTEntry("BLIP_373") 'Property For Sale
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.GarageForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE0") 'Garage For Sale
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.HangarForSale
                        .Name = Game.GetGXTEntry("BLIP_372") 'Hangar For Sale
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.WarehouseForSale
                        .Name = Game.GetGXTEntry("BLIP_474") 'Warehouse For Sale
                End Select
            Else
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.Safehouse
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.Office
                    Case eBuildingType.ClubHouse
                        .Sprite = BlipSprite.BikerClubhouse
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.Garage
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.GTAOHangar
                    Case eBuildingType.NightClub
                        .Sprite = BlipSprite.NightclubProperty
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.Warehouse
                    Case eBuildingType.Bunker
                        .Sprite = BlipSprite.Bunker
                End Select
                .Name = Name
            End If
        End With

        If Apartments.Count <> 0 AndAlso Not BuildingType = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(GarageInPos)
            With GarageBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"{Name} Garage"
            End With
        End If
    End Sub

    Private Sub AptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles AptMenu.OnItemSelect
        Try
            Dim selectedApt As ApartmentClass = selectedItem.Tag
            If selectedApt.Owner = GetPlayer() Then
                AptMenu.Visible = False
                HideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                selectedApt.SetInteriorActive()
                FadeScreen(1)
                PP.Position = selectedApt.ApartmentInPos
                FadeScreen(0)
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub GrgMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles GrgMenu.OnItemSelect
        Try
            Dim selectedApt As ApartmentClass = selectedItem.Tag
            If selectedApt.Owner = GetPlayer() Then
                GrgMenu.Visible = False
                HideHud = False
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                Select Case GarageType
                    Case eGarageType.TwoCarGarage
                        TwoCarGarage.SetInteriorActive()
                    Case eGarageType.SixCarGarage
                        SixCarGarage.SetInteriorActive()
                    Case eGarageType.TenCarGarage
                        FadeScreen(1)
                        TenCarGarage.SetInteriorActive()
                        PP.Position = TenCarGarage
                        FadeScreen(0)
                    Case eGarageType.TwentyCarGarage
                        TwentyCarGarage.SetInteriorActive()
                End Select
                If Not PP.IsInVehicle Then
                    'On Foot

                Else
                    'In Vehicle

                End If
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub AptMenu_OnMenuClose(sender As UIMenu) Handles AptMenu.OnMenuClose, BuyMenu.OnMenuClose
        FadeScreen(1)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        HideHud = False
        FadeScreen(0)
    End Sub

    Private Sub BuyMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles BuyMenu.OnItemSelect
        Try
            For Each apt In Apartments
                Dim selectedApt As ApartmentClass = selectedItem.Tag
                If selectedApt.Name = apt.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso apt.Owner = eOwner.Nobody Then
                    'Buy Apartment
                    If PM > apt.Price Then
                        apt.UpdateApartmentOwner()
                        FadeScreen(1)
                        Player.Money = (PM - apt.Price)
                        BuildingBlip.Remove()
                        If Not GarageBlip Is Nothing Then GarageBlip.Remove()
                        RefreshBuyMenu()
                        RefreshAptMenu()
                        RefreshGrgMenu()
                        'UpdateMechanicMenu
                        FadeScreen(0)
                        PlayPropertyPurchase(apt.Name)
                        Select Case GetPlayer()
                            Case eOwner.Michael
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                            Case eOwner.Franklin
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                            Case eOwner.Trevor
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                            Case Else
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                        End Select
                        selectedItem.SetRightLabel(Nothing)
                        RefreshBlips()
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub
End Class

Public Enum eGarageType
    TwoCarGarage = 2
    SixCarGarage = 6
    TenCarGarage = 10
    TwentyCarGarage = 20
End Enum

Public Enum eBuildingType
    Apartment
    Garage
    Office
    ClubHouse
    Warehouse
    NightClub
    Hangar
    Bunker
End Enum