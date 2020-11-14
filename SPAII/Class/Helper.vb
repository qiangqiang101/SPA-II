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

    'Menu
    Public MenuPool As New MenuPool
    Public MenuBanner As New UIResRectangle(Point.Empty, New Size(0, 0), Color.FromArgb(0, 0, 0, 0))
    Public MichaelBanner As New Sprite("shopui_title_graphics_michael", "shopui_title_graphics_michael", Nothing, Nothing)
    Public FranklinBanner As New Sprite("shopui_title_graphics_franklin", "shopui_title_graphics_franklin", Nothing, Nothing)
    Public TrevorBanner As New Sprite("shopui_title_graphics_trevor", "shopui_title_graphics_trevor", Nothing, Nothing)

    'Coords
    Public TwentyCarGarage As New Vector3(0, 0, 0)

    'Prop
    Public ForSaleSign As String = "prop_forsale_dyn_01"

    'Speech
    Public OnTheClock As New Speech("mechanic_on_the_clock_some_wheels.wav")
    Public YouNeedSomething As New Speech("mechanic_u_need_something_huh.wav")
    Public ICantGetYourRide As New Speech("mechanic_cant_get_your_ride.wav")
    Public IllGetBackToWork As New Speech("mechanic_get_back_to_work_then.wav")
    Public IllBeThere As New Speech("mechanic_get_there_as_soon_as_i_can.wav")

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
        Dim playerText As New UIResText($"Player Position: {PP.Position}     Rotation: {PP.Rotation}     Heading: {PP.Heading}", Point.Empty, 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim playerVehText As New UIResText($"Player Vehicle Position: {PP.LastVehicle.Position}     Rotation: {PP.LastVehicle.Rotation}", New Point(0, playerText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim camText As New UIResText($"Camera Position: {GameplayCamera.Position}     Rotation: {GameplayCamera.Rotation}     FOV: {GameplayCamera.FieldOfView}", New Point(0, playerVehText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim direction As New UIResText($"Up: Vector     Down: Quaternion     Left: CameraPRH     Right: Door", New Point(0, camText.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        Dim forthLine As New UIResText(debug3rdLine, New Point(0, direction.Position.Y + 20), 0.3F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Left)
        playerText.Draw()
        playerVehText.Draw()
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
            Case "apa_v_mp_h_01_b"
                door = New Door(-658026477, New Vector3(-782.4497F, 317.5156F, 188.0627F))
            Case "apa_v_mp_h_01_c"
                door = New Door(-658026477, New Vector3(-778.5566F, 340.2328F, 196.8354F))

            Case "apa_v_mp_h_02_a" 'Moody
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_02_b"
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_02_c"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_03_a" 'Vibrant
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_03_b"
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_03_c"
                door = New Door(1398355146, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_04_a" 'Sharp
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 217.7884F))
            Case "apa_v_mp_h_04_b"
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 188.0634F))
            Case "apa_v_mp_h_04_c"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2332F, 196.8362F))

            Case "apa_v_mp_h_05_a" 'Monochrome
                door = New Door(-711771128, New Vector3(-782.4497F, 317.5156F, 217.7876F))
            Case "apa_v_mp_h_05_b"
                door = New Door(-711771128, New Vector3(-782.4497F, 317.5156F, 188.0627F))
            Case "apa_v_mp_h_05_c"
                door = New Door(-711771128, New Vector3(-778.5566F, 340.2328F, 196.8354F))

            Case "apa_v_mp_h_06_a" 'Seductive
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_06_b"
                door = New Door(103339342, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_06_c"
                door = New Door(103339342, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_07_a" 'Regal
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 217.7876F))
            Case "apa_v_mp_h_07_b"
                door = New Door(1398355146, New Vector3(-782.4496F, 317.5228F, 188.0627F))
            Case "apa_v_mp_h_07_c"
                door = New Door(1398355146, New Vector3(-778.5568F, 340.2256F, 196.8354F))

            Case "apa_v_mp_h_08_a" 'Aqua
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 217.7884F))
            Case "apa_v_mp_h_08_b"
                door = New Door(103339342, New Vector3(-782.4495F, 317.5152F, 188.0634F))
            Case "apa_v_mp_h_08_c"
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
        Return Native.Function.Call(Of Boolean)(Hash.IS_POSITION_OCCUPIED, pos.X, pos.Y, pos.Z, range, False, True, False, False, False, 0, False)
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
        NFunc.Call(Hash.SET_CURRENT_PED_VEHICLE_WEAPON, PP, WeaponHash.Unarmed, True)
        Dim ts As New TaskSequence
        ts.AddTask.SlideTo(apt.SavePos, PP.Heading)
        ts.AddTask.PlayAnimation("anim@mp_bedmid@left_var_02", "f_getin_l_bighouse")
        ts.AddTask.PlayAnimation("anim@mp_bedmid@left_var_02", "f_sleep_l_loop_bighouse")
        PP.Task.PerformSequence(ts)
        NFunc.Call(Hash.FORCE_PED_MOTION_STATE, PP, 1063765679, False, 0, False)
        ts.Close()
        ts.Dispose()
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
    Public Sub SetProp(ped As Ped, com As Integer, draw As Integer, txd As Integer)
        If draw = -1 Then NFunc.Call(Hash.CLEAR_PED_PROP, ped, com)
        NFunc.Call(Hash.SET_PED_PROP_INDEX, ped, com, draw, txd, 0)
    End Sub

    <Extension>
    Public Sub SetProp(ped As Ped, cs As CS)
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

End Module
