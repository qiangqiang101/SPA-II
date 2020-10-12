Imports System.IO
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports SPAII.INM

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

    Public WithEvents AptMenu As UIMenu

    Public Function Owner() As eOwner
        Return config.GetValue(Of eOwner)("BUILDING", Name, eOwner.Nobody)
    End Function

    Public Function FriendlyName() As String
        Return Game.GetGXTEntry(Name)
    End Function

    Public Function FriendlyDescription() As String
        Return Game.GetGXTEntry(Description)
    End Function

    Public Function InteriorPos() As Vector3
        Return WardrobePos.ToVector3
    End Function

    Public Function ShareInterior() As Boolean
        Select Case ApartmentType
            Case eApartmentType.LowEnd, eApartmentType.MediumEnd
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function InteriorID()
        Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, InteriorPos.X, InteriorPos.Y, InteriorPos.Z)
    End Function

    Public Function Vehicles() As List(Of VehicleClass)
        Dim procFile As String = Nothing
        Dim list As New List(Of VehicleClass)
        Try
            For Each file As String In Directory.GetFiles($"{grgXmlPath}{GarageFilePath}", "*.xml")
                procFile = file
                Dim vd As VehicleData = New VehicleData(file).Instance
                Dim v As VehicleClass = New VehicleClass(vd, Owner)
                If Not list.Contains(v) Then list.Add(v)
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message}{procFile}{ex.StackTrace}")
        End Try
        Return list
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

    Public Sub SetInteriorActive()
        Try
            Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, InteriorPos.X, InteriorPos.Y, InteriorPos.Z)
            Native.Function.Call(PIN_INTERIOR_IN_MEMORY, New InputArgument() {intID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

End Class

Public Enum eApartmentType
    None
    MediumEnd
    LowEnd
    IPL
    Other
End Enum

Public Enum eOwner
    Nobody = -1
    Michael
    Franklin
    Trevor
    Others
End Enum