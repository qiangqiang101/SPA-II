Imports System.IO
Imports GTA

Public Class SPA2
    Inherits Script

    Public Sub New()
        LoadBuildings(Directory.GetFiles(aptXmlPath, "*.xml"))
    End Sub

    Private Sub SPA2_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        PP = Game.Player.Character
        LV = Game.Player.Character.LastVehicle
    End Sub

    Private Sub SPA2_Aborted(sender As Object, e As EventArgs) Handles Me.Aborted
        For Each building In buildings
            building.BuildingBlip.Remove()
            If Not building.GarageBlip = Nothing Then building.GarageBlip.Remove()
        Next
    End Sub

End Class
