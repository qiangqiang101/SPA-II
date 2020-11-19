Imports GTA
Imports GTA.Math

Public Class DebugCamera
    Inherits Script

    Private Shared freeCam As Camera = Nothing
    Public Shared ReadOnly Property Camera() As Camera
        Get
            Return freeCam
        End Get
    End Property

    Public Sub New()

    End Sub

    Private Sub DebugCamera_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        If World.RenderingCamera = freeCam Then
            Game.EnableControlThisFrame(0, Control.LookLeftRight)
            Game.EnableControlThisFrame(0, Control.LookUpDown)
            Game.EnableControlThisFrame(0, Control.CursorX)
            Game.EnableControlThisFrame(0, Control.CursorY)
            Game.EnableControlThisFrame(0, Control.FrontendPauseAlternate)
            Game.EnableControlThisFrame(0, Control.WeaponWheelPrev)
            Game.EnableControlThisFrame(0, Control.WeaponWheelNext)

            Dim lookLR = Game.GetControlNormal(0, Control.LookLeftRight)
            Dim lookUD = Game.GetControlNormal(0, Control.LookUpDown)

            freeCam.Rotation = freeCam.Rotation + New Vector3(lookUD * -10.0F, 0F, lookLR * -10.0F)
            If freeCam.Rotation.X < -90.0F Then freeCam.Rotation = freeCam.Rotation + New Vector3(1.0F, 0F, 0F)
            If freeCam.Rotation.X > 90.0F Then freeCam.Rotation = freeCam.Rotation + New Vector3(-1.0F, 0F, 0F)

            Dim spdMult = 0.25F
            If Game.IsControlPressed(2, Control.Sprint) Then spdMult = 1.0F
            If Game.IsControlPressed(2, Control.Duck) Then spdMult = 0.1F

            Dim pos As Vector3 = freeCam.Position
                Dim rotHead As Vector3 = freeCam.Rotation.RotationToDirection
                Dim camZ As Single = freeCam.Position.Z
                Dim rot As Vector3 = freeCam.Rotation + New Vector3(0F, 0F, -10.0F)
                Dim rot2 As Vector3 = freeCam.Rotation + New Vector3(0F, 0F, 10.0F)
                Dim val3 = rot2.RotationToDirection - rot.RotationToDirection

                If Game.IsControlPressed(0, Control.MoveUpOnly) Then pos += rotHead * spdMult
                If Game.IsControlPressed(0, Control.MoveDownOnly) Then pos -= rotHead * spdMult
                If Game.IsControlPressed(0, Control.MoveLeftOnly) Then pos += val3 * (spdMult * 2.0F)
                If Game.IsControlPressed(0, Control.MoveRightOnly) Then pos -= val3 * (spdMult * 2.0F)
                If Game.IsControlPressed(0, Control.PhoneLeft) Then
                    Dim obj As Camera = freeCam
                    obj.Rotation = obj.Rotation - New Vector3(0F, 0.5F, 0F)
                End If
                If Game.IsControlPressed(0, Control.PhoneRight) Then
                    Dim obj As Camera = freeCam
                    obj.Rotation = obj.Rotation + New Vector3(0F, 0.5F, 0F)
                End If
                If Game.IsControlPressed(0, Control.PhoneUp) Then
                    Dim obj As Camera = freeCam
                    obj.FieldOfView = obj.FieldOfView - 0.5F
                End If
                If Game.IsControlPressed(0, Control.PhoneDown) Then
                    Dim obj As Camera = freeCam
                    obj.FieldOfView = obj.FieldOfView + 0.5F
                End If
                If Game.IsControlPressed(0, Control.Reload) Then
                    freeCam.FieldOfView = 50.0F
                    freeCam.Rotation = GameplayCamera.Rotation
                    freeCam.Position = GameplayCamera.Position
                End If
                freeCam.Position = pos
            End If
    End Sub

    Public Shared Function IsEnabled() As Boolean
        If Not freeCam = Nothing Then Return freeCam.IsActive
        Return False
    End Function

    Public Shared Sub Toggle()
        If IsEnabled() Then Disable() Else Enable()
    End Sub

    Public Shared Sub Enable()
        freeCam = World.CreateCamera(GameplayCamera.Position, GameplayCamera.Rotation, 50.0F)
        World.RenderingCamera = freeCam
        Game.Player.Character.Task.StartScenario("WORLD_HUMAN_YOGA", Game.Player.Character.Position, Game.Player.Character.Heading)
        Game.Player.Character.Task.LookAt(freeCam.Position)
        Game.Player.Character.AlwaysKeepTask = True
    End Sub

    Public Shared Sub Disable()
        freeCam.Destroy()
        World.RenderingCamera = Nothing
        Game.Player.Character.Task.ClearAllImmediately()
    End Sub

End Class