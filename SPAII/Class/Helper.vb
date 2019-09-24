Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Native
Imports Metadata

Module Helper

    'Config
    Public config As ScriptSettings = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

    'Path 
    Public aptXmlPath As String = ".\scripts\SPA II\Apartments\"
    Public grgXmlPath As String = ".\scripts\SPA II\Garages\"
    Public soundPath As String = ".\scripts\SPA II\Sounds\"

    'Decor
    Public nitroModDecor As String = "inm_nitro_active"

    'Memory
    Public buildings As New List(Of BuildingClass)
    Public mikesCars As New List(Of Vehicle)
    Public franksCars As New List(Of Vehicle)
    Public trevsCars As New List(Of Vehicle)
    Public playersCars As New List(Of Vehicle)
    Public buildingsLoaded As Boolean = False

    Public PP As Ped
    Public LV As Vehicle

    <Extension>
    Public Function Make(vehicle As Vehicle) As String
        Return Game.GetGXTEntry(vehicle.Model.Hash.GetVehicleMakeName)
    End Function

    <Extension>
    Public Function WheelsVariation(vehicle As Vehicle) As Boolean
        Return Native.Function.Call(Of Boolean)(Native.Hash.GET_VEHICLE_MOD_VARIATION, vehicle, VehicleMod.FrontWheels)
    End Function

    <Extension>
    Public Function ToColor(vs As VsColor) As Color
        Return Color.FromArgb(vs.Red, vs.Green, vs.Blue)
    End Function

    <Extension>
    Public Function ToVsColor(col As Color) As VsColor
        Return New VsColor(col.R, col.G, col.B)
    End Function

    <Extension()>
    Public Function Livery2(veh As Vehicle) As Integer
        Return Native.Function.Call(Of Integer)(DirectCast(&H60190048C0764A26UL, Hash), veh.Handle)
    End Function

    <Extension()>
    Public Sub Livery2(veh As Vehicle, liv As Integer)
        Native.Function.Call(DirectCast(&HA6D3A8750DC73270UL, Hash), veh.Handle, liv)
    End Sub

    <Extension>
    Public Function XenonHeadlightsColor(ByVal veh As Vehicle) As Integer
        Return Native.Function.Call(Of Integer)(&H3DFF319A831E0CDB, veh.Handle)
    End Function

    <Extension()>
    Public Sub XenonHeadlightsColor(ByVal veh As Vehicle, colorID As Integer)
        Native.Function.Call(&HE41033B25D003A07UL, veh.Handle, colorID)
    End Sub

    Public Function IsNitroModInstalled() As Boolean
        Return Decor.Registered(nitroModDecor, Decor.eDecorType.Bool)
    End Function

    Public Sub LoadBuildings(files As String())
        Dim procFile As String = Nothing
        buildings.Clear()

        Try
            For Each file As String In files
                procFile = file
                Dim bd = New BuildingData(file).Instance
                Dim bc As New BuildingClass(bd.Name, bd.EntrancePos, bd.ExitPos, bd.GarageEntrancePos, bd.GarageExitPos, bd.CameraPos, bd.CameraRot, bd.Apartments, bd.GarageType, bd.BuildingType)
                If Not buildings.Contains(bc) Then buildings.Add(bc)
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {procFile}{ex.StackTrace}")
        Finally
            buildingsLoaded = True
            UI.Notify($"Loaded {buildings.Count} or {files.Count} apartments.")
        End Try
    End Sub

End Module
