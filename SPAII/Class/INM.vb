Imports GTA
Imports GTA.Math

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

    End Class

End Namespace