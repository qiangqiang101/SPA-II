Imports GTA
Imports GTA.Math

Public Class ApartmentClass

    Public Name As String
    Public Description As String
    Public Price As Integer
    Public SavePos As Vector3
    ''' <summary>
    ''' a.k.a TeleportInside in SPA
    ''' </summary>
    Public ApartmentInPos As Vector3
    ''' <summary>
    ''' a.k.a ApartmentExit in SPA
    ''' </summary>
    Public ApartmentOutPos As Vector3
    Public WardrobePos As Quaternion
    Public GarageFilePath As String
    Public IPL As String
    Public AptStyleCam As CameraPRH
    Public ApartmentType As eApartmentType
    Public GarageElevatorPos As Vector3
    Public GarageMenuPos As Vector3

    Public Function Owner() As Integer
        Return config.GetValue(Of Integer)("BUILDING", Name, -1)
    End Function

    Public Function FriendlyName() As String
        Return Game.GetGXTEntry(Name)
    End Function

    Public Function FriendlyDescription() As String
        Return Game.GetGXTEntry(Description)
    End Function

    Public Function InteriorPos() As Vector3
        Return ApartmentInPos
    End Function

    Public Function ShareInterior() As Boolean
        Select Case ApartmentType
            Case eApartmentType.LowEnd, eApartmentType.MediumEnd
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Sub New()

    End Sub

    Public Sub New(name As String, desc As String, price As Integer, savePos As Vector3, enterPos As Vector3, exitPos As Vector3, wardrobePos As Quaternion, garagePath As String,
                   ipl As String, aptStyleCamPos As CameraPRH, garageElevatorPos As Vector3, garageMenuPos As Vector3, aptType As eApartmentType)
        Me.Name = name
        Description = desc
        Me.Price = price
        Me.SavePos = savePos
        Me.ApartmentInPos = enterPos
        Me.ApartmentOutPos = exitPos
        Me.WardrobePos = wardrobePos
        GarageFilePath = garagePath
        Me.IPL = ipl
        Me.AptStyleCam = aptStyleCamPos
        Me.GarageElevatorPos = garageElevatorPos
        Me.GarageMenuPos = garageMenuPos
        ApartmentType = aptType
    End Sub

End Class

Public Enum eApartmentType
    None
    MediumEnd
    LowEnd
    IPL
    Other
End Enum