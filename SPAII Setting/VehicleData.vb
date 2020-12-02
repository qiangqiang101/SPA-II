Imports System.IO
Imports System.Xml.Serialization

Public Structure VehicleData

    Public ReadOnly Property Instance As VehicleData
        Get
            Return ReadFromFile()
        End Get
    End Property

    <XmlIgnore>
    Public Property FileName() As String

    Public Index As Integer
    Public Make As String
    Public Name As String
    Public Hash As Integer
    Public Owner As eOwner
    Public Aerials As Integer
    Public Suspension As Integer
    Public Armor As Integer
    Public Brakes As Integer
    Public Engine As Integer
    Public Transmission As Integer
    Public FrontBumper As Integer
    Public RearBumper As Integer
    Public SideSkirt As Integer
    Public Trim As Integer
    Public EngineBlock As Integer
    Public AirFilter As Integer
    Public Struts As Integer
    Public ColumnShifterLevers As Integer
    Public Dashboard As Integer
    Public DialDesign As Integer
    Public Ornaments As Integer
    Public Seats As Integer
    Public SteeringWheel As Integer
    Public TrimDesign As Integer
    Public TrimColor As Integer
    Public PlateHolder As Integer
    Public VanityPlates As Integer
    Public NumberPlate As Integer
    Public PlateNumber As String
    Public WheelType As Integer
    Public Frontwheels As Integer
    Public BackWheels As Integer
    Public WheelsVariation As Boolean
    Public Headlights As Boolean
    Public FrontNeon As Boolean
    Public BackNeon As Boolean
    Public LeftNeon As Boolean
    Public RightNeon As Boolean
    Public ArchCover As Integer
    Public Exhaust As Integer
    Public Fender As Integer
    Public RightFender As Integer
    Public DoorSpeakers As Integer
    Public Frame As Integer
    Public Grille As Integer
    Public Hood As Integer
    Public Horn As Integer
    Public Hydraulics As Integer
    Public Livery As Integer
    Public Plaques As Integer
    Public Roof As Integer
    Public Speakers As Integer
    Public Spoiler As Integer
    Public Tank As Integer
    Public Trunk As Integer
    Public Windows As Integer
    Public Turbo As Boolean
    Public Tint As Integer
    Public PrimaryColor As Integer
    Public SecondaryColor As Integer
    Public PearlescentColor As Integer
    Public RimColor As Integer
    Public LightsColor As Integer
    Public NeonLightsColor As VsColor
    Public TireSmokeColor As VsColor
    Public Tiresmoke As Boolean
    Public Livery2 As Integer
    Public HeadlightsColor As Integer
    Public BulletProofTires As Boolean
    Public CustomPrimaryColor As VsColor
    Public CustomSecondaryColor As VsColor
    Public HasCustomPrimaryColor As Boolean
    Public HasCustomSecondaryColor As Boolean
    Public Extra0, Extra1, Extra2, Extra3, Extra4, Extra5, Extra6, Extra7, Extra8, Extra9, Extra10, Extra11, Extra12, Extra13, Extra14, Extra15 As Boolean
    Public RoofState As Integer
    Public HasNitro As Boolean
    Public Livery1 As Integer
    Public ApartmentID As Integer
    Public UniqueID As Integer

    Public Sub New(_filename As String)
        FileName = _filename
    End Sub

    Public Sub New(_filename As String, vehicle As VehicleClass)
        FileName = _filename
        Index = vehicle.Index
        Make = vehicle.Make
        Name = vehicle.Name
        Hash = vehicle.Hash
        Owner = vehicle.Owner
        Aerials = vehicle.Aerials
        Suspension = vehicle.Suspension
        Armor = vehicle.Armor
        Brakes = vehicle.Brakes
        Engine = vehicle.Engine
        Transmission = vehicle.Transmission
        FrontBumper = vehicle.FrontBumper
        RearBumper = vehicle.RearBumper
        SideSkirt = vehicle.SideSkirt
        Trim = vehicle.Trim
        EngineBlock = vehicle.EngineBlock
        AirFilter = vehicle.AirFilter
        Struts = vehicle.Struts
        ColumnShifterLevers = vehicle.ColumnShifterLevers
        Dashboard = vehicle.Dashboard
        DialDesign = vehicle.DialDesign
        Ornaments = vehicle.Ornaments
        Seats = vehicle.Seats
        SteeringWheel = vehicle.SteeringWheel
        TrimDesign = vehicle.TrimDesign
        TrimColor = vehicle.TrimColor
        PlateHolder = vehicle.PlateHolder
        VanityPlates = vehicle.VanityPlates
        NumberPlate = vehicle.NumberPlate
        PlateNumber = vehicle.PlateNumber
        WheelType = vehicle.WheelType
        Frontwheels = vehicle.Frontwheels
        BackWheels = vehicle.BackWheels
        WheelsVariation = vehicle.WheelsVariation
        Headlights = vehicle.Headlights
        FrontNeon = vehicle.FrontNeon
        BackNeon = vehicle.BackNeon
        LeftNeon = vehicle.LeftNeon
        RightNeon = vehicle.RightNeon
        ArchCover = vehicle.ArchCover
        Exhaust = vehicle.Exhaust
        Fender = vehicle.Fender
        RightFender = vehicle.RightFender
        DoorSpeakers = vehicle.DoorSpeakers
        Frame = vehicle.Frame
        Grille = vehicle.Grille
        Hood = vehicle.Hood
        Horn = vehicle.Horn
        Hydraulics = vehicle.Hydraulics
        Livery = vehicle.Livery
        Plaques = vehicle.Plaques
        Roof = vehicle.Roof
        Speakers = vehicle.Speakers
        Spoiler = vehicle.Spoiler
        Tank = vehicle.Tank
        Trunk = vehicle.Trunk
        Windows = vehicle.Windows
        Turbo = vehicle.Turbo
        Tint = vehicle.Tint
        PrimaryColor = vehicle.PrimaryColor
        SecondaryColor = vehicle.SecondaryColor
        PearlescentColor = vehicle.PearlescentColor
        RimColor = vehicle.RimColor
        LightsColor = vehicle.LightsColor
        NeonLightsColor = vehicle.NeonLightsColor
        TireSmokeColor = vehicle.TireSmokeColor
        Tiresmoke = vehicle.Tiresmoke
        Livery2 = vehicle.Livery2
        HeadlightsColor = vehicle.HeadlightsColor
        BulletProofTires = vehicle.BulletProofTires
        CustomPrimaryColor = vehicle.CustomPrimaryColor
        CustomSecondaryColor = vehicle.CustomSecondaryColor
        HasCustomPrimaryColor = vehicle.HasCustomPrimaryColor
        HasCustomSecondaryColor = vehicle.HasCustomSecondaryColor
        Extra0 = vehicle.Extra0
        Extra1 = vehicle.Extra1
        Extra2 = vehicle.Extra2
        Extra3 = vehicle.Extra3
        Extra4 = vehicle.Extra4
        Extra5 = vehicle.Extra5
        Extra6 = vehicle.Extra6
        Extra7 = vehicle.Extra7
        Extra8 = vehicle.Extra8
        Extra9 = vehicle.Extra9
        Extra10 = vehicle.Extra10
        Extra11 = vehicle.Extra11
        Extra12 = vehicle.Extra12
        Extra13 = vehicle.Extra13
        Extra14 = vehicle.Extra14
        Extra15 = vehicle.Extra15
        RoofState = vehicle.RoofState
        Livery1 = vehicle.Livery1
        HasNitro = vehicle.HasNitro
        ApartmentID = vehicle.ApartmentID
        UniqueID = vehicle.UniqueID
    End Sub

    Public Sub New(gfp As String, spa1 As String, _index As Integer, aptID As Integer)
        Try
            Dim uid As Integer = Guid.NewGuid.GetHashCode
            Dim _fileName As String = $"{My.Application.Info.DirectoryPath}\Garages\{gfp}\{uid}.xml"

            FileName = _fileName
            Index = _index
            Make = ""
            Name = ReadCfgValue(Of String)("VehicleName", spa1)
            Hash = ReadCfgValue(Of Integer)("VehicleHash", spa1)
            Owner = eOwner.Nobody
            Aerials = ReadCfgValue(Of Integer)("ForthyThree", spa1)
            Suspension = ReadCfgValue(Of Integer)("Suspension", spa1)
            Armor = ReadCfgValue(Of Integer)("Armor", spa1)
            Brakes = ReadCfgValue(Of Integer)("Brakes", spa1)
            Engine = ReadCfgValue(Of Integer)("Engine", spa1)
            Transmission = ReadCfgValue(Of Integer)("Transmission", spa1)
            FrontBumper = ReadCfgValue(Of Integer)("FrontBumper", spa1)
            RearBumper = ReadCfgValue(Of Integer)("RearBumper", spa1)
            SideSkirt = ReadCfgValue(Of Integer)("SideSkirt", spa1)
            Trim = ReadCfgValue(Of Integer)("ForthyFour", spa1)
            EngineBlock = ReadCfgValue(Of Integer)("ThirtyNine", spa1)
            AirFilter = ReadCfgValue(Of Integer)("ForthyZero", spa1)
            Struts = ReadCfgValue(Of Integer)("ForthyOne", spa1)
            ColumnShifterLevers = ReadCfgValue(Of Integer)("ThirtyFour", spa1)
            Dashboard = ReadCfgValue(Of Integer)("TwentyNine", spa1)
            DialDesign = ReadCfgValue(Of Integer)("ThirtyZero", spa1)
            Ornaments = ReadCfgValue(Of Integer)("TwentyEight", spa1)
            Seats = ReadCfgValue(Of Integer)("ThirtyTwo", spa1)
            SteeringWheel = ReadCfgValue(Of Integer)("ThirtyThree", spa1)
            TrimDesign = ReadCfgValue(Of Integer)("TwentySeven", spa1)
            TrimColor = ReadCfgValue(Of Integer)("TrimColor", spa1)
            PlateHolder = ReadCfgValue(Of Integer)("TwentyFive", spa1)
            VanityPlates = ReadCfgValue(Of Integer)("TwentySix", spa1)
            NumberPlate = ReadCfgValue(Of Integer)("PlateType", spa1)
            PlateNumber = ReadCfgValue(Of String)("PlateNumber", spa1)
            WheelType = ReadCfgValue(Of Integer)("WheelType", spa1)
            Frontwheels = ReadCfgValue(Of Integer)("FrontWheels", spa1)
            BackWheels = ReadCfgValue(Of Integer)("BackWheels", spa1)
            WheelsVariation = ReadCfgValue(Of Boolean)("FrontTireVariation", spa1)
            Headlights = ReadCfgValue(Of Boolean)("XenonHeadlights", spa1)
            FrontNeon = ReadCfgValue(Of Boolean)("HasNeonLightFront", spa1)
            BackNeon = ReadCfgValue(Of Boolean)("HasNeonLightBack", spa1)
            LeftNeon = ReadCfgValue(Of Boolean)("HasNeonLightLeft", spa1)
            RightNeon = ReadCfgValue(Of Boolean)("HasNeonLightRight", spa1)
            ArchCover = ReadCfgValue(Of Integer)("ForthyTwo", spa1)
            Exhaust = ReadCfgValue(Of Integer)("Exhaust", spa1)
            Fender = ReadCfgValue(Of Integer)("Fender", spa1)
            RightFender = ReadCfgValue(Of Integer)("RightFender", spa1)
            DoorSpeakers = ReadCfgValue(Of Integer)("ThirtyOne", spa1)
            Frame = ReadCfgValue(Of Integer)("Frame", spa1)
            Grille = ReadCfgValue(Of Integer)("Grille", spa1)
            Hood = ReadCfgValue(Of Integer)("Hood", spa1)
            Horn = ReadCfgValue(Of Integer)("Horn", spa1)
            Hydraulics = ReadCfgValue(Of Integer)("ThirtyEight", spa1)
            Livery = ReadCfgValue(Of Integer)("ForthyEight", spa1)
            Plaques = ReadCfgValue(Of Integer)("ThirtyFive", spa1)
            Roof = ReadCfgValue(Of Integer)("Roof", spa1)
            Speakers = ReadCfgValue(Of Integer)("ThirtySix", spa1)
            Spoiler = ReadCfgValue(Of Integer)("Spoiler", spa1)
            Tank = ReadCfgValue(Of Integer)("ForthyFive", spa1)
            Trunk = ReadCfgValue(Of Integer)("ThirtySeven", spa1)
            Windows = ReadCfgValue(Of Integer)("ForthySix", spa1)
            Turbo = ReadCfgValue(Of Boolean)("Turbo", spa1)
            Tint = ReadCfgValue(Of Integer)("WindowTint", spa1)
            PrimaryColor = ReadCfgValue(Of Integer)("PrimaryColor", spa1)
            SecondaryColor = ReadCfgValue(Of Integer)("SecondaryColor", spa1)
            PearlescentColor = ReadCfgValue(Of Integer)("PearlescentColor", spa1)
            RimColor = ReadCfgValue(Of Integer)("RimColor", spa1)
            LightsColor = ReadCfgValue(Of Integer)("DashboardColor", spa1)
            NeonLightsColor = New VsColor(ReadCfgValue(Of Integer)("NeonColorRed", spa1), ReadCfgValue(Of Integer)("NeonColorGreen", spa1), ReadCfgValue(Of Integer)("NeonColorBlue", spa1))
            TireSmokeColor = New VsColor(ReadCfgValue(Of Integer)("TyreSmokeColorRed", spa1), ReadCfgValue(Of Integer)("TyreSmokeColorGreen", spa1), ReadCfgValue(Of Integer)("TyreSmokeColorBlue", spa1))
            Tiresmoke = True
            Livery2 = ReadCfgValue(Of Integer)("CustomRoof", spa1)
            HeadlightsColor = -1
            BulletProofTires = ReadCfgValue(Of Boolean)("BulletproofTyres", spa1)
            CustomPrimaryColor = New VsColor(ReadCfgValue(Of Integer)("CustomPrimaryColorRed", spa1), ReadCfgValue(Of Integer)("CustomPrimaryColorGreen", spa1), ReadCfgValue(Of Integer)("CustomPrimaryColorBlue", spa1))
            CustomSecondaryColor = New VsColor(ReadCfgValue(Of Integer)("CustomSecondaryColorRed", spa1), ReadCfgValue(Of Integer)("CustomSecondaryColorGreen", spa1), ReadCfgValue(Of Integer)("CustomSecondaryColorBlue", spa1))
            HasCustomPrimaryColor = ReadCfgValue(Of Boolean)("HasCustomPrimaryColor", spa1)
            HasCustomSecondaryColor = ReadCfgValue(Of Boolean)("HasCustomSecondaryColor", spa1)
            Extra0 = False
            Extra1 = ReadCfgValue(Of Boolean)("ExtraOne", spa1)
            Extra2 = ReadCfgValue(Of Boolean)("ExtraTwo", spa1)
            Extra3 = ReadCfgValue(Of Boolean)("ExtraThree", spa1)
            Extra4 = ReadCfgValue(Of Boolean)("ExtraFour", spa1)
            Extra5 = ReadCfgValue(Of Boolean)("ExtraFive", spa1)
            Extra6 = ReadCfgValue(Of Boolean)("ExtraSix", spa1)
            Extra7 = ReadCfgValue(Of Boolean)("ExtraSeven", spa1)
            Extra8 = ReadCfgValue(Of Boolean)("ExtraEight", spa1)
            Extra9 = ReadCfgValue(Of Boolean)("ExtraNine", spa1)
            Extra10 = False
            Extra11 = False
            Extra12 = False
            Extra13 = False
            Extra14 = False
            Extra15 = False
            RoofState = ReadCfgValue(Of Integer)("VehicleRoof", spa1)
            Livery1 = ReadCfgValue(Of Integer)("Livery", spa1)
            HasNitro = False
            ApartmentID = aptID
            UniqueID = uid
        Catch ex As Exception
            MsgBox($"{ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "ERR")
        End Try
    End Sub

    Public Sub Save()
        Dim ser = New XmlSerializer(GetType(VehicleData))
        Dim writer As TextWriter = New StreamWriter(FileName)
        ser.Serialize(writer, Me)
        writer.Close()
    End Sub

    Public Function ReadFromFile() As VehicleData
        If Not File.Exists(FileName) Then
            Return New VehicleData(FileName)
        End If

        Try
            Dim ser = New XmlSerializer(GetType(VehicleData))
            Dim reader As TextReader = New StreamReader(FileName)
            Dim instance = CType(ser.Deserialize(reader), VehicleData)
            reader.Close()
            Return instance
        Catch ex As Exception
            Return New VehicleData(FileName)
        End Try
    End Function

End Structure

Public Structure VsColor

    Public Red As Integer
    Public Green As Integer
    Public Blue As Integer

    Public Sub New(r As Integer, g As Integer, b As Integer)
        Red = r
        Green = g
        Blue = b
    End Sub

End Structure

Public Enum eOwner
    Nobody = -1
    Michael
    Franklin
    Trevor
    Others
End Enum