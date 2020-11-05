Imports System.Drawing
Imports GTA
Imports GTA.Math
Imports Metadata

Public Module TenCarGarage

    Public Apartment As ApartmentClass

    'Vehicle
    Public Vehicle0 As Vehicle
    Public Vehicle1 As Vehicle
    Public Vehicle2 As Vehicle
    Public Vehicle3 As Vehicle
    Public Vehicle4 As Vehicle
    Public Vehicle5 As Vehicle
    Public Vehicle6 As Vehicle
    Public Vehicle7 As Vehicle
    Public Vehicle8 As Vehicle
    Public Vehicle9 As Vehicle
    Public Vehicles As New List(Of Vehicle)

    'Coords
    Public Interior As New Vector3(222.592, -968.1, -99)
    Public Elevator As New Vector3(238.7097, -1004.8488, -99.9999)
    Public GarageDoorL As New Vector3(231.9013, -1006.686, -99.9999)
    Public GarageDoorR As New Vector3(224.4288, -1006.6892, -99.9999)
    Public MenuActivator As New Vector3(225.0141, -975.5068, -99.9999)
    Public Veh0Pos As New Quaternion(223.4, -1001, -99.99999, 241.3)
    Public Veh1Pos As New Quaternion(223.4, -996, -99.99999, 241.3)
    Public Veh2Pos As New Quaternion(223.4, -991, -99.99999, 241.3)
    Public Veh3Pos As New Quaternion(223.4, -986, -99.99999, 241.3)
    Public Veh4Pos As New Quaternion(223.4, -981, -99.99999, 241.3)
    Public Veh5Pos As New Quaternion(232.7, -1001, -99.99999, 116.3)
    Public Veh6Pos As New Quaternion(232.7, -996, -99.99999, 116.3)
    Public Veh7Pos As New Quaternion(232.7, -991, -99.99999, 116.3)
    Public Veh8Pos As New Quaternion(232.7, -986, -99.99999, 116.3)
    Public Veh9Pos As New Quaternion(232.7, -981, -99.99999, 116.3)

    Public Sub LoadVehicles()
        Try
            Vehicles.Clear()
            If Vehicle0 <> Nothing Then Vehicle0.Delete()
            If Vehicle1 <> Nothing Then Vehicle1.Delete()
            If Vehicle2 <> Nothing Then Vehicle2.Delete()
            If Vehicle3 <> Nothing Then Vehicle3.Delete()
            If Vehicle4 <> Nothing Then Vehicle4.Delete()
            If Vehicle5 <> Nothing Then Vehicle5.Delete()
            If Vehicle6 <> Nothing Then Vehicle6.Delete()
            If Vehicle7 <> Nothing Then Vehicle7.Delete()
            If Vehicle8 <> Nothing Then Vehicle8.Delete()
            If Vehicle9 <> Nothing Then Vehicle9.Delete()

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
                        Case 2
                            Vehicle2 = CreateGarageVehicle(veh, Veh2Pos, Apartment.ID)
                            Vehicle2.PlaceOnGround()
                            Vehicles.Add(Vehicle2)
                        Case 3
                            Vehicle3 = CreateGarageVehicle(veh, Veh3Pos, Apartment.ID)
                            Vehicle3.PlaceOnGround()
                            Vehicles.Add(Vehicle3)
                        Case 4
                            Vehicle4 = CreateGarageVehicle(veh, Veh4Pos, Apartment.ID)
                            Vehicle4.PlaceOnGround()
                            Vehicles.Add(Vehicle4)
                        Case 5
                            Vehicle5 = CreateGarageVehicle(veh, Veh5Pos, Apartment.ID)
                            Vehicle5.PlaceOnGround()
                            Vehicles.Add(Vehicle5)
                        Case 6
                            Vehicle6 = CreateGarageVehicle(veh, Veh6Pos, Apartment.ID)
                            Vehicle6.PlaceOnGround()
                            Vehicles.Add(Vehicle6)
                        Case 7
                            Vehicle7 = CreateGarageVehicle(veh, Veh7Pos, Apartment.ID)
                            Vehicle7.PlaceOnGround()
                            Vehicles.Add(Vehicle7)
                        Case 8
                            Vehicle8 = CreateGarageVehicle(veh, Veh8Pos, Apartment.ID)
                            Vehicle8.PlaceOnGround()
                            Vehicles.Add(Vehicle8)
                        Case 9
                            Vehicle9 = CreateGarageVehicle(veh, Veh9Pos, Apartment.ID)
                            Vehicle9.PlaceOnGround()
                            Vehicles.Add(Vehicle9)
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
        Return Game.Player.Character.Position.DistanceToSquared(GarageDoorL)
    End Function

    Public Function GarageDoorRightDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(GarageDoorR)
    End Function

    Public Sub TenCarGarageOnTick()
        'Enter Apartment from Garage Elevator
        If GarageElevatorDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                FadeScreen(1)
                Apartment.SetInteriorActive()
                Game.Player.Character.Position = Apartment.ApartmentInPos
                Clear()
                FadeScreen(0)
            End If
        End If

        'Exit Garage
        If GarageDoorLeftDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                FadeScreen(1)
                If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                    Apartment.Building.PlayExitGarageCamera(10000, True, True, CameraShake.Hand, 0.4F)
                Else
                    Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                    Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                    FadeScreen(0)
                End If
                Clear()
            End If
        End If
        If GarageDoorRightDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                FadeScreen(1)
                If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                    Apartment.Building.PlayExitGarageCamera(10000, True, True, CameraShake.Hand, 0.4F)
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
                    Game.Player.Character.Position = bd.GarageDoorPos.ToVector3
                    newVeh = curVeh.CloneVehicle(bd.GarageDoorPos.ToVector3, bd.GarageDoorPos.W, False)
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
                    newVeh.Position = bd.GarageDoorPos.ToVector3
                Else
                    newVeh.Position = bd.GarageOutPos.ToVector3
                End If
                newVeh.SetPlayerIntoVehicle
                newVeh.EngineRunning = True
                Clear()
                FadeScreen(0)
                Apartment.Building.PlayExitGarageCamera(5000, True, True, CameraShake.Hand, 0.4F)
            End If
        End If

        'Draw marker
        If MenuDistance() <= 300.0F Then MenuActivator.DrawMarker
    End Sub

    Public Function MenuDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(MenuActivator)
    End Function

    Public Sub Clear()
        If Vehicle0 <> Nothing Then Vehicle0.Delete()
        If Vehicle1 <> Nothing Then Vehicle1.Delete()
        If Vehicle2 <> Nothing Then Vehicle2.Delete()
        If Vehicle3 <> Nothing Then Vehicle3.Delete()
        If Vehicle4 <> Nothing Then Vehicle4.Delete()
        If Vehicle5 <> Nothing Then Vehicle5.Delete()
        If Vehicle6 <> Nothing Then Vehicle6.Delete()
        If Vehicle7 <> Nothing Then Vehicle7.Delete()
        If Vehicle8 <> Nothing Then Vehicle8.Delete()
        If Vehicle9 <> Nothing Then Vehicle9.Delete()
    End Sub

End Module
