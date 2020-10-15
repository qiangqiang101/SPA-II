Imports GTA
Imports GTA.Math

Module MediumEndApartment

    Public Apartment As ApartmentClass

    'Coords
    Public Interior As New Vector3(350.8938, -993.6076, -99.1961)
    Public SavePos As New Vector3(349.9618, -997.4911, -99.1962)
    Public InPos As New Vector3(346.5235, -1002.9012, -99.1962)
    Public OutPos As New Vector3(346.3732, -1013.137, -99.1962)
    Public WardrobePos As New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)

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
        If ExitDistance() <= 2.0FThen
            If Not MenuPool.IsAnyMenuOpen Then
                UI.ShowHelpMessage(Game.GetGXTEntry("SHR_EXIT_HELP"))
                If Game.IsControlJustReleased(0, Control.Context) Then
                    Apartment.AptMenu.Visible = True
                End If
            End If
        End If
    End Sub

End Module
