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
    Public vehIdDecor As String = "inm_spa2_id"
    Public vehUidDecor As String = "inm_spa2_uid"

    'Memory
    Public buildings As New List(Of BuildingClass)
    Public apartments As New List(Of ApartmentClass)
    Public buildingsLoaded As Boolean = False
    Public outVehicleList As New List(Of Vehicle)

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
    Public SixCarGarage As New Vector3(0, 0, 0)
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

    <Extension>
    Public Function CreateGarageVehicle(vehClass As VehicleClass, pos As Quaternion, aptID As Integer) As Vehicle
        Dim veh As Vehicle = Nothing
        Dim model = New Model(vehClass.Hash)
        model.Request(250)
        If model.IsInCdImage AndAlso model.IsValid Then
            While Not model.IsLoaded
                Script.Yield()
            End While
            veh = World.CreateVehicle(vehClass.Hash, pos.ToVector3, pos.W)
            With veh
                .InstallModKit()
                .WheelType = vehClass.WheelType
                .SetMod(VehicleMod.Aerials, vehClass.Aerials, True)
                .SetMod(VehicleMod.Suspension, vehClass.Suspension, True)
                .SetMod(VehicleMod.Brakes, vehClass.Brakes, True)
                .SetMod(VehicleMod.Engine, vehClass.Engine, True)
                .SetMod(VehicleMod.Transmission, vehClass.Transmission, True)
                .SetMod(VehicleMod.FrontBumper, vehClass.FrontBumper, True)
                .SetMod(VehicleMod.RearBumper, vehClass.RearBumper, True)
                .SetMod(VehicleMod.SideSkirt, vehClass.SideSkirt, True)
                .SetMod(VehicleMod.Trim, vehClass.Trim, True)
                .SetMod(VehicleMod.EngineBlock, vehClass.EngineBlock, True)
                .SetMod(VehicleMod.AirFilter, vehClass.AirFilter, True)
                .SetMod(VehicleMod.Struts, vehClass.Struts, True)
                .SetMod(VehicleMod.ColumnShifterLevers, vehClass.ColumnShifterLevers, True)
                .SetMod(VehicleMod.Dashboard, vehClass.Dashboard, True)
                .SetMod(VehicleMod.DialDesign, vehClass.DialDesign, True)
                .SetMod(VehicleMod.Ornaments, vehClass.Ornaments, True)
                .SetMod(VehicleMod.Seats, vehClass.Seats, True)
                .SetMod(VehicleMod.SteeringWheels, vehClass.SteeringWheel, True)
                .SetMod(VehicleMod.TrimDesign, vehClass.TrimDesign, True)
                .SetMod(VehicleMod.PlateHolder, vehClass.PlateHolder, True)
                .SetMod(VehicleMod.VanityPlates, vehClass.VanityPlates, True)
                .SetMod(VehicleMod.FrontWheels, vehClass.Frontwheels, vehClass.WheelsVariation)
                .SetMod(VehicleMod.BackWheels, vehClass.BackWheels, vehClass.WheelsVariation)
                .SetMod(VehicleMod.ArchCover, vehClass.ArchCover, True)
                .SetMod(VehicleMod.Exhaust, vehClass.Exhaust, True)
                .SetMod(VehicleMod.Fender, vehClass.Fender, True)
                .SetMod(VehicleMod.RightFender, vehClass.RightFender, True)
                .SetMod(VehicleMod.DoorSpeakers, vehClass.DoorSpeakers, True)
                .SetMod(VehicleMod.Frame, vehClass.Frame, True)
                .SetMod(VehicleMod.Grille, vehClass.Grille, True)
                .SetMod(VehicleMod.Hood, vehClass.Hood, True)
                .SetMod(VehicleMod.Horns, vehClass.Horn, True)
                .SetMod(VehicleMod.Hydraulics, vehClass.Hydraulics, True)
                .SetMod(VehicleMod.Livery, vehClass.Livery, True)
                .SetMod(VehicleMod.Plaques, vehClass.Plaques, True)
                .SetMod(VehicleMod.Roof, vehClass.Roof, True)
                .SetMod(VehicleMod.Speakers, vehClass.Speakers, True)
                .SetMod(VehicleMod.Spoilers, vehClass.Spoiler, True)
                .SetMod(VehicleMod.Tank, vehClass.Tank, True)
                .SetMod(VehicleMod.Trunk, vehClass.Trunk, True)
                .SetMod(VehicleMod.Windows, vehClass.Windows, True)
                .ToggleMod(VehicleToggleMod.XenonHeadlights, vehClass.Headlights)
                .ToggleMod(VehicleToggleMod.Turbo, vehClass.Turbo)
                .ToggleMod(VehicleToggleMod.TireSmoke, vehClass.Tiresmoke)
                .TrimColor = vehClass.TrimColor
                .NumberPlateType = vehClass.NumberPlate
                .NumberPlate = vehClass.PlateNumber
                .SetNeonLightsOn(VehicleNeonLight.Front, vehClass.FrontNeon)
                .SetNeonLightsOn(VehicleNeonLight.Back, vehClass.BackNeon)
                .SetNeonLightsOn(VehicleNeonLight.Left, vehClass.LeftNeon)
                .SetNeonLightsOn(VehicleNeonLight.Right, vehClass.RightNeon)
                .WindowTint = vehClass.Tint
                .PrimaryColor = vehClass.PrimaryColor
                .SecondaryColor = vehClass.SecondaryColor
                .PearlescentColor = vehClass.PearlescentColor
                .RimColor = vehClass.RimColor
                .DashboardColor = vehClass.LightsColor
                .NeonLightsColor = vehClass.NeonLightsColor.ToColor
                .TireSmokeColor = vehClass.TireSmokeColor.ToColor
                .Livery2(vehClass.Livery2)
                .Livery = vehClass.Livery1
                .XenonHeadlightsColor(vehClass.HeadlightsColor)
                .CanTiresBurst = vehClass.BulletProofTires
                If vehClass.HasCustomPrimaryColor Then .CustomPrimaryColor = vehClass.CustomPrimaryColor.ToColor
                If vehClass.HasCustomSecondaryColor Then .CustomSecondaryColor = vehClass.CustomSecondaryColor.ToColor
                .ToggleExtra(0, vehClass.Extra0)
                .ToggleExtra(1, vehClass.Extra1)
                .ToggleExtra(2, vehClass.Extra2)
                .ToggleExtra(3, vehClass.Extra3)
                .ToggleExtra(4, vehClass.Extra4)
                .ToggleExtra(5, vehClass.Extra5)
                .ToggleExtra(6, vehClass.Extra6)
                .ToggleExtra(7, vehClass.Extra7)
                .ToggleExtra(8, vehClass.Extra8)
                .ToggleExtra(9, vehClass.Extra9)
                .ToggleExtra(10, vehClass.Extra10)
                .ToggleExtra(11, vehClass.Extra11)
                .ToggleExtra(12, vehClass.Extra12)
                .ToggleExtra(13, vehClass.Extra13)
                .ToggleExtra(14, vehClass.Extra14)
                .ToggleExtra(15, vehClass.Extra15)
                .RoofState = vehClass.RoofState
                If IsNitroModInstalled() Then .SetInt(nitroModDecor, vehClass.HasNitro)
                .IsPersistent = True
                .SetInt(vehIdDecor, aptID)
                .SetInt(vehUidDecor, vehClass.UniqueID)
            End With
        End If
        model.MarkAsNoLongerNeeded()
        Return veh
    End Function

    Public Sub RegisterDecor(d As String, t As Decor.eDecorType)
        If Not Decor.Registered(d, t) Then
            Decor.Unlock()
            Decor.Register(d, t)
            Decor.Lock()
        End If
    End Sub

    Public Sub Debug()
        Dim playerText As New UIResText($"Player Position: {PP.Position}     Rotation: {PP.Rotation}", Point.Empty, 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim playerVehText As New UIResText($"Player Vehicle Position: {PP.LastVehicle.Position}     Rotation: {PP.LastVehicle.Rotation}", New Point(0, playerText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim camText As New UIResText($"Camera Position: {GameplayCamera.Position}     Rotation: {GameplayCamera.Rotation}", New Point(0, playerVehText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        playerText.Draw()
        playerVehText.Draw()
        camText.Draw()
    End Sub

    Public Sub ChangeIPL(old As String, [new] As String)
        If Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, old) Then Native.Function.Call(Hash.REMOVE_IPL, old)
        While Not Native.Function.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, [new])
            Native.Function.Call(Hash.REQUEST_IPL, [new])
            Script.Yield()
        End While
    End Sub

    Public Function NewUiMenuItem2(title As String, Optional desc As String = Nothing, Optional rightbadge As UIMenuItem.BadgeStyle = UIMenuItem.BadgeStyle.None)
        Dim item As New UIMenuItem(title, desc)
        With item
            .SetRightBadge(rightbadge)
        End With
        Return item
    End Function

End Module
