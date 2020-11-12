Imports System.Drawing
Imports System.IO
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI
Imports Metadata
Imports SPAII.INM
Imports NFunc = GTA.Native.Function

Public Class BuildingClass

    Public Name As String
    ''' <summary>
    ''' a.k.a Entrance in SPA
    ''' </summary>
    Public BuildingInPos As Quaternion
    Public BuildingLobby As Quaternion
    ''' <summary>
    ''' a.k.a TeleportOutside in SPA
    ''' </summary>
    Public BuildingOutPos As Quaternion
    Public GarageInPos As Vector3
    Public GarageFootInPos As Quaternion
    Public GarageFootOutPos As Quaternion
    Public GarageOutPos As Quaternion
    Public CameraPos As CameraPRH
    Public EnterCamera1, EnterCamera2, EnterCamera3, EnterCamera4 As CameraPRH
    Public GarageType As eGarageType
    Public BuildingType As eBuildingType
    Public Apartments As List(Of ApartmentClass)
    Public HideObjects() As String
    Public SaleSign As EntityVector
    Public FrontDoor As eFrontDoor
    Public Door1 As Door
    Public Door2 As Door
    Public GarageDoor As eFrontDoor
    Public Door3 As Door
    Public GarageWaypoint As Quaternion

    Public BuildingBlip As Blip
    Public GarageBlip As Blip
    Public SaleSignProp As Prop

    Public WithEvents BuyMenu As UIMenu
    Public WithEvents AptMenu As UIMenu
    Public WithEvents GrgMenu As UIMenu

    Public Sub New()

    End Sub

    Public Function IsVacant() As Boolean
        Dim apt = (From a In Apartments Where a.Owner <> eOwner.Nobody Select a)
        Return apt.Count = 0
    End Function

    Public Sub Load()
        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        BuildingBlip = World.CreateBlip(BuildingInPos.ToVector3)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If IsVacant() Then
                If Not debugMode Then
                    Select Case BuildingType
                        Case eBuildingType.Apartment
                            .Sprite = BlipSprite.SafehouseForSale
                            .Name = Game.GetGXTEntry("MP_PROP_SALE1") 'Apartment For Sale
                        Case eBuildingType.Office
                            .Sprite = BlipSprite.OfficeForSale
                            .Name = Game.GetGXTEntry("MP_PROP_SALE2") 'Office For Sale
                        Case eBuildingType.ClubHouse, eBuildingType.NightClub, eBuildingType.Bunker
                            .Sprite = BlipSprite.BusinessForSale
                            .Name = Game.GetGXTEntry("BLIP_373") 'Property For Sale
                        Case eBuildingType.Garage
                            .Sprite = BlipSprite.GarageForSale
                            .Name = Game.GetGXTEntry("MP_PROP_SALE0") 'Garage For Sale
                        Case eBuildingType.Hangar
                            .Sprite = BlipSprite.HangarForSale
                            .Name = Game.GetGXTEntry("BLIP_372") 'Hangar For Sale
                        Case eBuildingType.Warehouse
                            .Sprite = BlipSprite.WarehouseForSale
                            .Name = Game.GetGXTEntry("BLIP_474") 'Warehouse For Sale
                    End Select
                Else
                    Select Case BuildingType
                        Case eBuildingType.Apartment
                            .Sprite = BlipSprite.Safehouse
                        Case eBuildingType.Office
                            .Sprite = BlipSprite.Office
                        Case eBuildingType.ClubHouse
                            .Sprite = BlipSprite.BikerClubhouse
                        Case eBuildingType.Garage
                            .Sprite = BlipSprite.Garage
                        Case eBuildingType.Hangar
                            .Sprite = BlipSprite.GTAOHangar
                        Case eBuildingType.NightClub
                            .Sprite = BlipSprite.NightclubProperty
                        Case eBuildingType.Warehouse
                            .Sprite = BlipSprite.Warehouse
                        Case eBuildingType.Bunker
                            .Sprite = BlipSprite.Bunker
                    End Select
                    .Name = Name
                End If
            Else
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.Safehouse
                        .Name = Game.GetGXTEntry("CELL_2630")
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.Office
                        .Name = Game.GetGXTEntry("BLIP_475")
                    Case eBuildingType.ClubHouse
                        .Sprite = BlipSprite.BikerClubhouse
                        .Name = Game.GetGXTEntry("PM_SPAWN_CLUBH")
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.Garage
                        .Name = Game.GetGXTEntry("BLIP_357")
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.GTAOHangar
                        .Name = Game.GetGXTEntry("BLIP_359")
                    Case eBuildingType.NightClub
                        .Sprite = BlipSprite.NightclubProperty
                        .Name = Game.GetGXTEntry("CELL_CLUB")
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.Warehouse
                        .Name = Game.GetGXTEntry("BLIP_473")
                    Case eBuildingType.Bunker
                        .Sprite = BlipSprite.Bunker
                        .Name = Game.GetGXTEntry("BLIP_557")
                End Select
            End If
        End With

        If Not IsVacant() AndAlso Not BuildingType = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(GarageInPos)
            With GarageBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = Game.GetGXTEntry("BLIP_357")
            End With
        End If

        BuyMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN0"), New Point(0, -107))
        BuyMenu.SetBannerType(MenuBanner)
        BuyMenu.MouseEdgeEnabled = False
        MenuPool.Add(BuyMenu)
        With BuyMenu
            For Each apt As ApartmentClass In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
                With item
                    Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                        Case eOwner.Nobody 'For Sale
                            .SetRightLabel($"${apt.Price.ToString("0,0")}")
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case eOwner.Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case eOwner.Franklin
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case eOwner.Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case eOwner.Others
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        AptMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2A"), New Point(0, -107))
        AptMenu.SetBannerType(MenuBanner)
        AptMenu.MouseEdgeEnabled = False
        MenuPool.Add(AptMenu)
        With AptMenu
            For Each apt As ApartmentClass In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
                With item
                    Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                        Case eOwner.Nobody 'For Sale
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case eOwner.Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case eOwner.Franklin
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case eOwner.Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case eOwner.Others
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        GrgMenu = New UIMenu("", Game.GetGXTEntry("MP_PROP_GEN2B"), New Point(0, -107))
        GrgMenu.SetBannerType(MenuBanner)
        GrgMenu.MouseEdgeEnabled = False
        MenuPool.Add(GrgMenu)
        With GrgMenu
            For Each apt In Apartments
                Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
                With item
                    Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                        Case eOwner.Nobody 'For Sale
                            .SetRightBadge(UIMenuItem.BadgeStyle.None)
                        Case eOwner.Michael
                            .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                        Case eOwner.Franklin
                            .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                        Case eOwner.Trevor
                            .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                        Case eOwner.Others
                            .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                    End Select
                    .Tag = apt
                End With
                .AddItem(item)
            Next
            .RefreshIndex()
        End With

        For Each apt In Apartments
            apt.Load()
            If Not Helper.apartments.Contains(apt) Then Helper.apartments.Add(apt)
        Next
    End Sub

    Public Sub SpawnForSaleSigns()
        SaleSignProp = World.CreateProp(SaleSign.Model, SaleSign.Position.ToVector3, New Vector3(0F, 0F, SaleSign.Position.W), True, False)
        With SaleSignProp
            .IsPersistent = True
        End With
    End Sub

    Public Sub RefreshBuyMenu()
        BuyMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
            With item
                Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                    Case eOwner.Nobody 'For Sale
                        .SetRightLabel($"${apt.Price.ToString("0,0")}")
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case eOwner.Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case eOwner.Franklin
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case eOwner.Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case eOwner.Others
                        .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                End Select
                .Tag = apt
            End With
            BuyMenu.AddItem(item)
        Next
        BuyMenu.RefreshIndex()
    End Sub

    Public Sub RefreshAptMenu()
        AptMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
            With item
                Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                    Case eOwner.Nobody 'For Sale
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case eOwner.Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case eOwner.Franklin
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case eOwner.Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case eOwner.Others
                        .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                End Select
                .Tag = apt
            End With
            AptMenu.AddItem(item)
        Next
        AptMenu.RefreshIndex()
    End Sub

    Public Sub RefreshGrgMenu()
        GrgMenu.MenuItems.Clear()
        For Each apt In Apartments
            Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name), Game.GetGXTEntry(apt.Description).Truncate)
            With item
                Select Case config.GetValue(Of eOwner)("BUILDING", apt.Name, eOwner.Nobody)
                    Case eOwner.Nobody 'For Sale
                        .SetRightBadge(UIMenuItem.BadgeStyle.None)
                    Case eOwner.Michael
                        .SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                    Case eOwner.Franklin
                        .SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                    Case eOwner.Trevor
                        .SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                    Case eOwner.Others
                        .SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                End Select
                .Tag = apt
            End With
            GrgMenu.AddItem(item)
        Next
        GrgMenu.RefreshIndex()
    End Sub

    Public Function GarageDistance() As Single
        If Game.Player.Character.IsInVehicle Then
            Return Game.Player.Character.CurrentVehicle.Position.DistanceToSquared(GarageInPos)
        Else
            Return Game.Player.Character.Position.DistanceToSquared(GarageFootInPos.ToVector3)
        End If
    End Function

    Public Function EntranceDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(BuildingInPos.ToVector3)
    End Function

    Public Function SaleSignDistance() As Single
        If SaleSignProp <> Nothing Then
            Return Game.Player.Character.Position.DistanceToSquared(SaleSignProp.Position - SaleSignProp.RightVector)
        Else
            Return Game.Player.Character.Position.DistanceToSquared(SaleSign.Position.ToVector3)
        End If
    End Function

    Public Function IsForSale() As Boolean
        Return BuildingBlip.Sprite = BlipSprite.SafehouseForSale Or BlipSprite.OfficeForSale Or BlipSprite.GarageForSale
    End Function

    Public Function GarageElevatorDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.GarageElevatorPos)
    End Function

    Public Function GarageMenuDistance(apt As ApartmentClass) As Single
        Return Game.Player.Character.Position.DistanceToSquared(apt.GarageMenuPos)
    End Function

    Public Function IsAtHome() As Boolean
        Return NFunc.Call(Of Boolean)(Hash.IS_INTERIOR_SCENE)
    End Function

    Public Sub HideExterior()
        If Not HideObjects Is Nothing Then
            If IsAtHome() AndAlso HideObjects.Count <> 0 AndAlso HighEndApartment.Building Is Me Then
                NFunc.Call(BEGIN_HIDE_MAP_OBJECT_THIS_FRAME)
                For Each obj In HideObjects
                    NFunc.Call(Hash._HIDE_MAP_OBJECT_THIS_FRAME, obj.GetHashKey)
                Next
                NFunc.Call(DISABLE_OCCLUSION_THIS_FRAME)
            End If
        End If
    End Sub

    Private Sub RefreshBlips()
        BuildingBlip = World.CreateBlip(BuildingInPos.ToVector3)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If Apartments.Count = 0 Then
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.SafehouseForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE1") 'Apartment For Sale
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.OfficeForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE2") 'Office For Sale
                    Case eBuildingType.ClubHouse, eBuildingType.NightClub, eBuildingType.Bunker
                        .Sprite = BlipSprite.BusinessForSale
                        .Name = Game.GetGXTEntry("BLIP_373") 'Property For Sale
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.GarageForSale
                        .Name = Game.GetGXTEntry("MP_PROP_SALE0") 'Garage For Sale
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.HangarForSale
                        .Name = Game.GetGXTEntry("BLIP_372") 'Hangar For Sale
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.WarehouseForSale
                        .Name = Game.GetGXTEntry("BLIP_474") 'Warehouse For Sale
                End Select
            Else
                Select Case BuildingType
                    Case eBuildingType.Apartment
                        .Sprite = BlipSprite.Safehouse
                    Case eBuildingType.Office
                        .Sprite = BlipSprite.Office
                    Case eBuildingType.ClubHouse
                        .Sprite = BlipSprite.BikerClubhouse
                    Case eBuildingType.Garage
                        .Sprite = BlipSprite.Garage
                    Case eBuildingType.Hangar
                        .Sprite = BlipSprite.GTAOHangar
                    Case eBuildingType.NightClub
                        .Sprite = BlipSprite.NightclubProperty
                    Case eBuildingType.Warehouse
                        .Sprite = BlipSprite.Warehouse
                    Case eBuildingType.Bunker
                        .Sprite = BlipSprite.Bunker
                End Select
                .Name = Name
            End If
        End With

        If Apartments.Count <> 0 AndAlso Not BuildingType = eBuildingType.Garage Then
            GarageBlip = World.CreateBlip(GarageInPos)
            With GarageBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"{Name} Garage"
            End With
        End If
    End Sub

    Private Sub AptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles AptMenu.OnItemSelect
        Try
            Dim selectedApt As ApartmentClass = selectedItem.Tag
            If selectedApt.Owner = GetPlayer() Then
                AptMenu.Visible = False
                HideHud = True
                PlayEnterApartmentCamera(3000, True, True, CameraShake.Hand, 0.4F)
                selectedApt.SetInteriorActive()
                PP.Position = selectedApt.ApartmentInPos
                Select Case selectedApt.ApartmentType
                    Case eApartmentType.LowEnd
                        LowEndApartment.Apartment = selectedApt
                        LowEndApartment.SpawnDoor()
                    Case eApartmentType.MediumEnd
                        MediumEndApartment.Apartment = selectedApt
                        MediumEndApartment.SpawnDoor()
                    Case eApartmentType.None, eApartmentType.IPL
                        HighEndApartment.Building = Me
                End Select
                selectedApt.PlayApartmentEnterCutscene()
                World.DestroyAllCameras()
                World.RenderingCamera = Nothing
                HideHud = False
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Function GetGarageVehicleCount() As Integer
        Select Case GarageType
            Case eGarageType.TwoCarGarage
                Return 2
            Case eGarageType.SixCarGarage
                Return 6
            Case eGarageType.TenCarGarage
                Return 10
            Case Else
                Return 20
        End Select
    End Function

    Private Sub SaveVehicle(selectedApt As ApartmentClass)
        GrgMenu.Visible = False
        HideHud = False
        PlayEnterGarageCamera(7000, True, True, CameraShake.Hand, 0.4F)
        FadeScreen(1)
        HideHud = False
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        Select Case selectedApt.ApartmentType
            Case eApartmentType.LowEnd
                LowEndApartment.Apartment = selectedApt
                LowEndApartment.SpawnDoor()
            Case eApartmentType.MediumEnd
                MediumEndApartment.Apartment = selectedApt
                MediumEndApartment.SpawnDoor()
            Case eApartmentType.None, eApartmentType.IPL
                HighEndApartment.Building = Me
        End Select
        Select Case GarageType
            Case eGarageType.TwoCarGarage
                TwoCarGarage.Apartment = selectedApt
                TwoCarGarage.Interior.SetInteriorActive

                If PP.IsInVehicle Then
                    'In Vehicle
                    Dim currVeh = PP.CurrentVehicle
                    Dim FromApartment = currVeh.GetInt(vehIdDecor)
                    Dim UniqueID = currVeh.GetInt(vehUidDecor)

                    PP.Task.WarpOutOfVehicle(PP.CurrentVehicle)

                    Select Case FromApartment
                        Case 0
                                    'Nothing need to do for this step
                        Case selectedApt.ID
                            Dim ExistingFileToDelete As String = $"{grgXmlPath}{selectedApt.GarageFilePath}\{UniqueID}.xml"
                            If File.Exists(ExistingFileToDelete) Then File.Delete(ExistingFileToDelete)
                        Case Else
                            Dim ExistingFileToDelete As String = $"{grgXmlPath}{Helper.apartments.Find(Function(x) x.ID = FromApartment).GarageFilePath}\{UniqueID}.xml"
                            If File.Exists(ExistingFileToDelete) Then File.Delete(ExistingFileToDelete)
                    End Select

                    If currVeh.IsCurrentVehicleExistInList Then outVehicleList.Remove(currVeh)
                    Dim uid As Integer = Guid.NewGuid.GetHashCode
                    Dim newVeh As New VehicleData($"{grgXmlPath}{selectedApt.GarageFilePath}\{uid}.xml", New VehicleClass(currVeh, GetPlayer, selectedApt.ID, uid, GetAvailableIndex(selectedApt.Vehicles, GarageType)))
                    newVeh.Save()
                    PP.Position = TwoCarGarage.Elevator
                    TwoCarGarage.LoadVehiclesSetPlayerPos(uid)
                    currVeh.CurrentBlip.Remove()
                    currVeh.Delete()
                    PP.Task.LeaveVehicle()
                Else
                    'On Foot
                    PP.Position = TwoCarGarage.GarageDoor
                    TwoCarGarage.LoadVehicles()
                End If

                FadeScreen(0)
            Case eGarageType.SixCarGarage
                SixCarGarage.Apartment = selectedApt
                SixCarGarage.Interior.SetInteriorActive

                If PP.IsInVehicle Then
                    'In Vehicle
                    Dim currVeh = PP.CurrentVehicle
                    Dim FromApartment = currVeh.GetInt(vehIdDecor)
                    Dim UniqueID = currVeh.GetInt(vehUidDecor)

                    PP.Task.WarpOutOfVehicle(PP.CurrentVehicle)

                    Select Case FromApartment
                        Case 0
                                    'Nothing need to do for this step
                        Case selectedApt.ID
                            Dim ExistingFileToDelete As String = $"{grgXmlPath}{selectedApt.GarageFilePath}\{UniqueID}.xml"
                            If File.Exists(ExistingFileToDelete) Then File.Delete(ExistingFileToDelete)
                        Case Else
                            Dim ExistingFileToDelete As String = $"{grgXmlPath}{Helper.apartments.Find(Function(x) x.ID = FromApartment).GarageFilePath}\{UniqueID}.xml"
                            If File.Exists(ExistingFileToDelete) Then File.Delete(ExistingFileToDelete)
                    End Select

                    If currVeh.IsCurrentVehicleExistInList Then outVehicleList.Remove(currVeh)
                    Dim uid As Integer = Guid.NewGuid.GetHashCode
                    Dim newVeh As New VehicleData($"{grgXmlPath}{selectedApt.GarageFilePath}\{uid}.xml", New VehicleClass(currVeh, GetPlayer, selectedApt.ID, uid, GetAvailableIndex(selectedApt.Vehicles, GarageType)))
                    newVeh.Save()
                    PP.Position = SixCarGarage.Elevator
                    SixCarGarage.LoadVehiclesSetPlayerPos(uid)
                    currVeh.CurrentBlip.Remove()
                    currVeh.Delete()
                    PP.Task.LeaveVehicle()
                Else
                    'On Foot
                    PP.Position = SixCarGarage.GarageDoorL
                    SixCarGarage.LoadVehicles()
                End If

                FadeScreen(0)
            Case eGarageType.TenCarGarage
                TenCarGarage.Apartment = selectedApt
                TenCarGarage.Interior.SetInteriorActive()

                If PP.IsInVehicle Then
                    'In Vehicle
                    Dim currVeh = PP.CurrentVehicle
                    Dim FromApartment = currVeh.GetInt(vehIdDecor)
                    Dim UniqueID = currVeh.GetInt(vehUidDecor)

                    PP.Task.WarpOutOfVehicle(PP.CurrentVehicle)

                    Select Case FromApartment
                        Case 0
                                    'Nothing need to do for this step
                        Case selectedApt.ID
                            Dim ExistingFileToDelete As String = $"{grgXmlPath}{selectedApt.GarageFilePath}\{UniqueID}.xml"
                            If File.Exists(ExistingFileToDelete) Then File.Delete(ExistingFileToDelete)
                        Case Else
                            Dim ExistingFileToDelete As String = $"{grgXmlPath}{Helper.apartments.Find(Function(x) x.ID = FromApartment).GarageFilePath}\{UniqueID}.xml"
                            If File.Exists(ExistingFileToDelete) Then File.Delete(ExistingFileToDelete)
                    End Select

                    If currVeh.IsCurrentVehicleExistInList Then outVehicleList.Remove(currVeh)
                    Dim uid As Integer = Guid.NewGuid.GetHashCode
                    Dim newVeh As New VehicleData($"{grgXmlPath}{selectedApt.GarageFilePath}\{uid}.xml", New VehicleClass(currVeh, GetPlayer, selectedApt.ID, uid, GetAvailableIndex(selectedApt.Vehicles, GarageType)))
                    newVeh.Save()
                    PP.Position = TenCarGarage.Elevator
                    TenCarGarage.LoadVehiclesSetPlayerPos(uid)
                    currVeh.CurrentBlip.Remove()
                    currVeh.Delete()
                    PP.Task.LeaveVehicle()
                Else
                    'On Foot
                    PP.Position = TenCarGarage.GarageDoorL
                    TenCarGarage.LoadVehicles()
                End If

                FadeScreen(0)
            Case eGarageType.TwentyCarGarage
                TwentyCarGarage.SetInteriorActive()
        End Select
    End Sub

    Private Sub GrgMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles GrgMenu.OnItemSelect
        Try
            Dim selectedApt As ApartmentClass = selectedItem.Tag
            If selectedApt.Owner = GetPlayer() Then
                If PP.IsInVehicle Then
                    If Not selectedApt.Vehicles.Count = GetGarageVehicleCount() Then
                        SaveVehicle(selectedApt)
                    Else
                        'Garage is full
                        UI.ShowSubtitle(Game.GetGXTEntry("WEB_VEH_FULL"))
                    End If
                Else
                    SaveVehicle(selectedApt)
                End If
            End If
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Private Sub AptMenu_OnMenuClose(sender As UIMenu) Handles AptMenu.OnMenuClose, BuyMenu.OnMenuClose
        FadeScreen(1)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        HideHud = False
        FadeScreen(0)
    End Sub

    Private Sub BuyMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles BuyMenu.OnItemSelect
        Try
            For Each apt In Apartments
                Dim selectedApt As ApartmentClass = selectedItem.Tag
                If selectedApt.Name = apt.Name AndAlso selectedItem.RightBadge = UIMenuItem.BadgeStyle.None AndAlso apt.Owner = eOwner.Nobody Then
                    'Buy Apartment
                    If PM > apt.Price Then
                        apt.UpdateApartmentOwner()
                        BuyMenu.Visible = False
                        FadeScreen(1)
                        Player.Money = (PM - apt.Price)
                        BuildingBlip.Remove()
                        If Not GarageBlip Is Nothing Then GarageBlip.Remove()
                        RefreshBuyMenu()
                        RefreshAptMenu()
                        RefreshGrgMenu()
                        'UpdateMechanicMenu
                        FadeScreen(0)
                        PlayPropertyPurchase(apt.Name)
                        Select Case GetPlayer()
                            Case eOwner.Michael
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Michael)
                            Case eOwner.Franklin
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Franklin)
                            Case eOwner.Trevor
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Trevor)
                            Case Else
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Heart)
                        End Select
                        selectedItem.SetRightLabel(Nothing)
                        RefreshBlips()
                        Script.Wait(2000)
                        FadeScreen(1)
                        World.DestroyAllCameras()
                        World.RenderingCamera = Nothing
                        HideHud = False
                        FadeScreen(0)
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub PlayEnterApartmentCamera(duration As Integer, easePosition As Boolean, easeRotation As Boolean, camShake As CameraShake, amplitude As Single)
        HideHud = True
        Select Case FrontDoor
            Case eFrontDoor.DoubleDoors
                Door1.UnlockDoor()
                Door2.UnlockDoor()
            Case eFrontDoor.StandardDoor
                Door1.UnlockDoor()
        End Select
        PP.Task.GoTo(BuildingLobby.ToVector3, True, 7000)
        Dim scriptCam As Camera = World.CreateCamera(EnterCamera1.Position, EnterCamera1.Rotation, EnterCamera1.FOV)
        Dim interpCam As Camera = World.CreateCamera(EnterCamera2.Position, EnterCamera2.Rotation, EnterCamera2.FOV)
        World.RenderingCamera = scriptCam
        scriptCam.InterpTo(interpCam, duration, easePosition, easeRotation)
        World.RenderingCamera = interpCam
        interpCam.Shake(camShake, amplitude)
        Script.Wait(duration)
        Select Case FrontDoor
            Case eFrontDoor.DoubleDoors
                Door1.LockDoor()
                Door2.LockDoor()
            Case eFrontDoor.StandardDoor
                Door1.LockDoor()
        End Select
        HideHud = False
    End Sub

    Public Sub PlayExitApartmentCamera(duration As Integer, easePosition As Boolean, easeRotation As Boolean, camShake As CameraShake, amplitude As Single)
        HideHud = True
        PP.Position = BuildingLobby.ToVector3
        PP.Heading = BuildingOutPos.W
        Select Case FrontDoor
            Case eFrontDoor.DoubleDoors
                Door1.UnlockDoor()
                Door2.UnlockDoor()
            Case eFrontDoor.StandardDoor
                Door1.UnlockDoor()
        End Select
        PP.Task.GoTo(BuildingOutPos.ToVector3, False, 7000)
        Dim scriptCam As Camera = World.CreateCamera(EnterCamera2.Position, EnterCamera2.Rotation, EnterCamera2.FOV)
        Dim interpCam As Camera = World.CreateCamera(EnterCamera1.Position, EnterCamera1.Rotation, EnterCamera1.FOV)
        World.RenderingCamera = scriptCam
        scriptCam.InterpTo(interpCam, duration, easePosition, easeRotation)
        World.RenderingCamera = interpCam
        interpCam.Shake(camShake, amplitude)
        Script.Wait(duration)
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
        Select Case FrontDoor
            Case eFrontDoor.DoubleDoors
                Door1.LockDoor()
                Door2.LockDoor()
            Case eFrontDoor.StandardDoor
                Door1.LockDoor()
        End Select
        HideHud = False
    End Sub

    Public Sub PlayEnterGarageCamera(duration As Integer, easePosition As Boolean, easeRotation As Boolean, camShake As CameraShake, amplitude As Single)
        If GarageDoor = eFrontDoor.StandardDoor Then
            HideHud = True
            Door3.UnlockDoor()

            If PP.IsInVehicle Then
                PP.CurrentVehicle.Position = GarageOutPos.ToVector3
                PP.CurrentVehicle.Heading = GarageOutPos.W - 180.0F
                PP.CurrentVehicle.PlaceOnGround()
                Dim scriptCam As Camera = World.CreateCamera(EnterCamera3.Position, EnterCamera3.Rotation, EnterCamera3.FOV)
                Dim interpCam As Camera = World.CreateCamera(EnterCamera4.Position, EnterCamera4.Rotation, EnterCamera4.FOV)
                World.RenderingCamera = scriptCam
                Script.Wait(3000)
                Dim ts As New TaskSequence()
                ts.AddTask.DriveTo(PP.CurrentVehicle, GarageInPos, 0.1F, 5.0F, DrivingStyle.Rushed)
                ts.AddTask.DriveTo(PP.CurrentVehicle, GarageFootOutPos.ToVector3, 0.1F, 5.0F, DrivingStyle.Rushed)
                ts.AddTask.DriveTo(PP.CurrentVehicle, GarageWaypoint.ToVector3, 0.1F, 5.0F, DrivingStyle.Rushed)
                PP.Task.PerformSequence(ts)
                scriptCam.InterpTo(interpCam, duration, easePosition, easeRotation)
                World.RenderingCamera = interpCam
                interpCam.Shake(camShake, amplitude)
                Script.Wait(duration)
                ts.Close()
                ts.Dispose()
            Else
                PP.Position = New Vector3(GarageInPos.X, GarageInPos.Y, GarageInPos.Z - 1.0F)
                PP.Heading = GarageOutPos.W - 180.0F
                Dim ts As New TaskSequence()
                ts.AddTask.GoTo(GarageFootOutPos.ToVector3, False, duration)
                ts.AddTask.GoTo(GarageWaypoint.ToVector3, False, duration)
                PP.Task.PerformSequence(ts)
                Dim scriptCam As Camera = World.CreateCamera(EnterCamera3.Position, EnterCamera3.Rotation, EnterCamera3.FOV)
                Dim interpCam As Camera = World.CreateCamera(EnterCamera4.Position, EnterCamera4.Rotation, EnterCamera4.FOV)
                World.RenderingCamera = scriptCam
                scriptCam.InterpTo(interpCam, duration, easePosition, easeRotation)
                World.RenderingCamera = interpCam
                interpCam.Shake(camShake, amplitude)
                Script.Wait(duration)
                ts.Close()
                ts.Dispose()
            End If

            Door3.LockDoor()
        End If
    End Sub

    Public Sub PlayExitGarageCamera(duration As Integer, easePosition As Boolean, easeRotation As Boolean, camShake As CameraShake, amplitude As Single)
        If GarageDoor = eFrontDoor.StandardDoor Then
            HideHud = True
            Door3.UnlockDoor()

            If PP.IsInVehicle Then
                PP.CurrentVehicle.Position = GarageWaypoint.ToVector3
                PP.CurrentVehicle.Heading = GarageWaypoint.W
                Dim ts As New TaskSequence()
                ts.AddTask.DriveTo(PP.CurrentVehicle, GarageFootOutPos.ToVector3, 0.1F, 5.0F, DrivingStyle.Rushed)
                ts.AddTask.DriveTo(PP.CurrentVehicle, GarageInPos, 0.1F, 5.0F, DrivingStyle.Rushed)
                ts.AddTask.DriveTo(PP.CurrentVehicle, GarageOutPos.ToVector3, 0.1F, 5.0F, DrivingStyle.Rushed)
                PP.Task.PerformSequence(ts)
                Dim scriptCam As Camera = World.CreateCamera(EnterCamera4.Position, EnterCamera4.Rotation, EnterCamera4.FOV)
                Dim interpCam As Camera = World.CreateCamera(EnterCamera3.Position, EnterCamera3.Rotation, EnterCamera3.FOV)
                World.RenderingCamera = scriptCam
                scriptCam.InterpTo(interpCam, duration, easePosition, easeRotation)
                World.RenderingCamera = interpCam
                interpCam.Shake(camShake, amplitude)
                FadeScreen(0)
                Script.Wait(duration)
                ts.Close()
                ts.Dispose()
            Else
                PP.Position = GarageInPos
                PP.Heading = GarageFootOutPos.W
                FadeScreen(0)
            End If
            World.DestroyAllCameras()
            World.RenderingCamera = Nothing

            Door3.LockDoor()
            HideHud = False
        End If
    End Sub

    Public Sub PlayEnterElevatorCutScene(duration As Integer)
        HideHud = True
        Select Case GarageType
            Case eGarageType.TwoCarGarage
                Dim scriptCam As Camera = World.CreateCamera(New Vector3(176.5861F, -1007.405F, -98.99998F), New Vector3(3.541232F, 0.0000001069259F, -44.71983F), 50.0F)
                World.RenderingCamera = scriptCam
                PP.Position = TwoCarGarage.Elevator
                PP.Heading = TwoCarGarage.ElevatorInside.W - 160.0F
                PP.Task.GoTo(TwoCarGarage.ElevatorInside.ToVector3, False, duration)
            Case eGarageType.SixCarGarage
                Dim scriptCam As Camera = World.CreateCamera(New Vector3(204.9573F, -1001.148F, -98.99999F), New Vector3(1.120068F, 0.00000005337105F, -57.21745F), 50.0F)
                World.RenderingCamera = scriptCam
                PP.Position = SixCarGarage.Elevator
                PP.Heading = SixCarGarage.ElevatorInside.W - 160.0F
                PP.Task.GoTo(SixCarGarage.ElevatorInside.ToVector3, False, duration)
            Case eGarageType.TenCarGarage
                Dim scriptCam As Camera = World.CreateCamera(New Vector3(235.6371F, -1003.728F, -98.9999F), New Vector3(2.576892F, -0.00000005341485F, -110.4919F), 50.0F)
                World.RenderingCamera = scriptCam
                PP.Position = New Vector3(237.2018F, -1004.526F, -99.9999F)
                PP.Heading = 270.0F
                PP.Task.PlayAnimation("anim@apt_trans@elevator", "elev_1")
            Case eGarageType.TwentyCarGarage
        End Select
        Script.Wait(duration)
    End Sub

    Public Sub PlayExitElevatorCutscene(duration As Integer)
        HideHud = True
        Select Case GarageType
            Case eGarageType.TwoCarGarage
                Dim scriptCam As Camera = World.CreateCamera(New Vector3(176.5861F, -1007.405F, -98.99998F), New Vector3(3.541232F, 0.0000001069259F, -44.71983F), 50.0F)
                World.RenderingCamera = scriptCam
                PP.Position = TwoCarGarage.ElevatorInside.ToVector3
                PP.Heading = TwoCarGarage.ElevatorInside.W
                PP.Task.GoTo(New Vector3(177.9277F, -1006.376F, -99.99992F), False, duration)
            Case eGarageType.SixCarGarage
                Dim scriptCam As Camera = World.CreateCamera(New Vector3(204.9573F, -1001.148F, -98.99999F), New Vector3(1.120068F, 0.00000005337105F, -57.21745F), 50.0F)
                World.RenderingCamera = scriptCam
                PP.Position = SixCarGarage.ElevatorInside.ToVector3
                PP.Heading = SixCarGarage.ElevatorInside.W
                PP.Task.GoTo(New Vector3(205.923F, -999.2991F, -100.0F), False, duration)
            Case eGarageType.TenCarGarage
                Dim scriptCam As Camera = World.CreateCamera(New Vector3(235.6371F, -1003.728F, -98.9999F), New Vector3(2.576892F, -0.00000005341485F, -110.4919F), 50.0F)
                World.RenderingCamera = scriptCam
                PP.Position = TenCarGarage.ElevatorInside.ToVector3
                PP.Heading = TenCarGarage.ElevatorInside.W
                PP.Task.GoTo(New Vector3(237.2018F, -1004.526F, -99.9999F), False, duration)
            Case eGarageType.TwentyCarGarage
        End Select
        Script.Wait(duration)
    End Sub
End Class

Public Enum eGarageType
    TwoCarGarage = 2
    SixCarGarage = 6
    TenCarGarage = 10
    TwentyCarGarage = 20
End Enum

Public Enum eBuildingType
    Apartment
    Garage
    Office
    ClubHouse
    Warehouse
    NightClub
    Hangar
    Bunker
End Enum

Public Enum eFrontDoor
    NoDoor
    StandardDoor
    DoubleDoors
End Enum