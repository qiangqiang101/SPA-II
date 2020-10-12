Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM

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
    Public MenuBanner As New UIResRectangle(Point.Empty, New Size(0, 0), Color.FromArgb(0, 0, 0, 0))

    'Coords
    Public TwoCarGarage As New Vector3(0, 0, 0)
    Public FourCarGarage As New Vector3(0, 0, 0)
    Public SixCarGarage As New Vector3(0, 0, 0)
    Public TenCarGarage As New Vector3(222.592, -968.1, -99)
    Public TwentyCarGarage As New Vector3(0, 0, 0)

    'Prop
    Public ForSaleSign As String = "prop_forsale_dyn_01"

    <Extension>
    Public Function Make(vehicle As Vehicle) As String
        Return Game.GetGXTEntry(Native.Function.Call(Of String)(_GET_MAKE_NAME_FROM_VEHICLE_MODEL, vehicle.Model.Hash))
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
        Return Native.Function.Call(Of Integer)(_GET_VEHICLE_ROOF_LIVERY, veh.Handle)
    End Function

    <Extension()>
    Public Sub Livery2(veh As Vehicle, liv As Integer)
        Native.Function.Call(_SET_VEHICLE_ROOF_LIVERY, veh.Handle, liv)
    End Sub

    <Extension>
    Public Function XenonHeadlightsColor(ByVal veh As Vehicle) As Integer
        Return Native.Function.Call(Of Integer)(_GET_VEHICLE_XENON_LIGHTS_COLOR, veh.Handle)
    End Function

    <Extension()>
    Public Sub XenonHeadlightsColor(ByVal veh As Vehicle, colorID As Integer)
        Native.Function.Call(_SET_VEHICLE_XENON_LIGHTS_COLOR, veh.Handle, colorID)
    End Sub

    Public Function IsNitroModInstalled() As Integer
        Return Decor.Registered(nitroModDecor, Decor.eDecorType.Int)
    End Function

    Public Function GetPlayer() As eOwner
        Select Case Game.Player.Character.Model.GetHashCode
            Case 225514697
                Return eOwner.Michael
            Case -1692214353
                Return eOwner.Franklin
            Case -1686040670
                Return eOwner.Trevor
            Case Else
                Return eOwner.Others
        End Select
    End Function

    <Extension>
    Public Sub UpdateApartmentOwner(ByRef apt As ApartmentClass)
        config.SetValue(Of eOwner)("BUILDING", apt.Name, GetPlayer)
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
    Public Sub SetInteriorActive(coord As Vector3)
        Try
            Dim id As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, coord.X, coord.Y, coord.Z)
            Native.Function.Call(PIN_INTERIOR_IN_MEMORY, id)
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

    <Extension>
    Public Function GetHashKey(str As String) As Integer
        Return Native.Function.Call(Of Integer)(Hash.GET_HASH_KEY, str)
    End Function

    <Extension>
    Public Function ToRotation(heading As Single) As Vector3
        Return New Vector3(0F, 0F, heading)
    End Function

End Module
