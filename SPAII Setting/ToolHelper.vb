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
