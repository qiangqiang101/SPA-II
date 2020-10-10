Imports GTA.Math

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
