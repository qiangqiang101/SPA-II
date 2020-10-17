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

    Public Function GarageDoorRightDistance() As Single
        Return GarageDoorLeftDistance()
    End Function

    Public Sub TwoCarGarageOnTick()
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
                Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                Clear()
                FadeScreen(0)
            End If
        End If
        If GarageDoorRightDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                FadeScreen(1)
                Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                Clear()
                FadeScreen(0)
            End If
        End If

        'Exit Garage with vehicle
        If Game.Player.Character.IsInVehicle Then
            If Vehicles.Contains(Game.Player.Character.CurrentVehicle) AndAlso Game.Player.Character.CurrentVehicle.Speed >= 0.5 Then
                FadeScreen(1)
                Dim curVeh As Vehicle = Vehicles.Find(Function(x) x.GetInt(vehUidDecor) = Game.Player.Character.CurrentVehicle.GetInt(vehUidDecor) AndAlso x.GetInt(vehIdDecor) = Apartment.ID)
                Dim bd = Apartment.Building
                Game.Player.Character.Position = bd.GarageOutPos.ToVector3
                Dim newVeh As Vehicle = curVeh.CloneVehicle(bd.GarageOutPos.ToVector3, bd.GarageOutPos.W, False)
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
                newVeh.Position = bd.GarageOutPos.ToVector3
                newVeh.SetPlayerIntoVehicle
                newVeh.EngineRunning = True
                Clear()
                FadeScreen(0)
            End If
        End If

        'Draw marker
        World.DrawMarker(MarkerType.VerticalCylinder, MenuActivator, Vector3.Zero, Vector3.Zero, New Vector3(0.8F, 0.8F, 0.4F), Color.FromArgb(150, Color.DeepSkyBlue))
    End Sub

    Public Sub Clear()
        If Vehicle0 <> Nothing Then Vehicle0.Delete()
        If Vehicle1 <> Nothing Then Vehicle1.Delete()
    End Sub

End Module
