﻿Imports System.Drawing
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports iFruitAddon2
Imports Metadata
Imports GameControl = GTA.Control
Imports NFunc = GTA.Native.Function

Public Class SPA2
    Inherits Script

    Public Sub New()
        Decor.Unlock()
        Decor.Register(vehIdDecor, Decor.eDecorType.Int)
        Decor.Register(vehUidDecor, Decor.eDecorType.Int)
        Decor.Lock()

        LoadBuildings()
        LoadContacts()
        LoadWardrobe()
        TwoCarGarage.LoadGarageMenu()
        SixCarGarage.LoadGarageMenu()
        TenCarGarage.LoadGarageMenu()
        LoadDebugMenu()
        EnableOnlineMap()
    End Sub

    Private Sub SPA2_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        RegisterDecor(vehIdDecor, Decor.eDecorType.Int)
        RegisterDecor(vehUidDecor, Decor.eDecorType.Int)

        PP = Game.Player.Character
        LV = Game.Player.Character.LastVehicle
        PM = Game.Player.Money
        Player = Game.Player
        PI = Game.Player.Character.Position.GetInterior

        Try
            If Not forSaleSignSpawned Then SpawnForSaleSignsAndLockDoors()

            If buildingsLoaded Then
                For i As Integer = 0 To buildings.Count - 1
                    Dim bd As BuildingClass = buildings(i)
                    'Open Buy Menu
                    If bd.SaleSignDistance <= 3.0F Then
                        If Not MenuPool.IsAnyMenuOpen() Then
                            Select Case bd.BuildingType
                                Case eBuildingType.Apartment, eBuildingType.ClubHouse
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_PUR0"))
                                Case eBuildingType.Garage, eBuildingType.Hangar
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_PUR1"))
                                Case eBuildingType.Office, eBuildingType.Bunker, eBuildingType.NightClub, eBuildingType.Warehouse
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_OFF_BUY"))
                            End Select
                            If Game.IsControlJustReleased(0, GameControl.Context) Then
                                FadeScreen(1)
                                bd.BuyMenu.Visible = True
                                World.RenderingCamera = World.CreateCamera(bd.CameraPos.Position, bd.CameraPos.Rotation, bd.CameraPos.FOV)
                                HideHud = True
                                FadeScreen(0)
                            End If
                        End If
                    End If

                    'Open Apartment Menu
                    If bd.EntranceDistance <= 2.0F Then
                        If Not MenuPool.IsAnyMenuOpen() Then
                            Select Case bd.BuildingType
                                Case eBuildingType.Apartment
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1"))
                                Case eBuildingType.ClubHouse
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_BUZZ_CLU"))
                                Case eBuildingType.Office
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_BUZZ_OFF"))
                            End Select
                            If Game.IsControlJustReleased(0, GameControl.Context) Then
                                Select Case bd.BuildingType
                                    Case eBuildingType.Apartment, eBuildingType.ClubHouse, eBuildingType.Office
                                        FadeScreen(1)
                                        bd.AptMenu.Visible = True
                                        World.RenderingCamera = World.CreateCamera(bd.CameraPos.Position, bd.CameraPos.Rotation, bd.CameraPos.FOV)
                                        HideHud = True
                                        FadeScreen(0)
                                End Select
                            End If
                        End If
                    End If

                    'Open Garage Menu
                    If bd.GarageDistance <= 5.0F Then
                        If Not MenuPool.IsAnyMenuOpen Then
                            UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1B"))
                            If Game.IsControlJustReleased(0, GameControl.Context) Then
                                bd.GrgMenu.Visible = True
                            End If
                        End If
                    End If

                    'When Player is in any interior
                    If bd.IsAtHome() Then
                        'Hide Building Exteriors
                        bd.HideExterior()

                        If Not TwoCarGarage.Apartment Is Nothing Then TwoCarGarageOnTick()
                        If Not SixCarGarage.Apartment Is Nothing Then SixCarGarageOnTick()
                        If Not TenCarGarage.Apartment Is Nothing Then TenCarGarageOnTick()

                        If Not MediumEndApartment.Apartment Is Nothing Then MediumEndApartmentOnTick()
                        If Not LowEndApartment.Apartment Is Nothing Then LowEndApartmentOnTick()
                    End If

                    'Draw circle
                    If bd.EntranceDistance <= 300.0F AndAlso Not bd.BuildingInPos = QuaternionZero() AndAlso Not bd.BuildingType = eBuildingType.Garage Then bd.BuildingInPos.ToVector3.DrawMarker
                    If bd.GarageDistance <= 300.0F AndAlso Not bd.GarageFootInPos = QuaternionZero() Then bd.GarageFootInPos.ToVector3.DrawMarker

                    If debugMode Then
                        'Debug Circle
                        If bd.EntranceDistance <= 1000.0F Then
                            If Not bd.BuildingLobby = QuaternionZero() Then bd.BuildingLobby.ToVector3.DrawMarker(Color.LightPink, text:="Lobby")
                            If Not bd.BuildingOutPos = QuaternionZero() Then bd.BuildingOutPos.ToVector3.DrawMarker(Color.Red, text:="Out Pos")
                        End If
                        If bd.GarageDistance <= 1000.0F Then
                            If Not bd.GarageInPos = Vector3.Zero Then bd.GarageInPos.DrawMarker(Color.Orange, text:="Car in Pos")
                            If Not bd.GarageFootOutPos = QuaternionZero() Then bd.GarageFootOutPos.ToVector3.DrawMarker(Color.Yellow, text:="Foot out Pos")
                            If Not bd.GarageOutPos = QuaternionZero() Then bd.GarageOutPos.ToVector3.DrawMarker(Color.Green, text:="Car out Pos")
                            If Not bd.GarageWaypoint = QuaternionZero() Then bd.GarageWaypoint.ToVector3.DrawMarker(Color.Indigo, text:="Garage waypoint")
                        End If

                        For a As Integer = 0 To bd.Apartments.Count - 1
                            Dim apt As ApartmentClass = bd.Apartments(a)
                            If apt.ExitDistance <= 3000.0F Then
                                If Not apt.ApartmentDoorPos = QuaternionZero() Then apt.ApartmentDoorPos.ToVector3.DrawMarker(Color.Red, text:=$"Door Pos {apt.FriendlyName}")
                                If Not apt.ApartmentInPos = Vector3.Zero Then apt.ApartmentInPos.DrawMarker(Color.Green, text:=$"Teleport in Pos {apt.FriendlyName}")
                                If Not apt.ApartmentOutPos = Vector3.Zero Then apt.ApartmentOutPos.DrawMarker(Color.Blue, text:=$"Exit Pos {apt.FriendlyName}")
                                If Not apt.WardrobePos = QuaternionZero() Then apt.WardrobePos.ToVector3.DrawMarker(Color.Purple, text:=$"Wardrobe Pos {apt.FriendlyName}")
                                If Not apt.SavePos = Vector3.Zero Then apt.SavePos.DrawMarker(Color.Pink, text:=$"Save Pos {apt.FriendlyName}")
                            End If
                        Next
                    End If
                Next

                HighEndApartmentOnTick()

                'Hide vehicle blip
                If PP.LastVehicle.IsPersonalVehicle Then
                    If PP.IsInVehicle() Then
                        PP.LastVehicle.CurrentBlip.Alpha = 0
                    Else
                        PP.LastVehicle.CurrentBlip.Alpha = 255
                    End If
                End If

                MenuPool.ProcessMenus()
                iFruit.Update()
            End If

            'debug only
            If debugMode Then
                Debug()
                If Player.IsAiming Then
                    Dim prop = Player.GetTargetedEntity
                    If prop = Nothing Then
                        debug3rdLine = "Nothing to show"
                    Else
                        debug3rdLine = $"New Door({prop.Model.Hash}, New Vector3({prop.Position.X}F, {prop.Position.Y}F, {prop.Position.Z}F))"
                    End If
                End If
            End If

            If NewFunc.IsCheating("spadebug") Then debugMode = Not debugMode
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub SPA2_Aborted(sender As Object, e As EventArgs) Handles Me.Aborted
        For Each Building In buildings
            If Building.SaleSignProp <> Nothing Then Building.SaleSignProp.Delete()
            Building.BuildingBlip.Remove()
            If Not Building.GarageBlip = Nothing Then Building.GarageBlip.Remove()
        Next

        For Each vehicle In outVehicleList
            vehicle.CurrentBlip.Remove()
            vehicle.Delete()
        Next

        iFruit.Contacts.Remove(MechanicContact)

        TwoCarGarage.Clear()
        SixCarGarage.Clear()
        TenCarGarage.Clear()
        LowEndApartment.Clear()
        MediumEndApartment.Clear()

        If Not RadioEmitter = Nothing Then RadioEmitter.Delete()

        World.RenderingCamera = Nothing
        World.DestroyAllCameras()
    End Sub

    Private Sub SPA2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If debugMode Then
            If Game.IsKeyPressed(Keys.Up) Then
                If Game.Player.Character.IsInVehicle Then
                    Dim gpccvp = Game.Player.Character.CurrentVehicle.Position
                    Logger.Logg($"New Vector3({gpccvp.X}F, {gpccvp.Y}F, {gpccvp.Z}F)")
                Else
                    Dim gpcp = Game.Player.Character.Position
                    Logger.Logg($"New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z - 1.0F}F)")
                End If
                UI.ShowSubtitle("Position copied")
            End If

            If Game.IsKeyPressed(Keys.Down) Then
                If Game.Player.Character.IsInVehicle Then
                    Dim gpccvp = Game.Player.Character.CurrentVehicle.Position
                    Dim cvhead = Game.Player.Character.CurrentVehicle.Heading
                    Logger.Logg($"New Quaternion({gpccvp.X}F, {gpccvp.Y}F, {gpccvp.Z}F, {cvhead}F)")
                Else
                    Dim gpcp = Game.Player.Character.Position
                    Dim head = Game.Player.Character.Heading
                    Logger.Logg($"New Quaternion({gpcp.X}F, {gpcp.Y}F, {gpcp.Z - 1.0F}F, {head}F)")
                End If
                UI.ShowSubtitle("Quaternion copied")
            End If

            If Game.IsKeyPressed(Keys.Left) Then
                If DebugCamera.IsEnabled Then
                    Dim cam = DebugCamera.Camera
                    Logger.Logg($"New CameraPRH(New Vector3({cam.Position.X}F, {cam.Position.Y}F, {cam.Position.Z}F), New Vector3({cam.Rotation.X}F, {cam.Rotation.Y}F, {cam.Rotation.Z}F), {cam.FieldOfView}F)")
                    UI.ShowSubtitle("Gameplay camera copied")
                End If
            End If

            If Game.IsKeyPressed(Keys.Right) Then
                Logger.Logg(debug3rdLine)
                UI.ShowSubtitle("Prop captured")
            End If

            If Game.IsKeyPressed(Keys.Delete) Then
                DebugCamera.Toggle()
            End If

            If Game.IsKeyPressed(Keys.End) Then
                DebugMenu.Visible = True
            End If
        End If
    End Sub

End Class
