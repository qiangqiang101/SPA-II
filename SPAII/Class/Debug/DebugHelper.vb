Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports NFunc = GTA.Native.Function

Module DebugHelper

    <Extension>
    Public Function GetRaycastCoords(cam As Camera) As Vector3
        Dim rr As RaycastResult = World.Raycast(cam.Position, cam.Direction, 1000.0F, IntersectOptions.Everything, Game.Player.Character)
        Return rr.HitCoords
    End Function

    Private Function DegToRad(deg As Double) As Double
        Return deg * System.Math.PI / 180.0
    End Function

    <Extension>
    Public Function RotationToDirection(rot As Vector3) As Vector3
        Dim rotZ As Double = DegToRad(rot.Z)
        Dim rotX As Double = DegToRad(rot.X)
        Dim num3 As Double = System.Math.Abs(System.Math.Cos(rotX))
        Return New Vector3(CSng((0.0 - System.Math.Sin(rotZ)) * num3), CSng(System.Math.Cos(rotZ) * num3), CSng(System.Math.Sin(rotX)))
    End Function

    Public WithEvents DebugMenu As UIMenu

    Public Sub LoadDebugMenu()
        DebugMenu = New UIMenu("", "DEBUG MENU", New Point(0, -107))
        With DebugMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            MenuPool.Add(DebugMenu)
            For Each apt As ApartmentClass In apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name)) With {.Tag = apt}
                .AddItem(item)
            Next
            .AddItem(New UIMenuItem("Clear Selection"))
            .AddItem(New UIMenuItem("Debug Camera"))
            .RefreshIndex()
        End With
    End Sub

    Private Sub DebugMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles DebugMenu.OnItemSelect
        Select Case selectedItem.Text
            Case "Clear Selection"
                LowEndApartment.Apartment = Nothing
                MediumEndApartment.Apartment = Nothing
                HighEndApartment.Building = Nothing
                TwoCarGarage.Apartment = Nothing
                SixCarGarage.Apartment = Nothing
                TenCarGarage.Apartment = Nothing
            Case "Debug Camera"
                DebugCamera.Toggle()
            Case Else
                Dim selectedApt As ApartmentClass = selectedItem.Tag
                selectedApt.SetInteriorActive()
                Select Case selectedApt.ApartmentType
                    Case eApartmentType.LowEnd
                        Game.Player.Character.Position = selectedApt.InteriorPos
                        LowEndApartment.Apartment = selectedApt
                        LowEndApartment.SpawnDoor()
                    Case eApartmentType.MediumEnd
                        Game.Player.Character.Position = selectedApt.InteriorPos
                        MediumEndApartment.Apartment = selectedApt
                        MediumEndApartment.SpawnDoor()
                    Case eApartmentType.None, eApartmentType.IPL, eApartmentType.IPLwoStyle
                        Game.Player.Character.Position = selectedApt.InteriorPos
                        HighEndApartment.Building = selectedApt.Building
                    Case eApartmentType.Other
                        Game.Player.Character.Position = selectedApt.Building.BuildingInPos.ToVector3
                End Select
        End Select
    End Sub
End Module
