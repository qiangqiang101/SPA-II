Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports NFunc = GTA.Native.Function

Namespace INM

    Public Class CameraPRH

        Public Position As Vector3
        Public Rotation As Vector3
        Public FOV As Single

        Public Sub New(pos As Vector3, rot As Vector3, fov As Single)
            Position = pos
            Rotation = rot
            Me.FOV = fov
        End Sub

        Public Function Zero() As CameraPRH
            Return New CameraPRH(Vector3.Zero, Vector3.Zero, 0F)
        End Function

    End Class

    Public Class EntityVector

        Public Model As String
        Public Position As Quaternion

        Public Sub New(model As String, position As Quaternion)
            Me.Model = model
            Me.Position = position
        End Sub

    End Class

    Public Class Door

        Public ModelHash As Integer
        Public Position As Vector3

        Public Sub New(hash As Integer, position As Vector3)
            ModelHash = hash
            Me.Position = position
        End Sub

        Public Sub LockDoor()
            NFunc.Call(Hash._DOOR_CONTROL, ModelHash, Position.X, Position.Y, Position.Z, True, 0.0, 50.0, 0)
        End Sub

        Public Sub UnlockDoor()
            NFunc.Call(Hash._DOOR_CONTROL, ModelHash, Position.X, Position.Y, Position.Z, False, 0.0, 50.0, 0)
        End Sub

    End Class

End Namespace