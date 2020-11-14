Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports NFunc = GTA.Native.Function

Namespace INM

    Public Class CameraPRH

        Public Position As Vector3
        Public Rotation As Vector3
        Public FOV As Single

        Public Sub New(pos As Vector3, rot As Vector3, fov As Single)
            Position = pos
            Rotation = rot
            Me.FOV = fov
        End Sub

        Public Function Zero() As CameraPRH
            Return New CameraPRH(Vector3.Zero, Vector3.Zero, 0F)
        End Function

    End Class

    Public Class EntityVector

        Public Model As String
        Public Position As Quaternion

        Public Sub New(model As String, position As Quaternion)
            Me.Model = model
            Me.Position = position
        End Sub

    End Class

    Public Class Door

        Public ModelHash As Integer
        Public Position As Vector3

        Public Sub New(hash As Integer, position As Vector3)
            ModelHash = hash
            Me.Position = position
        End Sub

        Public Sub LockDoor()
            NFunc.Call(Hash._DOOR_CONTROL, ModelHash, Position.X, Position.Y, Position.Z, True, 0.0, 50.0, 0)
        End Sub

        Public Sub UnlockDoor()
            NFunc.Call(Hash._DOOR_CONTROL, ModelHash, Position.X, Position.Y, Position.Z, False, 0.0, 50.0, 0)
        End Sub

    End Class

    Public Class Speech

        Public Wav As String

        Public Sub New(wav As String)
            Me.Wav = wav
        End Sub

    End Class

    Public Class Vector5

        Public Vector3 As Vector3
        Public Vector2 As Vector2

        Public Sub New(v3 As Vector3, v2 As Vector2)
            Vector3 = v3
            Vector2 = v2
        End Sub

        Public Shared Function Zero() As Vector5
            Return New Vector5(Vector3.Zero, Vector2.Zero)
        End Function

    End Class

    Public Class Clothing

        Public Name As String
        Public LocalizedName As String
        Public Type As eClothingType
        Public ComponentID As Integer
        Public DrawableID As Integer
        Public TextureID As Integer
        Public PaletteID As Integer
        Public ComponentID2 As Integer
        Public DrawableID2 As Integer
        Public TextureID2 As Integer
        Public PaletteID2 As Integer
        Public ComponentID3 As Integer
        Public DrawableID3 As Integer
        Public TextureID3 As Integer
        Public PaletteID3 As Integer

        Public Sub New(name As String, local As String, type As eClothingType, com As Integer, draw As Integer, txd As Integer, Optional pal As Integer = 2)
            Me.Name = name
            LocalizedName = local
            Me.Type = type
            ComponentID = com
            DrawableID = draw
            TextureID = txd
            PaletteID = pal

            ComponentID2 = -1
            DrawableID2 = -1
            TextureID2 = -1
            PaletteID2 = -1

            ComponentID3 = -1
            DrawableID3 = -1
            TextureID3 = -1
            PaletteID3 = -1
        End Sub

        Public Sub New(name As String, local As String, type As eClothingType, com1 As Integer, draw1 As Integer, txd1 As Integer,
                       com2 As Integer, draw2 As Integer, txd2 As Integer, Optional pal1 As Integer = 2, Optional pal2 As Integer = 2)
            Me.Name = name
            LocalizedName = local
            Me.Type = type
            ComponentID = com1
            DrawableID = draw1
            TextureID = txd1
            PaletteID = pal1

            ComponentID2 = com2
            DrawableID2 = draw2
            TextureID2 = txd2
            PaletteID2 = pal2

            ComponentID3 = -1
            DrawableID3 = -1
            TextureID3 = -1
            PaletteID3 = -1
        End Sub

        Public Sub New(name As String, local As String, type As eClothingType, com1 As Integer, draw1 As Integer, txd1 As Integer,
                       com2 As Integer, draw2 As Integer, txd2 As Integer, com3 As Integer, draw3 As Integer, txd3 As Integer,
                       Optional pal1 As Integer = 2, Optional pal2 As Integer = 2, Optional pal3 As Integer = 2)
            Me.Name = name
            LocalizedName = local
            Me.Type = type
            ComponentID = com1
            DrawableID = draw1
            TextureID = txd1
            PaletteID = pal1

            ComponentID2 = com2
            DrawableID2 = draw2
            TextureID2 = txd2
            PaletteID2 = pal2

            ComponentID3 = com3
            DrawableID3 = draw3
            TextureID3 = txd3
            PaletteID3 = pal3
        End Sub

        Public Function GetLocalizedName() As String
            Dim result As String = Nothing
            If Name = "" Then
                result = LocalizedName
            Else
                result = Game.GetGXTEntry(Name)
            End If
            If result = "NULL" Then Return LocalizedName Else Return result
        End Function

        Public Function CS1() As ClothingSet.CS
            Return New ClothingSet.CS(ComponentID, DrawableID, TextureID, PaletteID)
        End Function

        Public Function CS2() As ClothingSet.CS
            Return New ClothingSet.CS(ComponentID2, DrawableID2, TextureID2, PaletteID2)
        End Function

        Public Function CS3() As ClothingSet.CS
            Return New ClothingSet.CS(ComponentID3, DrawableID3, TextureID3, PaletteID3)
        End Function

    End Class

    Public Class ClothingSet

        Class CS

            Public ComponentID As Integer
            Public DrawableID As Integer
            Public TextureID As Integer
            Public PaletteID As Integer

            Public Sub New(cid As Integer, did As Integer, tid As Integer, Optional pid As Integer = 2)
                ComponentID = cid
                DrawableID = did
                TextureID = tid
                PaletteID = pid
            End Sub

            Public Sub New()
                ComponentID = -1
                DrawableID = -1
                TextureID = -1
                PaletteID = -1
            End Sub

        End Class

        Public Name As String
        Public LocalizedName As String
        Public Type As eClothingType
        Public Set1, Set2, Set3, Set4, Set5, Set6, Set7, Set8, Set9, Set10 As CS

        Public Sub New(name As String, local As String, s1 As CS, s2 As CS, s3 As CS, s4 As CS, s5 As CS, s6 As CS, s7 As CS)
            Me.Name = name
            LocalizedName = local
            Me.Type = eClothingType.FullSuit
            Set1 = s1
            Set2 = s2
            Set3 = s3
            Set4 = s4
            Set5 = s5
            Set6 = s6
            Set7 = s7
            Set8 = Nothing
            Set9 = Nothing
            Set10 = Nothing
        End Sub

        Public Sub New(name As String, local As String, s1 As CS, s2 As CS, s3 As CS, s4 As CS, s5 As CS, s6 As CS, s7 As CS, s8 As CS, s9 As CS, s10 As CS)
            Me.Name = name
            LocalizedName = local
            Me.Type = eClothingType.Outfit
            Set1 = s1
            Set2 = s2
            Set3 = s3
            Set4 = s4
            Set5 = s5
            Set6 = s6
            Set7 = s7
            Set8 = s8
            Set9 = s9
            Set10 = s10
        End Sub

        Public Function GetLocalizedName() As String
            Dim result As String = Nothing
            If Name = "" Then
                result = LocalizedName
            Else
                result = Game.GetGXTEntry(Name)
            End If
            If result = "NULL" Then Return LocalizedName Else Return result
        End Function

    End Class

    Public Enum eClothingType
        None = -1
        CapBackward
        CapForward
        CasualJacket
        CasualTShirt
        Chain
        Earrings
        FullSuit
        Glasses
        Hat
        Hoodie
        Jacket
        Outfit
        Pants
        Polo
        Shirt
        Shoes
        Shorts
        SportShades
        StreetShades
        SuitJacket
        SuitJacketButtoned
        SuitPants
        SuitTie
        SuitVest
        TankTop
        Top
        TShirt
        Vest
    End Enum

    Public Enum ePedVariation
        None = -1
        Face
        Beard
        Hair
        Torso
        Legs
        Hands
        Feet
        Eyes
        Accessories
        Props
        Textures
        AuxiliaryTorso
    End Enum

    Public Enum ePropVariation
        None = -1
        Helmet
        Glasses
        Earrings
    End Enum

End Namespace