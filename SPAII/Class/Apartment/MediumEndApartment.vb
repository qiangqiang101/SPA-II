Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module MediumEndApartment

    Public Apartment As ApartmentClass = Nothing

    'Coords
    Public Interior As New Vector3(350.8938, -993.6076, -99.1961)
    Public SavePos As New Vector3(349.9618, -997.4911, -99.1962)
    Public DoorPos As New Quaternion(346.3658F, -1006.062F, -100.1963F, 0F)
    Public InPos As New Vector3(346.453F, -1000.721F, -100.1963F)
    Public OutPos As New Vector3(346.5699F, -1002.002F, -100.1963F)
    Public WardrobePos As New Quaternion(350.8415F, -993.6423F, -100.2054F, 202.6284F)
    Public EnterCam As New CameraPRH(New Vector3(347.2171F, -1001.196F, -98.58544F), New Vector3(-2.076967F, 0.000003791111F, 159.947F), 50.0F)
    Public ExitCam As New CameraPRH(New Vector3(347.5302F, -1004.706F, -98.59762F), New Vector3(-2.470681F, 0.00001281852F, 32.38723F), 50.0F)
    Public Door As New Door("v_ilev_mp_mid_frontdoor".GetHashKey, New Vector3(345.8695F, -1003.079F, -100.2F))
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
