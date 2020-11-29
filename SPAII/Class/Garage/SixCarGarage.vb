Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Math
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM

Module SixCarGarage

    Public Apartment As ApartmentClass = Nothing
    Public WithEvents MgmtMenu, MgmtOptMenu, MgmtMoveMenu As UIMenu
    Public Camera As Camera
    Public MgmtSelVeh As VehClassMenuItem = Nothing

    'Vehicle
    Public Vehicle0 As Vehicle
    Public Vehicle1 As Vehicle
    Public Vehicle2 As Vehicle
    Public Vehicle3 As Vehicle
    Public Vehicle4 As Vehicle
    Public Vehicle5 As Vehicle
    Public Vehicles As New List(Of Vehicle)

    'Coords
    Public Interior As New Vector3(193.9493, -1004.425, -99.99999)
    Public Elevator As New Vector3(207.1506, -998.9948, -99.9999)
    Public ElevatorInside As New Quaternion(209.4215F, -999.0895F, -100.0F, 90.90394F)
    Public SpawnInPos As New Quaternion(198.3316F, -1007.227F, -99.99992F, 21.38214F)
    Public GarageDoorL As New Vector3(202.2906, -1007.7249, -99.9999)
    Public GarageDoorR As New Vector3(194.4465, -1007.7326, -99.9999)
    Public MenuActivator As New Vector3(204.1768, -995.3179, -99.9999)
    Public Veh0Pos As New Quaternion(197.5, -1004.425, -99.99999, -4.035995)
    Public Veh1Pos As New Quaternion(201.06, -1004.425, -99.99999, -4.035995)
    Public Veh2Pos As New Quaternion(204.62, -1004.425, -99.99999, -4.035995)
    Public Veh3Pos As New Quaternion(192.9262, -996.3292, -99.99999, 146.2832)
    Public Veh4Pos As New Quaternion(197.5, -996.3292, -99.99999, 146.2832)
    Public Veh5Pos As New Quaternion(203.9257, -999.1467, -99.99999, 146.2832)
    Public MenuCam As New CameraPRH(New Vector3(205.5775F, -1006.326F, -97.99998F), New Vector3(-13.71649F, 0F, 48.66722F), 50.0F)

    Public Sub LoadGarageMenu()
        MgmtMenu = New UIMenu("", Game.GetGXTEntry("MP_MAN_VEH0").ToUpper, New Point(0, -107))
        With MgmtMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            MenuPool.Add(MgmtMenu)
            .RefreshIndex()
        End With

        MgmtOptMenu = New UIMenu("", Game.GetGXTEntry("MP_MAN_VEH0").ToUpper, New Point(0, -107))
        With MgmtOptMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            MenuPool.Add(MgmtOptMenu)
            .RefreshIndex()
        End With

        MgmtMoveMenu = New UIMenu("", Game.GetGXTEntry("MP_MAN_VEH0").ToUpper, New Point(0, -107))
        With MgmtMoveMenu
            .SetBannerType(MenuBanner)
            .MouseEdgeEnabled = False
            MenuPool.Add(MgmtMoveMenu)
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshOptMenu()
        MgmtOptMenu.MenuItems.Clear()

        With MgmtOptMenu
            Dim move As New UIMenuItem(Game.GetGXTEntry("MP_MAN_VEH2")) With {.Tag = "Move"}
            .AddItem(move)
            MgmtMenu.BindMenuToItem(MgmtOptMenu, move)
            Dim remove As New UIMenuItem(Game.GetGXTEntry("ITEM_REM")) With {.Tag = "Remove"}
            .AddItem(remove)
            MgmtMenu.BindMenuToItem(MgmtOptMenu, remove)
            Dim plate As New UIMenuItem(Game.GetGXTEntry("CMOD_MOD_PLA")) With {.Tag = "Plate"}
            .AddItem(plate) 'Change Plate
            MgmtMenu.BindMenuToItem(MgmtOptMenu, plate)
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshMgmtMenu(Optional itemDesc As String = "MP_MAN_VEH3")
        MgmtMenu.MenuItems.Clear()

        With MgmtMenu
            Dim veh1 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 0)
            Dim item1 As New UIMenuItem(If(veh1 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh1.Make} {veh1.Name} ({veh1.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(0, veh1), .Enabled = If(veh1 Is Nothing, False, True)}
            .AddItem(item1)
            Dim veh2 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 1)
            Dim item2 As New UIMenuItem(If(veh2 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh2.Make} {veh2.Name} ({veh2.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(1, veh2), .Enabled = If(veh2 Is Nothing, False, True)}
            .AddItem(item2)
            Dim veh3 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 2)
            Dim item3 As New UIMenuItem(If(veh3 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh3.Make} {veh3.Name} ({veh3.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(2, veh3), .Enabled = If(veh3 Is Nothing, False, True)}
            .AddItem(item3)
            Dim veh4 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 3)
            Dim item4 As New UIMenuItem(If(veh4 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh4.Make} {veh4.Name} ({veh4.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(3, veh4), .Enabled = If(veh4 Is Nothing, False, True)}
            .AddItem(item4)
            Dim veh5 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 4)
            Dim item5 As New UIMenuItem(If(veh5 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh5.Make} {veh5.Name} ({veh5.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(4, veh5), .Enabled = If(veh5 Is Nothing, False, True)}
            .AddItem(item5)
            Dim veh6 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 5)
            Dim item6 As New UIMenuItem(If(veh6 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh6.Make} {veh6.Name} ({veh6.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(5, veh6), .Enabled = If(veh6 Is Nothing, False, True)}
            .AddItem(item6)
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshMoveMenu(Optional itemDesc As String = "MP_MAN_VEH3")
        MgmtMoveMenu.MenuItems.Clear()

        With MgmtMoveMenu
            Dim veh1 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 0)
            Dim item1 As New UIMenuItem(If(veh1 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh1.Make} {veh1.Name} ({veh1.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(0, If(veh1 Is Nothing, Nothing, veh1))}
            .AddItem(item1)
            MgmtOptMenu.BindMenuToItem(MgmtMoveMenu, item1)
            Dim veh2 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 1)
            Dim item2 As New UIMenuItem(If(veh2 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh2.Make} {veh2.Name} ({veh2.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(1, If(veh2 Is Nothing, Nothing, veh2))}
            .AddItem(item2)
            MgmtOptMenu.BindMenuToItem(MgmtMoveMenu, item2)
            Dim veh3 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 2)
            Dim item3 As New UIMenuItem(If(veh3 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh3.Make} {veh3.Name} ({veh3.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(2, If(veh3 Is Nothing, Nothing, veh3))}
            .AddItem(item3)
            MgmtOptMenu.BindMenuToItem(MgmtMoveMenu, item3)
            Dim veh4 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 3)
            Dim item4 As New UIMenuItem(If(veh4 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh4.Make} {veh4.Name} ({veh4.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(3, If(veh4 Is Nothing, Nothing, veh4))}
            .AddItem(item4)
            MgmtOptMenu.BindMenuToItem(MgmtMoveMenu, item4)
            Dim veh5 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 4)
            Dim item5 As New UIMenuItem(If(veh5 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh5.Make} {veh5.Name} ({veh5.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(4, If(veh5 Is Nothing, Nothing, veh5))}
            .AddItem(item5)
            MgmtOptMenu.BindMenuToItem(MgmtMoveMenu, item5)
            Dim veh6 As VehicleClass = Apartment.Vehicles.Find(Function(x) x.Index = 5)
            Dim item6 As New UIMenuItem(If(veh6 Is Nothing, Game.GetGXTEntry("MP_MAN_VEH_S"), $"{veh6.Make} {veh6.Name} ({veh6.PlateNumber})"), Game.GetGXTEntry(itemDesc)) With {.Tag = New VehClassMenuItem(5, If(veh6 Is Nothing, Nothing, veh6))}
            .AddItem(item6)
            MgmtOptMenu.BindMenuToItem(MgmtMoveMenu, item6)
            .RefreshIndex()
        End With
    End Sub

    Public Sub LoadVehicles()
        Try
            Vehicles.Clear()
            If Vehicle0 <> Nothing Then Vehicle0.Delete()
            If Vehicle1 <> Nothing Then Vehicle1.Delete()
            If Vehicle2 <> Nothing Then Vehicle2.Delete()
            If Vehicle3 <> Nothing Then Vehicle3.Delete()
            If Vehicle4 <> Nothing Then Vehicle4.Delete()
            If Vehicle5 <> Nothing Then Vehicle5.Delete()

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
                    End Select
                End If
            Next

            'SixCarGarage Only
            TurnOffRadio("SE_MP_GARAGE_M_RADIO")
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

    Public Function MenuDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(MenuActivator)
    End Function

    Public Sub SixCarGarageOnTick()
        If PI = SixCarGarage.Interior.GetInterior Then
            If Vehicles.Count <> 0 Then
                If Game.IsControlPressed(0, Control.MultiplayerInfo) Then
                    If Vehicle0 <> Nothing Then StatScaleform0.DrawMPCarStats(Vehicle0)
                    If Vehicle1 <> Nothing Then StatScaleform1.DrawMPCarStats(Vehicle1)
                    If Vehicle2 <> Nothing Then StatScaleform2.DrawMPCarStats(Vehicle2)
                    If Vehicle3 <> Nothing Then StatScaleform3.DrawMPCarStats(Vehicle3)
                    If Vehicle4 <> Nothing Then StatScaleform4.DrawMPCarStats(Vehicle4)
                    If Vehicle5 <> Nothing Then StatScaleform5.DrawMPCarStats(Vehicle5)
                End If
            End If

            'Vehicle Management
            If MenuDistance() <= 2.0F Then
                If Not MenuPool.IsAnyMenuOpen Then
                    UI.ShowHelpMessage(Game.GetGXTEntry("MP_MAN_VEH"))
                    If Game.IsControlJustReleased(0, Control.Context) Then
                        RefreshMgmtMenu()
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
                    Audio.PlaySoundAt(PP, "GARAGE_DOOR_SCRIPTED_CLOSE")
                    Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                    Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                    Script.Wait(1000)
                    FadeScreen(0)
                End If
                Clear()
                Apartment = Nothing
            End If
            If GarageDoorRightDistance() <= 2.0F Then
                FadeScreen(1)
                If Apartment.Building.GarageDoor = eFrontDoor.StandardDoor Then
                    Apartment.Building.PlayExitGarageCamera(5000, True, True, CameraShake.Hand, 0.4F)
                Else
                    Audio.PlaySoundAt(PP, "GARAGE_DOOR_SCRIPTED_CLOSE")
                    Game.Player.Character.Position = Apartment.Building.GarageOutPos.ToVector3
                    Game.Player.Character.Heading = Apartment.Building.GarageOutPos.W
                    Script.Wait(1000)
                    FadeScreen(0)
                End If
                Clear()
                Apartment = Nothing
            End If

            'Exit Garage with vehicle
            If Game.Player.Character.IsInVehicle Then
                If Vehicles.Contains(Game.Player.Character.CurrentVehicle) AndAlso Game.Player.Character.CurrentVehicle.Speed >= 0.5 Then
                    FadeScreen(1)

                    Audio.PlaySoundAt(PP, "GARAGE_DOOR_SCRIPTED_CLOSE")
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
                        .CurrentBlip.Sprite = newVeh.Model.GetProperBlipSprite
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
                    Script.Wait(1000)
                    If Apartment.Building.GarageDoor = eFrontDoor.NoDoor Then FadeScreen(0)
                    Apartment.Building.PlayExitGarageCamera(7000, True, True, CameraShake.Hand, 0.4F)
                    Apartment = Nothing
                End If
            End If

            'Draw marker
            If MenuDistance() <= 200.0F AndAlso Not Apartment Is Nothing Then MenuActivator.DrawMarker
            If MgmtMenu.Visible Or MgmtOptMenu.Visible Or MgmtMoveMenu.Visible Then GarageMarkerIndicator.DrawMgmtMarker
        End If
    End Sub

    Private Sub MgmtMenu_OnIndexChange(sender As UIMenu, Index As Integer) Handles MgmtMenu.OnIndexChange, MgmtMoveMenu.OnIndexChange
        Dim selectedItem As UIMenuItem = sender.MenuItems(Index)
        Dim selectedVeh As VehClassMenuItem = selectedItem.Tag

        Select Case selectedVeh.Index
            Case 0
                GarageMarkerIndicator = Veh0Pos.ToVector3
            Case 1
                GarageMarkerIndicator = Veh1Pos.ToVector3
            Case 2
                GarageMarkerIndicator = Veh2Pos.ToVector3
            Case 3
                GarageMarkerIndicator = Veh3Pos.ToVector3
            Case 4
                GarageMarkerIndicator = Veh4Pos.ToVector3
            Case 5
                GarageMarkerIndicator = Veh5Pos.ToVector3
        End Select

        Camera.PointAt(GarageMarkerIndicator)
    End Sub

    Private Sub MgmtMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MgmtMenu.OnItemSelect
        MgmtSelVeh = selectedItem.Tag
        RefreshOptMenu()
        MgmtOptMenu.Visible = True
        sender.Visible = False
    End Sub

    Private Sub MgmtMenu_OnMenuClose(sender As UIMenu) Handles MgmtMenu.OnMenuClose
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        HideHud = False
    End Sub

    Private Sub MgmtOptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MgmtOptMenu.OnItemSelect
        If MgmtSelVeh IsNot Nothing Then
            Select Case selectedItem.Tag
                Case "Move"
                    RefreshMoveMenu()
                    MgmtMoveMenu.Visible = True
                    sender.Visible = False
                Case "Remove"
                    Dim ExistingFileToDelete As String = $"{grgXmlPath}{Apartment.GarageFilePath}\{MgmtSelVeh.VehClass.UniqueID}.xml"
                    If File.Exists(ExistingFileToDelete) Then
                        File.Delete(ExistingFileToDelete)
                        LoadVehicles()
                        MgmtSelVeh = Nothing
                        RefreshMgmtMenu()
                        sender.GoBack()
                    End If
                Case "Plate"
                    Dim plateText As String = Game.GetUserInput(WindowTitle.FMMC_KEY_TIP8, MgmtSelVeh.VehClass.PlateNumber, 8)
                    If plateText <> "" Then
                        Dim vc As VehicleClass = MgmtSelVeh.VehClass
                        Dim vd As New VehicleData($"{grgXmlPath}{Apartment.GarageFilePath}\{vc.UniqueID}.xml", vc)
                        vd.PlateNumber = plateText.ToUpper.TruncateString(8)
                        vd.Save()
                        LoadVehicles()
                        MgmtSelVeh = Nothing
                        RefreshMgmtMenu()
                        sender.GoBack()
                    End If
            End Select
        Else
            sender.GoBack()
        End If
    End Sub

    Private Sub MgmtMoveMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MgmtMoveMenu.OnItemSelect
        Try
            If MgmtSelVeh IsNot Nothing Then
                Dim selectedVeh As VehClassMenuItem = selectedItem.Tag
                Dim vehToMove As VehClassMenuItem = MgmtSelVeh

                If selectedVeh.VehClass Is Nothing Then
                    Dim lvc = MgmtSelVeh.VehClass
                    Dim lvd As New VehicleData($"{grgXmlPath}{Apartment.GarageFilePath}\{lvc.UniqueID}.xml", lvc)
                    lvd.Index = selectedVeh.Index
                    lvd.Save()
                Else
                    Dim svc = selectedVeh.VehClass
                    Dim lvc = MgmtSelVeh.VehClass

                    Dim svd As New VehicleData($"{grgXmlPath}{Apartment.GarageFilePath}\{svc.UniqueID}.xml", svc)
                    svd.Index = MgmtSelVeh.VehClass.Index
                    svd.Save()
                    Dim lvd As New VehicleData($"{grgXmlPath}{Apartment.GarageFilePath}\{lvc.UniqueID}.xml", lvc)
                    lvd.Index = selectedVeh.VehClass.Index
                    lvd.Save()
                End If

                LoadVehicles()
                MgmtSelVeh = Nothing
                RefreshMgmtMenu()
                MgmtMenu.Visible = True
                sender.Visible = False
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub Clear()
        If Vehicle0 <> Nothing Then Vehicle0.Delete()
        If Vehicle1 <> Nothing Then Vehicle1.Delete()
        If Vehicle2 <> Nothing Then Vehicle2.Delete()
        If Vehicle3 <> Nothing Then Vehicle3.Delete()
        If Vehicle4 <> Nothing Then Vehicle4.Delete()
        If Vehicle5 <> Nothing Then Vehicle5.Delete()
    End Sub

End Module
