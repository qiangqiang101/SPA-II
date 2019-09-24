Imports GTA
Imports GTA.Math
Imports GTA.Native

Public Class BuildingClass

    Public Name As String
    Public EntrancePos As Vector3
    Public ExitPos As Quaternion
    Public GarageEntrancePos As Vector3
    Public GarageExitPos As Quaternion
    Public CameraPos As Quaternion
    Public CameraRot As Vector3
    Public GarageType As eGarageType
    Public BuildingType As eBuildingType
    Public Apartments As List(Of ApartmentData)

    Public BuildingBlip As Blip
    Public GarageBlip As Blip

    Public Sub New(n As String, ep As Vector3, xp As Quaternion, gep As Vector3, gxp As Quaternion, cp As Quaternion, cr As Vector3, a As List(Of ApartmentData), gt As eGarageType, bt As eBuildingType)
        Name = n
        EntrancePos = ep
        ExitPos = xp
        GarageEntrancePos = gep
        GarageExitPos = gxp
        CameraPos = cp
        CameraRot = cr
        Apartments = a
        GarageType = gt
        BuildingType = bt

        Dim apts As New List(Of ApartmentData)
        For Each apt In a
            If Not apt.Owner = -1 Then apts.Add(apt)
        Next

        BuildingBlip = World.CreateBlip(EntrancePos)
        With BuildingBlip
            .Color = BlipColor.White
            .IsShortRange = True
            If apts.Count = 0 Then
                Select Case bt
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
                Select Case bt
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
                .Name = n
            End If
        End With

        If apts.Count <> 0 Then
            GarageBlip = World.CreateBlip(GarageEntrancePos)
            With BuildingBlip
                .Color = BlipColor.White
                .IsShortRange = True
                .Sprite = BlipSprite.Garage
                .Name = $"{n} Garage"
            End With
        End If
    End Sub

    Public Function GarageDistance() As Single
        Return Game.Player.Character.Position.DistanceTo(GarageEntrancePos)
    End Function

    Public Function EntranceDistance() As Single
        Return Game.Player.Character.Position.DistanceTo(EntrancePos)
    End Function

    Public Function IsForSale() As Boolean
        Return BuildingBlip.Sprite = BlipSprite.SafehouseForSale Or BlipSprite.OfficeForSale
    End Function

    Public Function HaveOwner() As Boolean
        Return Apartments.Contains(Apartments.Find(Function(x) x.Owner = -1))
    End Function

    Public Function WardrobeDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.WardrobePos.Axis)
    End Function

    Public Function SaveDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.SavePos)
    End Function

    Public Function ExitDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.ExitPos)
    End Function

    Public Function GarageElevatorDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.GarageElevatorPos)
    End Function

    Public Function GarageMenuDistance(apt As ApartmentData) As Single
        Return Game.Player.Character.Position.DistanceTo(apt.GarageMenuPos)
    End Function

    Public Function IsAtHome(apt As ApartmentData) As Boolean
        Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
        Dim pIntID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z)
        Return intID = pIntID
    End Function

    Public Function InteriorID(apt As ApartmentData)
        Return Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
    End Function

    Public Sub SetInteriorActive(apt As ApartmentData)
        Try
            Dim intID As Integer = Native.Function.Call(Of Integer)(Hash.GET_INTERIOR_AT_COORDS, apt.InteriorPos.X, apt.InteriorPos.Y, apt.InteriorPos.Z)
            Native.Function.Call(Hash._0x2CA429C029CCF247, New InputArgument() {intID})
            Native.Function.Call(Hash.SET_INTERIOR_ACTIVE, intID, True)
            Native.Function.Call(Hash.DISABLE_INTERIOR, intID, False)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

End Class
