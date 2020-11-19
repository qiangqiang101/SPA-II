Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Math
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM

Module TwoCarGarage

    Public Apartment As ApartmentClass = Nothing
    Public WithEvents MgmtMenu As UIMenu
    Public Camera As Camera

    'Vehicle
    Public Vehicle0 As Vehicle
    Public Vehicle1 As Vehicle
    Public Vehicles As New List(Of Vehicle)

    'Coords
    Public Interior As New Vector3(173.1176F, -1003.27887F, -99)
    Public Elevator As New Vector3(179.1001, -1005.655, -99.9999)
    Public ElevatorInside As New Quaternion(179.0661F, -1002.717F, -99.99992F, 179.181F)
    Public SpawnInPos As New Quaternion(176.6249F, -1007.737F, -99.9999F, 32.54933F)
    Public GarageDoor As New Vector3(172.9447, -1008.339, -99.9999)
    Public MenuActivator As New Vector3(178.9034F, -1007.407F, -99.99998F)
    Public Veh0Pos As New Quaternion(175.2132, -1004.104, -99, -178.4487)
    Public Veh1Pos As New Quaternion(171.7141, -1004.023, -99, -178.4487)
    Public MenuCam As New CameraPRH(New Vector3(179.6135F, -1008.107F, -97.29996F), New Vector3(-24.14237F, 0F, 57.91766F), 50.0F)

    Public Sub LoadGarageMenu()
        MgmtMenu = New UIMenu("", Game.GetGXTEntry("MP_MAN_VEH0").ToUpper, New Point(0, -107))
        MgmtMenu.SetBannerType(MenuBanner)
        MgmtMenu.MouseEdgeEnabled = False
        MgmtMenu.RefreshIndex()
        MenuPool.Add(MgmtMenu)
    End Sub

    Public Sub RefreshMgmtMenu(apt As ApartmentClass)
        MgmtMenu.MenuItems.Clear()

        With MgmtMenu
            Dim veh1 As VehicleClass = apt.Vehicles.Find(Function(x) x.Index = 0)
            Dim item1 As New UIMenuItem(If(veh1 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh1.Make} {veh1.Name} ({veh1.PlateNumber})"), Game.GetGXTEntry("MP_MAN_VEH3")) With {.Tag = New VehClassMenuItem(0, veh1), .Enabled = If(veh1 Is Nothing, False, True)}
            .AddItem(item1)
            Dim veh2 As VehicleClass = apt.Vehicles.Find(Function(x) x.Index = 1)
            Dim item2 As New UIMenuItem(If(veh2 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh2.Make} {veh2.Name} ({veh2.PlateNumber})"), Game.GetGXTEntry("MP_MAN_VEH3")) With {.Tag = New VehClassMenuItem(1, veh2), .Enabled = If(veh2 Is Nothing, False, True)}
            .AddItem(item2)
            .RefreshIndex()
        End With
    End Sub

    Public Sub LoadVehicles()
        Try
            Vehicles.Clear()
            If Vehicle0 <> Nothing Then Vehicle0.Delete()
            If Vehicle1 <> Nothing Then Vehicle1.Delete()

            For Each veh In Apartment.Vehicles
                If Not IsGarageVehicleAlreadyExistInWorldMap(Apartment.ID, veh.UniqueID) Then
                    Select Case veh.Index
                        Case 0
                            Vehicle0 = CreateGarageVehicle(veh, Veh0Pos, Apartment.ID)
                            Vehicle0.PlaceOnGround()
                            Vehicles.Add(Vehicle0)
                        Case 1
                            Vehicle1 = CreateGarageVehicle(veh, Veh1Pos, Apartment.ID)
                            Vehicle1.PlaceOnGround()
                            Vehicles.Add(Vehicle1)
                    End Select
                End If
            Next

            'TwoCarGarage Only
            TurnOffRadio("SE_MP_GARAGE_S_RADIO")
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub LoadVehiclesSetPlayerPos(uid As Integer)
        Try
            LoadVehicles()

            Dim target As Vehicle = Vehicles.Find(Function(x) x.GetInt(vehUidDecor) = uid)
            If target.Exists Then
                Game.Player.Character.Position = target.Position
                target.SetPlayerIntoVehicle
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Function GarageElevatorDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(Elevator)
    End Function

    Public Function GarageDoorLeftDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(GarageDoor)
    End Function

    Public StatScaleform0 As New Scaleform("MP_CAR_STATS_01")
    Public StatScaleform1 As New Scaleform("MP_CAR_STATS_02")

    <Extension>
    Public Sub DrawMPCarStats(sf As Scaleform, veh As Vehicle, Optional scale As Vector3 = Nothing)
        If scale = Nothing Then scale = New Vector3(6.0F, 3.5F, 1.0F)
        If veh.IsOnScreen AndAlso veh.Position.DistanceToSquared(PP.Position) <= 100.0F Then
            sf.CallFunction("SET_VEHICLE_INFOR_AND_STATS", veh.FriendlyName, Game.GetGXTEntry("MP_PROP_CAR0"), "MPCarHUD", veh.Make, Game.GetGXTEntry("FMMC_VEHST_0"), Game.GetGXTEntry("FMMC_VEHST_1"),
                                   Game.GetGXTEntry("FMMC_VEHST_2"), Game.GetGXTEntry("FMMC_VEHST_3"), veh.TopSpeed * 100.0F, veh.MaxBraking * 100.0F, veh.Acceleration * 100.0F, veh.MaxTraction * 100.0F)
            sf.Render3D(New Vector3(veh.Position.X, veh.Position.Y, veh.Position.Z + 3.0F), GameplayCamera.Rotation, scale)
        End If
    End Sub

    Public Sub TwoCarGarageOnTick()
        If PI = TwoCarGarage.Interior.GetInterior Then
            If Vehicles.Count <> 0 Then
                If Game.IsControlPressed(0, Control.MultiplayerInfo) Then
                    If Vehicle0 <> Nothing Then StatScaleform0.DrawMPCarStats(Vehicle0)
                    If Vehicle1 <> Nothing Then StatScaleform1.DrawMPCarStats(Vehicle1)
                End If
            End If

            'Vehicle Management
            If MenuDistance() <= 2.0F Then
                If Not MenuPool.IsAnyMenuOpen Then
                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_MAN_VEH"))
                    If Game.IsControlJustReleased(0, Control.Context) Then
                        RefreshMgmtMenu(Apartment)
                        MgmtMenu.Visible = True
                        HideHud = True
                        Camera = World.CreateCamera(MenuCam.Position, MenuCam.Rotation, MenuCam.FOV)
                        World.RenderingCamera = Camera
                        GarageMarkerIndicator = Veh0Pos.ToVector3
                        Camera.PointAt(GarageMarkerIndicator)
                    End If
                End If
            End If

            'Enter Apartment from Garage Elevator
            If GarageElevatorDistance() <= 2.0F Then
                If Not Apartment.ApartmentType = eApartmentType.Other Then
                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1"))
                    If Game.IsControlJustReleased(0, Control.Context) Then
                        HideHud = True
                        Apartment.Building.PlayEnterElevatorCutScene(5000)
                        Apartment.SetInteriorActive()
                        Game.Player.Character.Position = Apartment.ApartmentInPos
                        Select Case Apartment.ApartmentType
                            Case eApartmentType.LowEnd
                                LowEndApartment.Apartment = Apartment
                                LowEndApartment.SpawnDoor()
                            Case eApartmentType.MediumEnd
                                MediumEndApartment.Apartment = Apartment
                                MediumEndApartment.SpawnDoor()
                            Case eApartmentType.None, eApartmentType.IPL, eApartmentType.IPLwoStyle
                                HighEndApartment.Building = Apartment.Building
                        End Select
                        Apartment.PlayApartmentEnterCutscene()
                        Clear()
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        HideHud = False
                        Apartment = Nothing
                    End If
                End If
            End If

            'Exit Garage
            If GarageDoorLeftDistance() <= 2.0F Then
                FadeScreen(1)
                If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                    Apartment.Building.PlayExitGarageCamera(5000, True, True, CameraShake.Hand, 0.4F)
                Else
                    Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                    Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                    FadeScreen(0)
                End If
                Clear()
                Apartment = Nothing
            End If

            'Exit Garage with vehicle
            If Game.Player.Character.IsInVehicle Then
                If Vehicles.Contains(Game.Player.Character.CurrentVehicle) AndAlso Game.Player.Character.CurrentVehicle.Speed >= 0.5 Then
                    FadeScreen(1)
                    Dim curVeh As Vehicle = Vehicles.Find(Function(x) x.GetInt(vehUidDecor) = Game.Player.Character.CurrentVehicle.GetInt(vehUidDecor) AndAlso x.GetInt(vehIdDecor) = Apartment.ID)
                    Dim bd = Apartment.Building

                    Dim newVeh As Vehicle
                    If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                        Game.Player.Character.Position = bd.GarageWaypoint.ToVector3
                        newVeh = curVeh.CloneVehicle(bd.GarageWaypoint.ToVector3, bd.GarageWaypoint.W, False)
                    Else
                        Game.Player.Character.Position = bd.GarageOutPos.ToVector3
                        newVeh = curVeh.CloneVehicle(bd.GarageOutPos.ToVector3, bd.GarageOutPos.W, False)
                    End If
                    With newVeh
                        .AddBlip()
                        .CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
                        Select Case GetPlayer()
                            Case eOwner.Michael
                                .CurrentBlip.Color = BlipColor.Michael
                            Case eOwner.Franklin
                                .CurrentBlip.Color = BlipColor.Franklin
                            Case eOwner.Trevor
                                .CurrentBlip.Color = BlipColor.Trevor
                            Case eOwner.Others
                                .CurrentBlip.Color = BlipColor.Yellow
                        End Select
                        .CurrentBlip.IsShortRange = True
                        .CurrentBlip.Name = $"{newVeh.Make} {newVeh.FriendlyName}"
                        .PlaceOnGround()
                    End With
                    outVehicleList.Add(newVeh)
                    If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                        newVeh.Position = bd.GarageWaypoint.ToVector3
                    Else
                        newVeh.Position = bd.GarageOutPos.ToVector3
                    End If
                    newVeh.SetPlayerIntoVehicle
                    newVeh.EngineRunning = True
                    Clear()
                    If Apartment.Building.GarageDoor = eFrontDoor.NoDoor Then FadeScreen(0)
                    Apartment.Building.PlayExitGarageCamera(7000, True, True, CameraShake.Hand, 0.4F)
                    Apartment = Nothing
                End If
            End If

            'Draw marker
            If MenuDistance() <= 200.0F AndAlso Not Apartment Is Nothing Then MenuActivator.DrawMarker
            If MgmtMenu.Visible Then GarageMarkerIndicator.DrawMgmtMarker
        End If
    End Sub

    Private Sub MgmtMenu_OnIndexChange(sender As UIMenu, Index As Integer) Handles MgmtMenu.OnIndexChange
        Dim selectedItem As UIMenuItem = sender.MenuItems(Index)
        Dim selectedVeh As VehClassMenuItem = selectedItem.Tag

        Select Case selectedVeh.Index
            Case 0
                GarageMarkerIndicator = Veh0Pos.ToVector3
            Case 1
                GarageMarkerIndicator = Veh1Pos.ToVector3
        End Select

        Camera.PointAt(GarageMarkerIndicator)
    End Sub

    Public Function MenuDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(MenuActivator)
    End Function

    Public Sub Clear()
        If Vehicle0 <> Nothing Then Vehicle0.Delete()
        If Vehicle1 <> Nothing Then Vehicle1.Delete()
    End Sub

    Private Sub MgmtMenu_OnMenuClose(sender As UIMenu) Handles MgmtMenu.OnMenuClose
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
    End Sub

End Module
