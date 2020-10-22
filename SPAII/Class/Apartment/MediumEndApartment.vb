﻿Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module MediumEndApartment

    Public Apartment As ApartmentClass

    'Coords
    Public Interior As New Vector3(350.8938, -993.6076, -99.1961)
    Public SavePos As New Vector3(349.9618, -997.4911, -99.1962)
    Public DoorPos As New Quaternion(346.3658F, -1006.062F, -100.1963F, 0F)
    Public InPos As New Vector3(346.5235, -1002.9012, -99.1962)
    Public OutPos As New Vector3(346.5699F, -1002.002F, -100.1963F)
    Public WardrobePos As New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
    Public EnterCam As New CameraPRH(New Vector3(347.7869F, -1002.219F, -99.49624F), New Vector3(-5.068632F, 0F, 125.6882F), 50.0F)
    Public ExitCam As New CameraPRH(Vector3.Zero, Vector3.Zero, 0F)
    Public Door As New Door("v_ilev_mp_mid_frontdoor".GetHashKey, New Vector3(345.8695F, -1003.079F, -100.1045F))
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

    Public Sub MediumEndApartmentOnTick()
        'Using Wardrobe
        If WardrobeDistance() <= 2.0F Then
            'todo
        End If

        'Get into bed
        If SaveDistance() <= 2.0F Then
            UI.ShowHelpMessage(Game.GetGXTEntry("SA_BED_IN"))
            'todo
        End If

        'Open Exit Apartment Menu
        If ExitDistance() <= 2.0F Then
            If Not MenuPool.IsAnyMenuOpen Then
                UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
                If Game.IsControlJustReleased(0, Control.Context) Then
                    Apartment.AptMenu.Visible = True
                End If
            End If
        End If
    End Sub

    Public Sub SpawnDoor()
        If FrontDoor <> Nothing Then FrontDoor.Delete()
        FrontDoor = World.CreateProp(Door.ModelHash, Door.Position, DoorRot, True, False)
        With FrontDoor
            .IsPersistent = True
            .FreezePosition = True
        End With
    End Sub

    Public Sub Clear()
        If FrontDoor <> Nothing Then FrontDoor.Delete()
    End Sub

End Module
