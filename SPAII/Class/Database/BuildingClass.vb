Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI

Public Class BuildingClass

    Public Name As String
    Public EntrancePos As Vector3
    Public ExitPos As Quaternion
    Public GarageEntrancePos As Vector3
    Public GarageExitPos As Quaternion
    Public CameraPos As Quaternion
    Public CameraRot As Vector3
    Public GarageType As eGarageType
    Public BuildingType As eBuildingType
    Public Apartments As List(Of ApartmentData)

    Public BuildingBlip As Blip
    Public GarageBlip As Blip

    Public WithEvents AptMenu As UIMenu
    Public WithEvents GrgMenu As UIMenu

    Public Sub New(n As String, ep As Vector3, xp As Quaternion, gep As Vector3, gxp As Quaternion, cp As Quaternion, cr As Vector3, a As List(Of ApartmentData),
                   gt As eGarageType, bt As eBuildingType)
        Name = n
        EntrancePos = ep
        ExitPos = xp
        GarageEntrancePos = gep
        GarageExitPos = gxp
        CameraPos = cp
        CameraRot = cr
        Apartments = a
        GarageType = gt
        BuildingType = bt

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        Dim apts As New List(Of ApartmentData)
        For Each apt In a
            If config.GetValue(Of Integer)("BUILDING", apt.Name, -1) <> -1 Then apts.Add(apt) 'If has owner then Add
        Next

        BuildingBlip = World.CreateBlip(EntrancePos)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If apts.Count = 0 Then
                Select Case bt
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
                Select Case bt
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
                .Name = n
            End If
        End With

        If apts.Count <> 0 AndAlso Not bt = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(GarageEntrancePos)
            With BuildingBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"{n} Garage"
            End With
        End If

        AptMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2A"), New Point(0, -107))
        Dim Rectangle As New UIResRectangle()
        Rectangle.Color = Color.FromArgb(0, 0, 0, 0)
        AptMenu.SetBannerType(Rectangle)
        AptMenu.MouseEdgeEnabled = False
        MenuPool.Add(AptMenu)
        With AptMenu
            For Each apt In a
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
                    .SubInteger1 = apt.Price
                    .SubString1 = apt.Name
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
            For Each apt In a
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
            End With
            GrgMenu.AddItem(item)
        Next
        GrgMenu.RefreshIndex()
    End Sub

    Public Function GarageDistance() As Single
        Return Game.Player.Character.Position.DistanceTo(GarageEntrancePos)
    End Function

    Public Function EntranceDistance() As Single
        Return Game.Player.Character.Position.DistanceTo(EntrancePos)
    End Function

    Public Function IsForSale() As Boolean
        Return BuildingBlip.Sprite = BlipSprite.SafehouseForSale Or BlipSprite.OfficeForSale
    End Function

    Public Function WardrobeDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.WardrobePos.Axis)
    End Function

    Public Function SaveDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.SavePos)
    End Function

    Public Function ExitDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.ExitPos)
    End Function

    Public Function GarageElevatorDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.GarageElevatorPos)
    End Function

    Public Function GarageMenuDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.GarageMenuPos)
    End Function

    Public Function IsAtHome(apt As ApartmentData) As Boolean
        Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
        Dim pIntID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z)
        Return intID = pIntID
    End Function

    Public Function InteriorID(apt As ApartmentData)
        Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
    End Function

    Public Sub SetInteriorActive(apt As ApartmentData)
        Try
            Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub AptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles AptMenu.OnItemSelect
        Try
            For Each apt In Apartments
                If selectedItem.SubString1 = apt.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso config.GetValue(Of Integer)("BUILDING", apt.Name, -1) = -1 Then
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
                    End If
                ElseIf selectedItem.SubString1 = apt.Name AndAlso Not selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso config.GetValue(Of Integer)("BUILDING", apt.Name, -1) = GetPlayerNum Then
                    AptMenu.Visible = False
                    hideHud = False
                    World.DestroyAllCameras()
                    World.RenderingCamera = Nothing
                    apt.SetInteriorActive()
                    FadeScreen(1)
                    PP.Position = apt.EnterPos
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
                If selectedItem.SubString1 = apt.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    If Not PP.IsInVehicle Then
                        'On Foot
                        FadeScreen(1)
                        Select Case GarageType
                            Case eGarageType.TwoCarGarage
                                TwoCarGarage.SetInteriorActive()
                            Case eGarageType.FourCarGarage
                                FourCarGarage.SetInteriorActive()
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
