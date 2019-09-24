Imports GTA
Imports GTA.Math
Imports Metadata

Public Class VehicleClass

    Public Make As String
    Public Name As String
    Public Hash As Integer
    Public Owner As Integer
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
    Public Extra0, Extra1, Extra2, Extra3, Extra4, Extra5, Extra6, Extra7, Extra8, Extra9, Extra10 As Boolean
    Public RoofState As Integer
    Public HasNitro As Boolean
    Public Livery1 As Integer

    Public Blip As Blip

    Public Sub New(_make As String, _name As String, _hash As Integer, own As Integer, arl As Integer, ssp As Integer, arm As Integer, brk As Integer, eng As Integer,
                   trn As Integer, fbp As Integer, rbp As Integer, ssk As Integer, trm As Integer, enb As Integer, air As Integer, stt As Integer, csl As Integer,
                   dbd As Integer, ddg As Integer, onm As Integer, sit As Integer, stw As Integer, tdg As Integer, trc As Integer, phd As Integer, vtp As Integer,
                   nmp As Integer, pnm As String, wht As Integer, fwh As Integer, bwh As Integer, whv As Boolean, hlg As Boolean, fnn As Boolean, bnn As Boolean,
                   lnn As Boolean, rnn As Boolean, arc As Integer, exh As Integer, lfd As Integer, rfd As Integer, dsk As Integer, fra As Integer, grl As Integer,
                   hud As Integer, hon As Integer, hyd As Integer, lv0 As Integer, plq As Integer, rof As Integer, spk As Integer, spl As Integer, tnk As Integer,
                   trk As Integer, win As Integer, tub As Boolean, tnt As Integer, co1 As Integer, co2 As Integer, cop As Integer, cor As Integer, col As Integer,
                   nlc As VsColor, tsc As VsColor, smk As Boolean, lv2 As Integer, coh As Integer, bpt As Boolean, cc1 As VsColor, cc2 As VsColor, hc1 As Boolean,
                   hc2 As Boolean, ex0 As Boolean, ex1 As Boolean, ex2 As Boolean, ex3 As Boolean, ex4 As Boolean, ex5 As Boolean, ex6 As Boolean, ex7 As Boolean,
                   ex8 As Boolean, ex9 As Boolean, ex10 As Boolean, rfs As Integer, nos As Boolean, lv1 As Integer)
        Make = _make
        Name = _name
        Hash = _hash
        Owner = own
        Aerials = arl
        Suspension = ssp
        Armor = arm
        Brakes = brk
        Engine = eng
        Transmission = trn
        FrontBumper = fbp
        RearBumper = rbp
        SideSkirt = ssk
        Trim = trm
        EngineBlock = enb
        AirFilter = air
        Struts = stt
        ColumnShifterLevers = csl
        Dashboard = dbd
        DialDesign = ddg
        Ornaments = onm
        Seats = sit
        SteeringWheel = stw
        TrimDesign = tdg
        TrimColor = trc
        PlateHolder = phd
        VanityPlates = vtp
        NumberPlate = nmp
        PlateNumber = pnm
        WheelType = wht
        Frontwheels = fwh
        BackWheels = bwh
        WheelsVariation = whv
        Headlights = hlg
        FrontNeon = fnn
        BackNeon = bnn
        LeftNeon = lnn
        RightNeon = rnn
        ArchCover = arc
        Exhaust = exh
        Fender = lfd
        RightFender = rfd
        DoorSpeakers = dsk
        Frame = fra
        Grille = grl
        Hood = hud
        Horn = hon
        Hydraulics = hyd
        Livery = lv0
        Plaques = plq
        Roof = rof
        Speakers = spk
        Spoiler = spl
        Tank = tnk
        Trunk = trk
        Windows = win
        Turbo = tub
        Tint = tnt
        PrimaryColor = co1
        SecondaryColor = co2
        PearlescentColor = cop
        RimColor = cor
        LightsColor = col
        NeonLightsColor = nlc
        TireSmokeColor = tsc
        Tiresmoke = smk
        Livery2 = lv2
        HeadlightsColor = coh
        BulletProofTires = bpt
        CustomPrimaryColor = cc1
        CustomSecondaryColor = cc2
        HasCustomPrimaryColor = hc1
        HasCustomSecondaryColor = hc2
        Extra0 = ex0
        Extra1 = ex1
        Extra2 = ex2
        Extra3 = ex3
        Extra4 = ex4
        Extra5 = ex5
        Extra6 = ex6
        Extra7 = ex7
        Extra8 = ex8
        Extra9 = ex9
        Extra10 = ex10
        RoofState = rfs
        Livery1 = lv1
        If IsNitroModInstalled() Then HasNitro = nos Else HasNitro = False
    End Sub

    Public Sub New(vehicle As Vehicle, _owner As Integer)
        Try
            Make = vehicle.Make
            Name = vehicle.FriendlyName
            Hash = vehicle.Model.Hash
            Owner = _owner
            Aerials = vehicle.GetMod(VehicleMod.Aerials)
            Suspension = vehicle.GetMod(VehicleMod.Suspension)
            Armor = vehicle.GetMod(VehicleMod.Armor)
            Brakes = vehicle.GetMod(VehicleMod.Brakes)
            Engine = vehicle.GetMod(VehicleMod.Engine)
            Transmission = vehicle.GetMod(VehicleMod.Transmission)
            FrontBumper = vehicle.GetMod(VehicleMod.FrontBumper)
            RearBumper = vehicle.GetMod(VehicleMod.RearBumper)
            SideSkirt = vehicle.GetMod(VehicleMod.SideSkirt)
            Trim = vehicle.GetMod(VehicleMod.Trim)
            EngineBlock = vehicle.GetMod(VehicleMod.EngineBlock)
            AirFilter = vehicle.GetMod(VehicleMod.AirFilter)
            Struts = vehicle.GetMod(VehicleMod.Struts)
            ColumnShifterLevers = vehicle.GetMod(VehicleMod.ColumnShifterLevers)
            Dashboard = vehicle.GetMod(VehicleMod.Dashboard)
            DialDesign = vehicle.GetMod(VehicleMod.DialDesign)
            Ornaments = vehicle.GetMod(VehicleMod.Ornaments)
            Seats = vehicle.GetMod(VehicleMod.Seats)
            SteeringWheel = vehicle.GetMod(VehicleMod.SteeringWheels)
            TrimDesign = vehicle.GetMod(VehicleMod.TrimDesign)
            TrimColor = vehicle.TrimColor
            PlateHolder = vehicle.GetMod(VehicleMod.PlateHolder)
            VanityPlates = vehicle.GetMod(VehicleMod.VanityPlates)
            NumberPlate = vehicle.NumberPlateType
            PlateNumber = vehicle.NumberPlate
            WheelType = vehicle.WheelType
            Frontwheels = vehicle.GetMod(VehicleMod.FrontWheels)
            BackWheels = vehicle.GetMod(VehicleMod.BackWheels)
            WheelsVariation = vehicle.WheelsVariation
            Headlights = vehicle.IsToggleModOn(VehicleToggleMod.XenonHeadlights)
            FrontNeon = vehicle.IsNeonLightsOn(VehicleNeonLight.Front)
            BackNeon = vehicle.IsNeonLightsOn(VehicleNeonLight.Back)
            LeftNeon = vehicle.IsNeonLightsOn(VehicleNeonLight.Left)
            RightNeon = vehicle.IsNeonLightsOn(VehicleNeonLight.Right)
            ArchCover = vehicle.GetMod(VehicleMod.ArchCover)
            Exhaust = vehicle.GetMod(VehicleMod.Exhaust)
            Fender = vehicle.GetMod(VehicleMod.Fender)
            RightFender = vehicle.GetMod(VehicleMod.RightFender)
            DoorSpeakers = vehicle.GetMod(VehicleMod.DoorSpeakers)
            Frame = vehicle.GetMod(VehicleMod.Frame)
            Grille = vehicle.GetMod(VehicleMod.Grille)
            Hood = vehicle.GetMod(VehicleMod.Hood)
            Horn = vehicle.GetMod(VehicleMod.Horns)
            Hydraulics = vehicle.GetMod(VehicleMod.Hydraulics)
            Livery = vehicle.GetMod(VehicleMod.Livery)
            Plaques = vehicle.GetMod(VehicleMod.Plaques)
            Roof = vehicle.GetMod(VehicleMod.Roof)
            Speakers = vehicle.GetMod(VehicleMod.Speakers)
            Spoiler = vehicle.GetMod(VehicleMod.Spoilers)
            Tank = vehicle.GetMod(VehicleMod.Tank)
            Trunk = vehicle.GetMod(VehicleMod.Trunk)
            Windows = vehicle.GetMod(VehicleMod.Windows)
            Turbo = vehicle.IsToggleModOn(VehicleToggleMod.Turbo)
            Tint = vehicle.WindowTint
            PrimaryColor = vehicle.PrimaryColor
            SecondaryColor = vehicle.SecondaryColor
            PearlescentColor = vehicle.PearlescentColor
            RimColor = vehicle.RimColor
            LightsColor = vehicle.DashboardColor
            NeonLightsColor = vehicle.NeonLightsColor.ToVsColor
            TireSmokeColor = vehicle.TireSmokeColor.ToVsColor
            Tiresmoke = vehicle.IsToggleModOn(VehicleToggleMod.TireSmoke)
            Livery2 = vehicle.Livery2
            HeadlightsColor = vehicle.XenonHeadlightsColor
            BulletProofTires = vehicle.CanTiresBurst
            CustomPrimaryColor = vehicle.CustomPrimaryColor.ToVsColor
            CustomSecondaryColor = vehicle.CustomSecondaryColor.ToVsColor
            HasCustomPrimaryColor = vehicle.IsPrimaryColorCustom
            HasCustomSecondaryColor = vehicle.IsSecondaryColorCustom
            Extra0 = vehicle.IsExtraOn(0)
            Extra1 = vehicle.IsExtraOn(1)
            Extra2 = vehicle.IsExtraOn(2)
            Extra3 = vehicle.IsExtraOn(3)
            Extra4 = vehicle.IsExtraOn(4)
            Extra5 = vehicle.IsExtraOn(5)
            Extra6 = vehicle.IsExtraOn(6)
            Extra7 = vehicle.IsExtraOn(7)
            Extra8 = vehicle.IsExtraOn(8)
            Extra9 = vehicle.IsExtraOn(9)
            Extra10 = vehicle.IsExtraOn(10)
            RoofState = vehicle.RoofState
            Livery1 = vehicle.Livery
            If IsNitroModInstalled() Then HasNitro = vehicle.GetBool(nitroModDecor) Else HasNitro = False
        Catch ex As Exception
            Logger.Log($"{ex.Message}{ex.HResult}{ex.StackTrace}")
        End Try
    End Sub

End Class
