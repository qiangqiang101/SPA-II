Imports System.IO
Imports System.Xml.Serialization
Imports GTA
Imports GTA.Math

Public Structure BuildingData

    Public ReadOnly Property Instance As BuildingData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public Name As String
    Public EntrancePos As Vector3
    Public ExitPos As Quaternion
    Public GarageEntrancePos As Vector3
    Public GarageExitPos As Quaternion
    Public CameraPos As Quaternion
    Public CameraRot As Vector3
    Public GarageType As eGarageType
    Public BuildingType As eBuildingType
    Public Apartments As List(Of ApartmentData)


    Public Sub New(_filename As String)
        FileName = _filename
    End Sub

    Public Sub Save()
        Dim ser = New XmlSerializer(GetType(BuildingData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()
    End Sub

    Public Function ReadFromFile() As BuildingData
        If Not File.Exists(FileName) Then
            Return New BuildingData(FileName) With {.Name = Nothing, .EntrancePos = Vector3.Zero, .ExitPos = New Quaternion(), .GarageEntrancePos = Vector3.Zero,
            .GarageExitPos = New Quaternion(), .CameraPos = New Quaternion(), .CameraRot = Vector3.Zero, .GarageType = eGarageType.TenCarGarage,
            .BuildingType = eBuildingType.Apartment, .Apartments = New List(Of ApartmentData)}
        End If

        Try
            Dim ser = New XmlSerializer(GetType(BuildingData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), BuildingData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New BuildingData(FileName) With {.Name = Nothing, .EntrancePos = Vector3.Zero, .ExitPos = New Quaternion(), .GarageEntrancePos = Vector3.Zero,
            .GarageExitPos = New Quaternion(), .CameraPos = New Quaternion(), .CameraRot = Vector3.Zero, .GarageType = eGarageType.TenCarGarage,
            .BuildingType = eBuildingType.Apartment, .Apartments = New List(Of ApartmentData)}
        End Try
    End Function

End Structure

Public Structure ApartmentData

    Public Name As String
    Public Description As String
    Public Price As Integer
    Public SavePos As Vector3
    Public EnterPos As Vector3
    Public ExitPos As Vector3
    Public WardrobePos As Quaternion
    Public InteriorPos As Vector3
    Public GarageFilePath As String
    Public IPL As String
    Public AptStyleCamPos As Quaternion
    Public AptStyleCamRot As Vector3
    Public ShareInterior As Boolean

    <XmlIgnore>
    Public LastIPL As String
    <XmlIgnore>
    Public GarageElevatorPos As Vector3
    <XmlIgnore>
    Public GarageMenuPos As Vector3

    Public Sub New(n As String, d As String, p As Integer, sp As Vector3, ep As Vector3, xp As Vector3, wp As Quaternion,
                   ip As Vector3, gp As String, il As String, ascp As Quaternion, ascr As Vector3, si As Boolean)
        Name = Game.GetGXTEntry(n)
        Description = Game.GetGXTEntry(d)
        Price = p
        SavePos = sp
        EnterPos = ep
        ExitPos = xp
        WardrobePos = wp
        InteriorPos = ip
        GarageFilePath = gp
        IPL = il
        AptStyleCamPos = ascp
        AptStyleCamRot = ascr
        ShareInterior = si
    End Sub

End Structure

Public Enum eGarageType
    TwoCarGarage = 2
    FourCarGarage = 4
    SixCarGarage = 6
    TenCarGarage = 10
    TwentyCarGarage = 20
End Enum

Public Enum eBuildingType
    Apartment
    Garage
    Office
    ClubHouse
    Warehouse
    NightClub
    Hangar
    Bunker
End Enum