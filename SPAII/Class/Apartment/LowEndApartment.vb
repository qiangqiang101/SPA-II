﻿Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module LowEndApartment

    Public Apartment As ApartmentClass = Nothing

    'Coords
    Public Interior As New Vector3(260.0521, -1004.1469, -99.0085)
    Public SavePos As New Vector3(262.9082, -1003.095, -99.0086)
    Public DoorPos As New Quaternion(264.9383F, -1003.388F, -100.0086F, 0F)
    Public InPos As New Vector3(265.0363F, -999.6489F, -100.0086F)
    Public OutPos As New Vector3(265.0587F, -1000.946F, -100.0087F)
    Public WardrobePos As New Quaternion(260.1203F, -1004.165F, -100.0086F, 0.1981915F)
    Public EnterCam As New CameraPRH(New Vector3(266.1936F, -999.7531F, -98.26804F), New Vector3(-4.893726F, -0.0000006426729F, 150.1184F), 50.0F)
    Public ExitCam As New CameraPRH(New Vector3(266.5379F, -1003.075F, -98.32577F), New Vector3(-3.240182F, -0.00000331367F, 43.73997F), 50.0F)
    Public Door As New Door("v_ilev_mp_low_frontdoor".GetHashKey, New Vector3(264.483F, -1001.621F, -100.0F))
    Public DoorRot As New Vector3(0F, 0F, 180.0F)

    Public FrontDoor As Prop

    Public Function WardrobeDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(WardrobePos.ToVector3)
    End Function

    Public Function SaveDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(SavePos)
    End Function

    Public Function ExitDistance() As Single
        Return Game.Player.Character.Position.DistanceToSquared(OutPos)
    End Function

    Public Sub LowEndApartmentOnTick()
        'Using Wardrobe
        If WardrobeDistance() <= 2.0F Then
            If Not MenuPool.IsAnyMenuOpen Then
                UI.ShowHelpMessage(Game.GetGXTEntry("WARD_TRIG").Replace("~a~", "~INPUT_CONTEXT~"))
                If Game.IsControlJustReleased(0, Control.Context) Then
                    MakeCamera(PP, WardrobePos.ToVector3, WardrobePos.W)
                End If
            End If
        End If

        'Get into bed
        If SaveDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SA_BED_IN"))
            If Game.IsControlJustReleased(0, Control.Context) Then
                Sleep(Apartment)
            End If
        End If

        'Open Exit Apartment Menu
        If ExitDistance() <= 2.0F Then
            If Not MenuPool.IsAnyMenuOpen Then
                If Apartment.AptMenu.Visible = False Then Apartment.AptMenu.Visible = True
            End If
        End If
    End Sub

    Public Sub SpawnDoor()
        If FrontDoor <> Nothing Then FrontDoor.Delete()
        FrontDoor = World.CreateProp(Door.ModelHash, Door.Position, DoorRot, False, False)
        With FrontDoor
            .IsPersistent = True
            .FreezePosition = False
        End With
    End Sub

    Public Sub Clear()
        If FrontDoor <> Nothing Then FrontDoor.Delete()
    End Sub

End Module
