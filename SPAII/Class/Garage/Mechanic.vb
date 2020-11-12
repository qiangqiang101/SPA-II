Imports System.Drawing
Imports GTA
Imports iFruitAddon2
Imports INMNativeUI

Module Mechanic

    Public iFruit As CustomiFruit
    Public WithEvents MechanicContact As iFruitContact
    Public WithEvents MechanicMenu, AptMenu As UIMenu


    Public Sub LoadContacts()
        iFruit = New CustomiFruit
        iFruit.Contacts.Clear()
        MechanicContact = New iFruitContact(Game.GetGXTEntry("CELL_E_MP0"))
        With MechanicContact
            .DialTimeout = 4000
            .Active = True
            .Icon = ContactIcon.LSCustoms
        End With
        iFruit.Contacts.Add(MechanicContact)

        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        MechanicMenu = New UIMenu("", Game.GetGXTEntry("MPCT_MECHH"), New Point(0, -107))
        MechanicMenu.SetBannerType(MenuBanner)
        MechanicMenu.MouseEdgeEnabled = False
        MechanicMenu.RefreshIndex()
        MenuPool.Add(MechanicMenu)

        AptMenu = New UIMenu("", Game.GetGXTEntry("MPCT_PERVEH1"), New Point(0, -107))
        AptMenu.SetBannerType(MenuBanner)
        AptMenu.MouseEdgeEnabled = False
        AptMenu.RefreshIndex()
        MenuPool.Add(AptMenu)
    End Sub

    Public Sub RefreshMechanicMenu()
        MechanicMenu.MenuItems.Clear()

        With MechanicMenu
            For Each apt As ApartmentClass In apartments
                If apt.Owner = GetPlayer() Then
                    Dim item As New UIMenuItem(Game.GetGXTEntry(apt.Name)) With {.Tag = apt, .Enabled = Not apt.Vehicles.Count = 0}
                    .AddItem(item)
                End If
            Next
            .RefreshIndex()
        End With
    End Sub

    Public Sub RefreshMechanicApartmentMenu(apt As ApartmentClass)
        AptMenu.MenuItems.Clear()

        With AptMenu
            For Each veh As VehicleClass In apt.Vehicles
                Dim item As New UIMenuItem($"{veh.Make} {veh.Name} ({veh.PlateNumber})", Game.GetGXTEntry("MPCT_PERVEHC")) With {.Tag = veh, .Enabled = Not IsGarageVehicleAlreadyExistInWorldMap(apt.ID, veh.UniqueID)}
                .AddItem(item)
                MechanicMenu.BindMenuToItem(AptMenu, item)
            Next
            .RefreshIndex()
        End With
    End Sub

    Private Sub MechanicContact_Answered(contact As iFruitContact) Handles MechanicContact.Answered
        RefreshMechanicMenu()
        MechanicMenu.Visible = True

        Dim r As New Random
        Dim rd As Integer = r.Next(1, 3)
        Select Case rd
            Case 1
                YouNeedSomething.Play
            Case Else
                OnTheClock.Play
        End Select

        iFruit.Close(5000)
    End Sub

    Private Sub MechanicMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles MechanicMenu.OnItemSelect
        Dim apt As ApartmentClass = selectedItem.Tag
        RefreshMechanicApartmentMenu(apt)
        AptMenu.Visible = True
        sender.Visible = False
    End Sub

    Private Sub AptMenu_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles AptMenu.OnItemSelect
        Dim veh As VehicleClass = selectedItem.Tag

        Dim nearestParkingSpot = PP.Position.GetNearestParkingSpot
        Dim distance = nearestParkingSpot.Vector3.DistanceTo(PP.Position)
        If distance >= 50.0F Then
            UI.ShowHelpMessage(distance)
            ICantGetYourRide.Play
        Else
            If nearestParkingSpot.Vector3.IsPositionOccupied(5.0F) Then
                World.GetClosestVehicle(nearestParkingSpot.Vector3, 5.0F).Delete()
            End If

            Dim newVeh As Vehicle = CreateGarageVehicle(veh, nearestParkingSpot.ToQuaternion, veh.ApartmentID)
            With newVeh
                .AddBlip()
                .CurrentBlip.Sprite = BlipSprite.PersonalVehicleCar
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
            IllBeThere.Play
        End If
        sender.Visible = False
    End Sub

    Private Sub MechanicMenu_OnMenuClose(sender As UIMenu) Handles MechanicMenu.OnMenuClose
        IllGetBackToWork.Play
    End Sub
End Module
