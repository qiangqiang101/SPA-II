Module ToolHelper

    Public SPA1Property As New Dictionary(Of String, String) From {
        {"3_alta_street", "3 Alta Street, Apt. 57"},
        {"4_integrity_way", "4 Integrity Way, Apt. 30"},
        {"4_integrity_way_hl", "4 Integrity Way, Apt. 28"},
        {"0112_south_rockford_dr", "0112 South Rockford Drive, Apt. 13"},
        {"0184_milton_road", "0184 Milton Road, Apt. 13"},
        {"0325_south_rockford_dr", "0325 South Rockford Drive, Apt. 1"},
        {"0604_las_lagunas_blvd", "0604 Las Lagunas Boulevard, Apt. 4"},
        {"2044_north_conker", "2044 North Conker Avenue"},
        {"2045_north_conker", "2045 North Conker Avenue"},
        {"2113_mad_wayne", "2113 Mad Wayne Thunder Drive"},
        {"2117_milton_road", "2117 Milton Road"},
        {"2143_las_lagunas_blvd", "2143 Las Lagunas Boulevard, Apt. 9"},
        {"2862_hillcreast_ave", "2862 Hillcrest Avenue"},
        {"2868_hillcreast_ave", "2868 Hillcrest Avenue"},
        {"2874_hillcreast_ave", "2874 Hillcrest Avenue"},
        {"3655_wild_oats", "3655 Wild Oats Drive"},
        {"3677_whispymound", "3677 Whispymound Drive"},
        {"4401_procopio_dr", "4401 Procopio Drive"},
        {"4584_procopio_dr", "4584 Procopio Drive"},
        {"bay_city_ave", "0115 Bay City Avenue, Apt. 45"},
        {"blvd_del_perro", "1115 Boulevard Del Perro, Apt. 18"},
        {"cougar_ave", "0069 Cougar Avenue, Apt. 19"},
        {"del_perro_heights", "Del Perro Heights, Apt. 7"},
        {"del_perro_heights_hl", "Del Perro Heights, Apt. 4"},
        {"dream_tower", "Dream Tower, Apt. 15"},
        {"eclipse_tower", "Eclipse Tower, Apt. 8"},
        {"eclipse_tower_hl", "Eclipse Tower, Apt. 3"},
        {"eclipse_tower_ps1", "Eclipse Tower, Penthouse Suite 1"},
        {"eclipse_tower_ps2", "Eclipse Tower, Penthouse Suite 2"},
        {"eclipse_tower_ps3", "Eclipse Tower, Penthouse Suite 3"},
        {"grapeseed_ave", "1893 Grapeseed Avenue"},
        {"hangman_ave", "4 Hangman Avenue"},
        {"paleto_blvd", "0232 Paleto Boulevard"},
        {"power_st", "1162 Power Street, Apt. 3"},
        {"prosperity_st", "1237 Prosperity Street, Apt. 21"},
        {"richard_majestic", "Richards Majestic, Apt. 4"},
        {"richard_majestic_hl", "Richards Majestic, Apt. 2"},
        {"san_vitas_st", "1561 San Vitas Street Apt. 2"},
        {"south_mo_milton_dr", "0504 South Mo Milton Drive, Apt. 1"},
        {"spanish_ave", "0605 Spanish Avenue, Apt. 1"},
        {"sustancia_rd", "12 Sustancia Road"},
        {"the_royale", "The Royale, Apt. 19"},
        {"tinsel_tower", "Tinsel Tower, Apt. 29"},
        {"tinsel_tower_hl", "Tinsel Tower, Apt. 42"},
        {"vespucci_blvd", "2057 Vespucci Boulevard, Apt. 1"},
        {"weazel_plaza", "Weazel Plaza, Apt. 70"},
        {"zancudo_ave", "140 Zancudo Avenue"}}

    Public SPA2Property As New Dictionary(Of String, String()) From {
        {"0069_cougar_ave_19", {"0069 Cougar Ave, Apt 19", 2, 21}},
        {"0112_s_rockford_dr_13", {"0112 S Rockford Dr, Apt 13", 2, 19}},
        {"0115_bay_city_ave_45", {"0115 Bay City Ave, Apt 45", 6, 14}},
        {"0120_murrieta_heights", {"0120 Murrieta Heights", 10, 24}},
        {"0184_milton_rd_13", {"0184 Milton Rd, Apt 13", 6, 11}},
        {"0232_poleto_blvd", {"0232 Paleto Blvd", 2, 76}},
        {"0325_south_rockford_dr", {"0325 South Rockford Dr", 6, 15}},
        {"0432_davis_ave", {"0432 Davis Ave", 6, 33}},
        {"0504_s_mo_milton_dr", {"0504 S Mo Milton Dr", 6, 13}},
        {"0552_roy_lowenstein_blvd", {"0552 Roy Lowenstein Blvd", 6, 32}},
        {"0604_las_lagunas_blvd_4", {"0604 Las Lagunas Blvd, Apt 4", 6, 10}},
        {"0605_spanish_ave_1", {"0605 Spanish Ave, Apt 1", 6, 9}},
        {"0754_roy_lowenstein_blvd", {"0754 Roy Lowenstein Blvd", 2, 29}},
        {"0897_mirror_park_blvd", {"0897 Mirror Park Blvd", 2, 66}},
        {"1_strawberry_ave", {"1 Strawberry Ave", 2, 45}},
        {"1115_blvd_del_perro_18", {"1115 Blvd Del Perro, Apt 18", 2, 23}},
        {"1162_power_street_3", {"1162 Power St, Apt 3", 6, 8}},
        {"12_little_bighorn_ave", {"12 Little Bighorn Ave", 2, 30}},
        {"12_sustancia_rd", {"12 Sustancia Rd", 6, 73}},
        {"1200_route_68", {"1200 Route 68", 2, 52}},
        {"1237_prosperity_st_21", {"1237 Prosperity St, Apt 21", 2, 22}},
        {"1337_exceptionalists_way", {"1337 Exceptionalists Way", 10, 62}},
        {"140_zancudo_ave", {"140 Zancudo Ave", 2, 77}},
        {"142_paleto_blvd", {"142 Paleto Blvd", 2, 44}},
        {"1561_san_vitas_st_2", {"1561 San Vitas St, Apt 2", 2, 18}},
        {"1623_south_shambles_st", {"1623 South Shambles St", 10, 60}},
        {"1893_grapeseed_ave", {"1893 Grapeseed Ave", 2, 78}},
        {"1905_davis_ave", {"1905 Davis Ave", 6, 59}},
        {"1920_senora_way", {"1920 Senora Way", 2, 48}},
        {"1932_grapeseed_ave", {"1932 Grapeseed Ave", 2, 46}},
        {"197_route_68", {"197 Route 68", 2, 50}},
        {"2000_great_ocean_highway", {"2000 Great Ocean Highway", 2, 49}},
        {"2044_north_conker_ave", {"2044 North Conker Avenue", 6, 84}},
        {"2045_north_conker_ave", {"2045 North Conker Avenue", 6, 95}},
        {"2057_vespucci_blvd", {"2057 Vespucci Blvd, Apt 1", 2, 20}},
        {"2113_mad_wayne_thunder_dr", {"2113 Mad Wayne Thunder Drive", 6, 94}},
        {"2117_milton_rd", {"2117 Milton Road", 6, 89}},
        {"2143_las_lagunas_blvd_9", {"2143 Las Lagunas Blvd, Apt 9", 2, 17}},
        {"2862_hillcrest_ave", {"2862 Hillcrest Avenue", 6, 86}},
        {"2866_hillcrest_ave", {"2866 Hillcrest Avenue", 6, 90}},
        {"2868_hillcrest_ave", {"2868 Hillcrest Avenue", 6, 85}},
        {"2874_hillcrest_ave", {"2874 Hillcrest Avenue", 6, 92}},
        {"3_alta_st_apt_10", {"3 Alta St, Apt 10", 10, 5}},
        {"3_alta_st_apt_57", {"3 Alta St, Apt 57", 10, 6}},
        {"331_supply_st", {"331 Supply St", 10, 27}},
        {"3655_wild_oats_dr", {"3655 Wild Oats Drive", 6, 83}},
        {"3677_whispymound_dr", {"3677 Whispymound Drive", 6, 87}},
        {"4_hangman_ave", {"4 Hangman Ave", 6, 72}},
        {"4_integrity_way_apt_28", {"4 Integrity Way, Apt 28", 10, 71}},
        {"4_integrity_way_apt_30", {"4 Integrity Way, Apt 30", 10, 38}},
        {"4_integrity_way_apt_35", {"4 Integrity Way, Apt 35", 10, 39}},
        {"4401_procopio_dr", {"4401 Procopio Dr", 6, 75}},
        {"4531_dry_dock_st", {"4531 Dry Dock St", 6, 61}},
        {"4584_procopio_dr", {"4584 Procopio Dr", 6, 74}},
        {"634_blvd_del_perro", {"634 Blvd Del Perro", 2, 65}},
        {"870_route_68_approach", {"870 Route 68 Approach", 6, 51}},
        {"8754_route_68", {"8754 Route 68", 6, 57}},
        {"del_perro_hts_apt_20", {"Del Perro Heights, Apt 20", 10, 7}},
        {"del_perro_hts_apt_4", {"Del Perro Heights, Apt 4", 10, 68}},
        {"del_perro_hts_apt_7", {"Del Perro Heights, Apt 7", 10, 34}},
        {"dream_tower_15", {"Dream Tower, Apt 15", 6, 16}},
        {"eclipse_towers_apt_3", {"Eclipse Towers, Apt 3", 10, 67}},
        {"eclipse_towers_apt_31", {"Eclipse Towers, Apt 31", 10, 1}},
        {"eclipse_towers_apt_40", {"Eclipse Towers, Apt 40", 10, 3}},
        {"eclipse_towers_apt_5", {"Eclipse Towers, Apt 5", 10, 4}},
        {"eclipse_towers_apt_9", {"Eclipse Towers, Apt 9", 10, 2}},
        {"eclipse_towers_phs_1", {"Eclipse Towers, Penthouse Suite 1", 10, 79}},
        {"eclipse_towers_phs_2", {"Eclipse Towers, Penthouse Suite 2", 10, 80}},
        {"eclipse_towers_phs_3", {"Eclipse Towers, Penthouse Suite 3", 10, 81}},
        {"garage_innocence_blvd", {"Garage Innocence Blvd", 2, 64}},
        {"richards_majestic_apt_2", {"Richards Majestic, Apt 2", 10, 69}},
        {"richards_majestic_apt_4", {"Richards Majestic, Apt 4", 10, 40}},
        {"richards_majestic_apt_51", {"Richards Majestic, Apt 51", 10, 41}},
        {"the_royale_12", {"The Royale, Apt 19", 6, 12}},
        {"tinsel_towers_apt_29", {"Tinsel Towers, Apt 29", 10, 43}},
        {"tinsel_towers_apt_42", {"Tinsel Towers, Apt 42", 10, 70}},
        {"tinsel_towers_apt_45", {"Tinsel Towers, Apt 45", 10, 42}},
        {"unit_1_olympic_fwy", {"Unit 1 Olympic Fwy", 6, 28}},
        {"unit_124_popular_st", {"Unit 124 Popular St", 2, 31}},
        {"unit_14_popular_st", {"Unit 14 Popular St", 6, 25}},
        {"unit_2_popular_st", {"Unit 2 Popular St", 10, 26}},
        {"unit_76_greenwich_parkway", {"Unit 76 Greenwich Parkway", 10, 63}},
        {"weazel_plaza_apt_70", {"Weazel Plaza, Apt 70", 10, 36}},
        {"weazel_plaze_apt_101", {"Weazel Plaza, Apt 101", 10, 35}},
        {"weazel_plaze_apt_26", {"Weazel Plaza, Apt 26", 10, 37}}}

    Public AptStyleDic As New Dictionary(Of String, String) From {
        {"Modern", "apa_v_mp_h_01_"}, {"Moody", "apa_v_mp_h_02_"}, {"Vibrant", "apa_v_mp_h_03_"}, {"Sharp", "apa_v_mp_h_04_"},
        {"Monochrome", "apa_v_mp_h_05_"}, {"Seductive", "apa_v_mp_h_06_"}, {"Regal", "apa_v_mp_h_07_"}, {"Aqua", "apa_v_mp_h_08_"}}

    Public BuildingDic As New Dictionary(Of String, String) From {
        {"Eclipse Towers, Apt 31", "MP_PROP_1"},
        {"Eclipse Towers, Apt 9", "MP_PROP_2"},
        {"Eclipse Towers, Apt 40", "MP_PROP_3"},
        {"Eclipse Towers, Apt 5", "MP_PROP_4"},
        {"3 Alta St, Apt 10", "MP_PROP_5"},
        {"3 Alta St, Apt 57", "MP_PROP_6"},
        {"Del Perro Heights, Apt 20", "MP_PROP_7"},
        {"1162 Power St, Apt 3", "MP_PROP_8"},
        {"0605 Spanish Ave, Apt 1", "MP_PROP_9"},
        {"0604 Las Lagunas Blvd, Apt 4", "MP_PROP_10"},
        {"0184 Milton Rd, Apt 13", "MP_PROP_11"},
        {"The Royale, Apt 19", "MP_PROP_12"},
        {"0504 S Mo Milton Dr", "MP_PROP_13"},
        {"0115 Bay City Ave, Apt 45", "MP_PROP_14"},
        {"0325 South Rockford Dr", "MP_PROP_15"},
        {"Dream Tower, Apt 15", "MP_PROP_16"},
        {"2143 Las Lagunas Blvd, Apt 9", "MP_PROP_17"},
        {"1561 San Vitas St, Apt 2", "MP_PROP_18"},
        {"0112 S Rockford Dr, Apt 13", "MP_PROP_19"},
        {"2057 Vespucci Blvd, Apt 1", "MP_PROP_20"},
        {"0069 Cougar Ave, Apt 19", "MP_PROP_21"},
        {"1237 Prosperity St, Apt 21", "MP_PROP_22"},
        {"1115 Blvd Del Perro, Apt 18", "MP_PROP_23"},
        {"0120 Murrieta Heights", "MP_PROP_24"},
        {"Unit 14 Popular St", "MP_PROP_25"},
        {"Unit 2 Popular St", "MP_PROP_26"},
        {"331 Supply St", "MP_PROP_27"},
        {"Unit 1 Olympic Fwy", "MP_PROP_28"},
        {"0754 Roy Lowenstein Blvd", "MP_PROP_29"},
        {"12 Little Bighorn Ave", "MP_PROP_30"},
        {"Unit 124 Popular St", "MP_PROP_31"},
        {"0552 Roy Lowenstein Blvd", "MP_PROP_32"},
        {"0432 Davis Ave", "MP_PROP_33"},
        {"Del Perro Heights, Apt 7", "MP_PROP_34"},
        {"Weazel Plaza, Apt 101", "MP_PROP_35"},
        {"Weazel Plaza, Apt 70", "MP_PROP_36"},
        {"Weazel Plaza, Apt 26", "MP_PROP_37"},
        {"4 Integrity Way, Apt 30", "MP_PROP_38"},
        {"4 Integrity Way, Apt 35", "MP_PROP_39"},
        {"Richards Majestic, Apt 4", "MP_PROP_40"},
        {"Richards Majestic, Apt 51", "MP_PROP_41"},
        {"Tinsel Towers, Apt 45", "MP_PROP_42"},
        {"Tinsel Towers, Apt 29", "MP_PROP_43"},
        {"142 Paleto Blvd", "MP_PROP_44"},
        {"1 Strawberry Ave", "MP_PROP_45"},
        {"1932 Grapeseed Ave", "MP_PROP_46"},
        {"1984 Senora Way", "MP_PROP_47"},
        {"1920 Senora Way", "MP_PROP_48"},
        {"2000 Great Ocean Highway", "MP_PROP_49"},
        {"197 Route 68", "MP_PROP_50"},
        {"870 Route 68 Approach", "MP_PROP_51"},
        {"1200 Route 68", "MP_PROP_52"},
        {"3 Zancudo Avenue", "MP_PROP_53"},
        {"1001 Panorama Drive", "MP_PROP_54"},
        {"100 Marina Drive", "MP_PROP_55"},
        {"Marlowe Vineyard Garage", "MP_PROP_56"},
        {"8754 Route 68", "MP_PROP_57"},
        {"Runway 1 Unit 5", "MP_PROP_58"},
        {"1905 Davis Ave", "MP_PROP_59"},
        {"1623 South Shambles St", "MP_PROP_60"},
        {"4531 Dry Dock St", "MP_PROP_61"},
        {"1337 Exceptionalists Way", "MP_PROP_62"},
        {"Unit 76 Greenwich Parkway", "MP_PROP_63"},
        {"Garage Innocence Blvd", "MP_PROP_64"},
        {"634 Blvd Del Perro", "MP_PROP_65"},
        {"0897 Mirror Park Blvd", "MP_PROP_66"},
        {"Eclipse Towers, Apt 3", "MP_PROP_67"},
        {"Del Perro Heights, Apt 4", "MP_PROP_68"},
        {"Richards Majestic, Apt 2", "MP_PROP_69"},
        {"Tinsel Towers, Apt 42", "MP_PROP_70"},
        {"4 Integrity Way, Apt 28", "MP_PROP_71"},
        {"4 Hangman Ave", "MP_PROP_72"},
        {"12 Sustancia Rd", "MP_PROP_73"},
        {"4584 Procopio Dr", "MP_PROP_74"},
        {"4401 Procopio Dr", "MP_PROP_75"},
        {"0232 Paleto Blvd", "MP_PROP_76"},
        {"140 Zancudo Ave", "MP_PROP_77"},
        {"1893 Grapeseed Ave", "MP_PROP_78"},
        {"Eclipse Towers, Penthouse Suite 1", "MP_PROP_79"},
        {"Eclipse Towers, Penthouse Suite 2", "MP_PROP_80"},
        {"Eclipse Towers, Penthouse Suite 3", "MP_PROP_81"},
        {"3655 Wild Oats Drive", "MP_PROP_83"},
        {"2044 North Conker Avenue", "MP_PROP_84"},
        {"2868 Hillcrest Avenue", "MP_PROP_85"},
        {"2862 Hillcrest Avenue", "MP_PROP_86"},
        {"3677 Whispymound Drive", "MP_PROP_87"},
        {"2117 Milton Road", "MP_PROP_89"},
        {"2866 Hillcrest Avenue", "MP_PROP_90"},
        {"2874 Hillcrest Avenue", "MP_PROP_92"},
        {"2113 Mad Wayne Thunder Drive", "MP_PROP_94"},
        {"2045 North Conker Avenue", "MP_PROP_95"}}

    Public Function GetAptStyle(stylekey As String, aptid As Integer) As String
        Dim abc As String = "a"
        Select Case aptid
            Case 79
                abc = "a"
            Case 80
                abc = "b"
            Case 81
                abc = "c"
        End Select
        Return $"{AptStyleDic.Item(stylekey)}{abc}"
    End Function

    Public Function ConvertAptStyle(style As String) As String
        Try
            Dim trimmed As String = style.Substring(0, style.Length - 2)
            Return AptStyleDic.Where(Function(x) x.Value = trimmed).FirstOrDefault.Key
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GetAvailableIndex(vdList As List(Of VehicleData), garageType As Integer) As Integer
        Dim existingIndexes As New List(Of Integer)
        For Each vd In vdList
            existingIndexes.Add(vd.Index)
        Next
        Dim missingIndexes = Enumerable.Range(0, garageType - 0 + 1).Except(existingIndexes)
        Return missingIndexes.FirstOrDefault
    End Function

    Public Function Vehicles(garagePath As String) As List(Of VehicleData)
        Dim procFile As String = Nothing
        Dim list As New List(Of VehicleData)
        Try
            For Each file As String In IO.Directory.GetFiles(garagePath, "*.xml")
                procFile = file
                Dim vd As VehicleData = New VehicleData(file).Instance
                If Not list.Contains(vd) Then list.Add(vd)
            Next
        Catch ex As Exception
            MsgBox($"{ex.Message}{procFile}{ex.StackTrace}", MsgBoxStyle.Critical, "ERR")
        End Try
        Return list
    End Function

End Module
