﻿Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports GTA
Imports GTA.Math
Imports GTA.Native
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
    End Sub

    Private Sub SPA2_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        RegisterDecor(vehIdDecor, Decor.eDecorType.Int)
        RegisterDecor(vehUidDecor, Decor.eDecorType.Int)

        PP = Game.Player.Character
        LV = Game.Player.Character.LastVehicle
        PM = Game.Player.Money
        Player = Game.Player

        Try
            If Not forSaleSignSpawned Then SpawnForSaleSigns()

            If buildingsLoaded Then
                For Each bd As BuildingClass In buildings
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
                                Case eBuildingType.Garage
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1B"))
                                Case eBuildingType.ClubHouse
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_BUZZ_CLU"))
                                Case eBuildingType.Office
                                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_BUZZ_OFF"))
                            End Select
                            If Game.IsControlJustReleased(0, GameControl.Context) Then
                                FadeScreen(1)
                                bd.AptMenu.Visible = True
                                World.RenderingCamera = World.CreateCamera(bd.CameraPos.Position, bd.CameraPos.Rotation, bd.CameraPos.FOV)
                                HideHud = True
                                FadeScreen(0)
                            End If
                        End If
                    End If

                    'Open Garage Menu
                    If bd.GarageDistance <= 10.0F Then
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

                        TwoCarGarageOnTick()
                        SixCarGarageOnTick()
                        TenCarGarageOnTick()
                        MediumEndApartmentOnTick()
                        LowEndApartmentOnTick()
                    End If
                Next

                For Each apt As ApartmentClass In apartments
                    If Not apt.ShareInterior Then
                        'Using Wardrobe
                        If apt.WardrobeDistance() <= 2.0F Then
                            'todo
                        End If

                        'Open Exit Apartment Menu
                        If apt.ExitDistance <= 2.0F Then
                            If Not MenuPool.IsAnyMenuOpen Then
                                UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
                                If Game.IsControlJustReleased(0, GameControl.Context) Then
                                    apt.AptMenu.Visible = True
                                End If
                            End If
                        End If

                        'Get into bed
                        If apt.SaveDistance <= 2.0F Then
                            UI.ShowHelpMessage(Game.GetGXTEntry("SA_BED_IN"))
                            'todo
                        End If
                    End If
                Next

                If PP.LastVehicle.IsPersonalVehicle Then
                    If PP.IsInVehicle() Then
                        PP.LastVehicle.CurrentBlip.Alpha = 0
                    Else
                        PP.LastVehicle.CurrentBlip.Alpha = 255
                    End If
                End If

                Debug()
                MenuPool.ProcessMenus()
            End If

            'Request GXT2 texts
            RequestAdditionalText("s_range", "SHR_EXIT_HELP")

            If HideHud Then
                NFunc.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
            End If

            If Player.IsAiming Then
                Dim prop = Player.GetTargetedEntity
                If prop = Nothing Then
                    debug3rdLine = "Nothing to show"
                Else
                    debug3rdLine = $".Door = New Door({prop.Model.Hash}, New Vector3({prop.Position.X}F, {prop.Position.Y}F, {prop.Position.Z}F))"
                End If
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub SPA2_Aborted(sender As Object, e As EventArgs) Handles Me.Aborted
        For Each building In buildings
            If building.SaleSignProp <> Nothing Then building.SaleSignProp.Delete()
            building.BuildingBlip.Remove()
            If Not building.GarageBlip = Nothing Then building.GarageBlip.Remove()
        Next

        For Each vehicle In outVehicleList
            vehicle.CurrentBlip.Remove()
            vehicle.Delete()
        Next

        TwoCarGarage.Clear()
        SixCarGarage.Clear()
        TenCarGarage.Clear()
        LowEndApartment.Clear()
        MediumEndApartment.Clear()
    End Sub

    Private Sub SPA2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If Game.IsKeyPressed(Keys.NumPad0) Then
        '    Dim gpcp = GameplayCamera.Position
        '    Dim gpcr = GameplayCamera.Rotation
        '    Logger.Logg($".EnterCamera1 = New CameraPRH(New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z}F), New Vector3({gpcr.X}F, 0F, {gpcr.Z}F), 50.0F){vbNewLine}.EnterCamera2 = New CameraPRH(New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z}F), New Vector3({gpcr.X + 60.0F}F, 0F, {gpcr.Z}F), 50.0F)")
        '    UI.ShowSubtitle("Gameplay camera copied")
        'End If
        If Game.IsKeyPressed(Keys.Left) Then
            Dim gpcp = Game.Player.Character.Position
            Dim gpcr = GameplayCamera.Rotation
            Logger.Logg($".EnterCam = New CameraPRH(New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z}F), New Vector3({gpcr.X}F, 0F, {gpcr.Z}F), 50.0F)")
            UI.ShowSubtitle("Gameplay camera copied")
        End If
        If Game.IsKeyPressed(Keys.Right) Then
            Logger.Logg(debug3rdLine)
            UI.ShowSubtitle("Prop captured")
        End If
        If Game.IsKeyPressed(Keys.Up) Then
            Dim gpcp = Game.Player.Character.Position
            Logger.Logg($".ApartmentDoorPos = New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z - 1.0F}F)")
            UI.ShowSubtitle("Position copied")
        End If
        If Game.IsKeyPressed(Keys.Down) Then
            Dim gpcp = Game.Player.Character.Position
            Dim head = Game.Player.Character.Heading
            Logger.Logg($"New Quaternion({gpcp.X}F, {gpcp.Y}F, {gpcp.Z}F, {head}F")
        End If
        'If Game.IsKeyPressed(Keys.NumPad1) Then
        '    Dim gpcp = GameplayCamera.Position
        '    Dim gpcr = GameplayCamera.Rotation
        '    Logger.Logg($".EnterCamera1 = New CameraPRH(New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z}F), New Vector3({gpcr.X}F, 0F, {gpcr.Z}F), 50.0F)")
        '    UI.ShowSubtitle("Gameplay camera copied 1")
        'End If
        'If Game.IsKeyPressed(Keys.NumPad2) Then
        '    Dim gpcp = GameplayCamera.Position
        '    Dim gpcr = GameplayCamera.Rotation
        '    Logger.Logg($".EnterCamera2 = New CameraPRH(New Vector3({gpcp.X}F, {gpcp.Y}F, {gpcp.Z}F), New Vector3({gpcr.X}F, 0F, {gpcr.Z}F), 50.0F)")
        '    UI.ShowSubtitle("Gameplay camera copied 2")
        'End If
    End Sub

End Class
