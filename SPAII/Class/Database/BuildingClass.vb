Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI

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

    Public BuildingBlip As Blip
    Public GarageBlip As Blip

    Public WithEvents AptMenu As UIMenu
    Public WithEvents GrgMenu As UIMenu

    Public Sub New()
        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        Dim apts As New List(Of ApartmentClass)
        For Each apt In Apartments
            If config.GetValue(Of Integer)("BUILDING", apt.Name, -1) <> -1 Then apts.Add(apt) 'If has owner then Add
        Next

        BuildingBlip = World.CreateBlip(BuildingInPos)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If apts.Count = 0 Then
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

        If apts.Count <> 0 AndAlso Not BuildingType = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(GarageInPos)
            With GarageBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"Garage: {Name}"
            End With
        End If

        AptMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2A"), New Point(0, -107))
        Dim Rectangle As New UIResRectangle(Point.Empty, New Size(0, 0), Color.FromArgb(0, 0, 0, 0))
        AptMenu.SetBannerType(Rectangle)
        AptMenu.MouseEdgeEnabled = False
        MenuPool.Add(AptMenu)
        With AptMenu
            For Each apt As ApartmentClass In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of Integer)("BUILDING", apt.Name, -1)
                        Case -1 'For Sale
                            .SetRightLabel($"${apt.Price.ToString("0,0")}")
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case 0 'Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case 1 'Frankline
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case 2 'Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case 3 'Player3
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        GrgMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2B"), New Point(0, -107))
        GrgMenu.SetBannerType(Rectangle)
        GrgMenu.MouseEdgeEnabled = False
        MenuPool.Add(GrgMenu)
        With GrgMenu
            For Each apt In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of Integer)("BUILDING", apt.Name, -1)
                        Case -1 'For Sale
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case 0 'Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case 1 'Frankline
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case 2 'Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case 3 'Player3
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With
    End Sub

    Public Sub New(name As String, entrancePos As Vector3, exitPos As Quaternion, garageEntrancePos As Vector3, garageExitPos As Quaternion, cameraPos As CameraPRH,
                   garageType As eGarageType, buildingType As eBuildingType, apartments As List(Of ApartmentClass))
        Me.Name = name
        Me.BuildingInPos = entrancePos
        Me.BuildingOutPos = exitPos
        Me.GarageInPos = garageEntrancePos
        Me.GarageOutPos = garageExitPos
        Me.CameraPos = cameraPos
        Me.Apartments = apartments
        Me.GarageType = garageType
        Me.BuildingType = buildingType

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        Dim apts As New List(Of ApartmentClass)
        For Each apt In apartments
            If config.GetValue(Of Integer)("BUILDING", apt.Name, -1) <> -1 Then apts.Add(apt) 'If has owner then Add
        Next

        BuildingBlip = World.CreateBlip(entrancePos)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If apts.Count = 0 Then
                Select Case buildingType
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
                Select Case buildingType
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
                .Name = name
            End If
        End With

        If apts.Count <> 0 AndAlso Not buildingType = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(garageEntrancePos)
            With GarageBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"Garage: {name}"
            End With
        End If

        AptMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2A"), New Point(0, -107))
        Dim Rectangle As New UIResRectangle(Point.Empty, New Size(0, 0), Color.FromArgb(0, 0, 0, 0))
        AptMenu.SetBannerType(Rectangle)
        AptMenu.MouseEdgeEnabled = False
        MenuPool.Add(AptMenu)
        With AptMenu
            For Each apt As ApartmentClass In apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of Integer)("BUILDING", apt.Name, -1)
                        Case -1 'For Sale
                            .SetRightLabel($"${apt.Price.ToString("0,0")}")
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case 0 'Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case 1 'Frankline
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case 2 'Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case 3 'Player3
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        GrgMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2B"), New Point(0, -107))
        GrgMenu.SetBannerType(Rectangle)
        GrgMenu.MouseEdgeEnabled = False
        MenuPool.Add(GrgMenu)
        With GrgMenu
            For Each apt In apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
                With item
                    Select Case config.GetValue(Of Integer)("BUILDING", apt.Name, -1)
                        Case -1 'For Sale
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case 0 'Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case 1 'Frankline
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case 2 'Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case 3 'Player3
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshAptMenu()
        AptMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description))
            With item
                Select Case config.GetValue(Of Integer)("BUILDING", apt.Name, -1)
                    Case -1 'For Sale
                        .SetRightLabel($"${apt.Price.ToString("0,0")}")
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case 0 'Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case 1 'Frankline
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case 2 'Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case 3 'Player3
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
                Select Case config.GetValue(Of Integer)("BUILDING", apt.Name, -1)
                    Case -1 'For Sale
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case 0 'Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case 1 'Frankline
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case 2 'Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case 3 'Player3
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

    Public Function IsAtHome(apt As ApartmentClass) As Boolean
        Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
        Dim pIntID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z)
        Return intID = pIntID
    End Function

    Public Function InteriorID(apt As ApartmentClass)
        Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
    End Function

    Public Sub SetInteriorActive(apt As ApartmentClass)
        Try
            Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
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
            For Each apt In Apartments
                Dim selectedApt As ApartmentClass = selectedItem.Tag
                If selectedApt.Name = apt.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso apt.Owner = -1 Then
                    'Buy Apartment
                    If PM > apt.Price Then
                        apt.UpdateApartmentOwner()
                        FadeScreen(1)
                        Player.Money = (PM - apt.Price)
                        BuildingBlip.Remove()
                        If Not GarageBlip Is Nothing Then GarageBlip.Remove()
                        RefreshAptMenu()
                        RefreshGrgMenu()
                        'UpdateMechanicMenu
                        FadeScreen(0)
                        PlayPropertyPurchase(apt.Name)
                        Select Case GetPlayerNum()
                            Case 0
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                            Case 1
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                            Case 2
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                            Case Else
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                        End Select
                        selectedItem.SetRightLabel(Nothing)
                        RefreshBlips()
                    End If
                ElseIf selectedApt.Name = apt.Name AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso apt.Owner = GetPlayerNum() Then
                    AptMenu.Visible = False
                    HideHud = False
                    World.DestroyAllCameras()
                    World.RenderingCamera = Nothing
                    apt.SetInteriorActive()
                    FadeScreen(1)
                    PP.Position = apt.ApartmentInPos
                    FadeScreen(0)
                End If
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub GrgMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles GrgMenu.OnItemSelect
        Try
            For Each apt In Apartments
                Dim selectedApt As ApartmentClass = selectedItem.Tag
                If selectedApt.Name = apt.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    If Not PP.IsInVehicle Then
                        'On Foot
                        FadeScreen(1)
                        Select Case GarageType
                            Case eGarageType.TwoCarGarage
                                TwoCarGarage.SetInteriorActive()
                            Case eGarageType.SixCarGarage
                                SixCarGarage.SetInteriorActive()
                            Case eGarageType.TenCarGarage
                                TenCarGarage.SetInteriorActive()
                            Case eGarageType.TwentyCarGarage
                                TwentyCarGarage.SetInteriorActive()
                        End Select
                        FadeScreen(0)
                    Else
                        'In Vehicle

                    End If



                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AptMenu_OnMenuClose(sender As UIMenu) Handles AptMenu.OnMenuClose
        FadeScreen(1)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        HideHud = False
        FadeScreen(0)
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