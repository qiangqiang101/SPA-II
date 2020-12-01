Imports System.Drawing
Imports System.Media
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM
Imports SPAII.INM.ClothingSet
Imports NFunc = GTA.Native.Function

Module Helper

    'Config
    Public config As ScriptSettings = ScriptSettings.Load("scripts\SPA II\modconfig.ini")
    Public debugMode As Boolean = False
    Public HideHud As Boolean = False

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
    Public forSaleSignSpawned As Boolean = False
    Public outVehicleList As New List(Of Vehicle)
    Public debug3rdLine As String = "Nothing to show now"

    Public PP As Ped
    Public LV As Vehicle
    Public PM As Integer
    Public Player As Player
    Public PI As Integer

    'Menu
    Public MenuPool As New MenuPool
    Public MenuBanner As New UIResRectangle(Point.Empty, New Size(0, 0), Color.FromArgb(0, 0, 0, 0))
    Public MichaelBanner As New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Nothing, Nothing)
    Public FranklinBanner As New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Nothing, Nothing)
    Public TrevorBanner As New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Nothing, Nothing)

    'Coords
    Public TwentyCarGarage As New Vector3(0, 0, 0)
    Public GarageMarkerIndicator As New Vector3(0F, 0F, 0F)

    'Prop
    Public ForSaleSign As String = "prop_forsale_dyn_01"

    'Speech
    Public OnTheClock As New Speech("mechanic_on_the_clock_some_wheels.wav")
    Public YouNeedSomething As New Speech("mechanic_u_need_something_huh.wav")
    Public ICantGetYourRide As New Speech("mechanic_cant_get_your_ride.wav")
    Public IllGetBackToWork As New Speech("mechanic_get_back_to_work_then.wav")
    Public IllBeThere As New Speech("mechanic_get_there_as_soon_as_i_can.wav")

    'Scaleform
    Public StatScaleform0 As New Scaleform("MP_CAR_STATS_01")
    Public StatScaleform1 As New Scaleform("MP_CAR_STATS_02")
    Public StatScaleform2 As New Scaleform("MP_CAR_STATS_03")
    Public StatScaleform3 As New Scaleform("MP_CAR_STATS_04")
    Public StatScaleform4 As New Scaleform("MP_CAR_STATS_05")
    Public StatScaleform5 As New Scaleform("MP_CAR_STATS_06")
    Public StatScaleform6 As New Scaleform("MP_CAR_STATS_07")
    Public StatScaleform7 As New Scaleform("MP_CAR_STATS_08")
    Public StatScaleform8 As New Scaleform("MP_CAR_STATS_09")
    Public StatScaleform9 As New Scaleform("MP_CAR_STATS_10")

    <Extension>
    Public Function Make(vehicle As Vehicle) As String
        Return Game.GetGXTEntry(NFunc.Call(Of String)(_GET_MAKE_NAME_FROM_VEHICLE_MODEL, vehicle.Model.Hash))
    End Function

    <Extension>
    Public Function WheelsVariation(vehicle As Vehicle) As Boolean
        Return NFunc.Call(Of Boolean)(Native.Hash.GET_VEHICLE_MOD_VARIATION, vehicle, VehicleMod.FrontWheels)
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
        Return NFunc.Call(Of Integer)(_GET_VEHICLE_ROOF_LIVERY, veh.Handle)
    End Function

    <Extension()>
    Public Sub Livery2(veh As Vehicle, liv As Integer)
        NFunc.Call(_SET_VEHICLE_ROOF_LIVERY, veh.Handle, liv)
    End Sub

    <Extension>
    Public Function XenonHeadlightsColor(ByVal veh As Vehicle) As Integer
        Return NFunc.Call(Of Integer)(_GET_VEHICLE_XENON_LIGHTS_COLOR, veh.Handle)
    End Function

    <Extension()>
    Public Sub XenonHeadlightsColor(ByVal veh As Vehicle, colorID As Integer)
        NFunc.Call(_SET_VEHICLE_XENON_LIGHTS_COLOR, veh.Handle, colorID)
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
    Public Sub UpdateApartmentOwner(apt As ApartmentClass, Optional tradeIn As Boolean = False)
        config.SetValue(Of eOwner)("BUILDING", apt.Name, If(tradeIn, eOwner.Nobody, GetPlayer()))
        config.Save()

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")
    End Sub

    ''' <summary>
    ''' In = 0, Out = 1
    ''' Duration is milliseconds
    ''' </summary>
    Public Sub FadeScreen(inOut As Integer, Optional duration As Integer = 1000, Optional _hidehud As Boolean = False)
        If _hidehud Then HideHud = _hidehud
        If inOut = 1 Then
            Game.FadeScreenOut(duration)
        Else
            Game.FadeScreenIn(duration)
        End If
        Script.Wait(duration)
        If _hidehud Then HideHud = Not _hidehud
    End Sub

    Public Sub PlayPropertyPurchase(aptName As String)
        NFunc.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
        BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & Game.GetGXTEntry("PROPR_PURCHASED"), "~w~" & Game.GetGXTEntry(aptName), Nothing)
    End Sub

    <Extension>
    Public Sub SetInteriorActive(coord As Vector3)
        Try
            Dim id As Integer = NFunc.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, coord.X, coord.Y, coord.Z)
            NFunc.Call(PIN_INTERIOR_IN_MEMORY, id)
            NFunc.Call(Hash.SET_INTERIOR_ACTIVE, id, True)
            NFunc.Call(Hash.DISABLE_INTERIOR, id, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    <Extension>
    Public Function ToVector3(q As Quaternion, Optional placeOnGround As Boolean = False) As Vector3
        Return New Vector3(q.X, q.Y, If(placeOnGround, World.GetGroundHeight(New Vector2(q.X, q.Y)), q.Z))
    End Function

    <Extension>
    Public Function GetHashKey(str As String) As Integer
        Return NFunc.Call(Of Integer)(Hash.GET_HASH_KEY, str)
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
            veh = CreateVehicle(vehClass.Hash, pos.ToVector3, pos.W)
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
                .DirtLevel = 0F
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
        Dim playerText As New UIResText($"Player Position: {PP.Position}  Rotation: {PP.Rotation}  Heading: {PP.Heading.ToString("N")}  |  Vehicle Position: {PP.LastVehicle.Position}  Rotation: {PP.LastVehicle.Rotation}  Heading: {PP.LastVehicle.Heading.ToString("N")}", Point.Empty, 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim camText As UIResText
        If DebugCamera.IsEnabled Then
            camText = New UIResText($"Camera Position: {DebugCamera.Camera.Position}  Rotation: {DebugCamera.Camera.Rotation}  FOV: {DebugCamera.Camera.FieldOfView}", New Point(0, playerText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Else
            camText = New UIResText($"Camera Position: {GameplayCamera.Position}  Rotation: {GameplayCamera.Rotation}  FOV: {GameplayCamera.FieldOfView}", New Point(0, playerText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        End If
        Dim direction As New UIResText($"↑: Vector  ↓: Quaternion  ←: CameraPRH  →: Door  Del: Debug Camera  End: Debug Menu  |  2 Car Garage: {If(TwoCarGarage.Apartment Is Nothing, False, True)}     6 Car Garage: {If(SixCarGarage.Apartment Is Nothing, False, True)}     10 Car Garage: {If(TenCarGarage.Apartment Is Nothing, False, True)}     Low Apt: {If(LowEndApartment.Apartment Is Nothing, False, True)}     Medium Apt: {If(MediumEndApartment.Apartment Is Nothing, False, True)}     High Apt: {If(HighEndApartment.Building Is Nothing, False, True)}", New Point(0, camText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim forthLine As New UIResText(debug3rdLine, New Point(0, direction.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        playerText.Draw()
        camText.Draw()
        direction.Draw()
        forthLine.Draw()
    End Sub

    Public Sub ChangeIPL(old As String, [new] As String)
        If NFunc.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, old) Then NFunc.Call(Hash.REMOVE_IPL, old)
        While Not NFunc.Call(Of Boolean)(Hash.IS_IPL_ACTIVE, [new])
            NFunc.Call(Hash.REQUEST_IPL, [new])
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

    Public Function WorldCreateVehicle(model As Model, position As Vector3, Optional heading As Single = 0F) As Vehicle
        If Not model.IsVehicle OrElse Not model.Request(1000) Then
            Return Nothing
        End If

        Return New Vehicle(NFunc.Call(Of Integer)(Hash.CREATE_VEHICLE, model.Hash, position.X, position.Y, position.Z, heading, False, False))
    End Function

    Public Function CreateVehicle(VehicleHash As Integer, Position As Vector3, Optional Heading As Single = 0) As Vehicle
        Dim model = New Model(VehicleHash)
        model.Request(250)
        If model.IsInCdImage AndAlso model.IsValid Then
            While Not model.IsLoaded
                Script.Wait(0)
            End While
            Return WorldCreateVehicle(model, Position, Heading)
        End If
        model.MarkAsNoLongerNeeded()
        Return Nothing
    End Function

    Public Function IsGarageVehicleAlreadyExistInWorldMap(aid As Integer, uid As Integer) As Boolean
        Return outVehicleList.Where(Function(x) x.GetInt(vehIdDecor) = aid AndAlso x.GetInt(vehUidDecor) = uid).Count >= 1
    End Function

    <Extension>
    Public Function IsCurrentVehicleExistInList(vehicle As Vehicle) As Boolean
        Return outVehicleList.Contains(vehicle)
    End Function

    <Extension>
    Public Function CloneVehicle(source As Vehicle, pos As Vector2, head As Single, Optional cloneDamage As Boolean = False) As Vehicle
        Dim newVeh As Vehicle = WorldCreateVehicle(source.Model, pos, head)
        With newVeh
            .InstallModKit()
            .WheelType = source.WheelType
            .SetMod(VehicleMod.Aerials, source.GetMod(VehicleMod.Aerials), True)
            .SetMod(VehicleMod.Suspension, source.GetMod(VehicleMod.Suspension), True)
            .SetMod(VehicleMod.Brakes, source.GetMod(VehicleMod.Brakes), True)
            .SetMod(VehicleMod.Engine, source.GetMod(VehicleMod.Engine), True)
            .SetMod(VehicleMod.Transmission, source.GetMod(VehicleMod.Transmission), True)
            .SetMod(VehicleMod.FrontBumper, source.GetMod(VehicleMod.FrontBumper), True)
            .SetMod(VehicleMod.RearBumper, source.GetMod(VehicleMod.RearBumper), True)
            .SetMod(VehicleMod.SideSkirt, source.GetMod(VehicleMod.SideSkirt), True)
            .SetMod(VehicleMod.Trim, source.GetMod(VehicleMod.Trim), True)
            .SetMod(VehicleMod.EngineBlock, source.GetMod(VehicleMod.EngineBlock), True)
            .SetMod(VehicleMod.AirFilter, source.GetMod(VehicleMod.AirFilter), True)
            .SetMod(VehicleMod.Struts, source.GetMod(VehicleMod.Struts), True)
            .SetMod(VehicleMod.ColumnShifterLevers, source.GetMod(VehicleMod.ColumnShifterLevers), True)
            .SetMod(VehicleMod.Dashboard, source.GetMod(VehicleMod.Dashboard), True)
            .SetMod(VehicleMod.DialDesign, source.GetMod(VehicleMod.DialDesign), True)
            .SetMod(VehicleMod.Ornaments, source.GetMod(VehicleMod.Ornaments), True)
            .SetMod(VehicleMod.Seats, source.GetMod(VehicleMod.Seats), True)
            .SetMod(VehicleMod.SteeringWheels, source.GetMod(VehicleMod.SteeringWheels), True)
            .SetMod(VehicleMod.TrimDesign, source.GetMod(VehicleMod.TrimDesign), True)
            .SetMod(VehicleMod.PlateHolder, source.GetMod(VehicleMod.PlateHolder), True)
            .SetMod(VehicleMod.VanityPlates, source.GetMod(VehicleMod.VanityPlates), True)
            .SetMod(VehicleMod.FrontWheels, source.GetMod(VehicleMod.FrontWheels), source.WheelsVariation)
            .SetMod(VehicleMod.BackWheels, source.GetMod(VehicleMod.BackWheels), source.WheelsVariation)
            .SetMod(VehicleMod.ArchCover, source.GetMod(VehicleMod.ArchCover), True)
            .SetMod(VehicleMod.Exhaust, source.GetMod(VehicleMod.Exhaust), True)
            .SetMod(VehicleMod.Fender, source.GetMod(VehicleMod.Fender), True)
            .SetMod(VehicleMod.RightFender, source.GetMod(VehicleMod.RightFender), True)
            .SetMod(VehicleMod.DoorSpeakers, source.GetMod(VehicleMod.DoorSpeakers), True)
            .SetMod(VehicleMod.Frame, source.GetMod(VehicleMod.Frame), True)
            .SetMod(VehicleMod.Grille, source.GetMod(VehicleMod.Grille), True)
            .SetMod(VehicleMod.Hood, source.GetMod(VehicleMod.Hood), True)
            .SetMod(VehicleMod.Horns, source.GetMod(VehicleMod.Horns), True)
            .SetMod(VehicleMod.Hydraulics, source.GetMod(VehicleMod.Hydraulics), True)
            .SetMod(VehicleMod.Livery, source.GetMod(VehicleMod.Livery), True)
            .SetMod(VehicleMod.Plaques, source.GetMod(VehicleMod.Plaques), True)
            .SetMod(VehicleMod.Roof, source.GetMod(VehicleMod.Roof), True)
            .SetMod(VehicleMod.Speakers, source.GetMod(VehicleMod.Speakers), True)
            .SetMod(VehicleMod.Spoilers, source.GetMod(VehicleMod.Spoilers), True)
            .SetMod(VehicleMod.Tank, source.GetMod(VehicleMod.Tank), True)
            .SetMod(VehicleMod.Trunk, source.GetMod(VehicleMod.Trunk), True)
            .SetMod(VehicleMod.Windows, source.GetMod(VehicleMod.Windows), True)
            .ToggleMod(VehicleToggleMod.XenonHeadlights, source.IsToggleModOn(VehicleToggleMod.XenonHeadlights))
            .ToggleMod(VehicleToggleMod.Turbo, source.IsToggleModOn(VehicleToggleMod.Turbo))
            .ToggleMod(VehicleToggleMod.TireSmoke, source.IsToggleModOn(VehicleToggleMod.TireSmoke))
            .TrimColor = source.TrimColor
            .NumberPlateType = source.NumberPlateType
            .NumberPlate = source.NumberPlate
            .SetNeonLightsOn(VehicleNeonLight.Front, source.IsNeonLightsOn(VehicleNeonLight.Front))
            .SetNeonLightsOn(VehicleNeonLight.Back, source.IsNeonLightsOn(VehicleNeonLight.Back))
            .SetNeonLightsOn(VehicleNeonLight.Left, source.IsNeonLightsOn(VehicleNeonLight.Left))
            .SetNeonLightsOn(VehicleNeonLight.Right, source.IsNeonLightsOn(VehicleNeonLight.Right))
            .WindowTint = source.WindowTint
            .PrimaryColor = source.PrimaryColor
            .SecondaryColor = source.SecondaryColor
            .PearlescentColor = source.PearlescentColor
            .RimColor = source.RimColor
            .DashboardColor = source.DashboardColor
            .NeonLightsColor = source.NeonLightsColor
            .TireSmokeColor = source.TireSmokeColor
            .Livery2(source.Livery2)
            .Livery = source.Livery
            .XenonHeadlightsColor(source.XenonHeadlightsColor)
            .CanTiresBurst = source.CanTiresBurst
            If source.IsPrimaryColorCustom Then .CustomPrimaryColor = source.CustomPrimaryColor
            If source.IsSecondaryColorCustom Then .CustomSecondaryColor = source.CustomSecondaryColor
            .ToggleExtra(0, source.IsExtraOn(0))
            .ToggleExtra(1, source.IsExtraOn(1))
            .ToggleExtra(2, source.IsExtraOn(2))
            .ToggleExtra(3, source.IsExtraOn(3))
            .ToggleExtra(4, source.IsExtraOn(4))
            .ToggleExtra(5, source.IsExtraOn(5))
            .ToggleExtra(6, source.IsExtraOn(6))
            .ToggleExtra(7, source.IsExtraOn(7))
            .ToggleExtra(8, source.IsExtraOn(8))
            .ToggleExtra(9, source.IsExtraOn(9))
            .ToggleExtra(10, source.IsExtraOn(10))
            .ToggleExtra(11, source.IsExtraOn(11))
            .ToggleExtra(12, source.IsExtraOn(12))
            .ToggleExtra(13, source.IsExtraOn(13))
            .ToggleExtra(14, source.IsExtraOn(14))
            .ToggleExtra(15, source.IsExtraOn(15))
            .RoofState = source.RoofState
            .DirtLevel = source.DirtLevel
            If IsNitroModInstalled() Then .SetInt(nitroModDecor, source.GetInt(nitroModDecor))
            .IsPersistent = True
            .SetInt(vehIdDecor, source.GetInt(vehIdDecor))
            .SetInt(vehUidDecor, source.GetInt(vehUidDecor))
        End With
        If cloneDamage Then NFunc.Call(COPY_VEHICLE_DAMAGES, source, newVeh)
        Return newVeh
    End Function

    <Extension>
    Public Sub SetPlayerIntoVehicle(vehicle As Vehicle, Optional seat As VehicleSeat = VehicleSeat.Driver)
        NFunc.Call(Hash.SET_PED_INTO_VEHICLE, Game.Player.Character, vehicle.Handle, seat)
    End Sub

    <Extension>
    Public Function IsPersonalVehicle(veh As Vehicle) As Boolean
        Return Not veh.GetInt(vehUidDecor) = 0
    End Function

    Public Sub RequestAdditionalText(gxt2Lib As String, gxt As String)
        If Not NFunc.Call(Of Boolean)(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, gxt2Lib, 10) Then
            NFunc.Call(Hash.CLEAR_ADDITIONAL_TEXT, 10, True)
            NFunc.Call(Hash.REQUEST_ADDITIONAL_TEXT, gxt2Lib, 10)
        End If
        If Game.GetGXTEntry(gxt) = "NULL" Then RequestAdditionalText(gxt2Lib, gxt)
    End Sub

    Public Function GetAvailableIndex(vcList As List(Of VehicleClass), garageType As eGarageType) As Integer
        Dim vol As Integer = 10
        Select Case garageType
            Case eGarageType.TwoCarGarage
                vol = 2
            Case eGarageType.SixCarGarage
                vol = 6
            Case eGarageType.TenCarGarage
                vol = 10
            Case eGarageType.TwentyCarGarage
                vol = 20
        End Select

        Dim existingIndexes As New List(Of Integer)
        For Each vc In vcList
            existingIndexes.Add(vc.Index)
        Next
        Dim missingIndexes = Enumerable.Range(0, vol - 0 + 1).Except(existingIndexes)
        Return missingIndexes.FirstOrDefault
    End Function

    <Extension>
    Public Function GetEclipseTowersPenthouseDoor(ipl As String) As Door
        Dim door As New Door(0, Vector3.Zero)
        Select Case ipl
            Case "apa_v_mp_h_01_a" 'Modern
                door = New Door(-658026477, New Vector3(-782.4497F, 317.5156F, 217.7876F))
            Case "apa_v_mp_h_01_c"
                door = New Door(-658026477, New Vector3(-782.4497F, 317.5156F, 188.0627F))
            Case "apa_v_mp_h_01_b"
                door = New Door(-658026477, New Vector3(-778.5566F, 340.2328F, 196.8354F))

            Case "apa_v_mp_h_02_a" 'Moody
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_02_c"
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_02_b"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_03_a" 'Vibrant
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_03_c"
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_03_b"
                door = New Door(1398355146, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_04_a" 'Sharp
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 217.7884F))
            Case "apa_v_mp_h_04_c"
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 188.0634F))
            Case "apa_v_mp_h_04_b"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2332F, 196.8362F))

            Case "apa_v_mp_h_05_a" 'Monochrome
                door = New Door(-711771128, New Vector3(-782.4497F, 317.5156F, 217.7876F))
            Case "apa_v_mp_h_05_c"
                door = New Door(-711771128, New Vector3(-782.4497F, 317.5156F, 188.0627F))
            Case "apa_v_mp_h_05_b"
                door = New Door(-711771128, New Vector3(-778.5566F, 340.2328F, 196.8354F))

            Case "apa_v_mp_h_06_a" 'Seductive
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_06_c"
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_06_b"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_07_a" 'Regal
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_07_c"
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_07_b"
                door = New Door(1398355146, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_08_a" 'Aqua
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 217.7884F))
            Case "apa_v_mp_h_08_c"
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 188.0634F))
            Case "apa_v_mp_h_08_b"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2332F, 196.8362F))
        End Select

        Return door
    End Function

    <Extension>
    Public Function Truncate(value As String, Optional length As Integer = 380) As String
        If IsAsian() Then length /= 3
        If length > value.Length2 Then
            If IsAsian() Then value = value.SplitChineseString
            Return value
        Else
            If IsAsian() Then value = value.SplitChineseString
            Try
                Return $"{value.Substring(0, length)}..."
            Catch ex As Exception
                Return value
            End Try
        End If
    End Function

    Public Function IsAsian() As Boolean
        Select Case Game.Language
            Case Language.Chinese, Language.ChineseSimplified, Language.Japanese, Language.Korean
                Return True
            Case Else
                Return False
        End Select
    End Function

    <Extension>
    Public Function SplitChineseString(value As String) As String
        For i = 0 To Len(value) Step 20 + 1
            Try
                value = value.Insert(i + 20, vbNewLine)
            Catch
            End Try
        Next
        Return value.Replace(vbNewLine, "~n~")
    End Function

    <Extension>
    Public Function Length2(value As String) As Integer
        If IsAsian() Then
            Return value.Length * 2
        Else
            Return value.Length
        End If
    End Function

    Public Function QuaternionZero() As Quaternion
        Return New Quaternion(0F, 0F, 0F, 0F)
    End Function

    <Extension>
    Public Sub DrawMarker(pos As Vector3, Optional col As Color = Nothing, Optional size As Vector3 = Nothing, Optional text As String = Nothing)
        If col = Nothing Then col = Color.DeepSkyBlue
        If size = Nothing Then size = New Vector3(0.8F, 0.8F, 0.4F)
        World.DrawMarker(MarkerType.VerticalCylinder, pos, Vector3.Zero, Vector3.Zero, size, Color.FromArgb(150, col))
        If Not text = Nothing Then pos.Draw3DText(text)
    End Sub

    <Extension>
    Public Sub DrawMgmtMarker(pos As Vector3, Optional col As Color = Nothing, Optional size As Vector3 = Nothing)
        If col = Nothing Then col = Color.DeepSkyBlue
        If size = Nothing Then size = New Vector3(0.4F, 0.4F, 0.4F)
        World.DrawMarker(MarkerType.ChevronUpx1, New Vector3(pos.X, pos.Y, pos.Z + 2.0F), Vector3.Zero, New Vector3(0F, 180.0F, 0F), size, Color.FromArgb(150, col))
    End Sub

    <Extension>
    Public Sub Draw3DText(pos As Vector3, text As String)
        Dim onScreen = pos.GetScreenCoordFromWorldCoord
        Dim camCoords = GameplayCamera.Position
        Dim distance = camCoords.GetDistanceBetweenCoords(pos)
        Dim scale = (1 / distance) * 2
        Dim fov = (1 / GameplayCamera.FieldOfView) * 100
        scale = scale * fov

        DrawText(text, scale, scale, GTA.Font.ChaletLondon, onScreen)
    End Sub

    <Extension>
    Public Function ToPoint(v2 As Vector2) As Point
        Return New Point(CInt(v2.X), CInt(v2.Y))
    End Function

    <Extension>
    Public Function GetScreenCoordFromWorldCoord(pos As Vector3) As Vector2
        Dim x, y As New OutputArgument
        NFunc.Call(Of Boolean)(GET_SCREEN_COORD_FROM_WORLD_COORD, pos.X, pos.Y, pos.Z, x, y)
        Return New Vector2(x.GetResult(Of Single), y.GetResult(Of Single))
    End Function

    <Extension>
    Public Function GetDistanceBetweenCoords(pos1 As Vector3, pos2 As Vector3) As Single
        Return NFunc.Call(Of Single)(Hash.GET_DISTANCE_BETWEEN_COORDS, pos1.X, pos1.Y, pos1.Z, pos2.X, pos2.Y, pos2.Z, True)
    End Function

    Public Sub DrawText(text As String, scale As Single, size As Single, font As GTA.Font, pos As Vector2)
        NFunc.Call(Hash.SET_TEXT_SCALE, scale, size)
        NFunc.Call(Hash.SET_TEXT_FONT, font)
        NFunc.Call(Hash.SET_TEXT_PROPORTIONAL, True)
        Dim c As Color = Color.White
        NFunc.Call(Hash.SET_TEXT_COLOUR, c.R, c.B, c.G, 150)
        Dim s As Color = Color.Black
        NFunc.Call(Hash.SET_TEXT_DROPSHADOW, 0, s.R, s.G, s.B, 255)
        NFunc.Call(Hash.SET_TEXT_DROP_SHADOW)
        NFunc.Call(Hash.SET_TEXT_OUTLINE)
        NFunc.Call(Hash._SET_TEXT_ENTRY, "STRING")
        NFunc.Call(Hash.SET_TEXT_CENTRE, True)
        NFunc.Call(Hash._ADD_TEXT_COMPONENT_STRING, text)
        NFunc.Call(Hash._DRAW_TEXT, pos.X, pos.Y)
    End Sub

    <Extension>
    Public Sub SetAsGarage(apt As ApartmentClass)
        With apt
            .SavePos = Vector3.Zero
            .ApartmentDoorPos = QuaternionZero()
            .ApartmentInPos = Vector3.Zero
            .ApartmentOutPos = Vector3.Zero
            .WardrobePos = QuaternionZero()
            .IPL = Nothing
            .AptStyleCam = Nothing
            .EnterCam = Nothing
            .ExitCam = Nothing
            .GarageElevatorPos = Vector3.Zero
            .GarageMenuPos = Vector3.Zero
            .ApartmentType = eApartmentType.Other
            .Door = Nothing
        End With
    End Sub

    <Extension>
    Public Sub SetAsGarage(bld As BuildingClass)
        With bld
            .BuildingInPos = New Quaternion(.GarageInPos.X, .GarageInPos.Y, .GarageInPos.Z, 0F)
            .BuildingOutPos = QuaternionZero()
            .BuildingLobby = QuaternionZero()
            .EnterCamera1 = Nothing
            .EnterCamera2 = Nothing
            .BuildingType = eBuildingType.Garage
            .FrontDoor = eFrontDoor.NoDoor
            .Door1 = Nothing
            .Door2 = Nothing
            .GarageDoor = eFrontDoor.NoDoor
            .Door3 = Nothing
            .GarageWaypoint = QuaternionZero()
        End With
    End Sub

    <Extension>
    Public Sub SetAsLowEndApartment(apt As ApartmentClass)
        With apt
            .SavePos = LowEndApartment.SavePos
            .ApartmentDoorPos = LowEndApartment.DoorPos
            .ApartmentInPos = LowEndApartment.InPos
            .ApartmentOutPos = LowEndApartment.OutPos
            .WardrobePos = LowEndApartment.WardrobePos
            .IPL = Nothing
            .AptStyleCam = Nothing
            .EnterCam = LowEndApartment.EnterCam
            .ExitCam = LowEndApartment.ExitCam
            .GarageElevatorPos = Vector3.Zero
            .GarageMenuPos = Vector3.Zero
            .ApartmentType = eApartmentType.LowEnd
            .Door = LowEndApartment.Door
        End With
    End Sub

    <Extension>
    Public Sub SetAsMediumApartment(apt As ApartmentClass)
        With apt
            .SavePos = MediumEndApartment.SavePos
            .ApartmentDoorPos = MediumEndApartment.DoorPos
            .ApartmentInPos = MediumEndApartment.InPos
            .ApartmentOutPos = MediumEndApartment.OutPos
            .WardrobePos = MediumEndApartment.WardrobePos
            .IPL = Nothing
            .AptStyleCam = Nothing
            .EnterCam = MediumEndApartment.EnterCam
            .ExitCam = MediumEndApartment.ExitCam
            .GarageElevatorPos = Vector3.Zero
            .GarageMenuPos = Vector3.Zero
            .ApartmentType = eApartmentType.MediumEnd
            .Door = MediumEndApartment.Door
        End With
    End Sub

    <Extension>
    Public Function GetParkingSpotByZone(pp As Vector3) As List(Of Vector5)
        Dim zone = NFunc.Call(Of String)(Hash.GET_NAME_OF_ZONE, pp.X, pp.Y, pp.Z)
        Select Case zone
            Case "DOWNT", "VINE"
                Return DOWNT
            Case "GALLI", "CHIL"
                Return CHIL
            Case "DESRT", "GREATC"
                Return DESRT
            Case "CMSW", "PALCOV"
                Return CMSW
            Case "PBOX"
                Return PBOX
            Case "SKID"
                Return SKID
            Case "TEXTI"
                Return TEXTI
            Case "LEGSQU"
                Return LEGSQU
            Case "CANNY"
                Return CANNY
            Case "DTVINE"
                Return DTVINE
            Case "EAST_V"
                Return EAST_V
            Case "MIRR"
                Return MIRR
            Case "WVINE"
                Return WVINE
            Case "ALTA"
                Return ALTA
            Case "HAWICK"
                Return HAWICK
            Case "RICHM"
                Return RICHM
            Case "golf"
                Return golf
            Case "ROCKF"
                Return ROCKF
            Case "CCREAK"
                Return CCREAK
            Case "RGLEN"
                Return RGLEN
            Case "OBSERV"
                Return OBSERV
            Case "DAVIS"
                Return DAVIS
            Case "STRAW"
                Return STRAW
            Case "CHAMH"
                Return CHAMH
            Case "RANCHO"
                Return RANCHO
            Case "BANNING"
                Return BANNING
            Case "ELYSIAN"
                Return ELYSIAN
            Case "TERMINA"
                Return TERMINA
            Case "ZP_ORT"
                Return ZP_ORT
            Case "LMESA"
                Return LMESA
            Case "CYPRE"
                Return CYPRE
            Case "EBURO"
                Return EBURO
            Case "MURRI"
                Return MURRI
            Case "VESP"
                Return VESP
            Case "BEACH"
                Return BEACH
            Case "VCANA"
                Return VCANA
            Case "DELSOL"
                Return DELSOL
            Case "DELBE"
                Return DELBE
            Case "DELPE"
                Return DELPE
            Case "LOSPUER"
                Return LOSPUER
            Case "STAD"
                Return STAD
            Case "KOREAT"
                Return KOREAT
            Case "AIRP"
                Return AIRP
            Case "MORN"
                Return MORN
            Case "PBLUFF"
                Return PBLUFF
            Case "BHAMCA"
                Return BHAMCA
            Case "CHU"
                Return CHU
            Case "TONGVAH"
                Return TONGVAH
            Case "TONGVAV"
                Return TONGVAV
            Case "TATAMO"
                Return TATAMO
            Case "PALHIGH"
                Return PALHIGH
            Case "NOOSE"
                Return NOOSE
            Case "MOVIE"
                Return MOVIE
            Case "SanAnd"
                Return SanAnd
            Case "ALAMO"
                Return ALAMO
            Case "JAIL"
                Return JAIL
            Case "RTRAK"
                Return RTRAK
            Case "SANCHIA"
                Return SANCHIA
            Case "WINDF"
                Return WINDF
            Case "PALMPOW"
                Return PALMPOW
            Case "HUMLAB"
                Return HUMLAB
            Case "ZQ_UAR"
                Return ZQ_UAR
            Case "PALETO"
                Return PALETO
            Case "PALFOR"
                Return PALFOR
            Case "PROCOB"
                Return PROCOB
            Case "HARMO"
                Return HARMO
            Case "SANDY"
                Return SANDY
            Case "ZANCUDO"
                Return ZANCUDO
            Case "SLAB"
                Return SLAB
            Case "NCHU"
                Return NCHU
            Case "GRAPES"
                Return GRAPES
            Case "MTGORDO"
                Return MTGORDO
            Case "MTCHIL"
                Return MTCHIL
            Case "GALFISH"
                Return GALFISH
            Case "LAGO"
                Return LAGO
            Case "ARMYB"
                Return ARMYB
            Case "BURTON"
                Return BURTON
            Case Else
                Return New List(Of Vector5)
        End Select
    End Function

    <Extension>
    Public Function GetNearestParkingSpot(pos As Vector3) As Vector5
        Dim result = pos.GetParkingSpotByZone.OrderBy(Function(x) System.Math.Abs(x.Vector3.DistanceToSquared(pos)))
        If result.Count <> 0 Then
            Return result.FirstOrDefault
        Else
            Return Vector5.Zero
        End If
    End Function

    <Extension>
    Public Function ToQuaternion(v5 As Vector5) As Quaternion
        Return New Quaternion(v5.Vector3.X, v5.Vector3.Y, v5.Vector3.Z, v5.Vector2.ToHeading)
    End Function

    <Extension>
    Public Function IsPositionOccupied(pos As Vector3, range As Single) As Boolean
        Return NFunc.Call(Of Boolean)(Hash.IS_POSITION_OCCUPIED, pos.X, pos.Y, pos.Z, range, False, True, False, False, False, 0, False)
    End Function

    <Extension>
    Public Sub Play(speech As Speech)
        Using stream As New WaveStream(IO.File.OpenRead($"{soundPath}{speech.Wav}"))
            stream.Volume = config.GetValue(Of Integer)("SOUND", "Volume", 100)
            Using player As New SoundPlayer(stream)
                player.Play()
            End Using
        End Using
    End Sub

    Public Sub Sleep(apt As ApartmentClass)
        'NFunc.Call(Hash.SET_CURRENT_PED_VEHICLE_WEAPON, PP, WeaponHash.Unarmed, True)
        'Dim ts As New TaskSequence
        'ts.AddTask.SlideTo(apt.SavePos, PP.Heading)
        'ts.AddTask.PlayAnimation("anim@mp_bedmid@left_var_02", "f_getin_l_bighouse")
        'ts.AddTask.PlayAnimation("anim@mp_bedmid@left_var_02", "f_sleep_l_loop_bighouse")
        'PP.Task.PerformSequence(ts)
        'NFunc.Call(Hash.FORCE_PED_MOTION_STATE, PP, 1063765679, False, 0, False)
        'ts.Close()
        'ts.Dispose()
    End Sub

    <Extension>
    Public Function GetClothes(ped As Ped, com As ePedVariation) As CS
        Return New CS(CInt(com), NFunc.Call(Of Integer)(Hash.GET_PED_DRAWABLE_VARIATION, ped, com), NFunc.Call(Of Integer)(Hash.GET_PED_TEXTURE_VARIATION, ped, com), NFunc.Call(Of Integer)(Hash.GET_PED_PALETTE_VARIATION, ped, com))
    End Function

    <Extension>
    Public Function GetProps(ped As Ped, com As ePropVariation) As CS
        Return New CS(CInt(com), NFunc.Call(Of Integer)(Hash.GET_PED_PROP_INDEX, ped, com), NFunc.Call(Of Integer)(Hash.GET_PED_PROP_TEXTURE_INDEX, ped, com), 0)
    End Function

    <Extension>
    Public Sub SetProps(ped As Ped, com As Integer, draw As Integer, txd As Integer)
        If draw = -1 Then NFunc.Call(Hash.CLEAR_PED_PROP, ped, com)
        NFunc.Call(Hash.SET_PED_PROP_INDEX, ped, com, draw, txd, 0)
    End Sub

    <Extension>
    Public Sub SetProps(ped As Ped, cs As CS)
        If cs.DrawableID = -1 Then NFunc.Call(Hash.CLEAR_PED_PROP, ped, cs.ComponentID)
        NFunc.Call(Hash.SET_PED_PROP_INDEX, ped, cs.ComponentID, cs.DrawableID, cs.TextureID, cs.PaletteID)
    End Sub

    <Extension>
    Public Sub SetClothes(ped As Ped, com As Integer, draw As Integer, txd As Integer)
        NFunc.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, com, draw, txd, 2)
    End Sub

    <Extension>
    Public Sub SetClothes(ped As Ped, cs As CS)
        NFunc.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, cs.ComponentID, cs.DrawableID, cs.TextureID, cs.PaletteID)
    End Sub

    Public Function GetControlInstructionalButton(control As Control) As String
        Return NFunc.Call(Of String)(GET_CONTROL_INSTRUCTIONAL_BUTTON, 2, control, True)
    End Function

    <Extension>
    Public Function GetInterior(pos As Vector3) As Integer
        Return NFunc.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, pos.X, pos.Y, pos.Z)
    End Function

    Public Function IsInInterior() As Boolean
        Return NFunc.Call(Of Boolean)(Hash.IS_INTERIOR_SCENE)
    End Function

    Public Function EnableOnlineMap() As Boolean
        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        Dim gotError As Boolean = False

        If config.GetValue(Of Boolean)("SETTING", "OnlineMap", True) Then
            Try
                NFunc.Call(ON_ENTER_MP)
            Catch ex As Exception
                gotError = True
            End Try
            If Not gotError Then LoadMPDLCMapMissingObjects()
        End If

        Return gotError
    End Function

    Public Sub LoadMPDLCMapMissingObjects()
        ActivateInteriorEntitySet(New Vector3(-1155.31005, -1518.5699, 10.6300001), "swap_clean_apt", "layer_whiskey", "layer_sextoys_a", "swap_mrJam_A", "swap_sofa_A") 'Floyd Apartment
        ActivateInteriorEntitySet(New Vector3(-802.31097, 175.05599, 72.84459), "V_Michael_bed_tidy", "V_Michael_L_Items", "V_Michael_S_Items", "V_Michael_D_Items", "V_Michael_M_Items", "Michael_premier", "V_Michael_plane_ticket") 'Michael House
        ActivateInteriorEntitySet(New Vector3(-9.96562, -1438.54003, 31.101499), "V_57_FranklinStuff") 'Franklin Aunt House
        ActivateInteriorEntitySet(New Vector3(0.91675, 528.48498, 174.628005), "franklin_settled", "franklin_unpacking", "bong_and_wine", "progress_flyer", "progress_tshirt", "progress_tux", "unlocked") 'Franklin House

        'Stilts Apartment kitchen window
        ActivateInteriorEntitySet(New Vector3(-172.983001, 494.032989, 137.654006), "Stilts_Kitchen_Window") '3655 Wild Oats
        ActivateInteriorEntitySet(New Vector3(340.941009, 437.17999, 149.389999), "Stilts_Kitchen_Window") '2044 North Conker
        ActivateInteriorEntitySet(New Vector3(373.0230102, 416.1050109, 145.70100402), "Stilts_Kitchen_Window") '2045 North Conker
        ActivateInteriorEntitySet(New Vector3(-676.1270141, 588.6119995, 145.16999816), "Stilts_Kitchen_Window") '2862 Hillcrest Avenue
        ActivateInteriorEntitySet(New Vector3(-763.10699462, 615.90600585, 144.139999), "Stilts_Kitchen_Window") '2868 Hillcrest Avenue
        ActivateInteriorEntitySet(New Vector3(-857.79797363, 682.56298828, 152.6529998), "Stilts_Kitchen_Window") '2874 Hillcrest Avenue
        ActivateInteriorEntitySet(New Vector3(-572.60998535, 653.13000488, 145.63000488), "Stilts_Kitchen_Window") '2117 Milton Road
        ActivateInteriorEntitySet(New Vector3(120.5, 549.952026367, 184.09700012207), "Stilts_Kitchen_Window") '3677 Whispymound Drive
        ActivateInteriorEntitySet(New Vector3(-1288, 440.74798583, 97.694602966), "Stilts_Kitchen_Window") '2113 Mad Wayne Thunder Drive
    End Sub

    Public Sub ActivateInteriorEntitySet(pos As Vector3, ParamArray entities As String())
        Dim id = NFunc.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, pos.X, pos.Y, pos.Z)
        For Each entity In entities
            NFunc.Call(ACTIVATE_INTERIOR_ENTITY_SET, id, entity)
        Next
        NFunc.Call(Hash.REFRESH_INTERIOR, id)
    End Sub

    <Extension>
    Public Function GetClosestProp(pos As Vector3, radius As Single, model As String, persistence As Boolean) As Prop
        Return NFunc.Call(Of Prop)(Hash.GET_CLOSEST_OBJECT_OF_TYPE, pos.X, pos.Y, pos.Z, radius, GetHashKey(model), persistence, False, True)
    End Function

    Public Sub RequestIPL(ipl As String)
        NFunc.Call(Hash.REQUEST_IPL, ipl)
    End Sub

    <Extension>
    Public Function TopSpeed(veh As Vehicle) As Single
        Return NFunc.Call(Of Single)(GET_VEHICLE_ESTIMATED_MAX_SPEED, veh.Model.GetHashCode)
    End Function

    Public Function Acceleration(veh As Vehicle) As Single
        Return NFunc.Call(Of Single)(Hash.GET_VEHICLE_ACCELERATION, veh)
    End Function

    <Extension>
    Public Sub DrawMPCarStats(sf As Scaleform, veh As Vehicle, Optional scale As Vector3 = Nothing)
        If scale = Nothing Then scale = New Vector3(6.0F, 3.5F, 1.0F)
        If veh.IsOnScreen AndAlso veh.Position.DistanceToSquared(PP.Position) <= 100.0F Then
            sf.CallFunction("SET_VEHICLE_INFOR_AND_STATS", veh.FriendlyName, Game.GetGXTEntry("MP_PROP_CAR0"), "MPCarHUD", veh.Make, Game.GetGXTEntry("FMMC_VEHST_0"), Game.GetGXTEntry("FMMC_VEHST_1"),
                                   Game.GetGXTEntry("FMMC_VEHST_2"), Game.GetGXTEntry("FMMC_VEHST_3"), veh.TopSpeed * 100.0F, veh.MaxBraking * 100.0F, veh.Acceleration * 100.0F, veh.MaxTraction * 100.0F)
            sf.Render3D(New Vector3(veh.Position.X, veh.Position.Y, veh.Position.Z + 3.0F), GameplayCamera.Rotation, scale)
        End If
    End Sub

    <Extension>
    Public Function GetBlipColor(bd As BuildingClass) As BlipColor
        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        If bd.Apartments.Count = 1 Then
            Select Case bd.Apartments.FirstOrDefault.Owner
                Case eOwner.Michael
                    Return BlipColor.Michael
                Case eOwner.Franklin
                    Return BlipColor.Franklin
                Case eOwner.Trevor
                    Return BlipColor.Trevor
                Case eOwner.Others
                    Return BlipColor.Yellow
            End Select
        Else
            Dim mc = bd.GetOwnerCount(eOwner.Michael)
            Dim fc = bd.GetOwnerCount(eOwner.Franklin)
            Dim tc = bd.GetOwnerCount(eOwner.Trevor)
            Dim fmc = bd.GetOwnerCount(eOwner.Others)
            Dim counts As Integer() = {mc, fc, tc, fmc}
            Dim max = counts.Max
            Select Case max
                Case mc
                    Return BlipColor.Michael
                Case fc
                    Return BlipColor.Franklin
                Case tc
                    Return BlipColor.Trevor
                Case fmc
                    Return BlipColor.Yellow
            End Select
        End If
        Return BlipColor.White
    End Function

    <Extension>
    Public Function GetOwnerCount(bd As BuildingClass, ow As eOwner) As Integer
        Return (From o In bd.Apartments Where o.Owner = ow).Count
    End Function

    <Extension>
    Public Function TruncateString(str As String, len As Integer) As String
        If len > str.Length Then Return str Else Return str.Substring(0, len)
    End Function

    <Extension>
    Public Function Owner(veh As Vehicle) As eOwner
        If veh.GetInt(vehUidDecor) <> 0 Then
            Select Case veh.CurrentBlip.Color
                Case BlipColor.Franklin
                    Return eOwner.Franklin
                Case BlipColor.Michael
                    Return eOwner.Michael
                Case BlipColor.Trevor
                    Return eOwner.Trevor
                Case BlipColor.Yellow
                    Return eOwner.Others
            End Select
        End If
        Return eOwner.Nobody
    End Function

    'open shop_controller.ysc and search for "!= 999"
    Public Enum GlobalValue
        b1_0_757_4 = &H271803
        b1_0_791_2 = &H272A34
        b1_0_877_1 = &H2750BD
        b1_0_944_2 = &H279476
        'b1_0_1011_1 = ?
        b1_0_1032_1 = 2593970
        b1_0_1103_2 = 2599337
        b1_0_1180_2 = 2606794
        'b1_0_1290_1 = ?
        b1_0_1365_1 = 4265719
        'b1_0_1493_0 = ?
        b1_0_1493_1 = 4266042
        b1_0_1604_1 = 4266905
        b1_0_1737_0 = 4267883
        b1_0_1868_0 = 4268190
        b1_0_2060_0 = 4268340
    End Enum

    Public Function GetGlobalValue() As GlobalValue
        Select Case Game.Version
            Case GameVersion.VER_1_0_757_4_NOSTEAM
                Return GlobalValue.b1_0_757_4
            Case GameVersion.VER_1_0_791_2_NOSTEAM, GameVersion.VER_1_0_791_2_STEAM
                Return GlobalValue.b1_0_791_2
            Case GameVersion.VER_1_0_877_1_NOSTEAM, GameVersion.VER_1_0_877_1_STEAM
                Return GlobalValue.b1_0_877_1
            Case GameVersion.VER_1_0_944_2_NOSTEAM, GameVersion.VER_1_0_944_2_STEAM
                Return GlobalValue.b1_0_944_2
            Case GameVersion.VER_1_0_1032_1_NOSTEAM, GameVersion.VER_1_0_1032_1_STEAM
                Return GlobalValue.b1_0_1032_1
            Case GameVersion.VER_1_0_1103_2_NOSTEAM, GameVersion.VER_1_0_1103_2_STEAM
                Return GlobalValue.b1_0_1103_2
            Case GameVersion.VER_1_0_1180_2_NOSTEAM, GameVersion.VER_1_0_1180_2_STEAM
                Return GlobalValue.b1_0_1180_2
            Case GameVersion.VER_1_0_1365_1_NOSTEAM, GameVersion.VER_1_0_1365_1_STEAM
                Return GlobalValue.b1_0_1365_1
            Case GameVersion.VER_1_0_1493_1_NOSTEAM, GameVersion.VER_1_0_1493_1_STEAM
                Return GlobalValue.b1_0_1493_1
            Case GameVersion.VER_1_0_1604_0_NOSTEAM, GameVersion.VER_1_0_1604_0_STEAM, GameVersion.VER_1_0_1604_1_NOSTEAM, GameVersion.VER_1_0_1604_1_STEAM
                Return GlobalValue.b1_0_1604_1
            Case GameVersion.VER_1_0_1737_0_NOSTEAM, GameVersion.VER_1_0_1737_0_STEAM, GameVersion.VER_1_0_1737_6_NOSTEAM, GameVersion.VER_1_0_1737_6_STEAM
                Return GlobalValue.b1_0_1737_0
            Case GameVersion.VER_1_0_1868_0_NOSTEAM, GameVersion.VER_1_0_1868_0_STEAM, 57, 58, 59 'GameVersion.VER_1_0_1868_1_STEAM, GameVersion.VER_1_0_1868_1_NOSTEAM, GameVersion.VER_1_0_1868_4_EGS
                Return GlobalValue.b1_0_1868_0
            Case 60, 61, 62, 63 'GameVersion.VER_1_0_2060_0_STEAM, GameVersion.VER_1_0_2060_0_NOSTEAM, GameVersion.VER_1_0_2060_1_STEAM, GameVersion.VER_1_0_2060_1_NOSTEAM
                Return GlobalValue.b1_0_2060_0
            Case Else
                Return GlobalValue.b1_0_2060_0
        End Select
    End Function

    <Extension>
    Public Function GetProperBlipSprite(model As Model) As BlipSprite
        Select Case True
            Case model = "akula"
                Return BlipSprite.Akula
            Case model = "alphaz1"
                Return BlipSprite.AlphaZ1
            Case model = "apc"
                Return BlipSprite.APC
            Case model = "boxville5"
                Return BlipSprite.ArmoredBoxville
            Case model = "stockade3", model = "stockade"
                Return BlipSprite.ArmoredTruck
            Case model = "avenger"
                Return BlipSprite.Avenger
            Case model = "strikeforce"
                Return BlipSprite.B11StrikeForce
            Case model = "barrage"
                Return BlipSprite.Barrage
            Case model = "blimp"
                Return BlipSprite.Blimp
            Case model = "blimp2", model = "blimp3"
                Return BlipSprite.Blimp2
            Case model = "bombushka"
                Return BlipSprite.Bombushka
            Case model = "bruiser", model = "bruiser2", model = "bruiser3"
                Return BlipSprite.Bruiser
            Case model = "brutus", model = "brutus2", model = "brutus3"
                Return BlipSprite.Brutus
            Case model = "bus", model = "airbus"
                Return BlipSprite.Bus
            Case model = "taxi"
                Return BlipSprite.Cab
            Case model = "caracara"
                Return BlipSprite.Caracara
            Case model = "cargobob", model = "cargobob2", model = "cargobob3", model = "cargobob4"
                Return BlipSprite.Cargobob
            Case model = "cerberus", model = "cerberus2", model = "cerberus3"
                Return BlipSprite.Cerberus
            Case model = "chernobog"
                Return BlipSprite.Chernobog
            Case model = "deathbike", model = "deathbike2", model = "deathbike3"
                Return BlipSprite.Deathbike
            Case model = "deluxo"
                Return BlipSprite.Deluxo
            Case model = "dinghy", model = "dinghy2", model = "dinghy3", model = "dinghy4"
                Return BlipSprite.Dinghy
            Case model = "dominator3"
                Return BlipSprite.Dominator
            Case model = "dune3"
                Return BlipSprite.DuneFAV
            Case model = "pbus2"
                Return BlipSprite.FestivalBus
            Case model = "insurgent", model = "insurgent2", model = "insurgent3"
                Return BlipSprite.GunCar
            Case model = "halftrack"
                Return BlipSprite.HalfTrack
            Case model = "havok"
                Return BlipSprite.Havok
            Case model = "howard"
                Return BlipSprite.HowardNX25
            Case model = "hunter"
                Return BlipSprite.Hunter
            Case model = "impaler", model = "impaler2", model = "impaler3", model = "impaler4"
                Return BlipSprite.Impaler
            Case model = "imperator", model = "imperator2", model = "imperator3"
                Return BlipSprite.Imperator
            Case model = "issi3", model = "issi4", model = "issi5", model = "issi6"
                Return BlipSprite.Issi
            Case model = "khanjali"
                Return BlipSprite.Khanjali
            Case model = "limo"
                Return BlipSprite.Limo
            Case model = "menacer"
                Return BlipSprite.Menacer
            Case model = "mogul"
                Return BlipSprite.Mogul
            Case model = "mule4"
                Return BlipSprite.MuleCustom
            Case model = "oppressor"
                Return BlipSprite.Oppressor
            Case model = "oppressor2"
                Return BlipSprite.OppressorMkII
            Case model = "nokota"
                Return BlipSprite.P45Nokota
            Case model = "phantom2"
                Return BlipSprite.PhantomWedge
            Case model = "pounder2"
                Return BlipSprite.PounderCustom
            Case model = "pyro"
                Return BlipSprite.Pyro
            Case model = "dune4", model = "dune5"
                Return BlipSprite.RampBuggy
            Case model = "riot2"
                Return BlipSprite.RCV
            Case model = "rcbandito"
                Return BlipSprite.RCVehicle
            Case model = "voltic2"
                Return BlipSprite.RocketVoltic
            Case model = "rogue"
                Return BlipSprite.Rogue
            Case model = "ruiner2"
                Return BlipSprite.Ruiner2000
            Case model = "monster", model = "monster2", model = "monster3"
                Return BlipSprite.Sasquatch
            Case model = "scarab", model = "scarab2", model = "scarab3"
                Return BlipSprite.Scarab
            Case model = "scramjet"
                Return BlipSprite.Scramjet
            Case model = "seabreeze"
                Return BlipSprite.Seabreeze
            Case model = "seashark", model = "seashark2", model = "seashark3"
                Return BlipSprite.Seashark
            Case model = "seasparrow"
                Return BlipSprite.SeaSparrow
            Case model = "slamvan4", model = "slamvan5", model = "slamvan6"
                Return BlipSprite.Slamvam
            Case model = "speedo4"
                Return BlipSprite.SpeedoCustom
            Case model = "starling"
                Return BlipSprite.Starling
            Case model = "stromberg"
                Return BlipSprite.Stromberg
            Case model = "submersible"
                Return BlipSprite.Sub
            Case model = "rhino"
                Return BlipSprite.Tank
            Case model = "technical2"
                Return BlipSprite.TechnicalAqua
            Case model = "terbyte"
                Return BlipSprite.Terrorbyte
            Case model = "thruster"
                Return BlipSprite.Thruster
            Case model = "towtruck"
                Return BlipSprite.TowTruck
            Case model = "towtruck2"
                Return BlipSprite.TowTruck2
            Case model = "tula"
                Return BlipSprite.Tula
            Case model = "limo2"
                Return BlipSprite.TurretedLimo
            Case model = "microlight"
                Return BlipSprite.Ultralight
            Case model = "molotok"
                Return BlipSprite.V65Molotok
            Case model = "volatol"
                Return BlipSprite.Volatol
            Case model = "wastelander"
                Return BlipSprite.Wastelander
            Case model = "tampa3"
                Return BlipSprite.WeaponizedTampa
            Case model = "trailersmall2"
                Return BlipSprite.WeaponizedTrailer
            Case model = "zr380", model = "zr3802", model = "zr3803"
                Return BlipSprite.ZR380

            Case model.IsBike
                Return BlipSprite.PersonalVehicleBike
            Case model.IsBoat
                Return BlipSprite.Boat
            Case model.IsHelicopter
                Return BlipSprite.Helicopter
            Case model.IsPlane
                Return BlipSprite.Plane
            Case model.IsQuadbike
                Return BlipSprite.QuadBike
            Case model.IsCargobob
                Return BlipSprite.Cargobob

            Case Else
                Return BlipSprite.PersonalVehicleCar
        End Select
    End Function

    Public Sub StartScreenFx(fxName As String, duration As Integer, looped As Boolean, stopAfterDuration As Boolean)
        NFunc.Call(ANIMPOSTFX_PLAY, fxName, duration, looped)
        Script.Wait(duration)
        If stopAfterDuration Then StopScreenFx(fxName)
    End Sub

    Public Sub StopScreenFx(fxName As String)
        NFunc.Call(ANIMPOSTFX_STOP, fxName)
    End Sub

End Module
