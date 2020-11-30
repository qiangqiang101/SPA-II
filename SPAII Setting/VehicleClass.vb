Public Class VehicleClass

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
    Public HasNitro As Integer
    Public Livery1 As Integer
    Public ApartmentID As Integer
    Public UniqueID As Integer

    Public Sub New(vehicle As VehicleData, _owner As eOwner)
        Try
            Index = vehicle.Index
            Make = vehicle.Make
            Name = vehicle.Name
            Hash = vehicle.Hash
            Owner = _owner
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
        Catch ex As Exception
            MsgBox($"{ex.Message}{ex.HResult}{ex.StackTrace}", MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

End Class
