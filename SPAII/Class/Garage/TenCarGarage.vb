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

    'Coords
    Public Interior As New Vector3(222.592, -968.1, -99)
    Public Elevator As New Vector3(238.7097, -1004.8488, -98.9999)
    Public GarageDoorL As New Vector3(231.9013, -1006.686, -98.9999)
    Public GarageDoorR As New Vector3(224.4288, -1006.6892, -98.9999)
    Public MenuActivator As New Vector3(226.5738, -975.5375, -99.9999)
    Public Veh0Pos As New Quaternion(223.4, -1001, -99.0, 241.3)
    Public Veh1Pos As New Quaternion(223.4, -996, -99.0, 241.3)
    Public Veh2Pos As New Quaternion(223.4, -991, -99.0, 241.3)
    Public Veh3Pos As New Quaternion(223.4, -986, -99.0, 241.3)
    Public Veh4Pos As New Quaternion(223.4, -981, -99.0, 241.3)
    Public Veh5Pos As New Quaternion(232.7, -1001, -99.0, 116.3)
    Public Veh6Pos As New Quaternion(232.7, -996, -99.0, 116.3)
    Public Veh7Pos As New Quaternion(232.7, -991, -99.0, 116.3)
    Public Veh8Pos As New Quaternion(232.7, -986, -99.0, 116.3)
    Public Veh9Pos As New Quaternion(232.7, -981, -99.0, 116.3)

    Public Sub LoadVehicles()
        Try
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

            For i As Integer = 0 To Apartment.Vehicles.Count - 1
                Dim veh = Apartment.Vehicles(i)
                Dim spawned = outVehicleList.Where(Function(x) x.GetInt(vehIdDecor) = Apartment.ID AndAlso x.GetInt(vehUidDecor) = veh.UniqueID)
                Select Case i
                    Case 0
                        If spawned.Count <> 0 Then Vehicle0 = CreateGarageVehicle(veh, Veh0Pos, Apartment.ID)
                    Case 1
                        If spawned.Count <> 0 Then Vehicle1 = CreateGarageVehicle(veh, Veh1Pos, Apartment.ID)
                    Case 2
                        If spawned.Count <> 0 Then Vehicle2 = CreateGarageVehicle(veh, Veh2Pos, Apartment.ID)
                    Case 3
                        If spawned.Count <> 0 Then Vehicle3 = CreateGarageVehicle(veh, Veh3Pos, Apartment.ID)
                    Case 4
                        If spawned.Count <> 0 Then Vehicle4 = CreateGarageVehicle(veh, Veh4Pos, Apartment.ID)
                    Case 5
                        If spawned.Count <> 0 Then Vehicle5 = CreateGarageVehicle(veh, Veh5Pos, Apartment.ID)
                    Case 6
                        If spawned.Count <> 0 Then Vehicle6 = CreateGarageVehicle(veh, Veh6Pos, Apartment.ID)
                    Case 7
                        If spawned.Count <> 0 Then Vehicle7 = CreateGarageVehicle(veh, Veh7Pos, Apartment.ID)
                    Case 8
                        If spawned.Count <> 0 Then Vehicle8 = CreateGarageVehicle(veh, Veh8Pos, Apartment.ID)
                    Case 9
                        If spawned.Count <> 0 Then Vehicle9 = CreateGarageVehicle(veh, Veh9Pos, Apartment.ID)
                End Select
            Next i
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub LoadVehiclesSetPlayerPos(uid As Integer)
        Try
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

            For i As Integer = 0 To Apartment.Vehicles.Count - 1
                Dim veh = Apartment.Vehicles(i)
                Dim spawned = outVehicleList.Where(Function(x) x.GetInt(vehIdDecor) = Apartment.ID AndAlso x.GetInt(vehUidDecor) = veh.UniqueID)
                Select Case i
                    Case 0
                        If spawned.Count <> 0 Then Vehicle0 = CreateGarageVehicle(veh, Veh0Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle0, VehicleSeat.Driver)
                    Case 1
                        If spawned.Count <> 0 Then Vehicle1 = CreateGarageVehicle(veh, Veh1Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle1, VehicleSeat.Driver)
                    Case 2
                        If spawned.Count <> 0 Then Vehicle2 = CreateGarageVehicle(veh, Veh2Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle2, VehicleSeat.Driver)
                    Case 3
                        If spawned.Count <> 0 Then Vehicle3 = CreateGarageVehicle(veh, Veh3Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle3, VehicleSeat.Driver)
                    Case 4
                        If spawned.Count <> 0 Then Vehicle4 = CreateGarageVehicle(veh, Veh4Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle4, VehicleSeat.Driver)
                    Case 5
                        If spawned.Count <> 0 Then Vehicle5 = CreateGarageVehicle(veh, Veh5Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle5, VehicleSeat.Driver)
                    Case 6
                        If spawned.Count <> 0 Then Vehicle6 = CreateGarageVehicle(veh, Veh6Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle6, VehicleSeat.Driver)
                    Case 7
                        If spawned.Count <> 0 Then Vehicle7 = CreateGarageVehicle(veh, Veh7Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle7, VehicleSeat.Driver)
                    Case 8
                        If spawned.Count <> 0 Then Vehicle8 = CreateGarageVehicle(veh, Veh8Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle8, VehicleSeat.Driver)
                    Case 9
                        If spawned.Count <> 0 Then Vehicle9 = CreateGarageVehicle(veh, Veh9Pos, Apartment.ID)
                        If veh.UniqueID = uid Then PP.Task.WarpIntoVehicle(Vehicle9, VehicleSeat.Driver)
                End Select
            Next i
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Function GarageElevatorDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(Elevator)
    End Function

    Public Function GarageDoorLeftDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(TenCarGarage.GarageDoorL)
    End Function

    Public Function GarageDoorRightDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(TenCarGarage.GarageDoorR)
    End Function

    Public Sub TenCarGarageOnTick()
        'Enter Apartment from Garage Elevator
        If GarageElevatorDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("MP_PROP_BUZZ1"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                PP.Position = Apartment.ApartmentInPos
            End If
        End If

        'Exit Garage
        If GarageDoorLeftDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                PP.Position = Apartment.Building.GarageOutPos.ToVector3
                PP.Heading = Apartment.Building.GarageOutPos.W
            End If
        End If
        If GarageDoorRightDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                PP.Position = Apartment.Building.GarageOutPos.ToVector3
                PP.Heading = Apartment.Building.GarageOutPos.W
            End If
        End If
    End Sub

End Module
