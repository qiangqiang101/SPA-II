Imports GTA

Module HighEndApartment

    Public Building As BuildingClass = Nothing

    Public Sub HighEndApartmentOnTick()
        If IsInInterior() Then
            For i As Integer = 0 To apartments.Count - 1
                Dim apt As ApartmentClass = apartments(i)
                If Not apt.ShareInterior Then
                    'Using Wardrobe
                    If apt.WardrobeDistance() <= 2.0F Then
                        If Not MenuPool.IsAnyMenuOpen Then
                            UI.ShowHelpMessage(Game.GetGXTEntry("WARD_TRIG").Replace("~a~", "~INPUT_CONTEXT~"))
                            If Game.IsControlJustReleased(0, Control.Context) Then
                                MakeCamera(PP, apt.WardrobePos.ToVector3, apt.WardrobePos.W)
                            End If
                        End If
                    End If

                    'Open Exit Apartment Menu
                    If apt.ExitDistance <= 2.0F Then
                        If Not MenuPool.IsAnyMenuOpen Then
                            If apt.AptMenu.Visible = False Then apt.AptMenu.Visible = True
                        End If
                    End If

                    'Get into bed
                    If apt.SaveDistance <= 2.0F Then
                        UI.ShowHelpMessage(Game.GetGXTEntry("SA_BED_IN"))
                        If Game.IsControlJustReleased(0, Control.Context) Then
                            Sleep(apt)
                        End If
                        'todo
                    End If

                    If apt.InteriorID = PI Then PropOnTick()
                End If
            Next
        End If
    End Sub

End Module
