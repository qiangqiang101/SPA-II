Imports GTA
Imports SPAII.INM
Imports SPAII.INM.ClothingSet

Public Class WardrobeMemory

    Public Sub New()
    End Sub

    Public Sub New(ped As Ped)
        Face = ped.GetClothes(ePedVariation.Face)
        Beard = ped.GetClothes(ePedVariation.Beard)
        Hair = ped.GetClothes(ePedVariation.Hair)
        Torso = ped.GetClothes(ePedVariation.Torso)
        Legs = ped.GetClothes(ePedVariation.Legs)
        Hands = ped.GetClothes(ePedVariation.Hands)
        Feet = ped.GetClothes(ePedVariation.Feet)
        Eyes = ped.GetClothes(ePedVariation.Eyes)
        Accessories = ped.GetClothes(ePedVariation.Accessories)
        Props = ped.GetClothes(ePedVariation.Props)
        Textures = ped.GetClothes(ePedVariation.Textures)
        AuxiliaryTorso = ped.GetClothes(ePedVariation.AuxiliaryTorso)

        Helmet = ped.GetProps(ePropVariation.Helmet)
        Glasses = ped.GetProps(ePropVariation.Glasses)
        Earrings = ped.GetProps(ePropVariation.Earrings)
    End Sub

    Private _face As CS
    Public Property Face() As CS
        Get
            Return _face
        End Get
        Set(value As CS)
            _face = value
        End Set
    End Property

    Private _beard As CS
    Public Property Beard() As CS
        Get
            Return _beard
        End Get
        Set(value As CS)
            _beard = value
        End Set
    End Property

    Private _hair As CS
    Public Property Hair() As CS
        Get
            Return _hair
        End Get
        Set(value As CS)
            _hair = value
        End Set
    End Property

    Private _torso As CS
    Public Property Torso() As CS
        Get
            Return _torso
        End Get
        Set(value As CS)
            _torso = value
        End Set
    End Property

    Private _legs As CS
    Public Property Legs() As CS
        Get
            Return _legs
        End Get
        Set(value As CS)
            _legs = value
        End Set
    End Property

    Private _hands As CS
    Public Property Hands() As CS
        Get
            Return _hands
        End Get
        Set(value As CS)
            _hands = value
        End Set
    End Property

    Private _feet As CS
    Public Property Feet() As CS
        Get
            Return _feet
        End Get
        Set(value As CS)
            _feet = value
        End Set
    End Property

    Private _eyes As CS
    Public Property Eyes() As CS
        Get
            Return _eyes
        End Get
        Set(value As CS)
            _eyes = value
        End Set
    End Property

    Private _accessories As CS
    Public Property Accessories() As CS
        Get
            Return _accessories
        End Get
        Set(value As CS)
            _accessories = value
        End Set
    End Property

    Private _props As CS
    Public Property Props() As CS
        Get
            Return _props
        End Get
        Set(value As CS)
            _props = value
        End Set
    End Property

    Private _textures As CS
    Public Property Textures() As CS
        Get
            Return _textures
        End Get
        Set(value As CS)
            _textures = value
        End Set
    End Property

    Private _auxTorso As CS
    Public Property AuxiliaryTorso() As CS
        Get
            Return _auxTorso
        End Get
        Set(value As CS)
            _auxTorso = value
        End Set
    End Property

    Private _helmet As CS
    Public Property Helmet() As CS
        Get
            Return _helmet
        End Get
        Set(value As CS)
            _helmet = value
        End Set
    End Property

    Private _glasses As CS
    Public Property Glasses() As CS
        Get
            Return _glasses
        End Get
        Set(value As CS)
            _glasses = value
        End Set
    End Property

    Private _earrings As CS
    Public Property Earrings() As CS
        Get
            Return _earrings
        End Get
        Set(value As CS)
            _earrings = value
        End Set
    End Property

    Public Sub SetClothes(cs As CS)
        Select Case cs.ComponentID
            Case 0
                Face = cs
            Case 1
                Beard = cs
            Case 2
                Hair = cs
            Case 3
                Torso = cs
            Case 4
                Legs = cs
            Case 5
                Hands = cs
            Case 6
                Feet = cs
            Case 7
                Eyes = cs
            Case 8
                Accessories = cs
            Case 9
                Props = cs
            Case 10
                Textures = cs
            Case 11
                AuxiliaryTorso = cs
        End Select
    End Sub

    Public Sub SetProps(cs As CS)
        Select Case cs.ComponentID
            Case 0
                Helmet = cs
            Case 1
                Glasses = cs
            Case 2
                Earrings = cs
        End Select
    End Sub

End Class
