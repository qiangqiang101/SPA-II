Imports System.IO
Imports GTA
Imports GTA.Native
Imports Metadata

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
                            If Game.IsControlJustReleased(0, Control.Context) Then
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
                            If Game.IsControlJustReleased(0, Control.Context) Then
                                FadeScreen(1)
                                bd.AptMenu.Visible = True
                                World.RenderingCamera = World.CreateCamera(bd.CameraPos.Position, bd.CameraPos.Rotation, bd.CameraPos.FOV)
                                HideHud = True
                                FadeScreen(0)
                            End If
                        End If
                    End If

                    'Open Garage Menu
                    If bd.GarageDistance <= 5.0F Then
                        If Not MenuPool.IsAnyMenuOpen Then
                            UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1B"))
                            If Game.IsControlJustReleased(0, Control.Context) Then
                                bd.GrgMenu.Visible = True
                            End If
                        End If
                    End If

                    'When Player is in any interior
                    If bd.IsAtHome() Then
                        'Hide Building Exteriors
                        bd.HideExterior()
                    End If
                Next

                TenCarGarageOnTick()

                For Each apt As ApartmentClass In apartments
                    'Open Exit Apartment Menu
                    If apt.ExitDistance <= 2.0F Then
                        If Not MenuPool.IsAnyMenuOpen Then
                            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
                            If Game.IsControlJustReleased(0, Control.Context) Then
                                apt.AptMenu.Visible = True
                            End If
                        End If
                    End If

                    'Get into bed
                    If apt.SaveDistance <= 2.0F Then
                        UI.ShowHelpMessage(Game.GetGXTEntry("SA_BED_IN"))
                        'todo
                    End If
                Next

                Debug()
                MenuPool.ProcessMenus()
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try

        If HideHud Then
            Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
        End If
    End Sub

    Private Sub SPA2_Aborted(sender As Object, e As EventArgs) Handles Me.Aborted
        For Each building In buildings
            If building.SaleSignProp <> Nothing Then building.SaleSignProp.Delete()
            building.BuildingBlip.Remove()
            If Not building.GarageBlip = Nothing Then building.GarageBlip.Remove()
        Next
    End Sub

End Class
