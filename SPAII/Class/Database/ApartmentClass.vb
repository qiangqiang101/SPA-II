﻿Imports System.Drawing
Imports System.IO
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM
Imports NFunc = GTA.Native.Function

Public Class ApartmentClass

    Public ID As Integer
    Public Name As String
    Public Description As String
    Public Price As Integer
    Public Door As Door
    Public SavePos As Vector3
    ''' <summary>
    ''' a.k.a TeleportInside in SPA
    ''' </summary>
    Public ApartmentInPos As Vector3
    Public ApartmentDoorPos As Quaternion
    ''' <summary>
    ''' a.k.a ApartmentExit in SPA
    ''' </summary>
    Public ApartmentOutPos As Vector3
    Public WardrobePos As Quaternion
    Public GarageFilePath As String
    Public OldIPL, IPL As String
    Public EnterCam As CameraPRH
    Public ExitCam As CameraPRH
    Public AptStyleCam As CameraPRH
    Public ApartmentType As eApartmentType
    Public GarageElevatorPos As Vector3
    Public GarageMenuPos As Vector3

    Public WithEvents AptMenu As UIMenu
    Public WithEvents StyleMenu As UIMenu

    Public Function Owner() As eOwner
        Return config.GetValue(Of eOwner)("BUILDING", Name, eOwner.Nobody)
    End Function

    Public Function Building() As BuildingClass
        Return (From b In buildings
                From a In b.Apartments Where a.ID = ID Select b).FirstOrDefault
    End Function

    Public Function FriendlyName() As String
        Return Game.GetGXTEntry(Name)
    End Function

    Public Function FriendlyDescription() As String
        Return Game.GetGXTEntry(Description)
    End Function

    Public Function InteriorPos() As Vector3
        Return WardrobePos.ToVector3
    End Function

    Public Function ShareInterior() As Boolean
        Select Case ApartmentType
            Case eApartmentType.LowEnd, eApartmentType.MediumEnd
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function InteriorID() As Integer
        Return NFunc.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, InteriorPos.X, InteriorPos.Y, InteriorPos.Z)
    End Function

    Public Function Vehicles() As List(Of VehicleClass)
        Dim procFile As String = Nothing
        Dim list As New List(Of VehicleClass)
        Try
            For Each file As String In Directory.GetFiles($"{grgXmlPath}{GarageFilePath}", "*.xml")
                procFile = file
                Dim vd As VehicleData = New VehicleData(file).Instance
                Dim v As VehicleClass = New VehicleClass(vd, Owner)
                If Not list.Contains(v) Then list.Add(v)
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message}{procFile}{ex.StackTrace}")
        End Try
        Return list
    End Function

    Public Function VehiclesContain(veh As Vehicle) As Boolean
        Dim got As Boolean = False
        For Each vc In Vehicles()
            If veh.GetInt(vehIdDecor) = vc.ApartmentID AndAlso veh.GetInt(vehUidDecor) = vc.UniqueID Then got = True
        Next
        Return got
    End Function

    Public Sub New()

    End Sub

    Public Function WardrobeDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(WardrobePos.ToVector3)
    End Function

    Public Function SaveDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(SavePos)
    End Function

    Public Function ExitDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(ApartmentOutPos)
    End Function

    Public Sub Load()
        Dim aptStyle As New UIMenuItem(Game.GetGXTEntry("PM_APT_TVARIANT")) With {.Tag = "Style"}
        AptMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2A"), New Point(0, -107))
        AptMenu.SetBannerType(MenuBanner)
        AptMenu.MouseEdgeEnabled = False
        MenuPool.Add(AptMenu)
        With AptMenu
            .AddItem(New UIMenuItem(Game.GetGXTEntry("MP_PROP_MENU2D")) With {.Tag = "Exit"}) 'Exit Apartment
            .AddItem(New UIMenuItem(Game.GetGXTEntry("MP_PROP_GOGAR")) With {.Tag = "Garage"}) 'Enter Garage
            If ApartmentType = eApartmentType.IPL Then .AddItem(aptStyle) 'Apartment Style
            .RefreshIndex()
        End With

        If Not Directory.Exists($"{grgXmlPath}{GarageFilePath}") Then Directory.CreateDirectory($"{grgXmlPath}{GarageFilePath}")

        If ApartmentType = eApartmentType.IPL Then
            StyleMenu = New UIMenu("", Game.GetGXTEntry("PM_APT_VARCAPS"), New Point(0, -107))
            StyleMenu.SetBannerType(MenuBanner)
            StyleMenu.MouseEdgeEnabled = False
            MenuPool.Add(StyleMenu)
            With StyleMenu
                Dim modern As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_0"))
                With modern
                    .Tag = "Modern"
                    .SetRightBadge(If(IPL.Contains("01"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(modern)
                Dim moody As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_1"))
                With moody
                    .Tag = "Moody"
                    .SetRightBadge(If(IPL.Contains("02"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(moody)
                Dim vibrant As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_2"))
                With vibrant
                    .Tag = "Vibrant"
                    .SetRightBadge(If(IPL.Contains("03"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(vibrant)
                Dim sharp As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_3"))
                With sharp
                    .Tag = "Sharp"
                    .SetRightBadge(If(IPL.Contains("04"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(sharp)
                Dim monochrome As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_4"))
                With monochrome
                    .Tag = "Monochrome"
                    .SetRightBadge(If(IPL.Contains("05"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(monochrome)
                Dim seductive As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_5"))
                With seductive
                    .Tag = "Seductive"
                    .SetRightBadge(If(IPL.Contains("06"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(seductive)
                Dim regal As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_6"))
                With regal
                    .Tag = "Regal"
                    .SetRightBadge(If(IPL.Contains("07"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(regal)
                Dim aqua As New UIMenuItem(Game.GetGXTEntry("PM_APT_VAR_7"))
                With aqua
                    .Tag = "Aqua"
                    .SetRightBadge(If(IPL.Contains("08"), UIMenuItem.BadgeStyle.Tick, UIMenuItem.BadgeStyle.None))
                End With
                .AddItem(aqua)
                .RefreshIndex()
            End With
            AptMenu.BindMenuToItem(StyleMenu, aptStyle)
        End If
    End Sub

    Public Sub SetInteriorActive()
        Try
            Dim intID As Integer = NFunc.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, InteriorPos.X, InteriorPos.Y, InteriorPos.Z)
            NFunc.Call(PIN_INTERIOR_IN_MEMORY, New InputArgument() {intID})
            NFunc.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
            NFunc.Call(Hash.DISABLE_INTERIOR, intID, False)

            If ApartmentType = eApartmentType.IPL Or ApartmentType = eApartmentType.IPLwoStyle Then
                NFunc.Call(Hash.REQUEST_IPL, IPL)
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub AptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles AptMenu.OnItemSelect
        Try
            Select Case selectedItem.Tag
                Case "Exit"
                    AptMenu.Visible = False
                    HideHud = True
                    PlayApartmerntExitCutscene()
                    Building.PlayExitApartmentCamera(3000, True, True, CameraShake.Hand, 0.4F)
                    HideHud = False
                    Select Case ApartmentType
                        Case eApartmentType.LowEnd
                            LowEndApartment.Apartment = Nothing
                        Case eApartmentType.MediumEnd
                            MediumEndApartment.Apartment = Nothing
                        Case eApartmentType.IPL, eApartmentType.IPLwoStyle, eApartmentType.None
                            HighEndApartment.Building = Nothing
                    End Select
                Case "Garage"
                    AptMenu.Visible = False
                    HideHud = True
                    PlayApartmerntExitCutscene()
                    Select Case Building.GarageType
                        Case eGarageType.TwoCarGarage
                            TwoCarGarage.Apartment = Me
                            TwoCarGarage.Interior.SetInteriorActive
                            TwoCarGarage.LoadVehicles()
                        Case eGarageType.SixCarGarage
                            SixCarGarage.Apartment = Me
                            SixCarGarage.Interior.SetInteriorActive
                            SixCarGarage.LoadVehicles()
                        Case eGarageType.TenCarGarage
                            TenCarGarage.Apartment = Me
                            TenCarGarage.Interior.SetInteriorActive()
                            TenCarGarage.LoadVehicles()
                        Case eGarageType.TwentyCarGarage

                    End Select
                    Building.PlayExitElevatorCutscene(5000)
                    HideHud = False
                    World.RenderingCamera = Nothing
                    World.DestroyAllCameras()
                    Select Case ApartmentType
                        Case eApartmentType.LowEnd
                            LowEndApartment.Apartment = Nothing
                        Case eApartmentType.MediumEnd
                            MediumEndApartment.Apartment = Nothing
                        Case eApartmentType.None, eApartmentType.IPL, eApartmentType.IPLwoStyle
                            HighEndApartment.Building = Nothing
                    End Select
                Case "Style"
                    FadeScreen(1)
                    HideHud = True
                    World.RenderingCamera = World.CreateCamera(AptStyleCam.Position, AptStyleCam.Rotation, AptStyleCam.FOV)
                    FadeScreen(0)
            End Select
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub StyleMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles StyleMenu.OnItemSelect
        Try
            Dim oldIPL As String = config.GetValue("IPL", Name, "apa_v_mp_h_01_a")

            Select Case selectedItem.Tag
                Case "Modern"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_01_a"
                        Case 80
                            IPL = "apa_v_mp_h_01_b"
                        Case 81
                            IPL = "apa_v_mp_h_01_c"
                    End Select
                Case "Moody"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_02_a"
                        Case 80
                            IPL = "apa_v_mp_h_02_b"
                        Case 81
                            IPL = "apa_v_mp_h_02_c"
                    End Select
                Case "Vibrant"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_03_a"
                        Case 80
                            IPL = "apa_v_mp_h_03_b"
                        Case 81
                            IPL = "apa_v_mp_h_03_c"
                    End Select
                Case "Sharp"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_04_a"
                        Case 80
                            IPL = "apa_v_mp_h_04_b"
                        Case 81
                            IPL = "apa_v_mp_h_04_c"
                    End Select
                Case "Monochrome"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_05_a"
                        Case 80
                            IPL = "apa_v_mp_h_05_b"
                        Case 81
                            IPL = "apa_v_mp_h_05_c"
                    End Select
                Case "Seductive"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_06_a"
                        Case 80
                            IPL = "apa_v_mp_h_06_b"
                        Case 81
                            IPL = "apa_v_mp_h_06_c"
                    End Select
                Case "Regal"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_07_a"
                        Case 80
                            IPL = "apa_v_mp_h_07_b"
                        Case 81
                            IPL = "apa_v_mp_h_07_c"
                    End Select
                Case "Aqua"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_08_a"
                        Case 80
                            IPL = "apa_v_mp_h_08_b"
                        Case 81
                            IPL = "apa_v_mp_h_08_c"
                    End Select
            End Select

            ChangeIPL(oldIPL, IPL)
            config.SetValue("IPL", Name, IPL)
            config.Save()

            For Each item In sender.MenuItems
                item.SetRightBadge(UIMenuItem.BadgeStyle.None)
            Next
            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub StyleMenu_OnIndexChange(sender As UIMenu, newIndex As Integer) Handles StyleMenu.OnIndexChange
        Try
            FadeScreen(1)
            OldIPL = IPL

            Dim selectedItem As UIMenuItem = sender.MenuItems(newIndex)
            Select Case selectedItem.Tag
                Case "Modern"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_01_a"
                        Case 80
                            IPL = "apa_v_mp_h_01_b"
                        Case 81
                            IPL = "apa_v_mp_h_01_c"
                    End Select
                Case "Moody"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_02_a"
                        Case 80
                            IPL = "apa_v_mp_h_02_b"
                        Case 81
                            IPL = "apa_v_mp_h_02_c"
                    End Select
                Case "Vibrant"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_03_a"
                        Case 80
                            IPL = "apa_v_mp_h_03_b"
                        Case 81
                            IPL = "apa_v_mp_h_03_c"
                    End Select
                Case "Sharp"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_04_a"
                        Case 80
                            IPL = "apa_v_mp_h_04_b"
                        Case 81
                            IPL = "apa_v_mp_h_04_c"
                    End Select
                Case "Monochrome"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_05_a"
                        Case 80
                            IPL = "apa_v_mp_h_05_b"
                        Case 81
                            IPL = "apa_v_mp_h_05_c"
                    End Select
                Case "Seductive"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_06_a"
                        Case 80
                            IPL = "apa_v_mp_h_06_b"
                        Case 81
                            IPL = "apa_v_mp_h_06_c"
                    End Select
                Case "Regal"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_07_a"
                        Case 80
                            IPL = "apa_v_mp_h_07_b"
                        Case 81
                            IPL = "apa_v_mp_h_07_c"
                    End Select
                Case "Aqua"
                    Select Case ID
                        Case 79
                            IPL = "apa_v_mp_h_08_a"
                        Case 80
                            IPL = "apa_v_mp_h_08_b"
                        Case 81
                            IPL = "apa_v_mp_h_08_c"
                    End Select
            End Select

            ChangeIPL(OldIPL, IPL)
            FadeScreen(0)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub StyleMenu_OnMenuClose(sender As UIMenu) Handles StyleMenu.OnMenuClose
        FadeScreen(1)
        ChangeIPL(IPL, config.GetValue("IPL", Name, "apa_v_mp_h_01_a"))
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        HideHud = False
        FadeScreen(0)
    End Sub

    Public Sub PlayApartmentEnterCutscene()
        Try
            HideHud = True
            Door.UnlockDoor()
            World.RenderingCamera = World.CreateCamera(EnterCam.Position, EnterCam.Rotation, EnterCam.FOV)
            Game.Player.Character.Position = ApartmentDoorPos.ToVector3
            Game.Player.Character.Heading = ApartmentDoorPos.W
            Game.Player.Character.Task.GoTo(ApartmentInPos, True, 6000)
            Script.Wait(6000)
            Door.LockDoor()
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub PlayApartmerntExitCutscene()
        Try
            Door.UnlockDoor()
            World.RenderingCamera = World.CreateCamera(ExitCam.Position, ExitCam.Rotation, ExitCam.FOV)
            Game.Player.Character.Position = ApartmentInPos
            Game.Player.Character.Heading = ApartmentDoorPos.W - 180.0F
            Game.Player.Character.Task.GoTo(ApartmentDoorPos.ToVector3, True, 3500)
            Script.Wait(3500)
            Door.LockDoor()
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub
End Class

Public Enum eApartmentType
    None
    MediumEnd
    LowEnd
    IPL
    Other
    IPLwoStyle
End Enum

Public Enum eOwner
    Nobody = -1
    Michael
    Franklin
    Trevor
    Others
End Enum