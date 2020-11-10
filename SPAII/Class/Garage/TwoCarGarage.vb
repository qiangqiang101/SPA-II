Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports Metadata

Module TwoCarGarage

    Public Apartment As ApartmentClass

    'Vehicle
    Public Vehicle0 As Vehicle
    Public Vehicle1 As Vehicle
    Public Vehicles As New List(Of Vehicle)

    'Coords
    Public Interior As New Vector3(173.1176F, -1003.27887F, -99)
    Public Elevator As New Vector3(179.1001, -1005.655, -99.9999)
    Public ElevatorInside As New Quaternion(179.0661F, -1002.717F, -99.99992F, 179.181F)
    Public GarageDoor As New Vector3(172.9447, -1008.339, -99.9999)
    Public MenuActivator As New Vector3(178.9034F, -1007.407F, -99.99998F)
    Public Veh0Pos As New Quaternion(175.2132, -1004.104, -99, -178.4487)
    Public Veh1Pos As New Quaternion(171.7141, -1004.023, -99, -178.4487)

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

    Public Sub TwoCarGarageOnTick()
        'Enter Apartment from Garage Elevator
        If Not Apartment.ApartmentType = eApartmentType.Other Then
            If GarageElevatorDistance() <= 2.0F Then
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
                        Case eApartmentType.None, eApartmentType.IPL
                            HighEndApartment.Building = Apartment.Building
                    End Select
                    Apartment.PlayApartmentEnterCutscene()
                    Clear()
                    World.DestroyAllCameras()
                    World.RenderingCamera = Nothing
                    HideHud = False
                End If
            End If
        End If

        'Exit Garage
        If GarageDoorLeftDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                FadeScreen(1)
                If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                    Apartment.Building.PlayExitGarageCamera(5000, True, True, CameraShake.Hand, 0.4F)
                Else
                    Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                    Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                    FadeScreen(0)
                End If
                Clear()
            End If
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
            End If
        End If

        'Draw marker
        If MenuDistance() <= 200.0F Then MenuActivator.DrawMarker
    End Sub

    Public Function MenuDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(MenuActivator)
    End Function

    Public Sub Clear()
        If Vehicle0 <> Nothing Then Vehicle0.Delete()
        If Vehicle1 <> Nothing Then Vehicle1.Delete()
    End Sub

End Module
