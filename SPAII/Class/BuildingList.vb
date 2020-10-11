Imports GTA
Imports GTA.Math

Module BuildingList

    Public Sub LoadBuildings()
        buildings.Clear()

        Try
#Region "High End Apartments"
            '3 Alta Street
            Dim _3AltaStreet57 As New ApartmentClass()
            With _3AltaStreet57
                .Name = "MP_PROP_6"
                .Description = "MP_PROP_6DES"
                .Price = 223000
                .SavePos = New Vector3(-284.4262, -958.5359, 86.3036)
                .ApartmentInPos = New Vector3(-281.0908, -943.2817, 92.5108)
                .ApartmentOutPos = New Vector3(-279.2097, -940.9369, 92.5108)
                .WardrobePos = New Quaternion(-277.7127, -960.4503, 86.3143, 328.5379)
                .GarageFilePath = "3_alta_st_apt_57"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _3AltaStreet As New BuildingClass()
            With _3AltaStreet
                .Name = "3 Alta St"
                .BuildingInPos = New Vector3(-261.768, -970.4873, 31.2199)
                .BuildingOutPos = New Quaternion(-258.1236, -969.0657, 31.2199, 0F)
                .GarageInPos = New Vector3(-279.7589, -995.9545, 24.5305)
                .GarageOutPos = New Quaternion(-271.5633, -999.2233, 26.0224, 249.66F)
                .CameraPos = New CameraPRH(New Vector3(-215.2378, -1071.639, 32.85828), New Vector3(22.62831, 0, 26.93762), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"hei_dt1_20_build2", "dt1_20_dt1_emissive_dt1_20"}
                .Apartments = New List(Of ApartmentClass) From {_3AltaStreet57}
            End With
            If Not buildings.Contains(_3AltaStreet) Then buildings.Add(_3AltaStreet)

            '4 Integrity Way       
            Dim _4IntegrityWay30 As New ApartmentClass()
            With _4IntegrityWay30
                .Name = "MP_PROP_38"
                .Description = "MP_PROP_38DES"
                .Price = 476000
                .SavePos = New Vector3(-36.6321, -578.1332, 83.9075)
                .ApartmentInPos = New Vector3(-21.0966, -580.4884, 90.1148)
                .ApartmentOutPos = New Vector3(-18.0797, -582.1524, 90.1148)
                .WardrobePos = New Quaternion(-37.8572, -583.7734, 83.9183, 255.3193)
                .GarageFilePath = "4_integrity_way_apt_30"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _4IntegrityWay28 As New ApartmentClass()
            With _4IntegrityWay28
                .Name = "MP_PROP_71"
                .Description = "MP_PROP_71DES"
                .Price = 952000
                .SavePos = New Vector3(-36.3656, -583.9371, 78.8302)
                .ApartmentInPos = New Vector3(-21.5202, -598.4841, 80.0662)
                .ApartmentOutPos = New Vector3(-24.4089, -597.69, 80.0311)
                .WardrobePos = New Quaternion(-38.1595, -589.3992, 78.8302, 336.2282)
                .GarageFilePath = "4_integrity_way_apt_28"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _4IntegrityWay As New BuildingClass()
            With _4IntegrityWay
                .Name = "4 Integrity Way"
                .BuildingInPos = New Vector3(-48.0058, -587.9324, 37.9529)
                .BuildingOutPos = New Quaternion(-49.3243, -583.1716, 37.0333, 0F)
                .GarageInPos = New Vector3(-73.43955, -489.4017, 43.24729)
                .GarageOutPos = New Quaternion(-24.074, -624.9826, 35.0905, 251.6195F)
                .CameraPos = New CameraPRH(New Vector3(-73.43955, -489.4017, 43.24729), New Vector3(20.34373, 0, -158.8398), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"hei_dt1_03_build1x", "DT1_Emissive_DT1_03_b1", "dt1_03_dt1_Emissive_b1"}
                .Apartments = New List(Of ApartmentClass) From {_4IntegrityWay30, _4IntegrityWay28}
            End With
            If Not buildings.Contains(_4IntegrityWay) Then buildings.Add(_4IntegrityWay)

            'Del Perro Hts
            Dim delPerroHts7 As New ApartmentClass()
            With delPerroHts7
                .Name = "MP_PROP_34"
                .Description = "MP_PROP_34DES"
                .Price = 468000
                .SavePos = New Vector3(-1471.4473, -533.1909, 50.7216)
                .ApartmentInPos = New Vector3(-1460.3659, -522.0636, 56.929)
                .ApartmentOutPos = New Vector3(-1457.5853, -520.3571, 56.929)
                .WardrobePos = New Quaternion(-1467.6958, -537.2778, 50.7325, 314.1525)
                .GarageFilePath = "del_perro_hts_apt_7"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim delPerroHts4 As New ApartmentClass()
            With delPerroHts4
                .Name = "MP_PROP_68"
                .Description = "MP_PROP_68DES"
                .Price = 936000
                .SavePos = New Vector3(-1454.6335, -552.5497, 72.8437)
                .ApartmentInPos = New Vector3(-1458.6523, -531.4198, 74.0796)
                .ApartmentOutPos = New Vector3(-1456.5989, -534.5363, 74.0445)
                .WardrobePos = New Quaternion(-1449.6384, -549.0426, 72.8437, 122.2167)
                .GarageFilePath = "del_perro_hts_apt_4"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim delPerroHts As New BuildingClass()
            With delPerroHts
                .Name = "Del Perro Hts"
                .BuildingInPos = New Vector3(-1443.0578, -544.7794, 34.7418)
                .BuildingOutPos = New Quaternion(-1439.5905, -550.6906, 34.7418, 0F)
                .GarageInPos = New Vector3(-1457.6473, -500.7265, 32.1985)
                .GarageOutPos = New Quaternion(-1457.4394, -490.838, 33.028, 300.666)
                .CameraPos = New CameraPRH(New Vector3(-1392.67, -572.4094, 35.15923), New Vector3(22.16564, 0, 66.90905), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"sm_14_emissive", "hei_sm_14_bld2"}
                .Apartments = New List(Of ApartmentClass) From {delPerroHts7, delPerroHts4}
            End With
            If Not buildings.Contains(delPerroHts) Then buildings.Add(delPerroHts)

            'Eclipse Towers
            Dim eclipseTowers31 As New ApartmentClass()
            With eclipseTowers31
                .Name = "MP_PROP_1"
                .Description = "MP_PROP_1DES"
                .Price = 400000
                .SavePos = New Vector3(-795.527, 337.415, 201.413)
                .ApartmentInPos = New Vector3(-780.152, 340.443, 207.621)
                .ApartmentOutPos = New Vector3(-777.584, 340.172, 207.621)
                .WardrobePos = New Quaternion(-795.0659, 331.7157, 201.4243, 268.5623)
                .GarageFilePath = "eclipse_towers_apt_31"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim eclipseTowers3 As New ApartmentClass()
            With eclipseTowers3
                .Name = "MP_PROP_67"
                .Description = "MP_PROP_67DES"
                .Price = 800000
                .SavePos = New Vector3(-793.2186, 332.4132, 210.7966)
                .ApartmentInPos = New Vector3(-774.3142, 323.8076, 212.0325)
                .ApartmentOutPos = New Vector3(-777.6211, 323.5111, 211.9974)
                .WardrobePos = New Quaternion(-793.4239, 326.7805, 210.7966, 356.4841)
                .GarageFilePath = "eclipse_towers_apt_3"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim eclipseTowersPH1 As New ApartmentClass()
            With eclipseTowersPH1
                .Name = "MP_PROP_79"
                .Description = "MP_PROP_79DES"
                .Price = 985000
                .SavePos = New Vector3(-797.7579, 337.3798, 220.4384)
                .ApartmentInPos = New Vector3(-784.0423, 320.9214, 217.439)
                .ApartmentOutPos = New Vector3(-781.851, 318.094, 217.6388)
                .WardrobePos = New Quaternion(-796.9515, 328.2715, 220.4384, 359.5432)
                .GarageFilePath = "eclipse_towers_phs_1"
                .IPL = "apa_v_mp_h_01_a"
                .AptStyleCam = New CameraPRH(New Vector3(-786.6251, 343.8772, 218.0287), New Vector3(-7.585561, 0, -163.3333), 50.0F)
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.IPL
            End With
            Dim eclipseTowersPH2 As New ApartmentClass()
            With eclipseTowersPH2
                .Name = "MP_PROP_80"
                .Description = "MP_PROP_80DES"
                .Price = 905000
                .SavePos = New Vector3(-763.3478, 320.4298, 199.4861)
                .ApartmentInPos = New Vector3(-776.9169, 336.887, 196.4864)
                .ApartmentOutPos = New Vector3(-779.2371, 339.6224, 196.6866)
                .WardrobePos = New Quaternion(-763.9934, 329.6285, 199.4863, 178.7236)
                .GarageFilePath = "eclipse_towers_phs_2"
                .IPL = "apa_v_mp_h_02_a"
                .AptStyleCam = New CameraPRH(New Vector3(-774.2443, 314.4292, 196.6641), New Vector3(-2.762131, 0, 16.02366), 50.0F)
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.IPL
            End With
            Dim eclipseTowersPH3 As New ApartmentClass()
            With eclipseTowersPH3
                .Name = "MP_PROP_81"
                .Description = "MP_PROP_81DES"
                .Price = 1100000
                .SavePos = New Vector3(-797.7316, 337.315, 190.7134)
                .ApartmentInPos = New Vector3(-784.0712, 320.7265, 187.7136)
                .ApartmentOutPos = New Vector3(-781.9078, 318.1647, 187.9138)
                .WardrobePos = New Quaternion(-796.9515, 328.2715, 190.7134, 359.5432)
                .GarageFilePath = "eclipse_towers_phs_3"
                .IPL = "apa_v_mp_h_03_a"
                .AptStyleCam = New CameraPRH(New Vector3(-786.7924, 343.3035, 187.8668), New Vector3(-1.956791, 0, -163.332), 50.0F)
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.IPL
            End With
            Dim eclipseTowers As New BuildingClass()
            With eclipseTowers
                .Name = "Eclipse Towers"
                .BuildingInPos = New Vector3(-770.258, 313.033, 85.6981)
                .BuildingOutPos = New Quaternion(-773.282, 312.275, 84.698, 0F)
                .GarageInPos = New Vector3(-796.1685, 311.4121, 85.7088)
                .GarageOutPos = New Quaternion(-796.2648, 302.5102, 85.1543, 179.532F)
                .CameraPos = New CameraPRH(New Vector3(-881.4312, 214.6852, 91.3971), New Vector3(25.6109, 0, -39.32376), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ss1_11_flats", "ss1_11_ss1_emissive_a", "ss1_11_detail01b", "ss1_11_Flats_LOD", "SS1_02_Building01_LOD", "SS1_LOD_01_02_08_09_10_11", "SS1_02_SLOD1"}
                .Apartments = New List(Of ApartmentClass) From {eclipseTowers31, eclipseTowers3, eclipseTowersPH1, eclipseTowersPH2, eclipseTowersPH3}
            End With
            If Not buildings.Contains(eclipseTowers) Then buildings.Add(eclipseTowers)

            'Richards Majestic
            Dim richardMajestic4 As New ApartmentClass()
            With richardMajestic4
                .Name = "MP_PROP_40"
                .Description = "MP_PROP_40DES"
                .Price = 484000
                .SavePos = New Vector3(-900.8789, -374.416, 79.2731)
                .ApartmentInPos = New Vector3(-913.1502, -384.5727, 85.4804)
                .ApartmentOutPos = New Vector3(-916.3039, -384.9148, 85.4804)
                .WardrobePos = New Quaternion(-904.1464, -369.6518, 79.2839, 112.4174)
                .GarageFilePath = "richard_majestic_apt_4"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim richardMajestic2 As New ApartmentClass()
            With richardMajestic2
                .Name = "MP_PROP_69"
                .Description = "MP_PROP_69DES"
                .Price = 968000
                .SavePos = New Vector3(-901.0586, -369.1378, 113.0741)
                .ApartmentInPos = New Vector3(-922.1152, -370.0627, 114.3101)
                .ApartmentOutPos = New Vector3(-919.3095, -368.5584, 114.275)
                .WardrobePos = New Quaternion(-903.3266, -364.2998, 113.074, 195.6396)
                .GarageFilePath = "richard_majestic_apt_2"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim richardMajestic As New BuildingClass()
            With richardMajestic
                .Name = "Richards Majestic"
                .BuildingInPos = New Vector3(-935.4753, -378.6128, 38.9613)
                .BuildingOutPos = New Quaternion(-933.4771, -383.6144, 38.9613, 0F)
                .GarageInPos = New Vector3(-876.1354, -363.0524, 36.3538)
                .GarageOutPos = New Quaternion(-873.362, -368.5318, 37.3505, 207.6679)
                .CameraPos = New CameraPRH(New Vector3(-958.2964, -478.6136, 38.73965), New Vector3(24.18255, 0, -19.8838), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"hei_bh1_08_bld2", "bh1_emissive_bh1_08", "bh1_08_bld2_LOD", "hei_bh1_08_bld2", "bh1_08_em"}
                .Apartments = New List(Of ApartmentClass) From {richardMajestic4, richardMajestic2}
            End With
            If Not buildings.Contains(richardMajestic) Then buildings.Add(richardMajestic)

            'Tinsel Towers
            Dim tinselTowers29 As New ApartmentClass()
            With tinselTowers29
                .Name = "MP_PROP_43"
                .Description = "MP_PROP_43DES"
                .Price = 492000
                .SavePos = New Vector3(-583.2249, 44.9624, 87.4188)
                .ApartmentInPos = New Vector3(-598.9042, 41.8059, 93.6261)
                .ApartmentOutPos = New Vector3(-601.8906, 42.3395, 93.6261)
                .WardrobePos = New Quaternion(-583.9974, 50.5919, 87.4296, 79.9632)
                .GarageFilePath = "tinsel_towers_apt_29"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim tinselTowers42 As New ApartmentClass()
            With tinselTowers42
                .Name = "MP_PROP_70"
                .Description = "MP_PROP_70DES"
                .Price = 984000
                .SavePos = New Vector3(-594.5658, 50.1804, 96.9996)
                .ApartmentInPos = New Vector3(-614.032, 58.9435, 98.2355)
                .ApartmentOutPos = New Vector3(-610.6395, 58.8867, 98.2004)
                .WardrobePos = New Quaternion(-594.8418, 55.761, 96.9996, 173.2113)
                .GarageFilePath = "tinsel_tower_apt_42"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim tinselTowers As New BuildingClass()
            With tinselTowers
                .Name = "Tinsel Towers"
                .BuildingInPos = New Vector3(-614.7656, 37.9, 43.5895)
                .BuildingOutPos = New Quaternion(-617.9388, 35.7848, 43.5558, 0F)
                .GarageInPos = New Vector3(-634.3952, 56.0859, 43.7127)
                .GarageOutPos = New Quaternion(-641.8661, 57.0499, 43.4129, 84.922)
                .CameraPos = New CameraPRH(New Vector3(-678.4925, -30.95172, 48.26074), New Vector3(16.23258, 0, -43.18668), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ss1_02_building01", "SS1_Emissive_SS1_02a_LOD", "ss1_02_ss1_emissive_ss1_02", "apa_ss1_02_building01", "SS1_02_Building01_LOD"}
                .Apartments = New List(Of ApartmentClass) From {tinselTowers29, tinselTowers42}
            End With
            If Not buildings.Contains(tinselTowers) Then buildings.Add(tinselTowers)

            'Weazel Plaza
            Dim weazelPlaza70 As New ApartmentClass()
            With weazelPlaza70
                .Name = "MP_PROP_36"
                .Description = "MP_PROP_36DES"
                .Price = 335000
                .SavePos = New Vector3(-913.0292, -440.8677, 115.3998)
                .ApartmentInPos = New Vector3(-900.6082, -431.0182, 121.607)
                .ApartmentOutPos = New Vector3(-897.3925, -430.1651, 121.607)
                .WardrobePos = New Quaternion(-909.721, -445.5214, 115.7431, 296.1297)
                .GarageFilePath = "weazel_plaza_apt_70"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim weazelPlaza As New BuildingClass()
            With weazelPlaza
                .Name = "Weazel Plaza"
                .BuildingInPos = New Vector3(-913.9732, -455.039, 39.5998)
                .BuildingOutPos = New Quaternion(-914.3189, -455.2902, 39.5998, 0F)
                .GarageInPos = New Vector3(-823.0811, -438.4828, 36.6387)
                .GarageOutPos = New Quaternion(-831.567, -430.7581, 36.0904, 116.1013)
                .CameraPos = New CameraPRH(New Vector3(-965.4064, -563.0858, 34.91125), New Vector3(24.98755, 0, -31.1508), 50.0F)
                .GarageType = eGarageType.TenCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"hei_bh1_09_bld_01", "bh1_09_ema", "prop_wall_light_12a"}
                .Apartments = New List(Of ApartmentClass) From {weazelPlaza70}
            End With
            If Not buildings.Contains(weazelPlaza) Then buildings.Add(weazelPlaza)
#End Region

#Region "Stilt Houses"
            '2862 Hillcrest Avenue
            Dim _2862HillcrestAveApt As New ApartmentClass()
            With _2862HillcrestAveApt
                .Name = "MP_PROP_86"
                .Description = "MP_PROP_86DES"
                .Price = 705000
                .SavePos = New Vector3(-666.4602, 586.9831, 141.5956)
                .ApartmentInPos = New Vector3(-680.1067, 590.6495, 145.393)
                .ApartmentOutPos = New Vector3(-682.4827, 592.6603, 145.3797)
                .WardrobePos = New Quaternion(-671.645, 587.338, 141.5698, 213.4807)
                .GarageFilePath = "2862_hillcrest_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2862HillcrestAve As New BuildingClass()
            With _2862HillcrestAve
                .Name = "2862 Hillcrest Avenue"
                .BuildingInPos = New Vector3(-686.0914, 596.1551, 143.6421)
                .BuildingOutPos = New Quaternion(-688.8965, 598.6945, 143.5084, 0F)
                .GarageInPos = New Vector3(-684.222, 602.92, 142.926)
                .GarageOutPos = New Quaternion(-682.2719, 605.082, 143.0796, 8.87)
                .CameraPos = New CameraPRH(New Vector3(-712.7956, 597.7189, 146.6349), New Vector3(-5.849331, 0, -87.56305), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_09c_hs11", "CH2_09c_Emissive_11_LOD", "CH2_09c_Emissive_11", "apa_ch2_09c_hs11_details"}
                .Apartments = New List(Of ApartmentClass) From {_2862HillcrestAveApt}
            End With
            If Not buildings.Contains(_2862HillcrestAve) Then buildings.Add(_2862HillcrestAve)

            '2868 Hillcrest Avenue
            Dim _2868HillcrestAveApt As New ApartmentClass()
            With _2868HillcrestAveApt
                .Name = "MP_PROP_85"
                .Description = "MP_PROP_85DES"
                .Price = 672000
                .SavePos = New Vector3(-769.5107, 606.3783, 140.3565)
                .ApartmentInPos = New Vector3(-761.0836, 617.9774, 144.1539)
                .ApartmentOutPos = New Vector3(-758.2289, 619.0676, 144.1405)
                .WardrobePos = New Quaternion(-767.4208, 611.0219, 140.3307, 113.3104)
                .GarageFilePath = "2868_hillcrest_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2868HillcrestAve As New BuildingClass()
            With _2868HillcrestAve
                .Name = "2868 Hillcrest Avenue"
                .BuildingInPos = New Vector3(-753.2365, 620.3427, 142.7831)
                .BuildingOutPos = New Quaternion(-751.1387, 621.1008, 142.2527, 0F)
                .GarageInPos = New Vector3(-754.1208, 629.6571, 141.9053)
                .GarageOutPos = New Quaternion(-752.724, 625.291, 141.7961, 244.24)
                .CameraPos = New CameraPRH(New Vector3(-734.5688, 618.7574, 148.982), New Vector3(-16.70547, 0, 86.47249), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_09b_hs01a_details", "apa_ch2_09b_hs01", "apa_ch2_09b_hs01_balcony", "apa_ch2_09b_Emissive_11_LOD", "apa_ch2_09b_Emissive_11", "apa_CH2_09b_House08_LOD"}
                .Apartments = New List(Of ApartmentClass) From {_2868HillcrestAveApt}
            End With
            If Not buildings.Contains(_2868HillcrestAve) Then buildings.Add(_2868HillcrestAve)

            '2874 Hillcrest Avenue
            Dim _2874HillcrestAveApt As New ApartmentClass()
            With _2874HillcrestAveApt
                .Name = "MP_PROP_92"
                .Description = "MP_PROP_92DES"
                .Price = 571000
                .SavePos = New Vector3(-851.2404, 677.0281, 149.0784)
                .ApartmentInPos = New Vector3(-859.5645, 688.7182, 152.8571)
                .ApartmentOutPos = New Vector3(-859.9158, 691.5079, 152.8589)
                .WardrobePos = New Quaternion(-855.3519, 680.0969, 149.0531, 182.5082)
                .GarageFilePath = "2874_hillcrest_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2874HillcrestAve As New BuildingClass()
            With _2874HillcrestAve
                .Name = "2874 Hillcrest Avenue"
                .BuildingInPos = New Vector3(-853.075, 695.4132, 148.7877)
                .BuildingOutPos = New Quaternion(-853.2899, 698.7006, 148.7756, 0F)
                .GarageInPos = New Vector3(-864.5076, 698.6345, 148.6063)
                .GarageOutPos = New Quaternion(-862.7094, 700.4839, 148.595, 328.02F)
                .CameraPos = New CameraPRH(New Vector3(-863.697, 713.9671, 152.9681), New Vector3(-8.148409, 1.0781, -167.5327), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_09b_hs02", "apa_ch2_09b_hs02b_details", "apa_ch2_09b_Emissive_09_LOD", "ch2_09b_botpoolHouse02_LOD", "apa_ch2_09b_Emissive_09", "apa_ch2_09b_hs02_balcony"}
                .Apartments = New List(Of ApartmentClass) From {_2874HillcrestAveApt}
            End With
            If Not buildings.Contains(_2874HillcrestAve) Then buildings.Add(_2874HillcrestAve)

            '2113 Mad Wayne Thunder Drive
            Dim _2113MadWayneThunderDrApt As New ApartmentClass()
            With _2113MadWayneThunderDrApt
                .Name = "MP_PROP_94"
                .Description = "MP_PROP_94DES"
                .Price = 449000
                .SavePos = New Vector3(-1282.3803, 434.7835, 94.1202)
                .ApartmentInPos = New Vector3(-1289.6389, 446.7739, 97.8989)
                .ApartmentOutPos = New Vector3(-1289.9187, 449.8238, 97.9025)
                .WardrobePos = New Quaternion(-1286.1141, 438.157, 94.0948, 177.5665)
                .GarageFilePath = "2113_mad_wayne_thunder_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2113MadWayneThunderDr As New BuildingClass()
            With _2113MadWayneThunderDr
                .Name = "2113 Mad Wayne Thunder Drive"
                .BuildingInPos = New Vector3(-1294.3609, 454.6022, 97.5311)
                .BuildingOutPos = New Quaternion(-1294.2279, 456.4709, 97.0794, 0F)
                .GarageInPos = New Vector3(-1294.9924, 456.477, 97.0332)
                .GarageOutPos = New Quaternion(-1297.027, 456.455, 96.9554, 322.69)
                .CameraPos = New CameraPRH(New Vector3(-1306.412, 467.0048, 102.6207), New Vector3(-17.02023, 0, -141.3645), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_12b_house03mc", "ch2_12b_emissive_02", "ch2_12b_house03_MC_a_LOD", "ch2_12b_emissive_02_LOD", "ch2_12b_railing_06"}
                .Apartments = New List(Of ApartmentClass) From {_2113MadWayneThunderDrApt}
            End With
            If Not buildings.Contains(_2113MadWayneThunderDr) Then buildings.Add(_2113MadWayneThunderDr)

            '2117 Milton Road
            Dim _2117MiltonRdApt As New ApartmentClass()
            With _2117MiltonRdApt
                .Name = "MP_PROP_89"
                .Description = "MP_PROP_89DES"
                .Price = 608000
                .SavePos = New Vector3(-568.4787, 645.6554, 142.0576)
                .ApartmentInPos = New Vector3(-572.4428, 658.958, 145.8364)
                .ApartmentOutPos = New Vector3(-571.8295, 662.1631, 145.8388)
                .WardrobePos = New Quaternion(-571.277, 649.8883, 142.0322, 166.0936)
                .GarageFilePath = "2117_milton_rd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2117MiltonRd As New BuildingClass()
            With _2117MiltonRd
                .Name = "2117 Milton Road"
                .BuildingInPos = New Vector3(-559.5131, 664.0349, 145.4592)
                .BuildingOutPos = New Quaternion(-558.0556, 666.2042, 145.1311, 0F)
                .GarageInPos = New Vector3(-555.3114, 665.145, 144.6135)
                .GarageOutPos = New Quaternion(-555.117, 666.15, 144.4309, 343.26)
                .CameraPos = New CameraPRH(New Vector3(-548.5573, 669.8001, 146.1121), New Vector3(-6.038576, 0, 124.0644), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_09c_hs07", "ch2_09c_build_11_07_LOD", "CH2_09c_Emissive_07_LOD", "apa_ch2_09c_build_11_07_LOD", "ch2_09c_hs07_details", "CH2_09c_Emissive_07"}
                .Apartments = New List(Of ApartmentClass) From {_2117MiltonRdApt}
            End With
            If Not buildings.Contains(_2117MiltonRd) Then buildings.Add(_2117MiltonRd)

            '2044 North Conker Avenue
            Dim _2044NorthConkerAveApt As New ApartmentClass()
            With _2044NorthConkerAveApt
                .Name = "MP_PROP_84"
                .Description = "MP_PROP_84DES"
                .Price = 762000
                .SavePos = New Vector3(332.7306, 423.6146, 145.5968)
                .ApartmentInPos = New Vector3(340.6531, 436.7456, 149.394)
                .ApartmentOutPos = New Vector3(342.1347, 437.8865, 149.3808)
                .WardrobePos = New Quaternion(334.2987, 428.6485, 145.5708, 103.0573)
                .GarageFilePath = "2044_north_conker_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2044NorthConkerAve As New BuildingClass()
            With _2044NorthConkerAve
                .Name = "2044 North Conker Avenue"
                .BuildingInPos = New Vector3(346.4214, 440.7363, 147.7075)
                .BuildingOutPos = New Quaternion(349.893, 442.8174, 147.3472, 0F)
                .GarageInPos = New Vector3(352.814, 437.2492, 146.3828)
                .GarageOutPos = New Quaternion(356.54, 439.226, 145.098, 294.08)
                .CameraPos = New CameraPRH(New Vector3(347.726, 459.0123, 150.3243), New Vector3(-3.703, 0, 161.5176), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_04_house02", "apa_ch2_04_house02_d", "apa_ch2_04_M_a_LOD", "ch2_04_house02_railings", "ch2_04_emissive_04", "ch2_04_emissive_04_LOD", "apa_ch2_04_house02_details"}
                .Apartments = New List(Of ApartmentClass) From {_2044NorthConkerAveApt}
            End With
            If Not buildings.Contains(_2044NorthConkerAve) Then buildings.Add(_2044NorthConkerAve)

            '2045 North Conker Avenue
            Dim _2045NorthConkerAveApt As New ApartmentClass()
            With _2045NorthConkerAveApt
                .Name = "MP_PROP_95"
                .Description = "MP_PROP_95DES"
                .Price = 727000
                .SavePos = New Vector3(377.2632, 407.4584, 142.1256)
                .ApartmentInPos = New Vector3(373.2864, 420.6612, 145.9045)
                .ApartmentOutPos = New Vector3(373.7533, 423.8348, 145.9078)
                .WardrobePos = New Quaternion()
                .GarageFilePath = "2045_north_conker_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _2045NorthConkerAve As New BuildingClass()
            With _2045NorthConkerAve
                .Name = "2045 North Conker Avenue"
                .BuildingInPos = New Vector3(373.8461, 427.7975, 145.6839)
                .BuildingOutPos = New Quaternion(371.9392, 430.4312, 145.1107, 0F)
                .GarageInPos = New Vector3(391.3488, 430.2205, 143.1705)
                .GarageOutPos = New Quaternion(392.482, 430.467, 143.0165, 298.54)
                .CameraPos = New CameraPRH(New Vector3(366.7971, 447.0355, 148.0793), New Vector3(-8.704479, -2.1593, -156.5936), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_04_house01", "apa_ch2_04_house01_d", "ch2_04_emissive_05_LOD", "apa_ch2_04_M_b_LOD", "ch2_04_emissive_05", "ch2_04_house01_details"}
                .Apartments = New List(Of ApartmentClass) From {_2045NorthConkerAveApt}
            End With
            If Not buildings.Contains(_2045NorthConkerAve) Then buildings.Add(_2045NorthConkerAve)

            '3677 Whispymound Drive
            Dim _3677WhispymoundDrApt As New ApartmentClass()
            With _3677WhispymoundDrApt
                .Name = "MP_PROP_87"
                .Description = "MP_PROP_87DES"
                .Price = 478000
                .SavePos = New Vector3(126.1813, 545.9031, 180.5226)
                .ApartmentInPos = New Vector3(117.5057, 557.3167, 184.3022)
                .ApartmentOutPos = New Vector3(117.2371, 560.0856, 184.3048)
                .WardrobePos = New Quaternion(122.0242, 548.9013, 180.4972, 182.3311)
                .GarageFilePath = "3677_whispymound_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _3677WhispymoundDr As New BuildingClass()
            With _3677WhispymoundDr
                .Name = "3677 Whispymound Drive"
                .BuildingInPos = New Vector3(119.3083, 564.0632, 183.9594)
                .BuildingOutPos = New Quaternion(118.8673, 567.283, 183.1295, 0F)
                .GarageInPos = New Vector3(131.7664, 568.0024, 183.1025)
                .GarageOutPos = New Quaternion(132.723, 568.142, 183.099, 335.12)
                .CameraPos = New CameraPRH(New Vector3(112.5791, 574.6387, 190.8119), New Vector3(-21.01317, 0, -144.2139), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_05c_b4", "ch2_05c_emissive_07", "ch2_05c_decals_05", "ch2_05c_B4_LOD"}
                .Apartments = New List(Of ApartmentClass) From {_3677WhispymoundDrApt}
            End With
            If Not buildings.Contains(_3677WhispymoundDr) Then buildings.Add(_3677WhispymoundDr)

            '3655 Wild Oats Drive
            Dim _3655WildOatsDrApt As New ApartmentClass()
            With _3655WildOatsDrApt
                .Name = "MP_PROP_83"
                .Description = "MP_PROP_83DES"
                .Price = 800000
                .SavePos = New Vector3(-163.1819, 484.9918, 133.8695)
                .ApartmentInPos = New Vector3(-173.286, 495.0179, 137.667)
                .ApartmentOutPos = New Vector3(-174.3115, 497.8294, 137.6536)
                .WardrobePos = New Quaternion(-167.5116, 487.8223, 133.8438, 103.0573)
                .GarageFilePath = "3655_wild_oats_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.None
            End With
            Dim _3655WildOatsDr As New BuildingClass()
            With _3655WildOatsDr
                .Name = "3655 Wild Oats Drive"
                .BuildingInPos = New Vector3(-174.606, 502.6157, 137.4205)
                .BuildingOutPos = New Quaternion(-177.3793, 503.8313, 136.8531, 0F)
                .GarageInPos = New Vector3(-189.307, 502.66, 133.9093)
                .GarageOutPos = New Quaternion(-187.563, 502.25, 134.13, 332.11)
                .CameraPos = New CameraPRH(New Vector3(-198.8929, 511.1027, 136.112), New Vector3(4.350469, 0, -128.423), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .HideObjects = {"apa_ch2_05e_res5", "apa_ch2_05e_res5_LOD"}
                .Apartments = New List(Of ApartmentClass) From {_3655WildOatsDrApt}
            End With
            If Not buildings.Contains(_3655WildOatsDr) Then buildings.Add(_3655WildOatsDr)
#End Region

#Region "Medium End Apartments"
            '0115 Bay City Ave
            Dim _0115BayCityAve45 As New ApartmentClass()
            With _0115BayCityAve45
                .Name = "MP_PROP_14"
                .Description = "MP_PROP_14DES"
                .Price = 150000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "0115_bay_city_ave_45"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _0115BayCityAve As New BuildingClass()
            With _0115BayCityAve
                .Name = "0115 Bay City Ave"
                .BuildingInPos = New Vector3(-969.2759, -1431.104, 7.763627)
                .BuildingOutPos = New Quaternion(-974.1464, -1433.113, 7.679172, 0F)
                .GarageInPos = New Vector3(-982.9502, -1450.931, 4.38989)
                .GarageOutPos = New Quaternion(-993.4175, -1425.568, 4.386545, 107.4124)
                .CameraPos = New CameraPRH(New Vector3(-1012.979, -1429.618, 6.07423), New Vector3(9.87174, 0, -98.14085), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0115BayCityAve45}
            End With
            If Not buildings.Contains(_0115BayCityAve) Then buildings.Add(_0115BayCityAve)

            'Dream Tower
            Dim dreamTower15 As New ApartmentClass()
            With dreamTower15
                .Name = "MP_PROP_16"
                .Description = "MP_PROP_16DES"
                .Price = 134000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "dream_tower_15"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim dreamTower As New BuildingClass()
            With dreamTower
                .Name = "Dream Tower"
                .BuildingInPos = New Vector3(-763.5511， -753.8142， 27.8686)
                .BuildingOutPos = New Quaternion(-757.82， -753.8024， 26.6554, 0F)
                .GarageInPos = New Vector3(-787.0813, -801.8603, 20.6192)
                .GarageOutPos = New Quaternion(-789.551, -815.7581, 20.1855, 181.6813)
                .CameraPos = New CameraPRH(New Vector3(-730.9564, -866.194, 39.5012), New Vector3(9.584155, 0, 35.26235), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {dreamTower15}
            End With
            If Not buildings.Contains(dreamTower) Then buildings.Add(dreamTower)

            '4 Hangman Ave
            Dim _4HangmanAveApt As New ApartmentClass()
            With _4HangmanAveApt
                .Name = "MP_PROP_72"
                .Description = "MP_PROP_72DES"
                .Price = 175000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "4_hangman_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _4HangmanAve As New BuildingClass()
            With _4HangmanAve
                .Name = "4 Hangman Ave"
                .BuildingInPos = New Vector3(-1405.445, 526.9388, 123.8313)
                .BuildingOutPos = New Quaternion(-1406.652, 533.3694, 122.9286, 0F)
                .GarageInPos = New Vector3(-1409.864, 540.1284, 122.5761)
                .GarageOutPos = New Quaternion(-1421.402, 535.7197, 120.7177, 111.9388)
                .CameraPos = New CameraPRH(New Vector3(-1437.455, 533.4254, 122.9885), New Vector3(-4.026862, 0, -94.79375), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_4HangmanAveApt}
            End With
            If Not buildings.Contains(_4HangmanAve) Then buildings.Add(_4HangmanAve)

            '0604 Las Lagunas Blvd
            Dim _0604LasLagunasBlvd4 As New ApartmentClass()
            With _0604LasLagunasBlvd4
                .Name = "MP_PROP_10"
                .Description = "MP_PROP_10DES"
                .Price = 126000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "0604_las_lagunas_blvd_4"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _0604LasLagunasBlvd As New BuildingClass()
            With _0604LasLagunasBlvd
                .Name = "0604 Las Lagunas Blvd"
                .BuildingInPos = New Vector3(9.446668, 81.46045, 78.43513)
                .BuildingOutPos = New Quaternion(10.9781, 86.45157, 78.39816, 0F)
                .GarageInPos = New Vector3(27.83206, 80.46669, 74.25099)
                .GarageOutPos = New Quaternion(39.44078, 77.11552, 74.9635, 241.9727)
                .CameraPos = New CameraPRH(New Vector3(-31.15757, 105.2271, 81.74537), New Vector3(6.371637, 0, -137.1451), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0604LasLagunasBlvd4}
            End With
            If Not buildings.Contains(_0604LasLagunasBlvd) Then buildings.Add(_0604LasLagunasBlvd)

            '0184 Milton Rd
            Dim _0184MiltonRd13 As New ApartmentClass()
            With _0184MiltonRd13
                .Name = "MP_PROP_11"
                .Description = "MP_PROP_11DES"
                .Price = 146000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "0184_milton_rd_13"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _0184MiltonRd As New BuildingClass()
            With _0184MiltonRd
                .Name = "0184 Milton Rd"
                .BuildingInPos = New Vector3(-511.7496, 108.2573, 63.80054)
                .BuildingOutPos = New Quaternion(-512.2141, 111.8229, 63.33881, 0F)
                .GarageInPos = New Vector3(-521.9894, 92.31882, 59.75345)
                .GarageOutPos = New Quaternion(-536.3447, 92.78167, 60.42566, 87.18483)
                .CameraPos = New CameraPRH(New Vector3(-526.9971, 133.2838, 65.28127), New Vector3(5.028964, 0, -148.544), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0184MiltonRd13}
            End With
            If Not buildings.Contains(_0184MiltonRd) Then buildings.Add(_0184MiltonRd)

            '1162 Power St
            Dim _1162PowerSt3 As New ApartmentClass()
            With _1162PowerSt3
                .Name = "MP_PROP_8"
                .Description = "MP_PROP_8DES"
                .Price = 130000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "1162_power_street_3"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _1162PowerSt As New BuildingClass()
            With _1162PowerSt
                .Name = "1162 Power St"
                .BuildingInPos = New Vector3(285.9683, -160.4879, 64.61704)
                .BuildingOutPos = New Quaternion(282.245, -159.5781, 63.62236, 0F)
                .GarageInPos = New Vector3(281.59, -146.9051, 64.62709)
                .GarageOutPos = New Quaternion(271.4526, -143.1953, 64.92351, 71.11879)
                .CameraPos = New CameraPRH(New Vector3(247.5116, -143.1925, 67.63675), New Vector3(1.717242, 0, -99.06012), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_1162PowerSt3}
            End With
            If Not buildings.Contains(_1162PowerSt) Then buildings.Add(_1162PowerSt)

            '4401 Procopio Dr
            Dim _4401ProcopioDrApt As New ApartmentClass()
            With _4401ProcopioDrApt
                .Name = "MP_PROP_75"
                .Description = "MP_PROP_75DES"
                .Price = 165000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "4401_procopio_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _4401ProcopioDr As New BuildingClass()
            With _4401ProcopioDr
                .Name = "4401 Procopio Dr"
                .BuildingInPos = New Vector3(-302.2182, 6327.001, 32.88741)
                .BuildingOutPos = New Quaternion(-305.5824, 6330.911, 32.48935, 0F)
                .GarageInPos = New Vector3(-294.8063, 6338.88, 32.00024)
                .GarageOutPos = New Quaternion(-296.2461, 6340.683, 31.76276, 44.08249)
                .CameraPos = New CameraPRH(New Vector3(-304.3051, 6344.134, 33.43044), New Vector3(-6.942835, 0, -170.2991), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_4401ProcopioDrApt}
            End With
            If Not buildings.Contains(_4401ProcopioDr) Then buildings.Add(_4401ProcopioDr)

            '4584 Procopio Dr
            Dim _4584ProcopioDrApt As New ApartmentClass()
            With _4584ProcopioDrApt
                .Name = "MP_PROP_74"
                .Description = "MP_PROP_74DES"
                .Price = 155000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "4584_procopio_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _4584ProcopioDr As New BuildingClass()
            With _4584ProcopioDr
                .Name = "4584 Procopio Dr"
                .BuildingInPos = New Vector3(-105.6365, 6528.601, 30.16694)
                .BuildingOutPos = New Quaternion(-108.5332, 6531.883, 29.80916, 0F)
                .GarageInPos = New Vector3(-105.0798, 6534.642, 29.56255)
                .GarageOutPos = New Quaternion(-108.9384, 6538.451, 29.60509, 47.39733)
                .CameraPos = New CameraPRH(New Vector3(-114.0698, 6545.125, 30.18196), New Vector3(-1.917315, 0, -155.1204), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_4584ProcopioDrApt}
            End With
            If Not buildings.Contains(_4584ProcopioDr) Then buildings.Add(_4584ProcopioDr)

            '0504 S Mo Milton Dr
            Dim _0504SMoMiltonDrApt As New ApartmentClass()
            With _0504SMoMiltonDrApt
                .Name = "MP_PROP_13"
                .Description = "MP_PROP_13DES"
                .Price = 141000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "0504_s_mo_milton_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _0504SMoMiltonDr As New BuildingClass()
            With _0504SMoMiltonDr
                .Name = "0504 S Mo Milton Dr"
                .BuildingInPos = New Vector3(-627.7245, 169.6668, 61.16204)
                .BuildingOutPos = New Quaternion(-633.7015, 169.4392, 61.22641, 0F)
                .GarageInPos = New Vector3(-630.657, 152.3768, 56.41848)
                .GarageOutPos = New Quaternion(-638.4281, 152.3656, 57.24699, 89.08953)
                .CameraPos = New CameraPRH(New Vector3(-663.4779, 162.9781, 62.82269), New Vector3(7.656792, 0, -92.89036), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0504SMoMiltonDrApt}
            End With
            If Not buildings.Contains(_0504SMoMiltonDr) Then buildings.Add(_0504SMoMiltonDr)

            '0325 South Rockford Dr
            Dim _0325SouthRockfordDrApt As New ApartmentClass()
            With _0325SouthRockfordDrApt
                .Name = "MP_PROP_15"
                .Description = "MP_PROP_15DES"
                .Price = 137000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "0325_south_rockford_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _0325SouthRockfordDr As New BuildingClass()
            With _0325SouthRockfordDr
                .Name = "0325 South Rockford Dr"
                .BuildingInPos = New Vector3(-831.4216, -862.641, 20.68967)
                .BuildingOutPos = New Quaternion(-831.6166, -856.5034, 19.59702, 0F)
                .GarageInPos = New Vector3(-758.8065, -870.7308, 20.9393)
                .GarageOutPos = New Quaternion(-755.0645, -870.7145, 21.18062, 267.8936)
                .CameraPos = New CameraPRH(New Vector3(-846.1815, -821.6712, 21.12708), New Vector3(9.139385, 0, -142.4772), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0325SouthRockfordDrApt}
            End With
            If Not buildings.Contains(_0325SouthRockfordDr) Then buildings.Add(_0325SouthRockfordDr)

            '0605 Spanish Ave
            Dim _0605SpanishAve1 As New ApartmentClass()
            With _0605SpanishAve1
                .Name = "MP_PROP_9"
                .Description = "MP_PROP_9DES"
                .Price = 128000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "0605_spanish_ave_1"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _0605SpanishAve As New BuildingClass()
            With _0605SpanishAve
                .Name = "0605 Spanish Ave"
                .BuildingInPos = New Vector3(3.602079, 37.2024, 71.53042)
                .BuildingOutPos = New Quaternion(2.387458, 34.19853, 71.16882, 0F)
                .GarageInPos = New Vector3(-11.9249, 37.897, 71.08931)
                .GarageOutPos = New Quaternion(-12.86958, 35.41181, 71.03293, 158.7376)
                .CameraPos = New CameraPRH(New Vector3(-23.84228, 11.21701, 74.10461), New Vector3(10.09729, 0, -29.36126), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0605SpanishAve1}
            End With
            If Not buildings.Contains(_0605SpanishAve) Then buildings.Add(_0605SpanishAve)

            '12 Sustancia Rd
            Dim _12SustanciaRdApt As New ApartmentClass()
            With _12SustanciaRdApt
                .Name = "MP_PROP_73"
                .Description = "MP_PROP_73DES"
                .Price = 143000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "12_sustancia_rd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim _12SustanciaRd As New BuildingClass()
            With _12SustanciaRd
                .Name = "12 Sustancia Rd"
                .BuildingInPos = New Vector3(1341.38, -1577.858, 54.44421)
                .BuildingOutPos = New Quaternion(1344.532, -1581.023, 54.05513, 0F)
                .GarageInPos = New Vector3(1351.739, -1574.466, 53.83353)
                .GarageOutPos = New Quaternion(1354.933, -1578.982, 53.38385, 216.5491)
                .CameraPos = New CameraPRH(New Vector3(1357.432, -1594.719, 53.01324), New Vector3(3.356584, 0, 35.79725), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_12SustanciaRdApt}
            End With
            If Not buildings.Contains(_12SustanciaRd) Then buildings.Add(_12SustanciaRd)

            'The Royale
            Dim theRoyale19 As New ApartmentClass()
            With theRoyale19
                .Name = "MP_PROP_12"
                .Description = "MP_PROP_12DES"
                .Price = 125000
                .SavePos = New Vector3(349.9618, -997.4911, -99.1962)
                .ApartmentInPos = New Vector3(346.5235, -1002.9012, -99.1962)
                .ApartmentOutPos = New Vector3(346.3732, -1013.137, -99.1962)
                .WardrobePos = New Quaternion(350.8938, -993.6076, -99.1961, 200.6809)
                .GarageFilePath = "the_royale_12"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
            End With
            Dim theRoyale As New BuildingClass()
            With theRoyale
                .Name = "The Royale"
                .BuildingInPos = New Vector3(-197.7387, 85.69609, 69.75623)
                .BuildingOutPos = New Quaternion(-197.6289, 90.04182, 69.65993, 0F)
                .GarageInPos = New Vector3(-212.6948, 73.81252, 66.74328)
                .GarageOutPos = New Quaternion(-215.8855, 75.07529, 66.78372, 81.58614)
                .CameraPos = New CameraPRH(New Vector3(-194.8486, 123.9623, 71.46825), New Vector3(1.435651, 0, -168.6253), 50.0F)
                .GarageType = eGarageType.SixCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {theRoyale19}
            End With
            If Not buildings.Contains(theRoyale) Then buildings.Add(theRoyale)
#End Region

#Region "Low End Apartments"
            '1115 Blvd Del Perro
            Dim _1115BlvdDelPerro18 As New ApartmentClass()
            With _1115BlvdDelPerro18
                .Name = "MP_PROP_23"
                .Description = "MP_PROP_23DES"
                .Price = 93000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "1115_blvd_del_perro_18"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _1115BlvdDelPerro As New BuildingClass()
            With _1115BlvdDelPerro
                .Name = "1115 Blvd Del Perro"
                .BuildingInPos = New Vector3(-1606.128, -432.6062, 40.43186)
                .BuildingOutPos = New Quaternion(-1610.868, -428.8814, 40.46698, 0F)
                .GarageInPos = New Vector3(-1608.53, -451.0937, 37.58678)
                .GarageOutPos = New Quaternion(-1611.859, -454.9521, 37.49269, 138.179)
                .CameraPos = New CameraPRH(New Vector3(-1643.548, -435.6621, 41.09145), New Vector3(8.244346, 0, -86.32664), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_1115BlvdDelPerro18}
            End With
            If Not buildings.Contains(_1115BlvdDelPerro) Then buildings.Add(_1115BlvdDelPerro)

            '1561 San Vitas St
            Dim _1561SanVitasSt2 As New ApartmentClass()
            With _1561SanVitasSt2
                .Name = "MP_PROP_18"
                .Description = "MP_PROP_18DES"
                .Price = 99000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "1561_san_vitas_st_2"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _1561SanVitasSt As New BuildingClass()
            With _1561SanVitasSt
                .Name = "1561 San Vitas St"
                .BuildingInPos = New Vector3(-200.6851, 186.0549, 80.50522)
                .BuildingOutPos = New Quaternion(-205.4685, 184.4087, 80.32763, 0F)
                .GarageInPos = New Vector3(-205.952, 192.6613, 79.88345)
                .GarageOutPos = New Quaternion(-213.1964, 193.2091, 80.66739, 82.44815)
                .CameraPos = New CameraPRH(New Vector3(-227.7641, 201.8866, 86.85343), New Vector3(-4.676774, 0, -109.3161), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_1561SanVitasSt2}
            End With
            If Not buildings.Contains(_1561SanVitasSt) Then buildings.Add(_1561SanVitasSt)

            '1237 Prosperity St
            Dim _1237ProsperitySt21 As New ApartmentClass()
            With _1237ProsperitySt21
                .Name = "MP_PROP_22"
                .Description = "MP_PROP_22DES"
                .Price = 105000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "1237_prosperity_st_21"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _1237ProsperitySt As New BuildingClass()
            With _1237ProsperitySt
                .Name = "1237 Prosperity St"
                .BuildingInPos = New Vector3(-1564.456, -406.2599, 42.38398)
                .BuildingOutPos = New Quaternion(-1562.17, -408.0945, 42.38398, 0F)
                .GarageInPos = New Vector3(-1554.318, -402.5234, 41.53171)
                .GarageOutPos = New Quaternion(-1548.194, -407.8083, 41.50047, 228.1096)
                .CameraPos = New CameraPRH(New Vector3(-1510.861, -407.8669, 42.94849), New Vector3(6.705585, 0, 82.56407), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_1237ProsperitySt21}
            End With
            If Not buildings.Contains(_1237ProsperitySt) Then buildings.Add(_1237ProsperitySt)

            '0069 Cougar Ave
            Dim _0069CougarAve19 As New ApartmentClass()
            With _0069CougarAve19
                .Name = "MP_PROP_21"
                .Description = "MP_PROP_21DES"
                .Price = 112000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "0069_cougar_ave_19"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _0069CougarAve As New BuildingClass()
            With _0069CougarAve
                .Name = "0069 Cougar Ave"
                .BuildingInPos = New Vector3(-1533.488, -326.8141, 47.91118)
                .BuildingOutPos = New Quaternion(-1535.237, -325.281, 47.48159, 0F)
                .GarageInPos = New Vector3(-1530.807, -346.3962, 44.66446)
                .GarageOutPos = New Quaternion(-1536.455, -352.6137, 44.54288, 135.3604)
                .CameraPos = New CameraPRH(New Vector3(-1563.921, -321.3005, 51.06629), New Vector3(-4.889933, 0, -100.0785), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0069CougarAve19}
            End With
            If Not buildings.Contains(_0069CougarAve) Then buildings.Add(_0069CougarAve)

            '2143 Las Lagunas Blvd
            Dim _2143LasLagunasBlvd9 As New ApartmentClass()
            With _2143LasLagunasBlvd9
                .Name = "MP_PROP_17"
                .Description = "MP_PROP_17DES"
                .Price = 115000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "2143_las_lagunas_blvd_9"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _2143LasLagunasBlvd As New BuildingClass()
            With _2143LasLagunasBlvd
                .Name = "2143 Las Lagunas Blvd"
                .BuildingInPos = New Vector3(-40.81998, -58.87804, 63.81212)
                .BuildingOutPos = New Quaternion(-44.99031, -60.94749, 63.58578, 0F)
                .GarageInPos = New Vector3(-32.13178, -69.51645, 58.91152)
                .GarageOutPos = New Quaternion(-40.82223, -67.3935, 58.69315, 69.59575)
                .CameraPos = New CameraPRH(New Vector3(-76.6449, -41.96963, 63.77706), New Vector3(4.850093, 0, -106.2234), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_2143LasLagunasBlvd9}
            End With
            If Not buildings.Contains(_2143LasLagunasBlvd) Then buildings.Add(_2143LasLagunasBlvd)

            '1893 Grapeseed Ave
            Dim _1893GrapeseedAveApt As New ApartmentClass()
            With _1893GrapeseedAveApt
                .Name = "MP_PROP_78"
                .Description = "MP_PROP_78DES"
                .Price = 118000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "1893_grapeseed_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _1893GrapeseedAve As New BuildingClass()
            With _1893GrapeseedAve
                .Name = "1893 Grapeseed Ave"
                .BuildingInPos = New Vector3(1662.156, 4776.137, 42.01189)
                .BuildingOutPos = New Quaternion(1665.579, 4776.712, 41.93869, 0F)
                .GarageInPos = New Vector3(1662.088, 4768.009, 41.79552)
                .GarageOutPos = New Quaternion(1667.8, 4768.668, 41.70086, 275.8229)
                .CameraPos = New CameraPRH(New Vector3(1683.295, 4774.074, 43.80255), New Vector3(-2.922752, 0, 93.5119), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_1893GrapeseedAveApt}
            End With
            If Not buildings.Contains(_1893GrapeseedAve) Then buildings.Add(_1893GrapeseedAve)

            '0232 Paleto Blvd
            Dim _0232PaletoBlvdApt As New ApartmentClass()
            With _0232PaletoBlvdApt
                .Name = "MP_PROP_76"
                .Description = "MP_PROP_76DES"
                .Price = 121000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "0232_poleto_blvd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _0232PaletoBlvd As New BuildingClass()
            With _0232PaletoBlvd
                .Name = "0232 Paleto Blvd"
                .BuildingInPos = New Vector3(-15.24203, 6557.372, 33.24039)
                .BuildingOutPos = New Quaternion(-12.83225, 6560.163, 31.97093, 0F)
                .GarageInPos = New Vector3(-12.11096, 6563.872, 31.77629)
                .GarageOutPos = New Quaternion(-6.329562, 6558.033, 31.7927, 225.0206)
                .CameraPos = New CameraPRH(New Vector3(-0.02845764, 6551.444, 32.63414), New Vector3(7.133693, 0, 85.69931), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0232PaletoBlvdApt}
            End With
            If Not buildings.Contains(_0232PaletoBlvd) Then buildings.Add(_0232PaletoBlvd)

            '0112 S Rockford Dr
            Dim _0112SRockfordDr13 As New ApartmentClass()
            With _0112SRockfordDr13
                .Name = "MP_PROP_19"
                .Description = "MP_PROP_19DES"
                .Price = 80000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "0112_s_rockford_dr_13"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _0112SRockfordDr As New BuildingClass()
            With _0112SRockfordDr
                .Name = "0112 S Rockford Dr"
                .BuildingInPos = New Vector3(-812.3849, -980.3691, 14.26866)
                .BuildingOutPos = New Quaternion(-814.8087, -984.2986, 14.03712, 0F)
                .GarageInPos = New Vector3(-812.1517, -954.1611, 15.22835)
                .GarageOutPos = New Quaternion(-822.1036, -955.2672, 15.24641, 99.68565)
                .CameraPos = New CameraPRH(New Vector3(-835.3129, -1003.118, 16.48207), New Vector3(3.313114, 0, -32.55415), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_0112SRockfordDr13}
            End With
            If Not buildings.Contains(_0112SRockfordDr) Then buildings.Add(_0112SRockfordDr)

            '2057 Vespucci Blvd
            Dim _2057VespucciBlvd1 As New ApartmentClass()
            With _2057VespucciBlvd1
                .Name = "MP_PROP_20"
                .Description = "MP_PROP_20DES"
                .Price = 87000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "2057_vespucci_blvd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _2057VespucciBlvd As New BuildingClass()
            With _2057VespucciBlvd
                .Name = "2057 Vespucci Blvd"
                .BuildingInPos = New Vector3(-662.4664, -854.2357, 24.4628)
                .BuildingOutPos = New Quaternion(-662.6467, -851.4024, 24.4296, 0F)
                .GarageInPos = New Vector3(-667.7385, -853.5117, 23.84)
                .GarageOutPos = New Quaternion(-667.6065, -849.4223, 23.8855, 358.19)
                .CameraPos = New CameraPRH(New Vector3(-644.9753, -820.6812, 33.11289), New Vector3(5.2089, -2.1432, 152.9055), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_2057VespucciBlvd1}
            End With
            If Not buildings.Contains(_2057VespucciBlvd) Then buildings.Add(_2057VespucciBlvd)

            '140 Zancudo Ave
            Dim _140ZancudoAveApt As New ApartmentClass()
            With _140ZancudoAveApt
                .Name = "MP_PROP_77"
                .Description = "MP_PROP_77DES"
                .Price = 121000
                .SavePos = New Vector3(262.9082, -1003.095, -99.0086)
                .ApartmentInPos = New Vector3(265.3285, -1002.7042, -99.0085)
                .ApartmentOutPos = New Vector3(266.1321, -1007.5136, -101.0085)
                .WardrobePos = New Quaternion(260.0521, -1004.1469, -99.0085, 359.818)
                .GarageFilePath = "140_zancudo_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
            End With
            Dim _140ZancudoAve As New BuildingClass()
            With _140ZancudoAve
                .Name = "140 Zancudo Ave"
                .BuildingInPos = New Vector3(1898.997, 3781.67, 32.87691)
                .BuildingOutPos = New Quaternion(1901.745, 3783.513, 32.79797, 0F)
                .GarageInPos = New Vector3(1884.389, 3769.249, 32.68288)
                .GarageOutPos = New Quaternion(1887.34, 3764.256, 32.59146, 214.5068)
                .CameraPos = New CameraPRH(New Vector3(1901.893, 3758.286, 33.14275), New Vector3(-1.035176, 0, 30.5063), 50.0F)
                .GarageType = eGarageType.TwoCarGarage
                .BuildingType = eBuildingType.Apartment
                .Apartments = New List(Of ApartmentClass) From {_140ZancudoAveApt}
            End With
            If Not buildings.Contains(_140ZancudoAve) Then buildings.Add(_140ZancudoAve)
#End Region

            For Each bd In buildings
                bd.Load()
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        Finally
            buildingsLoaded = True
        End Try
    End Sub

End Module
