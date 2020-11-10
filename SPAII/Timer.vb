Imports GTA
Imports GTA.Native
Imports NFunc = GTA.Native.Function

Public Class Timer
    Inherits Script

    Public Sub New()

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        If HideHud Then
            NFunc.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
        End If
    End Sub
End Class
