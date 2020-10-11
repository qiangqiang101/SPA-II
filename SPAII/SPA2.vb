Imports System.IO
Imports GTA
Imports GTA.Native

Public Class SPA2
    Inherits Script

    Public Sub New()
        LoadBuildings()
    End Sub

    Private Sub SPA2_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        PP = Game.Player.Character
        LV = Game.Player.Character.LastVehicle
        PM = Game.Player.Money
        Player = Game.Player

        Try
            If buildingsLoaded Then
                For Each bd As BuildingClass In buildings
                    If bd.EntranceDistance <= 2.0F Then
                        If Not MenuPool.IsAnyMenuOpen() Then
                            UI.ShowHelpMessage($"Press ~INPUT_CONTEXT~ to enter {bd.Name}.")
                            If Game.IsControlJustReleased(0, Control.Context) Then
                                FadeScreen(1)
                                bd.AptMenu.Visible = True
                                World.RenderingCamera = World.CreateCamera(bd.CameraPos.Position, bd.CameraPos.Rotation, bd.CameraPos.FOV)
                                HideHud = True
                                FadeScreen(0)
                            End If
                        End If
                    End If

                    If bd.IsAtHome() Then bd.HideExterior()

                    For Each apt As ApartmentClass In bd.Apartments

                    Next

                Next

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
            building.BuildingBlip.Remove()
            If Not building.GarageBlip = Nothing Then building.GarageBlip.Remove()
        Next
    End Sub

End Class
