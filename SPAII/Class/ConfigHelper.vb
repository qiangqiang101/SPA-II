Imports GTA

Module ConfigHelper

    'Config
    Public config As ScriptSettings = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

    Public DebugMode As Boolean = False
    Public OnlineMap As Boolean = True
    Public SoundVolume As Integer = 100

    Public Sub LoadModConfig()
        config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

        SoundVolume = config.GetValue(Of Integer)("SOUND", "Volume", 100)
        DebugMode = config.GetValue(Of Boolean)("SETTING", "DebugMode", False)
        OnlineMap = config.GetValue(Of Boolean)("SETTING", "OnlineMap", True)
    End Sub

    Public Sub GenerateModConfig()
        If Not IO.File.Exists("scripts\SPA II\modconfig.ini") Then
            config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

            config.SetValue(Of Integer)("SOUND", "Volume", 100)

            config.SetValue(Of Boolean)("SETTING", "OnlineMap", True)
            config.SetValue(Of Boolean)("SETTING", "HideBlipsOnMission", True)
            config.SetValue(Of Boolean)("SETTING", "DebugMode", False)

            Dim cutProp() As Integer = {82, 88, 91, 93}
            For i As Integer = 1 To 95
                If Not cutProp.Contains(i) Then
                    config.SetValue(Of eOwner)("BUILDING", $"MP_PROP_{i}", eOwner.Nobody)
                End If
            Next

            config.SetValue("IPL", "MP_PROP_79", "apa_v_mp_h_01_a")
            config.SetValue("IPL", "MP_PROP_80", "apa_v_mp_h_01_b")
            config.SetValue("IPL", "MP_PROP_81", "apa_v_mp_h_01_c")

            config.SetValue(Of Boolean)("APARTMENT", "3AST", True)
            config.SetValue(Of Boolean)("APARTMENT", "4IWY", True)
            config.SetValue(Of Boolean)("APARTMENT", "DPHS", True)
            config.SetValue(Of Boolean)("APARTMENT", "ESTS", True)
            config.SetValue(Of Boolean)("APARTMENT", "RCMC", True)
            config.SetValue(Of Boolean)("APARTMENT", "TSTS", True)
            config.SetValue(Of Boolean)("APARTMENT", "WZPZ", True)
            config.SetValue(Of Boolean)("APARTMENT", "2862HCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "2866HCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "2868HCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "2874HCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "2113MWTD", True)
            config.SetValue(Of Boolean)("APARTMENT", "2117MTRD", True)
            config.SetValue(Of Boolean)("APARTMENT", "2044NCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "2045NCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "3677WMDR", True)
            config.SetValue(Of Boolean)("APARTMENT", "3655WODR", True)
            config.SetValue(Of Boolean)("APARTMENT", "0115BCAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "DMTR", True)
            config.SetValue(Of Boolean)("APARTMENT", "4HMDR", True)
            config.SetValue(Of Boolean)("APARTMENT", "0604LLBL", True)
            config.SetValue(Of Boolean)("APARTMENT", "0184MTRD", True)
            config.SetValue(Of Boolean)("APARTMENT", "1162PWST", True)
            config.SetValue(Of Boolean)("APARTMENT", "4401PPDR", True)
            config.SetValue(Of Boolean)("APARTMENT", "4584PPDR", True)
            config.SetValue(Of Boolean)("APARTMENT", "0504SMMD", True)
            config.SetValue(Of Boolean)("APARTMENT", "0325SRFD", True)
            config.SetValue(Of Boolean)("APARTMENT", "0605SNAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "12STCR", True)
            config.SetValue(Of Boolean)("APARTMENT", "TRYL", True)
            config.SetValue(Of Boolean)("APARTMENT", "1115BDPR", True)
            config.SetValue(Of Boolean)("APARTMENT", "1561SVTS", True)
            config.SetValue(Of Boolean)("APARTMENT", "1237PPRS", True)
            config.SetValue(Of Boolean)("APARTMENT", "0069CGAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "2143LLBL", True)
            config.SetValue(Of Boolean)("APARTMENT", "1893GSAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "0232PLTB", True)
            config.SetValue(Of Boolean)("APARTMENT", "0112SRFD", True)
            config.SetValue(Of Boolean)("APARTMENT", "2057VPCB", True)
            config.SetValue(Of Boolean)("APARTMENT", "140ZCDA", True)
            config.SetValue(Of Boolean)("APARTMENT", "MRTH", True)
            config.SetValue(Of Boolean)("APARTMENT", "U2PS", True)
            config.SetValue(Of Boolean)("APARTMENT", "331SPST", True)
            config.SetValue(Of Boolean)("APARTMENT", "U76GP", True)
            config.SetValue(Of Boolean)("APARTMENT", "133XCTW", True)
            config.SetValue(Of Boolean)("APARTMENT", "1623SSBS", True)
            config.SetValue(Of Boolean)("APARTMENT", "0552RLSB", True)
            config.SetValue(Of Boolean)("APARTMENT", "U14PS", True)
            config.SetValue(Of Boolean)("APARTMENT", "1905DVAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "0432DVAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "U1OF", True)
            config.SetValue(Of Boolean)("APARTMENT", "4531DST", True)
            config.SetValue(Of Boolean)("APARTMENT", "8754RT68", True)
            config.SetValue(Of Boolean)("APARTMENT", "870R68A", True)
            config.SetValue(Of Boolean)("APARTMENT", "0897MPBL", True)
            config.SetValue(Of Boolean)("APARTMENT", "GICB", True)
            config.SetValue(Of Boolean)("APARTMENT", "634BDPR", True)
            config.SetValue(Of Boolean)("APARTMENT", "1920SNRW", True)
            config.SetValue(Of Boolean)("APARTMENT", "12LBHA", True)
            config.SetValue(Of Boolean)("APARTMENT", "2000GOHW", True)
            config.SetValue(Of Boolean)("APARTMENT", "0754RLSB", True)
            config.SetValue(Of Boolean)("APARTMENT", "197RT68", True)
            config.SetValue(Of Boolean)("APARTMENT", "1200RT68", True)
            config.SetValue(Of Boolean)("APARTMENT", "1932GSAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "142PLTB", True)
            config.SetValue(Of Boolean)("APARTMENT", "1SBAV", True)
            config.SetValue(Of Boolean)("APARTMENT", "U124PS", True)

            config.Save()
        End If
    End Sub

End Module
