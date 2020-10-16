Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module LowEndApartment

    Public Apartment As ApartmentClass

    'Coords
    Public Interior As New Vector3(260.0521, -1004.1469, -99.0085)
    Public SavePos As New Vector3(262.9082, -1003.095, -99.0086)
    Public InPos As New Vector3(265.3285, -1002.7042, -99.0085)
    Public OutPos As New Vector3(266.1321, -1007.5136, -101.0085)
    Public WardrobePos As New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
    Public EnterCam As New CameraPRH(New Vector3(265.5739F, -1001.004F, -99.40854F), New Vector3(-0.9101265F, 0F, 134.0882F), 50.0F)
    Public Door As New Door(0, Vector3.Zero)

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

End Module
