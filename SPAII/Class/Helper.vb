Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports Metadata

Module Helper

    'Config
    Public config As ScriptSettings = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

    'Path 
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
    Public PM As Integer
    Public Player As Player
    Public HideHud As Boolean

    'Menu
    Public MenuPool As New MenuPool

    'Coords
    Public TwoCarGarage As New Vector3(0, 0, 0)
    Public FourCarGarage As New Vector3(0, 0, 0)
    Public SixCarGarage As New Vector3(0, 0, 0)
    Public TenCarGarage As New Vector3(222.592, -968.1, -99)
    Public TwentyCarGarage As New Vector3(0, 0, 0)

    <Extension>
    Public Function Make(vehicle As Vehicle) As String
        Return Game.GetGXTEntry(Native.Function.Call(Of String)(&HF7AF4F159FF99F97UL, vehicle.Model.Hash))
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

    Public Function IsNitroModInstalled() As Integer
        Return Decor.Registered(nitroModDecor, Decor.eDecorType.Int)
    End Function

    Public Sub DisplayHelpTextThisFrame(helpText As String, Optional Shape As Integer = -1)
        Native.Function.Call(Native.Hash._SET_TEXT_COMPONENT_FORMAT, "CELL_EMAIL_BCON")
        Const maxStringLength As Integer = 99

        Dim i As Integer = 0
        While i < helpText.Length
            Native.Function.Call(Native.Hash._0x6C188BE134E074AA, helpText.Substring(i, System.Math.Min(maxStringLength, helpText.Length - i)))
            i += maxStringLength
        End While
        Native.Function.Call(Native.Hash._DISPLAY_HELP_TEXT_FROM_STRING_LABEL, 0, 0, 1, Shape)
    End Sub

    Public Function GetPlayerNum() As Integer
        Select Case Game.Player.Character.Model.GetHashCode
            Case 225514697
                Return 0
            Case -1692214353
                Return 1
            Case -1686040670
                Return 2
            Case Else
                Return 3
        End Select
    End Function

    <Extension>
    Public Sub UpdateApartmentOwner(ByRef apt As ApartmentClass)
        config.SetValue(Of Integer)("BUILDING", apt.Name, GetPlayerNum)
        config.Save()

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")
    End Sub

    Public Sub LoadSettings()

    End Sub

    ''' <summary>
    ''' In = 0, Out = 1
    ''' Duration is milliseconds
    ''' </summary>
    Public Sub FadeScreen(inOut As Integer, Optional duration As Integer = 500)
        If inOut = 1 Then
            Game.FadeScreenOut(duration)
        Else
            Game.FadeScreenIn(duration)
        End If
        Script.Wait(500)
    End Sub

    Public Sub PlayPropertyPurchase(aptName As String)
        Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & Game.GetGXTEntry("PROPR_PURCHASED"), "~w~" & Game.GetGXTEntry(aptName), Nothing)
    End Sub

    <Extension>
    Public Sub SetInteriorActive(apt As ApartmentClass)
        Try
            Dim id As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, id)
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, id, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, id, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    <Extension>
    Public Sub SetInteriorActive(coord As Vector3)
        Try
            Dim id As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, coord.X, coord.Y, coord.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, id)
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, id, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, id, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    <Extension>
    Public Function ToVector3(q As Quaternion) As Vector3
        Return New Vector3(q.X, q.Y, q.Z)
    End Function

End Module
