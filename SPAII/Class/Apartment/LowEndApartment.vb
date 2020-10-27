Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module LowEndApartment

    Public Apartment As ApartmentClass

    'Coords
    Public Interior As New Vector3(260.0521, -1004.1469, -99.0085)
    Public SavePos As New Vector3(262.9082, -1003.095, -99.0086)
    Public DoorPos As New Quaternion(264.9383F, -1003.388F, -100.0086F, 0F)
    Public InPos As New Vector3(265.0363F, -999.6489F, -100.0086F)
    Public OutPos As New Vector3(265.0587F, -1000.946F, -100.0087F)
    Public WardrobePos As New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
    Public EnterCam As New CameraPRH(New Vector3(263.8463F, -999.1443F, -99.00864F), New Vector3(-2.109026F, 0F, -153.4576F), 50.0F)
    Public ExitCam As New CameraPRH(New Vector3(266.5735F, -1004.03F, -99.00564F), New Vector3(-3.908313F, 0F, 30.38097F), 50.0F)
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
