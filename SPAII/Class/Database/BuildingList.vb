Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module BuildingList

    Public Sub LoadBuildings()
        buildings.Clear()
        apartments.Clear()

        Try
#Region "High End Apartments"
            '3 Alta Street
            If config.GetValue(Of Boolean)("APARTMENT", "3AST", True) Then
                Dim _3AltaStreet10 As New ApartmentClass() 'Newly Added
                With _3AltaStreet10
                    .ID = 5
                    .Name = "MP_PROP_5"
                    .Description = "MP_PROP_5DES"
                    .Price = 217000
                    .SavePos = New Vector3(-260.0051F, -949.0003F, 70.02404F)
                    .ApartmentDoorPos = New Quaternion(-264.7441F, -969.7109F, 76.23132F, 0F)
                    .ApartmentInPos = New Vector3(-262.9719F, -965.5146F, 76.23132F)
                    .ApartmentOutPos = New Vector3(-264.0814F, -967.5364F, 76.23132F)
                    .WardrobePos = New Quaternion(-265.4738F, -947.6708F, 70.03869F, 160.6728F)
                    .GarageFilePath = "3_alta_st_apt_10"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-262.6027F, -966.4926F, 77.74511F), New Vector3(0.1007454F, -0.000003034903F, 134.0962F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-263.5748F, -969.6506F, 77.6988F), New Vector3(-0.05672785F, -0.0000001992695F, 10.8675F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-264.6448F, -967.7161F, 77.34515F))
                End With
                Dim _3AltaStreet57 As New ApartmentClass()
                With _3AltaStreet57
                    .ID = 6
                    .Name = "MP_PROP_6"
                    .Description = "MP_PROP_6DES"
                    .Price = 223000
                    .SavePos = New Vector3(-284.4262, -958.5359, 86.3036)
                    .ApartmentDoorPos = New Quaternion(-278.4184F, -937.9305F, 91.51087F, 0F)
                    .ApartmentInPos = New Vector3(-281.0908, -943.2817, 92.5108)
                    .ApartmentOutPos = New Vector3(-279.2097, -940.9369, 92.5108)
                    .WardrobePos = New Quaternion(-277.6365F, -960.4476F, 85.31431F, 345.1764F)
                    .GarageFilePath = "3_alta_st_apt_57"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-280.7289F, -941.7155F, 93.1571F), New Vector3(-3.944601F, -0.000007488258F, -50.81424F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-279.6175F, -938.8705F, 93.05049F), New Vector3(0.4648432F, -0.000004936041F, -163.8833F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-278.5412F, -940.6227F, 92.62472F))
                End With
                Dim _3AltaStreet As New BuildingClass()
                With _3AltaStreet
                    .Name = "3 Alta St"
                    .BuildingInPos = New Quaternion(-259.8061F, -969.4397F, 30.21999F, 70.91596F)
                    .BuildingOutPos = New Quaternion(-261.1243F, -972.8566F, 30.21996F, 203.0815F)
                    .BuildingLobby = New Quaternion(-263.679F, -966.7826F, 30.22428F, 204.0962F)
                    .GarageInPos = New Vector3(-279.7589, -995.9545, 24.5305)
                    .GarageFootInPos = New Quaternion(-279.7421F, -992.0921F, 23.30595F, 74.48383F)
                    .GarageFootOutPos = New Quaternion(-286.7632F, -993.5939F, 23.13706F, 239.0284F)
                    .GarageOutPos = New Quaternion(-271.5633, -999.2233, 26.0224, 249.66F)
                    .CameraPos = New CameraPRH(New Vector3(-215.2378, -1071.639, 32.85828), New Vector3(22.62831, 0, 26.93762), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-261.2893F, -985.9326F, 34.31419F), New Vector3(-15.94485F, 0, 0.3253375F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-261.2893F, -985.9326F, 34.31419F), New Vector3(65.94485F, 0, 0.3253375F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .HideObjects = {"hei_dt1_20_build2", "dt1_20_dt1_emissive_dt1_20"}
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-252.6184F, -970.720764F, 30.22F, -20.0F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(1263238661, New Vector3(-263.461F, -970.5215F, 31.60709F))
                    .Door2 = New Door(-1934393132, New Vector3(-260.6575F, -969.2133F, 31.60706F))
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(1529620568, New Vector3(-282.5465F, -995.163F, 24.68051F))
                    .GarageWaypoint = New Quaternion(-292.5203F, -991.2855F, 23.47978F, 250.2265F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-288.8877F, -994.0138F, 24.12381F), New Vector3(-3.488037F, -0.0000001069198F, -100.3268F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-298.3831F, -990.7642F, 24.12381F), New Vector3(-3.879195F, -0.00000001337085F, -87.55238F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {_3AltaStreet10, _3AltaStreet57}
                End With
                If Not buildings.Contains(_3AltaStreet) Then buildings.Add(_3AltaStreet)
            End If

            '4 Integrity Way
            If config.GetValue(Of Boolean)("APARTMENT", "4IWY", True) Then
                Dim _4IntegrityWay30 As New ApartmentClass()
                With _4IntegrityWay30
                    .ID = 38
                    .Name = "MP_PROP_38"
                    .Description = "MP_PROP_38DES"
                    .Price = 476000
                    .SavePos = New Vector3(-36.6321, -578.1332, 83.9075)
                    .ApartmentDoorPos = New Quaternion(-15.53505F, -582.8347F, 89.11481F, 0F)
                    .ApartmentInPos = New Vector3(-21.0966, -580.4884, 90.1148)
                    .ApartmentOutPos = New Vector3(-18.0797, -582.1524, 90.1148)
                    .WardrobePos = New Quaternion(-37.88476F, -583.8307F, 82.92337F, 256.1314F)
                    .GarageFilePath = "4_integrity_way_apt_30"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-19.28315F, -580.7591F, 90.85917F), New Vector3(-5.267889F, 0.000004930021F, -134.2279F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-15.99379F, -581.983F, 90.5599F), New Vector3(2.089478F, -0.000001254814F, 93.78899F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-18.01365F, -582.781F, 90.22865F))
                End With
                Dim _4IntegrityWay35 As New ApartmentClass() 'Newly Added
                With _4IntegrityWay35
                    .ID = 39
                    .Name = "MP_PROP_39"
                    .Description = "MP_PROP_39DES"
                    .Price = 247000
                    .SavePos = New Vector3(-12.1413F, -589.0066F, 93.02555F)
                    .ApartmentDoorPos = New Quaternion(-16.9212F, -609.7066F, 99.23285F, 337.0011F)
                    .ApartmentInPos = New Vector3(-15.47026F, -606.2604F, 99.23285F)
                    .ApartmentOutPos = New Vector3(-16.02406F, -607.7055F, 99.23285F)
                    .WardrobePos = New Quaternion(-17.66597F, -587.9076F, 93.03635F, 157.4506F)
                    .GarageFilePath = "4_integrity_way_apt_35"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-14.84422F, -606.545F, 100.6203F), New Vector3(4.892231F, 0.000001071119F, 135.2383F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-15.88935F, -609.9943F, 100.7996F), New Vector3(-1.328225F, -0.0000007339088F, 8.465561F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-16.84285F, -607.7756F, 100.3467F))
                End With
                Dim _4IntegrityWay28 As New ApartmentClass()
                With _4IntegrityWay28
                    .ID = 71
                    .Name = "MP_PROP_71"
                    .Description = "MP_PROP_71DES"
                    .Price = 952000
                    .SavePos = New Vector3(-36.3656, -583.9371, 78.8302)
                    .ApartmentDoorPos = New Quaternion(-27.13547F, -596.6679F, 79.03082F, 0F)
                    .ApartmentInPos = New Vector3(-21.5202, -598.4841, 80.0662)
                    .ApartmentOutPos = New Vector3(-24.4089, -597.69, 80.0311)
                    .WardrobePos = New Quaternion(-38.09472F, -589.4041F, 77.82651F, 338.2186F)
                    .GarageFilePath = "4_integrity_way_apt_28"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-22.48642F, -597.2815F, 80.639F), New Vector3(-4.732824F, 0.000007603165F, 96.72656F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-26.30857F, -595.9876F, 80.58762F), New Vector3(-4.612982F, 0.000000428274F, -132.6383F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(34120519, New Vector3(-24.97746F, -598.1375F, 80.18041F))
                End With
                Dim _4IntegrityWay As New BuildingClass()
                With _4IntegrityWay
                    .Name = "4 Integrity Way"
                    .BuildingInPos = New Quaternion(-48.77471F, -589.6611F, 36.95303F, 154.7383F)
                    .BuildingOutPos = New Quaternion(-51.9436F, -586.4485F, 35.61865F, 69.12932F)
                    .BuildingLobby = New Quaternion(-45.4696F, -588.8636F, 37.16109F, 66.20447F)
                    .GarageInPos = New Vector3(-31.3821, -622.3356, 35.1917)
                    .GarageFootInPos = New Quaternion(-31.84189F, -619.3001F, 34.24325F, 65.96133F)
                    .GarageFootOutPos = New Quaternion(-36.14656F, -620.8832F, 34.05651F, 244.9995F)
                    .GarageOutPos = New Quaternion(-24.074, -624.9826, 35.0905, 251.6195F)
                    .CameraPos = New CameraPRH(New Vector3(-73.43955, -489.4017, 43.24729), New Vector3(20.34373, 0, -158.8398), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-64.34825F, -571.0589F, 39.82454F), New Vector3(-7.169178F, 0F, -140.2224F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-64.34825F, -571.0589F, 39.82454F), New Vector3(72.83083F, 0F, -140.2224F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .HideObjects = {"hei_dt1_03_build1x", "DT1_Emissive_DT1_03_b1", "dt1_03_dt1_Emissive_b1"}
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-55.02158, -592.0102, 35.0381165, 70.0F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(357195902, New Vector3(-47.83733F, -588.7703F, 38.36142F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(1652829067, New Vector3(-33.80561F, -621.6387F, 36.06102F))
                    .GarageWaypoint = New Quaternion(-38.56916F, -619.8274F, 34.41929F, 249.3876F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-39.21017F, -621.2138F, 35.66154F), New Vector3(-7.39955F, 0.00000005380897F, -94.96883F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-41.55785F, -620.5078F, 35.66154F), New Vector3(-7.634233F, 0.00000005383805F, -87.75737F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {_4IntegrityWay30, _4IntegrityWay35, _4IntegrityWay28}
                End With
                If Not buildings.Contains(_4IntegrityWay) Then buildings.Add(_4IntegrityWay)
            End If

            'Del Perro Hts
            If config.GetValue(Of Boolean)("APARTMENT", "DPHS", True) Then
                Dim delPerroHts7 As New ApartmentClass()
                With delPerroHts7
                    .ID = 34
                    .Name = "MP_PROP_34"
                    .Description = "MP_PROP_34DES"
                    .Price = 468000
                    .SavePos = New Vector3(-1471.4473, -533.1909, 50.7216)
                    .ApartmentDoorPos = New Quaternion(-1455.385F, -518.4211F, 55.929F, 0F)
                    .ApartmentInPos = New Vector3(-1460.3659, -522.0636, 56.929)
                    .ApartmentOutPos = New Vector3(-1457.5853, -520.3571, 56.929)
                    .WardrobePos = New Quaternion(-1467.644F, -537.3126F, 49.72213F, 316.111F)
                    .GarageFilePath = "del_perro_hts_apt_7"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-1459.262F, -520.3777F, 57.4729F), New Vector3(-0.6138833F, 0.000005569858F, -79.9688F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-1456.272F, -518.3873F, 57.56544F), New Vector3(-3.448524F, 0.00000523885F, 148.613F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-1456.818F, -520.5037F, 57.04281F))
                End With
                Dim delPerroHts20 As New ApartmentClass() 'Newly Added
                With delPerroHts20
                    .ID = 7
                    .Name = "MP_PROP_7"
                    .Description = "MP_PROP_7DES"
                    .Price = 205000
                    .SavePos = New Vector3(-1471.385F, -533.0422F, 62.34929F)
                    .ApartmentDoorPos = New Quaternion(-1455.568F, -518.8206F, 68.5566F, 126.4175F)
                    .ApartmentInPos = New Vector3(-1459.287F, -521.3007F, 68.5566F)
                    .ApartmentOutPos = New Vector3(-1457.529F, -520.3102F, 68.5566F)
                    .WardrobePos = New Quaternion(-1467.583F, -537.3127F, 62.36013F, 303.6598F)
                    .GarageFilePath = "del_perro_hts_apt_20"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-1459.072F, -520.311F, 70.23048F), New Vector3(-4.175738F, 0.000001979606F, -79.63849F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-1456.482F, -518.1489F, 70.14819F), New Vector3(-1.656038F, -0.000008914985F, 157.6829F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-1456.818F, -520.5037F, 69.67043F))
                End With
                Dim delPerroHts4 As New ApartmentClass()
                With delPerroHts4
                    .ID = 68
                    .Name = "MP_PROP_68"
                    .Description = "MP_PROP_68DES"
                    .Price = 936000
                    .SavePos = New Vector3(-1454.6335, -552.5497, 72.8437)
                    .ApartmentDoorPos = New Quaternion(-1454.578F, -537.0783F, 73.04426F, 0F)
                    .ApartmentInPos = New Vector3(-1458.6523, -531.4198, 74.0796)
                    .ApartmentOutPos = New Vector3(-1456.5989, -534.5363, 74.0445)
                    .WardrobePos = New Quaternion(-1449.683F, -548.9984F, 71.83705F, 124.2189F)
                    .GarageFilePath = "del_perro_hts_apt_4"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-1457.989F, -533.7233F, 74.71065F), New Vector3(-4.017842F, 0.000005991139F, -124.4527F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-1455.822F, -536.5961F, 74.65309F), New Vector3(-0.6320202F, 0.000004442561F, 13.73621F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(34120519, New Vector3(-1455.77F, -534.4214F, 74.19384F))
                End With
                Dim delPerroHts As New BuildingClass()
                With delPerroHts
                    .Name = "Del Perro Hts"
                    .BuildingInPos = New Quaternion(-1441.338F, -544.1608F, 33.74182F, 28.90462F)
                    .BuildingOutPos = New Quaternion(-1440.7F, -547.9163F, 33.74182F, 208.3939F)
                    .BuildingLobby = New Quaternion(-1445.426F, -540.9664F, 33.7409F, 211.3736F)
                    .GarageInPos = New Vector3(-1457.6473, -500.7265, 32.1985)
                    .GarageFootInPos = New Quaternion(-1454.177F, -499.3703F, 31.34857F, 208.1144F)
                    .GarageFootOutPos = New Quaternion(-1450.447F, -511.5497F, 30.58182F, 32.10187F)
                    .GarageOutPos = New Quaternion(-1457.4394, -490.838, 33.028, 300.666)
                    .CameraPos = New CameraPRH(New Vector3(-1392.67, -572.4094, 35.15923), New Vector3(22.16564, 0, 66.90905), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-1400.889F, -547.8552F, 36.19013F), New Vector3(-3.623728F, 0F, 81.89333F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1400.889F, -547.8552F, 36.19013F), New Vector3(40.37627F, 0F, 81.89333F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .HideObjects = {"sm_14_emissive", "hei_sm_14_bld2"}
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1424.716F, -568.2133F, 29.50431F, 28.99996F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-667009138, New Vector3(-1444.276F, -545.0115F, 34.98408F))
                    .Door2 = New Door(1640157877, New Vector3(-1442.299F, -543.6338F, 34.98407F))
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(245838764, New Vector3(-1455.871F, -503.8927F, 32.31301F))
                    .GarageWaypoint = New Quaternion(-1447.752F, -515.782F, 30.09689F, 34.72319F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-1451.946F, -515.6177F, 31.54084F), New Vector3(-5.834974F, 0F, 3.413804F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-1448.056F, -521.9968F, 31.54084F), New Vector3(-5.834974F, 0F, 3.413804F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {delPerroHts7, delPerroHts4, delPerroHts20}
                End With
                If Not buildings.Contains(delPerroHts) Then buildings.Add(delPerroHts)
            End If

            'Eclipse Towers
            If config.GetValue(Of Boolean)("APARTMENT", "ESTS", True) Then
                Dim eclipseTowers5 As New ApartmentClass() 'Newly Added
                With eclipseTowers5
                    .ID = 4
                    .Name = "MP_PROP_4"
                    .Description = "MP_PROP_4DES"
                    .Price = 382000
                    .SavePos = New Vector3(-795.8528F, 337.3569F, 200.4137F)
                    .ApartmentDoorPos = New Quaternion(-774.9395F, 340.0221F, 206.6209F, 89.76749F)
                    .ApartmentInPos = New Vector3(-778.6495F, 339.9896F, 206.6209F)
                    .ApartmentOutPos = New Vector3(-777.1475F, 339.9858F, 206.6209F)
                    .WardrobePos = New Quaternion(-795.308F, 331.7791F, 200.4244F, 267.3853F)
                    .GarageFilePath = "eclipse_towers_apt_5"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-778.2781F, 340.6561F, 208.1243F), New Vector3(0.7212611F, 0.00000893865F, -111.033F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-775.1168F, 340.783F, 208.229F), New Vector3(-3.373242F, -0.0000062006F, 115.5013F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-776.7023F, 339.3779F, 207.7347F))
                End With
                Dim eclipseTowers9 As New ApartmentClass() 'Newly Added
                With eclipseTowers9
                    .ID = 2
                    .Name = "MP_PROP_2"
                    .Description = "MP_PROP_2DES"
                    .Price = 373000
                    .SavePos = New Vector3(-760.1433F, 319.805F, 169.5965F)
                    .ApartmentDoorPos = New Quaternion(-781.5336F, 317.0257F, 175.8037F, 272.0089F)
                    .ApartmentInPos = New Vector3(-777.4405F, 317.2533F, 175.8037F)
                    .ApartmentOutPos = New Vector3(-778.8439F, 317.2298F, 175.8037F)
                    .WardrobePos = New Quaternion(-760.9385F, 325.5685F, 169.6072F, 93.80261F)
                    .GarageFilePath = "eclipse_towers_apt_9"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-777.6082F, 316.4773F, 177.3114F), New Vector3(1.001919F, 0.000000320214F, 65.75875F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-781.0718F, 316.2554F, 177.42F), New Vector3(-2.698871F, 0.000002457325F, -62.74499F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-779.3145F, 317.8782F, 176.9175F))
                End With
                Dim eclipseTowers31 As New ApartmentClass()
                With eclipseTowers31
                    .ID = 1
                    .Name = "MP_PROP_1"
                    .Description = "MP_PROP_1DES"
                    .Price = 400000
                    .SavePos = New Vector3(-796.1494F, 337.7686F, 152.7943F)
                    .ApartmentDoorPos = New Quaternion(-775.1887F, 340.5337F, 159.0015F, 105.508F)
                    .ApartmentInPos = New Vector3(-779.5142F, 340.4413F, 159.0015F)
                    .ApartmentOutPos = New Vector3(-777.7382F, 340.3186F, 159.0015F)
                    .WardrobePos = New Quaternion(-795.5483F, 332.1024F, 152.8052F, 267.7672F)
                    .GarageFilePath = "eclipse_towers_apt_31"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-778.8588F, 340.934F, 160.5463F), New Vector3(0.8061951F, 0.000002254719F, -106.6095F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-775.4404F, 341.37F, 160.5463F), New Vector3(-0.3749016F, -0.000002321247F, 118.1925F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-777.1694F, 339.7701F, 160.1154F))
                End With
                Dim eclipseTowers40 As New ApartmentClass() 'Newly Added
                With eclipseTowers40
                    .ID = 3
                    .Name = "MP_PROP_3"
                    .Description = "MP_PROP_3DES"
                    .Price = 391000
                    .SavePos = New Vector3(-760.2632F, 319.8222F, 216.0504F)
                    .ApartmentDoorPos = New Quaternion(-781.5247F, 317.2469F, 222.2576F, 269.913F)
                    .ApartmentInPos = New Vector3(-777.5369F, 317.3156F, 222.2576F)
                    .ApartmentOutPos = New Vector3(-778.976F, 317.259F, 222.2576F)
                    .WardrobePos = New Quaternion(-760.9446F, 325.4596F, 216.0613F, 96.50211F)
                    .GarageFilePath = "eclipse_towers_apt_40"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-777.4885F, 316.3747F, 223.9401F), New Vector3(-2.807639F, -0.000004701398F, 66.6688F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-781.105F, 316.3423F, 223.9509F), New Vector3(-4.146217F, 0.000001177019F, -63.88209F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-779.405F, 317.8782F, 223.3715F))
                End With
                Dim eclipseTowers3 As New ApartmentClass()
                With eclipseTowers3
                    .ID = 67
                    .Name = "MP_PROP_67"
                    .Description = "MP_PROP_67DES"
                    .Price = 800000
                    .SavePos = New Vector3(-793.2186, 332.4132, 210.7966)
                    .ApartmentDoorPos = New Quaternion(-780.8734F, 323.6186F, 210.9971F, 0F)
                    .ApartmentInPos = New Vector3(-774.3142, 323.8076, 212.0325)
                    .ApartmentOutPos = New Vector3(-777.6211, 323.5111, 211.9974)
                    .WardrobePos = New Quaternion(-793.3564F, 326.7588F, 209.7966F, 356.8686F)
                    .GarageFilePath = "eclipse_towers_apt_3"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-776.2745F, 324.4427F, 212.6635F), New Vector3(-3.839941F, -0.00000235316F, 112.9996F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-779.52F, 324.6114F, 212.6615F), New Vector3(-5.021046F, -0.00001285594F, -118.2596F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(34120519, New Vector3(-777.976F, 322.9964F, 212.1467F))
                End With
                Dim eclipseTowersPH1 As New ApartmentClass()
                With eclipseTowersPH1
                    .ID = 79
                    .Name = "MP_PROP_79"
                    .Description = "MP_PROP_79DES"
                    .Price = 985000
                    .SavePos = New Vector3(-797.7579, 337.3798, 220.4384)
                    .ApartmentDoorPos = New Quaternion(-781.4227F, 315.9428F, 216.6336F, 0.7958455F)
                    .ApartmentInPos = New Vector3(-784.0423, 320.9214, 217.439)
                    .ApartmentOutPos = New Vector3(-781.851, 318.094, 217.6388)
                    .WardrobePos = New Quaternion(-796.8506F, 328.2366F, 219.4408F, 359.5432F)
                    .GarageFilePath = "eclipse_towers_phs_1"
                    .IPL = config.GetValue("IPL", .Name, "apa_v_mp_h_01_a")
                    .AptStyleCam = New CameraPRH(New Vector3(-786.6251, 343.8772, 218.0287), New Vector3(-7.585561, 0, -163.3333), 50.0F)
                    .EnterCam = New CameraPRH(New Vector3(-781.0473F, 319.2194F, 218.3095F), New Vector3(-3.270323F, -0.000005130996F, 155.5242F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-780.9009F, 315.8782F, 218.3468F), New Vector3(-4.451426F, -0.00001113264F, 26.78304F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.IPL
                    .Door = .IPL.GetEclipseTowersPenthouseDoor
                End With
                Dim eclipseTowersPH2 As New ApartmentClass()
                With eclipseTowersPH2
                    .ID = 80
                    .Name = "MP_PROP_80"
                    .Description = "MP_PROP_80DES"
                    .Price = 905000
                    .SavePos = New Vector3(-763.3478, 320.4298, 199.4861)
                    .ApartmentDoorPos = New Quaternion(-779.198F, 342.5551F, 195.6864F, 0F)
                    .ApartmentInPos = New Vector3(-779.0727F, 336.8866F, 195.691F)
                    .ApartmentOutPos = New Vector3(-779.2371, 339.6224, 196.6866)
                    .WardrobePos = New Quaternion(-764.0985F, 329.6688F, 198.4862F, 178.7236F)
                    .GarageFilePath = "eclipse_towers_phs_2"
                    .IPL = config.GetValue("IPL", .Name, "apa_v_mp_h_01_b")
                    .AptStyleCam = New CameraPRH(New Vector3(-774.2443, 314.4292, 196.6641), New Vector3(-2.762131, 0, 16.02366), 50.0F)
                    .EnterCam = New CameraPRH(New Vector3(-779.7988F, 338.4059F, 197.2669F), New Vector3(-0.9279482F, -0.000002428237F, -18.07839F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-780.0955F, 341.8473F, 197.4116F), New Vector3(-4.392527F, -0.0000001070361F, -152.8809F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.IPL
                    .Door = .IPL.GetEclipseTowersPenthouseDoor
                End With
                Dim eclipseTowersPH3 As New ApartmentClass()
                With eclipseTowersPH3
                    .ID = 81
                    .Name = "MP_PROP_81"
                    .Description = "MP_PROP_81DES"
                    .Price = 1100000
                    .SavePos = New Vector3(-797.7316, 337.315, 190.7134)
                    .ApartmentDoorPos = New Quaternion(-781.6838F, 314.9191F, 186.9136F, 0F)
                    .ApartmentInPos = New Vector3(-781.5604F, 320.6204F, 186.9488F)
                    .ApartmentOutPos = New Vector3(-781.9078, 318.1647, 187.9138)
                    .WardrobePos = New Quaternion(-796.89F, 328.2856F, 189.7052F, 1.566094F)
                    .GarageFilePath = "eclipse_towers_phs_3"
                    .IPL = config.GetValue("IPL", .Name, "apa_v_mp_h_01_c")
                    .AptStyleCam = New CameraPRH(New Vector3(-786.7924, 343.3035, 187.8668), New Vector3(-1.956791, 0, -163.332), 50.0F)
                    .EnterCam = New CameraPRH(New Vector3(-780.9993F, 319.2357F, 188.625F), New Vector3(-3.514237F, 0.00001101304F, 155.6702F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-780.6867F, 315.939F, 188.5629F), New Vector3(-2.01817F, 0.00001099916F, 34.01553F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.IPL
                    .Door = .IPL.GetEclipseTowersPenthouseDoor
                End With
                Dim eclipseTowers As New BuildingClass()
                With eclipseTowers
                    .Name = "Eclipse Towers"
                    .BuildingInPos = New Quaternion(-778.8126F, 312.6634F, 84.69843F, 12.38459F)
                    .BuildingOutPos = New Quaternion(-777.3685F, 310.2097F, 84.69816F, 185.7139F)
                    .BuildingLobby = New Quaternion(-777.247F, 316.0079F, 84.66265F, 182.7023F)
                    .GarageInPos = New Vector3(-796.1188F, 308.4073F, 84.96577F) 'New Vector3(-796.1685, 311.4121, 85.7088)
                    .GarageFootInPos = New Quaternion(-790.242F, 307.9147F, 84.70213F, 4.71801F)
                    .GarageFootOutPos = New Quaternion(-796.1616F, 318.7691F, 84.67818F, 176.7606F)
                    .GarageOutPos = New Quaternion(-796.2648, 302.5102, 85.1543, 179.532F)
                    .CameraPos = New CameraPRH(New Vector3(-881.4312, 214.6852, 91.3971), New Vector3(25.6109, 0, -39.32376), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-772.3347F, 282.756F, 88.23641F), New Vector3(1.163976F, 0F, 4.700311F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-772.3347F, 282.756F, 88.23641F), New Vector3(61.16398F, 0F, 4.700311F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .HideObjects = {"apa_ss1_11_flats", "ss1_11_ss1_emissive_a", "ss1_11_detail01b", "ss1_11_Flats_LOD", "SS1_02_Building01_LOD", "SS1_LOD_01_02_08_09_10_11", "SS1_02_SLOD1"}
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-786.176453F, 299.092316F, 84.8250656F, 5.369569F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-2050436002, New Vector3(-778.3578F, 313.5395F, 86.14334F))
                    .Door2 = New Door(100848840, New Vector3(-776.1967F, 313.5395F, 86.14334F))
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(-1573772550, New Vector3(-796.0817F, 313.676F, 86.68316F))
                    .GarageWaypoint = New Quaternion(-798.2641F, 326.3963F, 85.21525F, 181.2166F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-798.883F, 321.1833F, 86.86268F), New Vector3(-4.817973F, 0.0000002142003F, -165.7958F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-801.0359F, 332.1553F, 86.86268F), New Vector3(-11.4675F, -0.000000871164F, -150.8577F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {eclipseTowers5, eclipseTowers9, eclipseTowers31, eclipseTowers40, eclipseTowers3, eclipseTowersPH1, eclipseTowersPH2, eclipseTowersPH3}
                End With
                If Not buildings.Contains(eclipseTowers) Then buildings.Add(eclipseTowers)
            End If

            'Richards Majestic
            If config.GetValue(Of Boolean)("APARTMENT", "RCMC", True) Then
                Dim richardsMajestic4 As New ApartmentClass()
                With richardsMajestic4
                    .ID = 40
                    .Name = "MP_PROP_40"
                    .Description = "MP_PROP_40DES"
                    .Price = 484000
                    .SavePos = New Vector3(-900.8789, -374.416, 79.2731)
                    .ApartmentDoorPos = New Quaternion(-919.0216F, -386.5883F, 84.48055F, 0F)
                    .ApartmentInPos = New Vector3(-913.1502, -384.5727, 85.4804)
                    .ApartmentOutPos = New Vector3(-916.3039, -384.9148, 85.4804)
                    .WardrobePos = New Quaternion(-904.1349F, -369.6084F, 78.28397F, 124.7661F)
                    .GarageFilePath = "richards_majestic_apt_4"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-914.7114F, -385.1256F, 85.94125F), New Vector3(3.15225F, 0.0000105013F, 95.40816F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-917.7518F, -387.0723F, 86.24625F), New Vector3(-6.532785F, -0.000009452887F, -33.09576F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-916.985F, -384.7734F, 85.59431F))
                End With
                Dim richardsMajestic51 As New ApartmentClass() 'Newly Added
                With richardsMajestic51
                    .ID = 41
                    .Name = "MP_PROP_41"
                    .Description = "MP_PROP_41DES"
                    .Price = 253000
                    .SavePos = New Vector3(-929.2203F, -376.9355F, 102.233F)
                    .ApartmentDoorPos = New Quaternion(-911.7111F, -364.968F, 108.4403F, 111.8704F)
                    .ApartmentInPos = New Vector3(-915.0739F, -366.594F, 108.4404F)
                    .ApartmentOutPos = New Vector3(-913.8405F, -365.995F, 108.4404F)
                    .WardrobePos = New Quaternion(-926.1819F, -381.6208F, 102.2438F, 290.208F)
                    .GarageFilePath = "richards_majestic_apt_51"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-915.3671F, -366.0391F, 109.9124F), New Vector3(1.898333F, 0.000003924176F, -81.59267F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-912.2787F, -364.3558F, 109.954F), New Vector3(0.7172135F, 0.000003095172F, 138.3281F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-913.2027F, -366.3348F, 109.5541F))
                End With
                Dim richardsMajestic2 As New ApartmentClass()
                With richardsMajestic2
                    .ID = 69
                    .Name = "MP_PROP_69"
                    .Description = "MP_PROP_69DES"
                    .Price = 968000
                    .SavePos = New Vector3(-901.0586, -369.1378, 113.0741)
                    .ApartmentDoorPos = New Quaternion(-916.2762F, -366.9405F, 113.2747F, 0F)
                    .ApartmentInPos = New Vector3(-922.1152, -370.0627, 114.3101)
                    .ApartmentOutPos = New Vector3(-919.3095, -368.5584, 114.275)
                    .WardrobePos = New Quaternion(-903.6965F, -363.973F, 112.0741F, 198.3367F)
                    .GarageFilePath = "richards_majestic_apt_2"
                    .IPL = Nothing
                    .AptStyleCam = Nothing

                    .EnterCam = New CameraPRH(New Vector3(-920.2776F, -369.8253F, 114.7411F), New Vector3(1.20418F, 0.0000001067453F, -45.5851F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-916.9238F, -368.4217F, 114.8122F), New Vector3(1.282935F, -0.00000009090298F, 89.45348F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(34120519, New Vector3(-919.1519F, -367.7008F, 114.4243F))
                End With
                Dim richardsMajestic As New BuildingClass()
                With richardsMajestic
                    .Name = "Richards Majestic"
                    .BuildingInPos = New Quaternion(-935.0035F, -380.3281F, 37.96134F, 294.9317F)
                    .BuildingOutPos = New Quaternion(-935.3661F, -384.3943F, 37.96133F, 115.7187F)
                    .BuildingLobby = New Quaternion(-932.979F, -383.5874F, 37.9613F, 113.8984F)
                    .GarageInPos = New Vector3(-876.1354, -363.0524, 36.3538)
                    .GarageFootInPos = New Quaternion(-875.8687F, -359.7995F, 34.86322F, 292.4232F)
                    .GarageFootOutPos = New Quaternion(-881.4058F, -353.3985F, 34.10711F, 205.9451F)
                    .GarageOutPos = New Quaternion(-873.362, -368.5318, 37.3505, 207.6679)
                    .CameraPos = New CameraPRH(New Vector3(-958.2964, -478.6136, 38.73965), New Vector3(24.18255, 0, -19.8838), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-944.4233F, -409.0229F, 39.88211F), New Vector3(-15.48672F, -0.0000004429699F, -29.8702F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-944.4233F, -409.0229F, 39.88211F), New Vector3(60.52476F, 0.000001076515F, -32.37362F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-963.0879F, -387.4315F, 36.75792F, -152.9992F))
                    .HideObjects = {"hei_bh1_08_bld2", "bh1_emissive_bh1_08", "bh1_08_bld2_LOD", "hei_bh1_08_bld2", "bh1_08_em"}
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(-976225932, New Vector3(-878.0236F, -359.4587F, 36.28026F))
                    .GarageWaypoint = New Quaternion(-885.1744F, -345.4747F, 33.05091F, 206.8757F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-882.0393F, -355.215F, 35.81071F), New Vector3(-6.46077F, 0F, -136.0225F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-889.6566F, -341.996F, 34.51073F), New Vector3(-6.46077F, 0F, -136.0225F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {richardsMajestic4, richardsMajestic2, richardsMajestic51}
                End With
                If Not buildings.Contains(richardsMajestic) Then buildings.Add(richardsMajestic)
            End If

            'Tinsel Towers
            If config.GetValue(Of Boolean)("APARTMENT", "TSTS", True) Then
                Dim tinselTowers29 As New ApartmentClass()
                With tinselTowers29
                    .ID = 43
                    .Name = "MP_PROP_43"
                    .Description = "MP_PROP_43DES"
                    .Price = 492000
                    .SavePos = New Vector3(-583.2249, 44.9624, 87.4188)
                    .ApartmentDoorPos = New Quaternion(-604.8759F, 42.28208F, 92.62614F, 0F)
                    .ApartmentInPos = New Vector3(-598.9042, 41.8059, 93.6261)
                    .ApartmentOutPos = New Vector3(-601.8906, 42.3395, 93.6261)
                    .WardrobePos = New Quaternion(-584.0144F, 50.65959F, 86.42953F, 93.00996F)
                    .GarageFilePath = "tinsel_towers_apt_29"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-600.6483F, 41.64714F, 94.25247F), New Vector3(-0.8585592F, -0.000001601005F, 69.9222F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-604.0479F, 41.40324F, 94.2058F), New Vector3(-1.173519F, -0.0000007472086F, -62.51841F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-602.4177F, 42.96198F, 93.73995F))
                End With
                Dim tinselTowers42 As New ApartmentClass()
                With tinselTowers42
                    .ID = 70
                    .Name = "MP_PROP_70"
                    .Description = "MP_PROP_70DES"
                    .Price = 984000
                    .SavePos = New Vector3(-594.5658, 50.1804, 96.9996)
                    .ApartmentDoorPos = New Quaternion(-607.3305F, 58.77972F, 97.2001F, 0F)
                    .ApartmentInPos = New Vector3(-614.032, 58.9435, 98.2355)
                    .ApartmentOutPos = New Vector3(-610.6395, 58.8867, 98.2004)
                    .WardrobePos = New Quaternion(-594.6629F, 55.68581F, 95.99756F, 175.684F)
                    .GarageFilePath = "tinsel_towers_apt_42"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-612.041F, 58.16896F, 98.81688F), New Vector3(-1.797036F, 0.0000007474194F, -71.5668F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-608.3382F, 58.27823F, 98.8198F), New Vector3(-1.167123F, 0.0000008539508F, 69.06284F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(34120519, New Vector3(-610.0969F, 59.60177F, 98.34972F))
                End With
                Dim tinselTowers45 As New ApartmentClass()
                With tinselTowers45
                    .ID = 42
                    .Name = "MP_PROP_42"
                    .Description = "MP_PROP_42DES"
                    .Price = 270000
                    .SavePos = New Vector3(-618.0376F, 62.36795F, 100.8197F)
                    .ApartmentDoorPos = New Quaternion(-597.0847F, 64.97559F, 107.027F, 99.10258F)
                    .ApartmentInPos = New Vector3(-601.0045F, 65.06656F, 107.027F)
                    .ApartmentOutPos = New Vector3(-599.3519F, 64.91546F, 107.027F)
                    .WardrobePos = New Quaternion(-616.9905F, 56.67279F, 100.8305F, 284.8896F)
                    .GarageFilePath = "tinsel_towers_apt_45"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-600.8429F, 65.51825F, 108.5387F), New Vector3(2.075258F, -0.000008596734F, -106.6773F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-597.3535F, 65.95759F, 108.6533F), New Vector3(-2.570407F, -0.0000120717F, 120.0153F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-598.9486F, 64.35553F, 108.1409F))
                End With
                Dim tinselTowers As New BuildingClass()
                With tinselTowers
                    .Name = "Tinsel Towers"
                    .BuildingInPos = New Quaternion(-614.3498F, 36.95148F, 42.57011F, 267.8349F)
                    .BuildingOutPos = New Quaternion(-615.4755F, 34.85121F, 42.53294F, 177.5101F)
                    .BuildingLobby = New Quaternion(-614.6836F, 41.68021F, 42.59146F, 181.9344F)
                    .GarageInPos = New Vector3(-634.3952, 56.0859, 43.7127)
                    .GarageFootInPos = New Quaternion(-631.3752F, 52.95258F, 42.72498F, 175.5509F)
                    .GarageFootOutPos = New Quaternion(-624.9257F, 56.47275F, 42.72746F, 93.49864F)
                    .GarageOutPos = New Quaternion(-641.8661, 57.0499, 43.4129, 84.922)
                    .CameraPos = New CameraPRH(New Vector3(-678.4925, -30.95172, 48.26074), New Vector3(16.23258, 0, -43.18668), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-595.746F, 7.326121F, 44.76005F), New Vector3(-1.93387F, 0F, 6.364491F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-595.746F, 7.326121F, 44.76005F), New Vector3(58.06613F, 0F, 6.364491F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-613.9074F, 24.62918F, 40.8037F, -179.1627F))
                    .HideObjects = {"apa_ss1_02_building01", "SS1_Emissive_SS1_02a_LOD", "ss1_02_ss1_emissive_ss1_02", "apa_ss1_02_building01", "SS1_02_Building01_LOD"}
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-2050436002, New Vector3(-615.8009F, 38.37179F, 44.03822F))
                    .Door2 = New Door(100848840, New Vector3(-613.6412F, 38.37005F, 44.03822F))
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(-1573772550, New Vector3(-629.9071F, 56.57387F, 44.72438F))
                    .GarageWaypoint = New Quaternion(-620.0411F, 59.18661F, 42.25226F, 102.8858F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-622.3945F, 59.88835F, 43.5915F), New Vector3(-3.644489F, 0F, 110.8087F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-615.8323F, 61.20481F, 43.5915F), New Vector3(-4.035642F, 0F, 126.1583F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {tinselTowers29, tinselTowers42, tinselTowers45}
                End With
                If Not buildings.Contains(tinselTowers) Then buildings.Add(tinselTowers)
            End If

            'Weazel Plaza
            If config.GetValue(Of Boolean)("APARTMENT", "WZPZ", True) Then
                Dim weazelPlaza26 As New ApartmentClass
                With weazelPlaza26
                    .ID = 37
                    .Name = "MP_PROP_37"
                    .Description = "MP_PROP_37DES"
                    .Price = 304000
                    .SavePos = New Vector3(-894.9255F, -430.7101F, 88.25381F)
                    .ApartmentDoorPos = New Quaternion(-883.1802F, -448.0886F, 94.46111F, 25.67751F)
                    .ApartmentInPos = New Vector3(-884.9413F, -444.9756F, 94.46111F)
                    .ApartmentOutPos = New Vector3(-884.2394F, -446.0929F, 94.46111F)
                    .WardrobePos = New Quaternion(-899.6545F, -433.8643F, 88.26462F, 207.2206F)
                    .GarageFilePath = "weazel_plaze_apt_26"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-884.1897F, -444.4021F, 95.94291F), New Vector3(2.221285F, -0.0000002269541F, -174.6369F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-882.4885F, -447.7111F, 96.11854F), New Vector3(-3.448023F, 0.000001389898F, 49.37878F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-884.5245F, -446.8338F, 95.57493F))
                End With
                Dim weazelPlaza70 As New ApartmentClass()
                With weazelPlaza70
                    .ID = 36
                    .Name = "MP_PROP_36"
                    .Description = "MP_PROP_36DES"
                    .Price = 335000
                    .SavePos = New Vector3(-913.0292, -440.8677, 115.3998)
                    .ApartmentDoorPos = New Quaternion(-894.4053F, -428.5895F, 120.6071F, 0F)
                    .ApartmentInPos = New Vector3(-900.6082, -431.0182, 121.607)
                    .ApartmentOutPos = New Vector3(-897.3925, -430.1651, 121.607)
                    .WardrobePos = New Quaternion(-909.7175F, -445.6808F, 114.4106F, 294.6847F)
                    .GarageFilePath = "weazel_plaza_apt_70"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-898.7294F, -430.2459F, 122.1569F), New Vector3(1.032692F, 0.000006938038F, -79.36346F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-895.7893F, -428.386F, 122.0217F), New Vector3(3.158687F, 0.000007375002F, 139.3751F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-896.6517F, -430.4684F, 121.7209F))
                End With
                Dim weazelPlaza101 As New ApartmentClass
                With weazelPlaza101
                    .ID = 35
                    .Name = "MP_PROP_35"
                    .Description = "MP_PROP_35DES"
                    .Price = 335000
                    .SavePos = New Vector3(-885.587F, -449.0947F, 119.3271F)
                    .ApartmentDoorPos = New Quaternion(-903.2214F, -461.3259F, 125.5344F, 290.9881F)
                    .ApartmentInPos = New Vector3(-899.3466F, -459.1319F, 125.5344F)
                    .ApartmentOutPos = New Vector3(-900.9765F, -459.9353F, 125.5344F)
                    .WardrobePos = New Quaternion(-888.6298F, -444.3869F, 119.3379F, 109.504F)
                    .GarageFilePath = "weazel_plaze_apt_101"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-899.5339F, -460.0195F, 126.9776F), New Vector3(3.433987F, -0.00000759087F, 99.08408F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-902.5319F, -461.772F, 127.1714F), New Vector3(-1.920356F, -0.000007154371F, -40.91536F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(330294775, New Vector3(-901.6349F, -459.6841F, 126.6482F))
                End With
                Dim weazelPlaza As New BuildingClass()
                With weazelPlaza
                    .Name = "Weazel Plaza"
                    .BuildingInPos = New Quaternion(-913.6771F, -456.4787F, 38.59988F, 294.5631F)
                    .BuildingOutPos = New Quaternion(-915.9673F, -456.3158F, 38.59988F, 121.3589F)
                    .BuildingLobby = New Quaternion(-910.3892F, -453.8744F, 38.60528F, 111.9039F)
                    .GarageInPos = New Vector3(-823.0811, -438.4828, 36.6387)
                    .GarageFootInPos = New Quaternion(-819.7535F, -440.558F, 35.63758F, 204.4043F)
                    .GarageFootOutPos = New Quaternion(-816.9793F, -433.2894F, 35.12066F, 126.2014F)
                    .GarageOutPos = New Quaternion(-825.5913F, -439.3314F, 35.92661F, 117.7293F)
                    .CameraPos = New CameraPRH(New Vector3(-965.4064, -563.0858, 34.91125), New Vector3(24.98755, 0, -31.1508), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-937.9976F, -464.0622F, 41.10617F), New Vector3(-12.63568F, 0F, -64.28323F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-937.9976F, -464.0622F, 41.10617F), New Vector3(47.36432F, 0F, -64.28323F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-929.1749F, -449.6654F, 36.0F, 115.3662F))
                    .HideObjects = {"hei_bh1_09_bld_01", "bh1_09_ema", "prop_wall_light_12a"}
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-1258405227, New Vector3(-914.056F, -453.654F, 39.80682F))
                    .Door2 = New Door(-1719104598, New Vector3(-912.9144F, -455.8944F, 39.80682F))
                    .GarageDoor = eFrontDoor.StandardDoor
                    .Door3 = New Door(815741875, New Vector3(-820.5675F, -436.8086F, 37.44185F))
                    .GarageWaypoint = New Quaternion(-813.7238F, -429.8186F, 34.4913F, 134.5638F)
                    .EnterCamera3 = New CameraPRH(New Vector3(-818.048F, -430.0121F, 36.71004F), New Vector3(-2.627478F, 0F, 154.9526F), 50.0F)
                    .EnterCamera4 = New CameraPRH(New Vector3(-809.6729F, -418.2455F, 34.41008F), New Vector3(-5.75667F, 0.0000002145253F, 145.7837F), 50.0F)
                    .Apartments = New List(Of ApartmentClass) From {weazelPlaza26, weazelPlaza70, weazelPlaza101}
                End With
                If Not buildings.Contains(weazelPlaza) Then buildings.Add(weazelPlaza)
            End If
#End Region

#Region "Stilt Houses"
            '2862 Hillcrest Avenue
            If config.GetValue(Of Boolean)("APARTMENT", "2862HCAV", True) Then
                Dim _2862HillcrestAveApt As New ApartmentClass()
                With _2862HillcrestAveApt
                    .ID = 86
                    .Name = "MP_PROP_86"
                    .Description = "MP_PROP_86DES"
                    .Price = 705000
                    .SavePos = New Vector3(-666.4602, 586.9831, 141.5956)
                    .ApartmentDoorPos = New Quaternion(-684.502F, 594.7916F, 144.3796F, 0F)
                    .ApartmentInPos = New Vector3(-680.1067, 590.6495, 145.393)
                    .ApartmentOutPos = New Vector3(-682.4827, 592.6603, 145.3797)
                    .WardrobePos = New Quaternion(-671.6359F, 587.3613F, 140.5697F, 218.6154F)
                    .GarageFilePath = "2862_hillcrest_ave"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-682.0281F, 591.2193F, 145.9482F), New Vector3(-0.5699974F, -0.000003788808F, 22.43671F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-684.446F, 593.6923F, 146.0174F), New Vector3(-0.9637012F, -0.000002214789F, -116.2243F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(-682.224F, 593.3776F, 145.5294F))
                End With
                Dim _2862HillcrestAve As New BuildingClass()
                With _2862HillcrestAve
                    .Name = "2862 Hillcrest Avenue"
                    .BuildingInPos = New Quaternion(-687.3952F, 595.6556F, 142.642F, 220.7892F)
                    .BuildingOutPos = New Quaternion(-687.8567F, 598.1826F, 142.642F, 31.52463F)
                    .BuildingLobby = New Quaternion(-685.0535F, 595.3129F, 143.0393F, 32.11814F)
                    .GarageInPos = New Vector3(-684.222, 602.92, 142.926)
                    .GarageFootInPos = New Quaternion(-680.4339F, 604.7629F, 142.7982F, 213.4816F)
                    .GarageOutPos = New Quaternion(-682.2719, 605.082, 143.0796, 8.87)
                    .CameraPos = New CameraPRH(New Vector3(-712.7956, 597.7189, 146.6349), New Vector3(-5.849331, 0, -87.56305), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-701.4848F, 605.7996F, 145.7361F), New Vector3(-5.291216F, 0F, -128.1343F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-698.0195F, 602.6122F, 145.1785F), New Vector3(1.749474F, 0F, -123.4982F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-696.6597F, 593.5092F, 141.6509F, -144.9992F))
                    .HideObjects = {"apa_ch2_09c_hs11", "CH2_09c_Emissive_11_LOD", "CH2_09c_Emissive_11", "apa_ch2_09c_hs11_details"}
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-1516927114, New Vector3(-686.0629F, 595.3705F, 144.2043F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2862HillcrestAveApt}
                End With
                If Not buildings.Contains(_2862HillcrestAve) Then buildings.Add(_2862HillcrestAve)
            End If

            '2866 Hillcrest Avenue
            If config.GetValue(Of Boolean)("APARTMENT", "2866HCAV", True) Then
                Dim _2866HillcrestAveApt As New ApartmentClass()
                With _2866HillcrestAveApt
                    .ID = 90
                    .Name = "MP_PROP_90"
                    .Description = "MP_PROP_90DES"
                    .Price = 525000
                    .SavePos = New Vector3(-742.2864F, 578.0889F, 141.486F)
                    .ApartmentDoorPos = New Quaternion(-739.8436F, 596.499F, 145.2602F, 154.217F)
                    .ApartmentInPos = New Vector3(-741.9156F, 593.0171F, 145.2681F)
                    .ApartmentOutPos = New Vector3(-740.9392F, 594.4683F, 145.2681F)
                    .WardrobePos = New Quaternion(-743.3365F, 582.6597F, 141.4606F, 153.7199F)
                    .GarageFilePath = "2866_hillcrest_ave"
                    .IPL = "apa_stilt_ch2_09c_int"
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-742.1704F, 593.3621F, 146.8467F), New Vector3(-0.8690338F, -0.000001841161F, -43.41822F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-740.7643F, 596.6168F, 147.0098F), New Vector3(-5.51471F, 0.000001407236F, 177.8408F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.IPLwoStyle
                    .Door = New Door(-658026477, New Vector3(-740.2452F, 594.4656F, 146.4097F))
                End With
                Dim _2866HillcrestAve As New BuildingClass()
                With _2866HillcrestAve
                    .Name = "2866 Hillcrest Avenue"
                    .BuildingInPos = New Quaternion(-733.7261F, 594.4695F, 141.181F, 152.2239F)
                    .BuildingOutPos = New Quaternion(-732.5177F, 594.8102F, 140.7785F, 333.7552F)
                    .BuildingLobby = New Quaternion(-733.6882F, 592.3795F, 141.526F, 331.2541F)
                    .GarageInPos = New Vector3(-742.4548F, 602.8987F, 141.5136F)
                    .GarageFootInPos = New Quaternion(-747.2038F, 602.7795F, 141.4891F, 160.8378F)
                    .GarageOutPos = New Quaternion(-742.4548F, 602.8987F, 141.5136F, 331.7553F)
                    .CameraPos = New CameraPRH(New Vector3(-727.5137F, 611.7052F, 148.4601F), New Vector3(-13.84566F, -0.0000008793234F, 135.3469F), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-727.5137F, 611.7052F, 148.4601F), New Vector3(-13.84566F, -0.0000008793234F, 135.3469F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-731.674F, 606.7108F, 145.4601F), New Vector3(-7.196094F, 0F, 139.4674F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-731.0602F, 593.8268F, 140.768F, 161.0006F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-1278729253, New Vector3(-733.8267F, 593.679F, 142.7272F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .HideObjects = {"apa_ch2_09c_hs13", "apa_ch2_09c_hs13_details", "apa_CH2_09c_House11_LOD", "ch2_09c_Emissive_13_LOD", "ch2_09c_Emissive_13"}
                    .Apartments = New List(Of ApartmentClass) From {_2866HillcrestAveApt}
                End With
                If Not buildings.Contains(_2866HillcrestAve) Then buildings.Add(_2866HillcrestAve)
            End If

            '2868 Hillcrest Avenue
            If config.GetValue(Of Boolean)("APARTMENT", "2868HCAV", True) Then
                Dim _2868HillcrestAveApt As New ApartmentClass()
                With _2868HillcrestAveApt
                    .ID = 85
                    .Name = "MP_PROP_85"
                    .Description = "MP_PROP_85DES"
                    .Price = 672000
                    .SavePos = New Vector3(-769.5107, 606.3783, 140.3565)
                    .ApartmentDoorPos = New Quaternion(-755.4508F, 619.9409F, 143.1404F, 0F)
                    .ApartmentInPos = New Vector3(-761.0836, 617.9774, 144.1539)
                    .ApartmentOutPos = New Vector3(-758.2289, 619.0676, 144.1405)
                    .WardrobePos = New Quaternion(-767.4363F, 611.0815F, 139.3306F, 114.3109F)
                    .GarageFilePath = "2868_hillcrest_ave"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-759.7622F, 619.1814F, 144.728F), New Vector3(-1.680784F, -0.000005245064F, -90.01781F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-756.6959F, 620.6716F, 144.7769F), New Vector3(-2.861892F, -0.000004274198F, 138.8788F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(-757.6743F, 618.5995F, 144.2903F))
                End With
                Dim _2868HillcrestAve As New BuildingClass()
                With _2868HillcrestAve
                    .Name = "2868 Hillcrest Avenue"
                    .BuildingInPos = New Quaternion(-753.1172F, 622.2552F, 141.5237F, 109.2664F)
                    .BuildingOutPos = New Quaternion(-750.5849F, 621.1575F, 141.2369F, 281.9844F)
                    .BuildingLobby = New Quaternion(-754.6815F, 619.9242F, 141.8568F, 289.8682F)
                    .GarageInPos = New Vector3(-754.1208, 629.6571, 141.9053)
                    .GarageFootInPos = New Quaternion(-756.4651F, 632.0547F, 141.7453F, 100.7473F)
                    .GarageOutPos = New Quaternion(-752.724, 625.291, 141.7961, 244.24)
                    .CameraPos = New CameraPRH(New Vector3(-734.5688, 618.7574, 148.982), New Vector3(-16.70547, 0, 86.47249), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-742.1857F, 633.7081F, 143.8869F), New Vector3(-7.755984F, 0F, 130.1775F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-744.1064F, 632.0983F, 145.4469F), New Vector3(-7.122308F, 0F, 128.3235F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-748.7184F, 615.1001F, 141.1166F, -72.99977F))
                    .HideObjects = {"apa_ch2_09b_hs01a_details", "apa_ch2_09b_hs01", "apa_ch2_09b_hs01_balcony", "apa_ch2_09b_Emissive_11_LOD", "apa_ch2_09b_Emissive_11", "apa_CH2_09b_House08_LOD"}
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(953540902, New Vector3(-753.5129F, 619.3382F, 143.2394F))
                    .Door2 = New Door(-1248765289, New Vector3(-754.114F, 621.1347F, 143.2394F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2868HillcrestAveApt}
                End With
                If Not buildings.Contains(_2868HillcrestAve) Then buildings.Add(_2868HillcrestAve)
            End If

            '2874 Hillcrest Avenue
            If config.GetValue(Of Boolean)("APARTMENT", "2874HCAV", True) Then
                Dim _2874HillcrestAveApt As New ApartmentClass()
                With _2874HillcrestAveApt
                    .ID = 92
                    .Name = "MP_PROP_92"
                    .Description = "MP_PROP_92DES"
                    .Price = 571000
                    .SavePos = New Vector3(-851.2404, 677.0281, 149.0784)
                    .ApartmentDoorPos = New Quaternion(-860.0256F, 693.7671F, 151.8527F, 0F)
                    .ApartmentInPos = New Vector3(-859.5645, 688.7182, 152.8571)
                    .ApartmentOutPos = New Vector3(-859.9158, 691.5079, 152.8589)
                    .WardrobePos = New Quaternion(-855.3519F, 680.0969F, 148.0489F, 182.5082F)
                    .GarageFilePath = "2874_hillcrest_ave"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-860.7798F, 689.9906F, 153.3707F), New Vector3(0.715884F, 0.0000001867775F, -22.23271F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-860.9935F, 693.2211F, 153.5973F), New Vector3(-4.927436F, -0.000001928117F, -147.9958F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(-859.3043F, 691.8406F, 153.0022F))
                End With
                Dim _2874HillcrestAve As New BuildingClass()
                With _2874HillcrestAve
                    .Name = "2874 Hillcrest Avenue"
                    .BuildingInPos = New Quaternion(-854.3719F, 695.4094F, 147.7927F, 190.9567F)
                    .BuildingOutPos = New Quaternion(-853.3763F, 699.441F, 147.7679F, 2.289755F)
                    .BuildingLobby = New Quaternion(-852.7853F, 693.8704F, 148.0418F, 3.726782F)
                    .GarageInPos = New Vector3(-864.5076, 698.6345, 148.6063)
                    .GarageFootInPos = New Quaternion(-861.3843F, 696.0538F, 147.9885F, 151.8818F)
                    .GarageOutPos = New Quaternion(-862.7094, 700.4839, 148.595, 328.02F)
                    .CameraPos = New CameraPRH(New Vector3(-863.697, 713.9671, 152.9681), New Vector3(-8.148409, 1.0781, -167.5327), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-870.0036F, 714.3647F, 152.0396F), New Vector3(-12.18705F, 0F, -156.5171F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-867.983F, 709.8389F, 152.276F), New Vector3(-11.76449F, 0F, -155.497F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-866.5663F, 700.5796F, 148.072F, 39.99988F))
                    .HideObjects = {"apa_ch2_09b_hs02", "apa_ch2_09b_hs02b_details", "apa_ch2_09b_Emissive_09_LOD", "ch2_09b_botpoolHouse02_LOD", "apa_ch2_09b_Emissive_09", "apa_ch2_09b_hs02_balcony"}
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-1278729253, New Vector3(-853.5507F, 694.6677F, 149.2446F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2874HillcrestAveApt}
                End With
                If Not buildings.Contains(_2874HillcrestAve) Then buildings.Add(_2874HillcrestAve)
            End If

            '2113 Mad Wayne Thunder Drive
            If config.GetValue(Of Boolean)("APARTMENT", "2113MWTD", True) Then
                Dim _2113MadWayneThunderDrApt As New ApartmentClass()
                With _2113MadWayneThunderDrApt
                    .ID = 94
                    .Name = "MP_PROP_94"
                    .Description = "MP_PROP_94DES"
                    .Price = 449000
                    .SavePos = New Vector3(-1282.3803, 434.7835, 94.1202)
                    .ApartmentDoorPos = New Quaternion(-1289.949F, 452.1783F, 96.89451F, 0F)
                    .ApartmentInPos = New Vector3(-1289.6389, 446.7739, 97.8989)
                    .ApartmentOutPos = New Vector3(-1289.9187, 449.8238, 97.9025)
                    .WardrobePos = New Quaternion(-1286.114F, 438.1574F, 93.09118F, 177.5123F)
                    .GarageFilePath = "2113_mad_wayne_thunder_dr"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-1290.876F, 448.4016F, 98.51272F), New Vector3(-0.8771584F, -0.000006804307F, -27.55624F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-1290.676F, 451.8625F, 98.57222F), New Vector3(-1.428376F, -0.00001233019F, -153.5391F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(-1289.193F, 450.2027F, 98.04399F))
                End With
                Dim _2113MadWayneThunderDr As New BuildingClass()
                With _2113MadWayneThunderDr
                    .Name = "2113 Mad Wayne Thunder Drive"
                    .BuildingInPos = New Quaternion(-1295.323F, 454.9241F, 96.50246F, 184.0353F)
                    .BuildingOutPos = New Quaternion(-1294.216F, 456.3217F, 96.12131F, 2.296318F)
                    .BuildingLobby = New Quaternion(-1294.24F, 453.134F, 96.64114F, 354.3855F)
                    .GarageInPos = New Vector3(-1294.9924, 456.477, 97.0332)
                    .GarageFootInPos = New Quaternion(-1300.91F, 454.9791F, 96.63154F, 180.2489F)
                    .GarageOutPos = New Quaternion(-1297.027, 456.455, 96.9554, 322.69)
                    .CameraPos = New CameraPRH(New Vector3(-1306.412, 467.0048, 102.6207), New Vector3(-17.02023, 0, -141.3645), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-1299.812F, 469.2448F, 98.88928F), New Vector3(-7.54013F, 0F, -155.5267F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1297.086F, 464.1164F, 99.2229F), New Vector3(-8.10345F, 0F, -160.1825F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1290.902F, 456.3815F, 95.88345F, 2.999995F))
                    .HideObjects = {"apa_ch2_12b_house03mc", "ch2_12b_emissive_02", "ch2_12b_house03_MC_a_LOD", "ch2_12b_emissive_02_LOD", "ch2_12b_railing_06"}
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-738253, New Vector3(-1294.866F, 453.9819F, 97.80495F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2113MadWayneThunderDrApt}
                End With
                If Not buildings.Contains(_2113MadWayneThunderDr) Then buildings.Add(_2113MadWayneThunderDr)
            End If

            '2117 Milton Road
            If config.GetValue(Of Boolean)("APARTMENT", "2117MTRD", True) Then
                Dim _2117MiltonRdApt As New ApartmentClass()
                With _2117MiltonRdApt
                    .ID = 89
                    .Name = "MP_PROP_89"
                    .Description = "MP_PROP_89DES"
                    .Price = 608000
                    .SavePos = New Vector3(-568.4787, 645.6554, 142.0576)
                    .ApartmentDoorPos = New Quaternion(-571.3181F, 664.392F, 144.8318F, 0F)
                    .ApartmentInPos = New Vector3(-572.4428, 658.958, 145.8364)
                    .ApartmentOutPos = New Vector3(-571.8295, 662.1631, 145.8388)
                    .WardrobePos = New Quaternion(-571.2837F, 649.8463F, 141.032F, 167.8028F)
                    .GarageFilePath = "2117_milton_rd"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-573.0067F, 660.9579F, 146.3971F), New Vector3(-0.2333052F, -0.0000005869742F, -38.99221F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-572.3709F, 664.3209F, 146.4011F), New Vector3(0.002916445F, -0.0000008503343F, -165.4475F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(-571.1619F, 662.2983F, 145.9814F))
                End With
                Dim _2117MiltonRd As New BuildingClass()
                With _2117MiltonRd
                    .Name = "2117 Milton Road"
                    .BuildingInPos = New Quaternion(-558.5587F, 664.2407F, 144.4564F, 173.1578F)
                    .BuildingOutPos = New Quaternion(-558.5435F, 666.3166F, 144.1324F, 343.9139F)
                    .BuildingLobby = New Quaternion(-559.8985F, 662.6853F, 144.4828F, 344.0194F)
                    .GarageInPos = New Vector3(-555.3114, 665.145, 144.6135)
                    .GarageFootInPos = New Quaternion(-553.761F, 663.1923F, 144.3056F, 69.52739F)
                    .GarageOutPos = New Quaternion(-555.117, 666.15, 144.4309, 343.26)
                    .CameraPos = New CameraPRH(New Vector3(-548.5573, 669.8001, 146.1121), New Vector3(-6.038576, 0, 124.0644), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-547.1796F, 672.5804F, 147.4934F), New Vector3(-15.5667F, 0F, 127.3951F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-550.8351F, 669.7869F, 147.4934F), New Vector3(-15.5667F, 0F, 127.3951F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-560.4914F, 669.8436F, 144.3237F, -16.99999F))
                    .HideObjects = {"apa_ch2_09c_hs07", "ch2_09c_build_11_07_LOD", "CH2_09c_Emissive_07_LOD", "apa_ch2_09c_build_11_07_LOD", "ch2_09c_hs07_details", "CH2_09c_Emissive_07"}
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-738253, New Vector3(-559.1312F, 663.2863F, 145.6409F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2117MiltonRdApt}
                End With
                If Not buildings.Contains(_2117MiltonRd) Then buildings.Add(_2117MiltonRd)
            End If

            '2044 North Conker Avenue
            If config.GetValue(Of Boolean)("APARTMENT", "2044NCAV", True) Then
                Dim _2044NorthConkerAveApt As New ApartmentClass()
                With _2044NorthConkerAveApt
                    .ID = 84
                    .Name = "MP_PROP_84"
                    .Description = "MP_PROP_84DES"
                    .Price = 762000
                    .SavePos = New Vector3(332.7306, 423.6146, 145.5968)
                    .ApartmentDoorPos = New Quaternion(344.6125F, 439.5033F, 148.3806F, 0F)
                    .ApartmentInPos = New Vector3(340.6531, 436.7456, 149.394)
                    .ApartmentOutPos = New Vector3(342.1347, 437.8865, 149.3808)
                    .WardrobePos = New Quaternion(334.3885F, 428.503F, 144.5707F, 108.439F)
                    .GarageFilePath = "2044_north_conker_ave"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(340.6346F, 437.8854F, 149.7858F), New Vector3(5.800322F, -0.000006302166F, -86.00694F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(343.4405F, 439.6113F, 149.9108F), New Vector3(1.863302F, -0.000006460079F, 148.5587F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(342.7773F, 437.4438F, 149.5304F))
                End With
                Dim _2044NorthConkerAve As New BuildingClass()
                With _2044NorthConkerAve
                    .Name = "2044 North Conker Avenue"
                    .BuildingInPos = New Quaternion(346.2178F, 441.8962F, 146.702F, 115.5625F)
                    .BuildingOutPos = New Quaternion(350.3196F, 443.1912F, 145.935F, 314.7183F)
                    .BuildingLobby = New Quaternion(345.1629F, 439.8701F, 147.0905F, 293.8614F)
                    .GarageInPos = New Vector3(352.814, 437.2492, 146.3828)
                    .GarageFootInPos = New Quaternion(353.4832F, 433.1829F, 146.3587F, 116.1643F)
                    .GarageOutPos = New Quaternion(356.54, 439.226, 145.098, 294.08)
                    .CameraPos = New CameraPRH(New Vector3(347.726, 459.0123, 150.3243), New Vector3(-3.703, 0, 161.5176), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(357.144F, 453.5841F, 148.8181F), New Vector3(-8.454393F, 0F, 134.5525F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(348.0152F, 458.2567F, 148.6299F), New Vector3(3.655707F, 0F, 161.996F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(349.7076F, 445.5944F, 145.218F, -38.99986F))
                    .HideObjects = {"apa_ch2_04_house02", "apa_ch2_04_house02_d", "apa_ch2_04_M_a_LOD", "ch2_04_house02_railings", "ch2_04_emissive_04", "ch2_04_emissive_04_LOD", "apa_ch2_04_house02_details"}
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-1516927114, New Vector3(345.579F, 440.7786F, 148.2533F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2044NorthConkerAveApt}
                End With
                If Not buildings.Contains(_2044NorthConkerAve) Then buildings.Add(_2044NorthConkerAve)
            End If

            '2045 North Conker Avenue
            If config.GetValue(Of Boolean)("APARTMENT", "2045NCAV", True) Then
                Dim _2045NorthConkerAveApt As New ApartmentClass()
                With _2045NorthConkerAveApt
                    .ID = 95
                    .Name = "MP_PROP_95"
                    .Description = "MP_PROP_95DES"
                    .Price = 727000
                    .SavePos = New Vector3(377.2632, 407.4584, 142.1256)
                    .ApartmentDoorPos = New Quaternion(374.2007F, 426.1936F, 144.8999F, 0F)
                    .ApartmentInPos = New Vector3(373.2864, 420.6612, 145.9045)
                    .ApartmentOutPos = New Vector3(373.7533, 423.8348, 145.9078)
                    .WardrobePos = New Quaternion(374.4204F, 411.802F, 141.1002F, 159.7387F)
                    .GarageFilePath = "2045_north_conker_ave"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(372.4944F, 422.6966F, 146.5321F), New Vector3(-1.5839F, -0.0000003202875F, -37.55392F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(373.4966F, 426.0858F, 146.4762F), New Vector3(-0.08786825F, -0.000004846671F, -172.6701F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(374.3812F, 424.0682F, 146.0494F))
                End With
                Dim _2045NorthConkerAve As New BuildingClass()
                With _2045NorthConkerAve
                    .Name = "2045 North Conker Avenue"
                    .BuildingInPos = New Quaternion(372.3179F, 427.8956F, 144.6842F, 173.3735F)
                    .BuildingOutPos = New Quaternion(372.3571F, 433.0236F, 143.44F, 351.4999F)
                    .BuildingLobby = New Quaternion(375.3373F, 427.2896F, 144.6839F, 75.35755F)
                    .GarageInPos = New Vector3(391.3488, 430.2205, 143.1705)
                    .GarageFootInPos = New Quaternion(387.3123F, 429.0544F, 143.0907F, 168.6405F)
                    .GarageOutPos = New Quaternion(392.482, 430.467, 143.0165, 298.54)
                    .CameraPos = New CameraPRH(New Vector3(366.7971, 447.0355, 148.0793), New Vector3(-8.704479, -2.1593, -156.5936), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(367.6814F, 448.751F, 148.0813F), New Vector3(-9.862497F, 0F, -167.5893F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(369.5516F, 440.801F, 148.9076F), New Vector3(-15.4247F, 0F, -170.2767F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(379.1338F, 430.2363F, 143.1804F, 165.999F))
                    .HideObjects = {"apa_ch2_04_house01", "apa_ch2_04_house01_d", "ch2_04_emissive_05_LOD", "apa_ch2_04_M_b_LOD", "ch2_04_emissive_05", "ch2_04_house01_details"}
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-833759002, New Vector3(374.6819F, 428.2515F, 145.7855F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2045NorthConkerAveApt}
                End With
                If Not buildings.Contains(_2045NorthConkerAve) Then buildings.Add(_2045NorthConkerAve)
            End If

            '3677 Whispymound Drive
            If config.GetValue(Of Boolean)("APARTMENT", "3677WMDR", True) Then
                Dim _3677WhispymoundDrApt As New ApartmentClass()
                With _3677WhispymoundDrApt
                    .ID = 87
                    .Name = "MP_PROP_87"
                    .Description = "MP_PROP_87DES"
                    .Price = 478000
                    .SavePos = New Vector3(126.1813, 545.9031, 180.5226)
                    .ApartmentDoorPos = New Quaternion(116.9348F, 562.4651F, 183.2969F, 0F)
                    .ApartmentInPos = New Vector3(117.5057, 557.3167, 184.3022)
                    .ApartmentOutPos = New Vector3(117.2371, 560.0856, 184.3048)
                    .WardrobePos = New Quaternion(122.0271F, 548.9055F, 179.4929F, 181.4568F)
                    .GarageFilePath = "3677_whispymound_dr"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(116.683F, 558.7029F, 184.8026F), New Vector3(1.974957F, -0.000000854281F, -14.23625F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(115.9096F, 561.972F, 184.8317F), New Vector3(1.266295F, -0.000003309181F, -139.5111F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(117.7951F, 560.5258F, 184.4464F))
                End With
                Dim _3677WhispymoundDr As New BuildingClass()
                With _3677WhispymoundDr
                    .Name = "3677 Whispymound Drive"
                    .BuildingInPos = New Quaternion(118.2447F, 564.3248F, 182.9595F, 184.5798F)
                    .BuildingOutPos = New Quaternion(119.2089F, 567.0546F, 182.1205F, 0.3951373F)
                    .BuildingLobby = New Quaternion(119.535F, 563.3027F, 182.9693F, 6.317203F)
                    .GarageInPos = New Vector3(131.7664, 568.0024, 183.1025)
                    .GarageFootInPos = New Quaternion(128.9535F, 566.6158F, 182.7594F, 182.9515F)
                    .GarageOutPos = New Quaternion(132.723, 568.142, 183.099, 335.12)
                    .CameraPos = New CameraPRH(New Vector3(112.5791, 574.6387, 190.8119), New Vector3(-21.01317, 0, -144.2139), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(110.5211F, 577.4346F, 184.6888F), New Vector3(-0.3576312F, 0F, -139.767F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(113.4681F, 573.951F, 184.6891F), New Vector3(-0.3575675F, 0F, -139.7686F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(114.8398F, 567.6824F, 182.0014F, -177.9989F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-1278729253, New Vector3(120.0483F, 563.6331F, 184.1356F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .HideObjects = {"apa_ch2_05c_b4", "ch2_05c_emissive_07", "ch2_05c_decals_05", "ch2_05c_B4_LOD"}
                    .Apartments = New List(Of ApartmentClass) From {_3677WhispymoundDrApt}
                End With
                If Not buildings.Contains(_3677WhispymoundDr) Then buildings.Add(_3677WhispymoundDr)
            End If

            '3655 Wild Oats Drive
            If config.GetValue(Of Boolean)("APARTMENT", "3655WODR", True) Then
                Dim _3655WildOatsDrApt As New ApartmentClass()
                With _3655WildOatsDrApt
                    .ID = 83
                    .Name = "MP_PROP_83"
                    .Description = "MP_PROP_83DES"
                    .Price = 800000
                    .SavePos = New Vector3(-163.1819, 484.9918, 133.8695)
                    .ApartmentDoorPos = New Quaternion(-175.3112F, 500.5898F, 136.6535F, 0F)
                    .ApartmentInPos = New Vector3(-173.286, 495.0179, 137.667)
                    .ApartmentOutPos = New Vector3(-174.3115, 497.8294, 137.6536)
                    .WardrobePos = New Quaternion(-167.3885F, 487.8109F, 132.8436F, 191.4724F)
                    .GarageFilePath = "3655_wild_oats_dr"
                    .IPL = Nothing
                    .AptStyleCam = Nothing
                    .EnterCam = New CameraPRH(New Vector3(-175.0323F, 496.2828F, 138.2804F), New Vector3(-1.126299F, 0.000006191054F, -17.43848F), 50.0F)
                    .ExitCam = New CameraPRH(New Vector3(-175.5355F, 499.6599F, 138.3829F), New Vector3(-3.260017F, -0.0000008551576F, -141.572F), 50.0F)
                    .GarageElevatorPos = Vector3.Zero
                    .GarageMenuPos = Vector3.Zero
                    .ApartmentType = eApartmentType.None
                    .Door = New Door(-658026477, New Vector3(-173.7538F, 498.3235F, 137.8034F))
                End With
                Dim _3655WildOatsDr As New BuildingClass()
                With _3655WildOatsDr
                    .Name = "3655 Wild Oats Drive"
                    .BuildingInPos = New Quaternion(-176.128F, 501.8195F, 136.42F, 181.8932F)
                    .BuildingOutPos = New Quaternion(-177.7746F, 504.3338F, 135.8636F, 17.95896F)
                    .BuildingLobby = New Quaternion(-173.3519F, 502.5593F, 136.4234F, 91.47756F)
                    .GarageInPos = New Vector3(-189.307, 502.66, 133.9093)
                    .GarageFootInPos = New Quaternion(-192.8916F, 499.4156F, 133.5215F, 202.9954F)
                    .GarageOutPos = New Quaternion(-187.563, 502.25, 134.13, 332.11)
                    .CameraPos = New CameraPRH(New Vector3(-198.8929, 511.1027, 136.112), New Vector3(4.350469, 0, -128.423), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-193.8861F, 517.1055F, 137.4361F), New Vector3(-1.835988F, 0F, -144.4966F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-191.1199F, 513.4308F, 137.5096F), New Vector3(-2.962687F, 0F, -147.5567F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-182.7856F, 504.6987F, 134.3637F, -165.0006F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-833759002, New Vector3(-174.2531F, 503.1949F, 137.5228F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .HideObjects = {"apa_ch2_05e_res5", "apa_ch2_05e_res5_LOD"}
                    .Apartments = New List(Of ApartmentClass) From {_3655WildOatsDrApt}
                End With
                If Not buildings.Contains(_3655WildOatsDr) Then buildings.Add(_3655WildOatsDr)
            End If
#End Region

#Region "Medium End Apartments"
            '0115 Bay City Ave
            If config.GetValue(Of Boolean)("APARTMENT", "0115BCAV", True) Then
                Dim _0115BayCityAve45 As New ApartmentClass()
                With _0115BayCityAve45
                    .ID = 14
                    .Name = "MP_PROP_14"
                    .Description = "MP_PROP_14DES"
                    .Price = 150000
                    .GarageFilePath = "0115_bay_city_ave_45"
                    .SetAsMediumApartment
                End With
                Dim _0115BayCityAve As New BuildingClass()
                With _0115BayCityAve
                    .Name = "0115 Bay City Ave"
                    .BuildingInPos = New Quaternion(-968.9597F, -1433.243F, 6.679171F, 295.2657F)
                    .BuildingOutPos = New Quaternion(-972.0879F, -1432.178F, 6.679171F, 104.6189F)
                    .BuildingLobby = New Quaternion(-967.2436F, -1430.285F, 6.763628F, 104.682F)
                    .GarageInPos = New Vector3(-982.9502, -1450.931, 4.38989)
                    .GarageFootInPos = New Quaternion(-980.3836F, -1447.838F, 3.720404F, 17.90004F)
                    .GarageOutPos = New Quaternion(-993.4175, -1425.568, 4.386545, 107.4124)
                    .CameraPos = New CameraPRH(New Vector3(-1012.979, -1429.618, 6.07423), New Vector3(9.87174, 0, -98.14085), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-992.3F, -1455.474F, 8.042947F), New Vector3(5.626956F, 0F, -42.1384F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1001.057F, -1422.589F, 11.79935F), New Vector3(-6.623852F, 0F, -106.4819F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-985.858F, -1443.61987F, 4.185236F, 80.0F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-106323690, New Vector3(-969.3597F, -1429.983F, 7.971441F))
                    .Door2 = New Door(-2042007659, New Vector3(-968.6031F, -1432.039F, 6.768328F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0115BayCityAve45}
                End With
                If Not buildings.Contains(_0115BayCityAve) Then buildings.Add(_0115BayCityAve)
            End If

            'Dream Tower
            If config.GetValue(Of Boolean)("APARTMENT", "DMTR", True) Then
                Dim dreamTower15 As New ApartmentClass()
                With dreamTower15
                    .ID = 16
                    .Name = "MP_PROP_16"
                    .Description = "MP_PROP_16DES"
                    .Price = 134000
                    .GarageFilePath = "dream_tower_15"
                    .SetAsMediumApartment
                End With
                Dim dreamTower As New BuildingClass()
                With dreamTower
                    .Name = "Dream Tower"
                    .BuildingInPos = New Quaternion(-763.0345F, -750.8807F, 26.87314F, 89.16949F)
                    .BuildingOutPos = New Quaternion(-760.9033F, -753.8873F, 26.86856F, 265.6472F)
                    .BuildingLobby = New Quaternion(-766.136F, -753.9084F, 26.87519F, 268.4077F)
                    .GarageInPos = New Vector3(-787.0813, -801.8603, 20.6192)
                    .GarageFootInPos = New Quaternion(-782.9156F, -800.0248F, 19.7514F, 270.3137F)
                    .GarageOutPos = New Quaternion(-789.551, -815.7581, 20.1855, 181.6813)
                    .CameraPos = New CameraPRH(New Vector3(-730.9564, -866.194, 39.5012), New Vector3(9.584155, 0, 35.26235), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-743.0842F, -743.1183F, 37.04325F), New Vector3(-17.28252F, 0F, 124.74F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-743.9262F, -743.5906F, 40.21276F), New Vector3(42.0002F, 0F, 126.3212F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-756.5352F, -759.9523F, 25.2726F, -89.99974F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-1447681559, New Vector3(-763.9033F, -755.0774F, 28.18733F))
                    .Door2 = New Door(1543931499, New Vector3(-763.9038F, -752.4891F, 28.18733F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {dreamTower15}
                End With
                If Not buildings.Contains(dreamTower) Then buildings.Add(dreamTower)
            End If

            '4 Hangman Ave
            If config.GetValue(Of Boolean)("APARTMENT", "4HMDR", True) Then
                Dim _4HangmanAveApt As New ApartmentClass()
                With _4HangmanAveApt
                    .ID = 72
                    .Name = "MP_PROP_72"
                    .Description = "MP_PROP_72DES"
                    .Price = 175000
                    .GarageFilePath = "4_hangman_ave"
                    .SetAsMediumApartment
                End With
                Dim _4HangmanAve As New BuildingClass()
                With _4HangmanAve
                    .Name = "4 Hangman Ave"
                    .BuildingInPos = New Quaternion(-1406.162F, 528.3837F, 122.8313F, 268.0251F)
                    .BuildingOutPos = New Quaternion(-1406.496F, 532.2239F, 121.9276F, 3.244553F)
                    .BuildingLobby = New Quaternion(-1406.137F, 526.6689F, 122.8355F, 359.3124F)
                    .GarageInPos = New Vector3(-1409.864, 540.1284, 122.5761)
                    .GarageFootInPos = New Quaternion(-1406.328F, 535.549F, 121.9281F, 269.7232F)
                    .GarageOutPos = New Quaternion(-1421.402, 535.7197, 120.7177, 111.9388)
                    .CameraPos = New CameraPRH(New Vector3(-1437.455, 533.4254, 122.9885), New Vector3(-4.026862, 0, -94.79375), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-1433.229F, 529.8447F, 123.8805F), New Vector3(-12.98773F, 0F, -83.01761F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1426.348F, 531.0089F, 123.0685F), New Vector3(-2.497101F, 0F, -87.09882F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1425.671F, 524.3229F, 117.4346F, -89.99987F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_4HangmanAveApt}
                End With
                If Not buildings.Contains(_4HangmanAve) Then buildings.Add(_4HangmanAve)
            End If

            '0604 Las Lagunas Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "0604LLBL", True) Then
                Dim _0604LasLagunasBlvd4 As New ApartmentClass()
                With _0604LasLagunasBlvd4
                    .ID = 10
                    .Name = "MP_PROP_10"
                    .Description = "MP_PROP_10DES"
                    .Price = 126000
                    .GarageFilePath = "0604_las_lagunas_blvd_4"
                    .SetAsMediumApartment
                End With
                Dim _0604LasLagunasBlvd As New BuildingClass()
                With _0604LasLagunasBlvd
                    .Name = "0604 Las Lagunas Blvd"
                    .BuildingInPos = New Quaternion(11.93229F, 81.0723F, 77.43513F, 245.1201F)
                    .BuildingOutPos = New Quaternion(10.86585F, 84.90939F, 77.39817F, 336.0916F)
                    .BuildingLobby = New Quaternion(8.42334F, 78.24831F, 77.44009F, 332.8646F)
                    .GarageInPos = New Vector3(27.83206, 80.46669, 74.25099)
                    .GarageFootInPos = New Quaternion(23.66939F, 79.08036F, 73.63882F, 156.6944F)
                    .GarageOutPos = New Quaternion(39.44078, 77.11552, 74.9635, 241.9727)
                    .CameraPos = New CameraPRH(New Vector3(-31.15757, 105.2271, 81.74537), New Vector3(6.371637, 0, -137.1451), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-20.9733F, 109.4043F, 83.1152F), New Vector3(5.766655F, 0F, -139.2088F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-32.46793F, 90.74984F, 86.03851F), New Vector3(0.3453688F, 0F, -111.2078F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-11.52826F, 90.36213F, 76.46286F, -109.9996F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(1596276849, New Vector3(8.739929F, 81.30667F, 78.65253F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0604LasLagunasBlvd4}
                End With
                If Not buildings.Contains(_0604LasLagunasBlvd) Then buildings.Add(_0604LasLagunasBlvd)
            End If

            '0184 Milton Rd
            If config.GetValue(Of Boolean)("APARTMENT", "0184MTRD", True) Then
                Dim _0184MiltonRd13 As New ApartmentClass()
                With _0184MiltonRd13
                    .ID = 11
                    .Name = "MP_PROP_11"
                    .Description = "MP_PROP_11DES"
                    .Price = 146000
                    .GarageFilePath = "0184_milton_rd_13"
                    .SetAsMediumApartment
                End With
                Dim _0184MiltonRd As New BuildingClass()
                With _0184MiltonRd
                    .Name = "0184 Milton Rd"
                    .BuildingInPos = New Quaternion(-510.2473F, 108.7654F, 62.80054F, 187.109F)
                    .BuildingOutPos = New Quaternion(-511.9591F, 111.4473F, 62.35081F, 4.710365F)
                    .BuildingLobby = New Quaternion(-511.1704F, 105.4279F, 62.80053F, 3.240718F)
                    .GarageInPos = New Vector3(-521.9894, 92.31882, 59.75345)
                    .GarageFootInPos = New Quaternion(-497.2905F, 78.43092F, 54.90026F, 259.0138F)
                    .GarageOutPos = New Quaternion(-536.3447, 92.78167, 60.42566, 87.18483)
                    .CameraPos = New CameraPRH(New Vector3(-526.9971, 133.2838, 65.28127), New Vector3(5.028964, 0, -148.544), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-514.3969F, 132.7893F, 67.846F), New Vector3(1.331019F, 0F, -168.7934F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-499.7988F, 133.2774F, 67.84874F), New Vector3(0.767808F, 0F, -158.6685F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-506.6722F, 112.8424F, 62.4247F, 46.99992F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(-725970636, New Vector3(-510.4186F, 107.9995F, 64.01761F))
                    .Door2 = New Door(827574885, New Vector3(-512.844F, 107.6585F, 64.01761F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0184MiltonRd13}
                End With
                If Not buildings.Contains(_0184MiltonRd) Then buildings.Add(_0184MiltonRd)
            End If

            '1162 Power St
            If config.GetValue(Of Boolean)("APARTMENT", "1162PWST", True) Then
                Dim _1162PowerSt3 As New ApartmentClass()
                With _1162PowerSt3
                    .ID = 8
                    .Name = "MP_PROP_8"
                    .Description = "MP_PROP_8DES"
                    .Price = 130000
                    .GarageFilePath = "1162_power_street_3"
                    .SetAsMediumApartment
                End With
                Dim _1162PowerSt As New BuildingClass()
                With _1162PowerSt
                    .Name = "1162 Power St"
                    .BuildingInPos = New Quaternion(284.9267F, -161.9545F, 63.61711F, 253.1728F)
                    .BuildingOutPos = New Quaternion(282.69F, -159.3567F, 62.62032F, 73.79153F)
                    .BuildingLobby = New Quaternion(288.5899F, -161.2495F, 63.61877F, 67.12601F)
                    .GarageInPos = New Vector3(281.59, -146.9051, 64.62709)
                    .GarageFootInPos = New Quaternion(285.5763F, -144.4771F, 64.11669F, 247.2319F)
                    .GarageOutPos = New Quaternion(271.4526, -143.1953, 64.92351, 71.11879)
                    .CameraPos = New CameraPRH(New Vector3(247.5116, -143.1925, 67.63675), New Vector3(1.717242, 0, -99.06012), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(264.757F, -154.3596F, 65.61347F), New Vector3(-9.511657F, 0F, -88.20109F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(265.054F, -154.3426F, 63.86195F), New Vector3(28.86012F, 0F, -88.38718F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(270.8202F, -151.4185F, 62.89344F, -110.0003F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(1523529669, New Vector3(286.9091F, -159.2244F, 64.84488F))
                    .Door2 = New Door(1596276849, New Vector3(285.9412F, -161.8838F, 64.84488F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_1162PowerSt3}
                End With
                If Not buildings.Contains(_1162PowerSt) Then buildings.Add(_1162PowerSt)
            End If

            '4401 Procopio Dr
            If config.GetValue(Of Boolean)("APARTMENT", "4401PPDR", True) Then
                Dim _4401ProcopioDrApt As New ApartmentClass()
                With _4401ProcopioDrApt
                    .ID = 75
                    .Name = "MP_PROP_75"
                    .Description = "MP_PROP_75DES"
                    .Price = 165000
                    .GarageFilePath = "4401_procopio_dr"
                    .SetAsMediumApartment
                End With
                Dim _4401ProcopioDr As New BuildingClass()
                With _4401ProcopioDr
                    .Name = "4401 Procopio Dr"
                    .BuildingInPos = New Quaternion(-301.8188F, 6328.303F, 31.88649F, 226.5495F)
                    .BuildingOutPos = New Quaternion(-304.3905F, 6329.918F, 31.48935F, 46.05778F)
                    .BuildingLobby = New Quaternion(-302.2718F, 6327.04F, 31.88734F, 38.47432F)
                    .GarageInPos = New Vector3(-294.8063, 6338.88, 32.00024)
                    .GarageFootInPos = New Quaternion(-294.687F, 6333.548F, 31.48935F, 222.4F)
                    .GarageOutPos = New Quaternion(-296.2461, 6340.683, 31.76276, 44.08249)
                    .CameraPos = New CameraPRH(New Vector3(-304.3051, 6344.134, 33.43044), New Vector3(-6.942835, 0, -170.2991), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-302.4189F, 6344.361F, 33.79319F), New Vector3(-4.512773F, 0F, -149.3539F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-312.6476F, 6336.418F, 34.04261F), New Vector3(-7.117667F, 0F, -142.2964F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-309.4597F, 6332.186F, 30.26265F, 43.99991F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_4401ProcopioDrApt}
                End With
                If Not buildings.Contains(_4401ProcopioDr) Then buildings.Add(_4401ProcopioDr)
            End If

            '4584 Procopio Dr
            If config.GetValue(Of Boolean)("APARTMENT", "4584PPDR", True) Then
                Dim _4584ProcopioDrApt As New ApartmentClass()
                With _4584ProcopioDrApt
                    .ID = 74
                    .Name = "MP_PROP_74"
                    .Description = "MP_PROP_74DES"
                    .Price = 155000
                    .GarageFilePath = "4584_procopio_dr"
                    .SetAsMediumApartment
                End With
                Dim _4584ProcopioDr As New BuildingClass()
                With _4584ProcopioDr
                    .Name = "4584 Procopio Dr"
                    .BuildingInPos = New Quaternion(-107.2951F, 6529.278F, 28.85814F, 226.0258F)
                    .BuildingOutPos = New Quaternion(-108.5191F, 6531.843F, 28.80917F, 40.73323F)
                    .BuildingLobby = New Quaternion(-105.0338F, 6528.75F, 29.16313F, 43.26908F)
                    .GarageInPos = New Vector3(-105.0798, 6534.642, 29.56255)
                    .GarageFootInPos = New Quaternion(-100.4929F, 6533.512F, 28.80917F, 226.8708F)
                    .GarageOutPos = New Quaternion(-108.9384, 6538.451, 29.60509, 47.39733)
                    .CameraPos = New CameraPRH(New Vector3(-114.0698, 6545.125, 30.18196), New Vector3(-1.917315, 0, -155.1204), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-115.7358F, 6545.911F, 32.30983F), New Vector3(-10.63827F, 0F, -159.0272F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-112.7549F, 6538.335F, 32.52457F), New Vector3(-13.38342F, 0F, -153.5122F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-115.3847F, 6535.471F, 28.72985F, 44.99985F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_4584ProcopioDrApt}
                End With
                If Not buildings.Contains(_4584ProcopioDr) Then buildings.Add(_4584ProcopioDr)
            End If

            '0504 S Mo Milton Dr
            If config.GetValue(Of Boolean)("APARTMENT", "0504SMMD", True) Then
                Dim _0504SMoMiltonDrApt As New ApartmentClass()
                With _0504SMoMiltonDrApt
                    .ID = 13
                    .Name = "MP_PROP_13"
                    .Description = "MP_PROP_13DES"
                    .Price = 141000
                    .GarageFilePath = "0504_s_mo_milton_dr"
                    .SetAsMediumApartment
                End With
                Dim _0504SMoMiltonDr As New BuildingClass()
                With _0504SMoMiltonDr
                    .Name = "0504 S Mo Milton Dr"
                    .BuildingInPos = New Quaternion(-628.4631F, 168.0906F, 60.14972F, 267.812F)
                    .BuildingOutPos = New Quaternion(-630.957F, 169.8016F, 60.30886F, 85.45199F)
                    .BuildingLobby = New Quaternion(-625.2684F, 169.8864F, 60.16246F, 94.83202F)
                    .GarageInPos = New Vector3(-630.657, 152.3768, 56.41848)
                    .GarageFootInPos = New Quaternion(-626.5711F, 149.506F, 55.51507F, 198.6616F)
                    .GarageOutPos = New Quaternion(-638.4281, 152.3656, 57.24699, 89.08953)
                    .CameraPos = New CameraPRH(New Vector3(-663.4779, 162.9781, 62.82269), New Vector3(7.656792, 0, -92.89036), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-641.499F, 146.8024F, 62.44689F), New Vector3(-4.820535F, 0F, -58.53614F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-640.8782F, 147.355F, 59.44838F), New Vector3(35.80408F, 0F, -60.85418F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-636.4809F, 164.2299F, 59.02254F, -88.99973F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(2049718375, New Vector3(-627.3351F, 170.8729F, 61.2907F))
                    .Door2 = New Door(216030657, New Vector3(-627.3351F, 168.5309F, 61.2907F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0504SMoMiltonDrApt}
                End With
                If Not buildings.Contains(_0504SMoMiltonDr) Then buildings.Add(_0504SMoMiltonDr)
            End If

            '0325 South Rockford Dr
            If config.GetValue(Of Boolean)("APARTMENT", "0325SRFD", True) Then
                Dim _0325SouthRockfordDrApt As New ApartmentClass()
                With _0325SouthRockfordDrApt
                    .ID = 15
                    .Name = "MP_PROP_15"
                    .Description = "MP_PROP_15DES"
                    .Price = 137000
                    .GarageFilePath = "0325_south_rockford_dr"
                    .SetAsMediumApartment
                End With
                Dim _0325SouthRockfordDr As New BuildingClass()
                With _0325SouthRockfordDr
                    .Name = "0325 South Rockford Dr"
                    .BuildingInPos = New Quaternion(-833.2334F, -862.5095F, 19.68971F, 92.72639F)
                    .BuildingOutPos = New Quaternion(-831.49F, -860.4144F, 19.68967F, 1.616654F)
                    .BuildingLobby = New Quaternion(-831.3128F, -865.3038F, 19.70801F, 1.040161F)
                    .GarageInPos = New Vector3(-758.8065, -870.7308, 20.9393)
                    .GarageFootInPos = New Quaternion(-762.5671F, -866.1973F, 19.97855F, 89.98593F)
                    .GarageOutPos = New Quaternion(-755.0645, -870.7145, 21.18062, 267.8936)
                    .CameraPos = New CameraPRH(New Vector3(-846.1815, -821.6712, 21.12708), New Vector3(9.139385, 0, -142.4772), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-837.5078F, -840.4797F, 25.09497F), New Vector3(-0.8073542F, 0F, -151.9999F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-815.1024F, -836.9585F, 24.44102F), New Vector3(7.923132F, 0F, -150.2361F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-838.065552F, -849.9184F, 18.380209F, 41.99988F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(340291898, New Vector3(-830.0517F, -862.994F, 21.09349F))
                    .Door2 = New Door(1701450624, New Vector3(-832.8119F, -862.9924F, 21.08801F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0325SouthRockfordDrApt}
                End With
                If Not buildings.Contains(_0325SouthRockfordDr) Then buildings.Add(_0325SouthRockfordDr)
            End If

            '0605 Spanish Ave
            If config.GetValue(Of Boolean)("APARTMENT", "0605SNAV", True) Then
                Dim _0605SpanishAve1 As New ApartmentClass()
                With _0605SpanishAve1
                    .ID = 9
                    .Name = "MP_PROP_9"
                    .Description = "MP_PROP_9DES"
                    .Price = 128000
                    .GarageFilePath = "0605_spanish_ave_1"
                    .SetAsMediumApartment
                End With
                Dim _0605SpanishAve As New BuildingClass()
                With _0605SpanishAve
                    .Name = "0605 Spanish Ave"
                    .BuildingInPos = New Quaternion(5.622878F, 36.0617F, 70.53041F, 251.2921F)
                    .BuildingOutPos = New Quaternion(2.416785F, 34.00145F, 70.15239F, 155.5339F)
                    .BuildingLobby = New Quaternion(4.652481F, 40.22895F, 70.52762F, 155.683F)
                    .GarageInPos = New Vector3(-11.9249, 37.897, 71.08931)
                    .GarageFootInPos = New Quaternion(-5.866289F, 39.95559F, 70.35876F, 244.2964F)
                    .GarageOutPos = New Quaternion(-12.86958, 35.41181, 71.03293, 158.7376)
                    .CameraPos = New CameraPRH(New Vector3(-23.84228, 11.21701, 74.10461), New Vector3(10.09729, 0, -29.36126), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-5.189341F, 6.643641F, 73.18093F), New Vector3(-3.764352F, 0F, -15.98091F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-5.157282F, 6.790481F, 72.23835F), New Vector3(22.07496F, 0F, -16.25898F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1.729892F, 34.72532F, 70.17053F, -18.99999F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(1596276849, New Vector3(4.402985F, 37.3213F, 71.75453F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0605SpanishAve1}
                End With
                If Not buildings.Contains(_0605SpanishAve) Then buildings.Add(_0605SpanishAve)
            End If

            '12 Sustancia Rd
            If config.GetValue(Of Boolean)("APARTMENT", "12STCR", True) Then
                Dim _12SustanciaRdApt As New ApartmentClass()
                With _12SustanciaRdApt
                    .ID = 73
                    .Name = "MP_PROP_73"
                    .Description = "MP_PROP_73DES"
                    .Price = 143000
                    .GarageFilePath = "12_sustancia_rd"
                    .SetAsMediumApartment
                End With
                Dim _12SustanciaRd As New BuildingClass()
                With _12SustanciaRd
                    .Name = "12 Sustancia Rd"
                    .BuildingInPos = New Quaternion(1336.244F, -1579.887F, 53.05425F, 25.44027F)
                    .BuildingOutPos = New Quaternion(1338.215F, -1580.812F, 53.05154F, 216.1938F)
                    .BuildingLobby = New Quaternion(1336.788F, -1578.938F, 53.44422F, 215.6132F)
                    .GarageInPos = New Vector3(1351.739, -1574.466, 53.83353)
                    .GarageFootInPos = New Quaternion(1347.405F, -1573.956F, 53.05155F, 29.38542F)
                    .GarageOutPos = New Quaternion(1354.933, -1578.982, 53.38385, 216.5491)
                    .CameraPos = New CameraPRH(New Vector3(1357.432, -1594.719, 53.01324), New Vector3(3.356584, 0, 35.79725), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(1331.451F, -1585.656F, 54.93246F), New Vector3(-5.454278F, 0F, -40.00616F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(1324.505F, -1577.788F, 55.85351F), New Vector3(-3.060358F, 0F, -68.83405F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(1349.97876F, -1585.836F, 51.49663F, -142.999435F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_12SustanciaRdApt}
                End With
                If Not buildings.Contains(_12SustanciaRd) Then buildings.Add(_12SustanciaRd)
            End If

            'The Royale
            If config.GetValue(Of Boolean)("APARTMENT", "TRYL", True) Then
                Dim theRoyale19 As New ApartmentClass()
                With theRoyale19
                    .ID = 12
                    .Name = "MP_PROP_12"
                    .Description = "MP_PROP_12DES"
                    .Price = 125000
                    .GarageFilePath = "the_royale_12"
                    .SetAsMediumApartment
                End With
                Dim theRoyale As New BuildingClass()
                With theRoyale
                    .Name = "The Royale"
                    .BuildingInPos = New Quaternion(-198.8772F, 86.29745F, 68.75475F, 161.634F)
                    .BuildingOutPos = New Quaternion(-197.4334F, 88.22113F, 68.74056F, 346.0997F)
                    .BuildingLobby = New Quaternion(-198.2083F, 82.97825F, 68.75932F, 350.151F)
                    .GarageInPos = New Vector3(-216.1293F, 39.01434F, 58.21085F)
                    .GarageFootInPos = New Quaternion(-212.3528F, 32.46584F, 58.8203F, 165.9531F)
                    .GarageOutPos = New Quaternion(-221.7991F, 40.25053F, 59.423F, 81.31723F)
                    .CameraPos = New CameraPRH(New Vector3(-194.8486, 123.9623, 71.46825), New Vector3(1.435651, 0, -168.6253), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-197.1429F, 107.9836F, 76.95716F), New Vector3(-8.904154F, 0F, -175.3624F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-170.4316F, 100.2801F, 76.5687F), New Vector3(-3.905282F, 0F, -173.4171F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-202.1117F, 104.088F, 68.71951F, 150.9993F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(1818395686, New Vector3(-197.2339F, 85.1613F, 69.89605F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {theRoyale19}
                End With
                If Not buildings.Contains(theRoyale) Then buildings.Add(theRoyale)
            End If
#End Region

#Region "Low End Apartments"
            '1115 Blvd Del Perro
            If config.GetValue(Of Boolean)("APARTMENT", "1115BDPR", True) Then
                Dim _1115BlvdDelPerro18 As New ApartmentClass()
                With _1115BlvdDelPerro18
                    .ID = 23
                    .Name = "MP_PROP_23"
                    .Description = "MP_PROP_23DES"
                    .Price = 93000
                    .GarageFilePath = "1115_blvd_del_perro_18"
                    .SetAsLowEndApartment
                End With
                Dim _1115BlvdDelPerro As New BuildingClass()
                With _1115BlvdDelPerro
                    .Name = "1115 Blvd Del Perro"
                    .BuildingInPos = New Quaternion(-1607.753F, -433.6076F, 39.42718F, 236.3623F)
                    .BuildingOutPos = New Quaternion(-1608.121F, -430.9056F, 39.43181F, 47.45515F)
                    .BuildingLobby = New Quaternion(-1603.889F, -434.4687F, 39.41705F, 43.47369F)
                    .GarageInPos = New Vector3(-1608.53, -451.0937, 37.58678)
                    .GarageFootInPos = New Quaternion(-1604.219F, -449.3874F, 37.18325F, 229.1051F)
                    .GarageOutPos = New Quaternion(-1611.859, -454.9521, 37.49269, 138.179)
                    .CameraPos = New CameraPRH(New Vector3(-1643.548, -435.6621, 41.09145), New Vector3(8.244346, 0, -86.32664), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-1622.862F, -419.2167F, 42.48126F), New Vector3(-3.694005F, 0F, -128.9246F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1622.669F, -419.2757F, 41.42789F), New Vector3(25.38408F, 0F, -131.1508F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1611.351F, -425.611F, 39.6413F, -126.9995F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(827574885, New Vector3(-1605.014F, -431.9617F, 40.63839F))
                    .Door2 = New Door(-725970636, New Vector3(-1606.588F, -433.838F, 40.63837F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_1115BlvdDelPerro18}
                End With
                If Not buildings.Contains(_1115BlvdDelPerro) Then buildings.Add(_1115BlvdDelPerro)
            End If

            '1561 San Vitas St
            If config.GetValue(Of Boolean)("APARTMENT", "1561SVTS", True) Then
                Dim _1561SanVitasSt2 As New ApartmentClass()
                With _1561SanVitasSt2
                    .ID = 18
                    .Name = "MP_PROP_18"
                    .Description = "MP_PROP_18DES"
                    .Price = 99000
                    .GarageFilePath = "1561_san_vitas_st_2"
                    .SetAsLowEndApartment
                End With
                Dim _1561SanVitasSt As New BuildingClass()
                With _1561SanVitasSt
                    .Name = "1561 San Vitas St"
                    .BuildingInPos = New Quaternion(-201.2312F, 185.0877F, 79.32613F, 271.6657F)
                    .BuildingOutPos = New Quaternion(-203.4454F, 186.1952F, 79.32265F, 89.14145F)
                    .BuildingLobby = New Quaternion(-197.6762F, 186.2286F, 79.50162F, 86.39969F)
                    .GarageInPos = New Vector3(-205.952, 192.6613, 79.88345)
                    .GarageFootInPos = New Quaternion(-201.3532F, 196.6772F, 78.55938F, 268.7947F)
                    .GarageOutPos = New Quaternion(-213.1964, 193.2091, 80.66739, 82.44815)
                    .CameraPos = New CameraPRH(New Vector3(-227.7641, 201.8866, 86.85343), New Vector3(-4.676774, 0, -109.3161), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-224.4747F, 195.8861F, 83.09782F), New Vector3(2.501759F, 0F, -100.0096F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-217.5541F, 196.4669F, 84.4538F), New Vector3(3.065019F, 0F, -106.035F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-211.5359F, 185.7793F, 78.2446F, -92.99972F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-815851463, New Vector3(-200.29F, 185.598F, 80.66135F))
                    .Door2 = New Door(-725970636, New Vector3(-1606.588F, -433.838F, 40.63837F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_1561SanVitasSt2}
                End With
                If Not buildings.Contains(_1561SanVitasSt) Then buildings.Add(_1561SanVitasSt)
            End If

            '1237 Prosperity St
            If config.GetValue(Of Boolean)("APARTMENT", "1237PPRS", True) Then
                Dim _1237ProsperitySt21 As New ApartmentClass()
                With _1237ProsperitySt21
                    .ID = 22
                    .Name = "MP_PROP_22"
                    .Description = "MP_PROP_22DES"
                    .Price = 105000
                    .GarageFilePath = "1237_prosperity_st_21"
                    .SetAsLowEndApartment
                End With
                Dim _1237ProsperitySt As New BuildingClass()
                With _1237ProsperitySt
                    .Name = "1237 Prosperity St"
                    .BuildingInPos = New Quaternion(-1562.376F, -404.384F, 41.38401F, 48.80745F)
                    .BuildingOutPos = New Quaternion(-1561.533F, -408.6808F, 41.38401F, 233.3411F)
                    .BuildingLobby = New Quaternion(-1566.9F, -404.2328F, 41.38815F, 227.0392F)
                    .GarageInPos = New Vector3(-1554.318, -402.5234, 41.53171)
                    .GarageFootInPos = New Quaternion(-1556.019F, -396.8065F, 40.98768F, 43.30437F)
                    .GarageOutPos = New Quaternion(-1548.194, -407.8083, 41.50047, 228.1096)
                    .CameraPos = New CameraPRH(New Vector3(-1510.861, -407.8669, 42.94849), New Vector3(6.705585, 0, 82.56407), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-1547.973F, -427.3674F, 46.60262F), New Vector3(7.007823F, 0F, 39.1917F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1535.943F, -420.7761F, 46.51907F), New Vector3(4.40272F, 0F, 37.12431F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1556.007F, -423.1586F, 40.99173F, -38.99994F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(827574885, New Vector3(-1565.58F, -406.9184F, 42.60905F))
                    .Door2 = New Door(-725970636, New Vector3(-1564.006F, -405.0421F, 42.60904F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_1237ProsperitySt21}
                End With
                If Not buildings.Contains(_1237ProsperitySt) Then buildings.Add(_1237ProsperitySt)
            End If

            '0069 Cougar Ave
            If config.GetValue(Of Boolean)("APARTMENT", "0069CGAV", True) Then
                Dim _0069CougarAve19 As New ApartmentClass()
                With _0069CougarAve19
                    .ID = 21
                    .Name = "MP_PROP_21"
                    .Description = "MP_PROP_21DES"
                    .Price = 112000
                    .GarageFilePath = "0069_cougar_ave_19"
                    .SetAsLowEndApartment
                End With
                Dim _0069CougarAve As New BuildingClass()
                With _0069CougarAve
                    .Name = "0069 Cougar Ave"
                    .BuildingInPos = New Quaternion(-1532.888F, -325.702F, 46.9112F, 302.2388F)
                    .BuildingOutPos = New Quaternion(-1535.262F, -325.0084F, 46.49091F, 44.92589F)
                    .BuildingLobby = New Quaternion(-1531.112F, -329.0014F, 46.91502F, 43.24371F)
                    .GarageInPos = New Vector3(-1530.807, -346.3962, 44.66446)
                    .GarageFootInPos = New Quaternion(-1526.439F, -345.511F, 44.32535F, 231.8272F)
                    .GarageOutPos = New Quaternion(-1536.455, -352.6137, 44.54288, 135.3604)
                    .CameraPos = New CameraPRH(New Vector3(-1563.921, -321.3005, 51.06629), New Vector3(-4.889933, 0, -100.0785), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-1556.265F, -321.7628F, 50.83025F), New Vector3(0.8824388F, 0F, -99.8124F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-1548.096F, -322.9098F, 51.45202F), New Vector3(3.980261F, 0F, -103.1511F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1538.956F, -330.1972F, 46.16157F, -123.0004F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(308262790, New Vector3(-1533.554F, -327.6279F, 48.07687F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0069CougarAve19}
                End With
                If Not buildings.Contains(_0069CougarAve) Then buildings.Add(_0069CougarAve)
            End If

            '2143 Las Lagunas Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "2143LLBL", True) Then
                Dim _2143LasLagunasBlvd9 As New ApartmentClass()
                With _2143LasLagunasBlvd9
                    .ID = 17
                    .Name = "MP_PROP_17"
                    .Description = "MP_PROP_17DES"
                    .Price = 115000
                    .GarageFilePath = "2143_las_lagunas_blvd_9"
                    .SetAsLowEndApartment
                End With
                Dim _2143LasLagunasBlvd As New BuildingClass()
                With _2143LasLagunasBlvd
                    .Name = "2143 Las Lagunas Blvd"
                    .BuildingInPos = New Quaternion(-41.5342F, -59.85516F, 62.65963F, 249.8663F)
                    .BuildingOutPos = New Quaternion(-43.97984F, -57.46555F, 62.37243F, 63.68441F)
                    .BuildingLobby = New Quaternion(-38.02718F, -59.60446F, 63.0576F, 71.43273F)
                    .GarageInPos = New Vector3(-32.13178, -69.51645, 58.91152)
                    .GarageFootInPos = New Quaternion(-29.60316F, -66.39739F, 58.53009F, 259.496F)
                    .GarageOutPos = New Quaternion(-40.82223, -67.3935, 58.69315, 69.59575)
                    .CameraPos = New CameraPRH(New Vector3(-76.6449, -41.96963, 63.77706), New Vector3(4.850093, 0, -106.2234), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-68.52925F, -45.01423F, 67.37651F), New Vector3(1.234458F, 0F, -109.9153F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-60.96994F, -47.91084F, 67.00711F), New Vector3(5.318053F, 0F, -107.3186F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-50.81142F, -56.97182F, 60.23486F, -105.9996F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-453852320, New Vector3(-40.19053F, -58.21105F, 64.20616F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2143LasLagunasBlvd9}
                End With
                If Not buildings.Contains(_2143LasLagunasBlvd) Then buildings.Add(_2143LasLagunasBlvd)
            End If

            '1893 Grapeseed Ave
            If config.GetValue(Of Boolean)("APARTMENT", "1893GSAV", True) Then
                Dim _1893GrapeseedAveApt As New ApartmentClass()
                With _1893GrapeseedAveApt
                    .ID = 78
                    .Name = "MP_PROP_78"
                    .Description = "MP_PROP_78DES"
                    .Price = 118000
                    .GarageFilePath = "1893_grapeseed_ave"
                    .SetAsLowEndApartment
                End With
                Dim _1893GrapeseedAve As New BuildingClass()
                With _1893GrapeseedAve
                    .Name = "1893 Grapeseed Ave"
                    .BuildingInPos = New Quaternion(1662.762F, 4775.079F, 41.00756F, 96.13656F)
                    .BuildingOutPos = New Quaternion(1664.084F, 4776.375F, 40.99482F, 277.3168F)
                    .BuildingLobby = New Quaternion(1662.278F, 4776.202F, 41.00917F, 278.1875F)
                    .GarageInPos = New Vector3(1662.088, 4768.009, 41.79552)
                    .GarageFootInPos = New Quaternion(1657.932F, 4764.533F, 41.09948F, 9.598463F)
                    .GarageOutPos = New Quaternion(1667.8, 4768.668, 41.70086, 275.8229)
                    .CameraPos = New CameraPRH(New Vector3(1683.295, 4774.074, 43.80255), New Vector3(-2.922752, 0, 93.5119), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(1659.381F, 4793.532F, 44.32456F), New Vector3(-7.496302F, 0F, 178.3484F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(1652.646F, 4793.602F, 44.33621F), New Vector3(-7.566323F, 0F, -179.8851F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(1668.179F, 4763.354F, 40.95217F, -79.99977F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_1893GrapeseedAveApt}
                End With
                If Not buildings.Contains(_1893GrapeseedAve) Then buildings.Add(_1893GrapeseedAve)
            End If

            '0232 Paleto Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "0232PLTB", True) Then
                Dim _0232PaletoBlvdApt As New ApartmentClass()
                With _0232PaletoBlvdApt
                    .ID = 76
                    .Name = "MP_PROP_76"
                    .Description = "MP_PROP_76DES"
                    .Price = 121000
                    .GarageFilePath = "0232_poleto_blvd"
                    .SetAsLowEndApartment
                End With
                Dim _0232PaletoBlvd As New BuildingClass()
                With _0232PaletoBlvd
                    .Name = "0232 Paleto Blvd"
                    .BuildingInPos = New Quaternion(-14.08983F, 6556.662F, 32.24046F, 138.433F)
                    .BuildingOutPos = New Quaternion(-12.83109F, 6559.883F, 30.97137F, 305.993F)
                    .BuildingLobby = New Quaternion(-15.05461F, 6557.533F, 32.2404F, 315.7144F)
                    .GarageInPos = New Vector3(-12.11096, 6563.872, 31.77629)
                    .GarageFootInPos = New Quaternion(-16.12879F, 6564.636F, 30.91137F, 44.208F)
                    .GarageOutPos = New Quaternion(-6.329562, 6558.033, 31.7927, 225.0206)
                    .CameraPos = New CameraPRH(New Vector3(-0.02845764, 6551.444, 32.63414), New Vector3(7.133693, 0, 85.69931), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(3.452975F, 6552.198F, 33.88968F), New Vector3(-0.5256906F, 0F, 68.92777F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-3.959476F, 6540.47F, 33.90584F), New Vector3(-0.6665078F, 0F, 65.04664F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-6.288683F, 6543.385F, 30.70873F, 44.99983F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0232PaletoBlvdApt}
                End With
                If Not buildings.Contains(_0232PaletoBlvd) Then buildings.Add(_0232PaletoBlvd)
            End If

            '0112 S Rockford Dr
            If config.GetValue(Of Boolean)("APARTMENT", "0112SRFD", True) Then
                Dim _0112SRockfordDr13 As New ApartmentClass()
                With _0112SRockfordDr13
                    .ID = 19
                    .Name = "MP_PROP_19"
                    .Description = "MP_PROP_19DES"
                    .Price = 80000
                    .GarageFilePath = "0112_s_rockford_dr_13"
                    .SetAsLowEndApartment
                End With
                Dim _0112SRockfordDr As New BuildingClass()
                With _0112SRockfordDr
                    .Name = "0112 S Rockford Dr"
                    .BuildingInPos = New Quaternion(-813.6389F, -979.8933F, 13.1934F, 33.42988F)
                    .BuildingOutPos = New Quaternion(-814.4296F, -984.7994F, 13.01444F, 175.6283F)
                    .BuildingLobby = New Quaternion(-810.0398F, -978.6992F, 13.22306F, 122.4979F)
                    .GarageInPos = New Vector3(-812.1517, -954.1611, 15.22835)
                    .GarageFootInPos = New Quaternion(-802.3793F, -982.8165F, 12.24729F, 125.5058F)
                    .GarageOutPos = New Quaternion(-822.1036, -955.2672, 15.24641, 99.68565)
                    .CameraPos = New CameraPRH(New Vector3(-835.3129, -1003.118, 16.48207), New Vector3(3.313114, 0, -32.55415), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-823.5617F, -993.9997F, 17.33217F), New Vector3(-5.102105F, 0F, -39.18001F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-834.0823F, -981.3882F, 17.52916F), New Vector3(-5.594988F, 0F, -43.62888F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-817.4551F, -989.7587F, 12.51171F, -60.99983F))
                    .FrontDoor = eFrontDoor.DoubleDoors
                    .Door1 = New Door(1701450624, New Vector3(-812.8308F, -979.011F, 14.60059F))
                    .Door2 = New Door(340291898, New Vector3(-811.2488F, -981.2729F, 14.60607F))
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_0112SRockfordDr13}
                End With
                If Not buildings.Contains(_0112SRockfordDr) Then buildings.Add(_0112SRockfordDr)
            End If

            '2057 Vespucci Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "2057VPCB", True) Then
                Dim _2057VespucciBlvd1 As New ApartmentClass()
                With _2057VespucciBlvd1
                    .ID = 20
                    .Name = "MP_PROP_20"
                    .Description = "MP_PROP_20DES"
                    .Price = 87000
                    .GarageFilePath = "2057_vespucci_blvd"
                    .SetAsLowEndApartment
                End With
                Dim _2057VespucciBlvd As New BuildingClass()
                With _2057VespucciBlvd
                    .Name = "2057 Vespucci Blvd"
                    .BuildingInPos = New Quaternion(-663.3229F, -853.7469F, 23.44383F, 175.6818F)
                    .BuildingOutPos = New Quaternion(-662.5211F, -851.8135F, 23.43667F, 358.7791F)
                    .BuildingLobby = New Quaternion(-662.4146F, -857.4342F, 23.51795F, 1.864921F)
                    .GarageInPos = New Vector3(-667.7385, -853.5117, 23.84)
                    .GarageFootInPos = New Quaternion(-665.6282F, -855.7734F, 23.35251F, 270.814F)
                    .GarageOutPos = New Quaternion(-667.6065, -849.4223, 23.8855, 358.19)
                    .CameraPos = New CameraPRH(New Vector3(-644.9753, -820.6812, 33.11289), New Vector3(5.2089, -2.1432, 152.9055), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(-647.1116F, -844.6727F, 30.94582F), New Vector3(-10.94582F, 0F, 136.1524F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(-647.5561F, -845.2822F, 27.76416F), New Vector3(37.7759F, 0F, 134.2969F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-674.4222F, -855.0154F, 23.15351F, 179.9991F))
                    .FrontDoor = eFrontDoor.StandardDoor
                    .Door1 = New Door(-645206502, New Vector3(-661.8653F, -854.6265F, 24.68869F))
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_2057VespucciBlvd1}
                End With
                If Not buildings.Contains(_2057VespucciBlvd) Then buildings.Add(_2057VespucciBlvd)
            End If

            '140 Zancudo Ave
            If config.GetValue(Of Boolean)("APARTMENT", "140ZCDA", True) Then
                Dim _140ZancudoAveApt As New ApartmentClass()
                With _140ZancudoAveApt
                    .ID = 77
                    .Name = "MP_PROP_77"
                    .Description = "MP_PROP_77DES"
                    .Price = 121000
                    .GarageFilePath = "140_zancudo_ave"
                    .SetAsLowEndApartment
                End With
                Dim _140ZancudoAve As New BuildingClass()
                With _140ZancudoAve
                    .Name = "140 Zancudo Ave"
                    .BuildingInPos = New Quaternion(1900.146F, 3781.11F, 31.81827F, 132.9305F)
                    .BuildingOutPos = New Quaternion(1901.294F, 3783.088F, 31.79955F, 296.1632F)
                    .BuildingLobby = New Quaternion(1899.119F, 3781.755F, 31.87691F, 295.7144F)
                    .GarageInPos = New Vector3(1884.389, 3769.249, 32.68288)
                    .GarageFootInPos = New Quaternion(1880.283F, 3771.847F, 31.85161F, 31.45572F)
                    .GarageOutPos = New Quaternion(1887.34, 3764.256, 32.59146, 214.5068)
                    .CameraPos = New CameraPRH(New Vector3(1901.893, 3758.286, 33.14275), New Vector3(-1.035176, 0, 30.5063), 50.0F)
                    .EnterCamera1 = New CameraPRH(New Vector3(1907.115F, 3768.551F, 33.62659F), New Vector3(-6.510109F, 0F, 31.67839F), 50.0F)
                    .EnterCamera2 = New CameraPRH(New Vector3(1900.649F, 3764.562F, 33.62659F), New Vector3(-6.510109F, 0F, 31.67839F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .BuildingType = eBuildingType.Apartment
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(1896.717F, 3762.96F, 31.5966F, 33.99994F))
                    .FrontDoor = eFrontDoor.NoDoor
                    .Door1 = Nothing
                    .Door2 = Nothing
                    .GarageDoor = eFrontDoor.NoDoor
                    .Door3 = Nothing
                    .GarageWaypoint = QuaternionZero()
                    .Apartments = New List(Of ApartmentClass) From {_140ZancudoAveApt}
                End With
                If Not buildings.Contains(_140ZancudoAve) Then buildings.Add(_140ZancudoAve)
            End If
#End Region

#Region "High End Garage"
            'Murrieta Heights
            If config.GetValue(Of Boolean)("APARTMENT", "MRTH", True) Then
                Dim _0120MurrietaHeightsGrg As New ApartmentClass()
                With _0120MurrietaHeightsGrg
                    .ID = 24
                    .Name = "MP_PROP_24"
                    .Description = "MP_PROP_24DES"
                    .Price = 150000
                    .GarageFilePath = "0120_murrieta_heights"
                    .SetAsGarage
                End With
                Dim _0120MurrietaHeights As New BuildingClass()
                With _0120MurrietaHeights
                    .Name = "0120 Murrieta Heights"
                    .GarageInPos = New Vector3(966.7083F, -1019.782F, 40.12651F)
                    .GarageFootInPos = New Quaternion(963.7991F, -1022.556F, 39.84747F, 88.24952F)
                    .GarageOutPos = New Quaternion(970.2502F, -1019.784F, 40.18027F, 270.5528F)
                    .CameraPos = New CameraPRH(New Vector3(979.8295F, -1042.648F, 45.68815F), New Vector3(0.3886027F, -0.00000005336208F, 48.74495F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(965.572F, -1011.164F, 40.04047F, 0F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_0120MurrietaHeightsGrg}
                End With
                If Not buildings.Contains(_0120MurrietaHeights) Then buildings.Add(_0120MurrietaHeights)
            End If

            'Unit 2 Popular St
            If config.GetValue(Of Boolean)("APARTMENT", "U2PS", True) Then
                Dim unit2PopularStGrg As New ApartmentClass()
                With unit2PopularStGrg
                    .ID = 26
                    .Name = "MP_PROP_26"
                    .Description = "MP_PROP_26DES"
                    .Price = 142500
                    .GarageFilePath = "unit_2_popular_st"
                    .SetAsGarage
                End With
                Dim unit2PopularSt As New BuildingClass()
                With unit2PopularSt
                    .Name = "Unit 2 Popular St"
                    .GarageInPos = New Vector3(814.6552F, -920.3521F, 25.20862F)
                    .GarageFootInPos = New Quaternion(812.2126F, -924.0813F, 25.19506F, 173.4696F)
                    .GarageOutPos = New Quaternion(812.6961F, -918.2408F, 25.017F, 37.62095F)
                    .CameraPos = New CameraPRH(New Vector3(796.3094F, -910.439F, 32.21284F), New Vector3(-4.784281F, 0F, -135.616F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(826.0184F, -924.6767F, 25.23146F, 0F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {unit2PopularStGrg}
                End With
                If Not buildings.Contains(unit2PopularSt) Then buildings.Add(unit2PopularSt)
            End If

            '331 Supply Street
            If config.GetValue(Of Boolean)("APARTMENT", "331SPST", True) Then
                Dim _331SupplyStGrg As New ApartmentClass()
                With _331SupplyStGrg
                    .ID = 27
                    .Name = "MP_PROP_27"
                    .Description = "MP_PROP_27DES"
                    .Price = 135000
                    .GarageFilePath = "331_supply_st"
                    .SetAsGarage
                End With
                Dim _331SupplySt As New BuildingClass()
                With _331SupplySt
                    .Name = "331 Supply St"
                    .GarageInPos = New Vector3(763.1778F, -752.5948F, 26.13646F)
                    .GarageFootInPos = New Quaternion(759.6586F, -750.0385F, 26.1365F, 92.18512F)
                    .GarageOutPos = New Quaternion(763.1874F, -752.6099F, 26.13522F, 269.8095F)
                    .CameraPos = New CameraPRH(New Vector3(773.3146F, -738.6525F, 32.96489F), New Vector3(-8.04293F, 0.0000002155638F, 120.9082F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(758.4609F, -749.3088F, 26.17052F, -89.99959F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_331SupplyStGrg}
                End With
                If Not buildings.Contains(_331SupplySt) Then buildings.Add(_331SupplySt)
            End If

            'Unit 76 Greenwich Parkway
            If config.GetValue(Of Boolean)("APARTMENT", "U76GP", True) Then
                Dim unit76GreenwichParkwayGrg As New ApartmentClass()
                With unit76GreenwichParkwayGrg
                    .ID = 63
                    .Name = "MP_PROP_63"
                    .Description = "MP_PROP_63DES"
                    .Price = 120000
                    .GarageFilePath = "unit_76_greenwich_parkway"
                    .SetAsGarage
                End With
                Dim unit76GreenwichParkway As New BuildingClass()
                With unit76GreenwichParkway
                    .Name = "Unit 76 Greenwich Parkway"
                    .GarageInPos = New Vector3(-1085.557F, -2231.689F, 12.51501F)
                    .GarageFootInPos = New Quaternion(-1090.821F, -2231.277F, 12.22299F, 134.4253F)
                    .GarageOutPos = New Quaternion(-1084.718F, -2230.858F, 12.51934F, 315.4821F)
                    .CameraPos = New CameraPRH(New Vector3(-1097.107F, -2198.045F, 22.43835F), New Vector3(-13.56797F, -0.0000002195711F, 170.8932F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1083.94F, -2239.23F, 12.21982F, -45.99988F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {unit76GreenwichParkwayGrg}
                End With
                If Not buildings.Contains(unit76GreenwichParkway) Then buildings.Add(unit76GreenwichParkway)
            End If

            '1337 Exceptionalists Way
            If config.GetValue(Of Boolean)("APARTMENT", "133XCTW", True) Then
                Dim _1337ExceptionalistWayGrg As New ApartmentClass()
                With _1337ExceptionalistWayGrg
                    .ID = 62
                    .Name = "MP_PROP_62"
                    .Description = "MP_PROP_62DES"
                    .Price = 112500
                    .GarageFilePath = "1337_exceptionalists_way"
                    .SetAsGarage
                End With
                Dim _1337ExceptionalistWay As New BuildingClass()
                With _1337ExceptionalistWay
                    .Name = "1337 Exceptionalists Way"
                    .GarageInPos = New Vector3(-667.9601F, -2378.509F, 13.13723F)
                    .GarageFootInPos = New Quaternion(-666.9728F, -2383.446F, 12.92736F, 252.5499F)
                    .GarageOutPos = New Quaternion(-671.0975F, -2376.583F, 13.0891F, 58.12129F)
                    .CameraPos = New CameraPRH(New Vector3(-687.2374F, -2390.862F, 18.91904F), New Vector3(-9.248301F, 0F, -83.19398F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-662.3256F, -2377.067F, 12.94378F, -119.9995F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1337ExceptionalistWayGrg}
                End With
                If Not buildings.Contains(_1337ExceptionalistWay) Then buildings.Add(_1337ExceptionalistWay)
            End If

            '1623 South Shambles St
            If config.GetValue(Of Boolean)("APARTMENT", "1623SSBS", True) Then
                Dim _1623SouthShamblesStGrg As New ApartmentClass()
                With _1623SouthShamblesStGrg
                    .ID = 60
                    .Name = "MP_PROP_60"
                    .Description = "MP_PROP_60DES"
                    .Price = 105000
                    .GarageFilePath = "1623_south_shambles_st"
                    .SetAsGarage
                End With
                Dim _1623SouthShamblesSt As New BuildingClass()
                With _1623SouthShamblesSt
                    .Name = "1623 South Shambles St"
                    .GarageInPos = New Vector3(1028.648F, -2398.632F, 29.10441F)
                    .GarageFootInPos = New Quaternion(1026.086F, -2394.247F, 29.08026F, 89.86459F)
                    .GarageOutPos = New Quaternion(1028.658F, -2398.667F, 29.10262F, 265.4493F)
                    .CameraPos = New CameraPRH(New Vector3(1048.913F, -2392.251F, 30.87638F), New Vector3(13.07097F, -0.0000004382413F, 100.7564F), 50.0F)
                    .GarageType = eGarageType.TenCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(1024.221F, -2406.932F, 28.60019F, -95.00002F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1623SouthShamblesStGrg}
                End With
                If Not buildings.Contains(_1623SouthShamblesSt) Then buildings.Add(_1623SouthShamblesSt)
            End If
#End Region

#Region "Medium Garage"
            '0552 Roy Lowenstein Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "0552RLSB", True) Then
                Dim _0552RoyLowensteinBlvdGrg As New ApartmentClass()
                With _0552RoyLowensteinBlvdGrg
                    .ID = 32
                    .Name = "MP_PROP_32"
                    .Description = "MP_PROP_32DES"
                    .Price = 80000
                    .GarageFilePath = "0552_roy_lowenstein_blvd"
                    .SetAsGarage
                End With
                Dim _0552RoyLowensteinBlvd As New BuildingClass()
                With _0552RoyLowensteinBlvd
                    .Name = "0552 Roy Lowenstein Blvd"
                    .GarageInPos = New Vector3(507.9363F, -1497.015F, 28.56527F)
                    .GarageFootInPos = New Quaternion(504.7118F, -1493.334F, 28.2883F, 2.796054F)
                    .GarageOutPos = New Quaternion(507.6498F, -1501.703F, 28.56643F, 176.5381F)
                    .CameraPos = New CameraPRH(New Vector3(493.9597F, -1504.415F, 31.0884F), New Vector3(-8.802479F, 0F, -30.41007F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(511.222F, -1496.117F, 28.28793F, -88.99961F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_0552RoyLowensteinBlvdGrg}
                End With
                If Not buildings.Contains(_0552RoyLowensteinBlvd) Then buildings.Add(_0552RoyLowensteinBlvd)
            End If

            'Unit 14 Popular St
            If config.GetValue(Of Boolean)("APARTMENT", "U14PS", True) Then
                Dim unit14PopularStGrg As New ApartmentClass()
                With unit14PopularStGrg
                    .ID = 25
                    .Name = "MP_PROP_25"
                    .Description = "MP_PROP_25DES"
                    .Price = 75000
                    .GarageFilePath = "unit_14_popular_st"
                    .SetAsGarage
                End With
                Dim unit14PopularSt As New BuildingClass()
                With unit14PopularSt
                    .Name = "Unit 14 Popular St"
                    .GarageInPos = New Vector3(891.5384F, -887.0665F, 26.52908F)
                    .GarageFootInPos = New Quaternion(894.9512F, -889.4141F, 26.1727F, 271.3639F)
                    .GarageOutPos = New Quaternion(886.0638F, -887.0806F, 26.10556F, 90.14727F)
                    .CameraPos = New CameraPRH(New Vector3(873.2957F, -893.0588F, 27.51537F), New Vector3(6.024229F, -0.0000001073143F, -81.14212F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(884.0314F, -893.7715F, 25.32593F, -179.999F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {unit14PopularStGrg}
                End With
                If Not buildings.Contains(unit14PopularSt) Then buildings.Add(unit14PopularSt)
            End If

            '1905 Davis Ave (Mosley)
            If config.GetValue(Of Boolean)("APARTMENT", "1905DVAV", True) Then
                Dim _1905DavisAveGrg As New ApartmentClass()
                With _1905DavisAveGrg
                    .ID = 59
                    .Name = "MP_PROP_59"
                    .Description = "MP_PROP_59DES"
                    .Price = 75000
                    .GarageFilePath = "1905_davis_ave"
                    .SetAsGarage
                End With
                Dim _1905DavisAve As New BuildingClass()
                With _1905DavisAve
                    .Name = "1905 Davis Ave"
                    .GarageInPos = New Vector3(-8.48543F, -1643.772F, 28.81939F)
                    .GarageFootInPos = New Quaternion(-8.424758F, -1647.976F, 28.32063F, 148.2428F)
                    .GarageOutPos = New Quaternion(-8.484629F, -1643.771F, 28.82254F, 319.3011F)
                    .CameraPos = New CameraPRH(New Vector3(-11.85002F, -1623.71F, 36.17014F), New Vector3(-14.35073F, -0.0000003304771F, 172.4813F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-13.8995F, -1644.27F, 27.83043F, -39.99995F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1905DavisAveGrg}
                End With
                If Not buildings.Contains(_1905DavisAve) Then buildings.Add(_1905DavisAve)
            End If

            '0432 Davis Ave
            If config.GetValue(Of Boolean)("APARTMENT", "0432DVAV", True) Then
                Dim _0432DavisAveGrg As New ApartmentClass()
                With _0432DavisAveGrg
                    .ID = 33
                    .Name = "MP_PROP_33"
                    .Description = "MP_PROP_33DES"
                    .Price = 72500
                    .GarageFilePath = "0432_davis_ave"
                    .SetAsGarage
                End With
                Dim _0432DavisAve As New BuildingClass()
                With _0432DavisAve
                    .Name = "0432 Davis Ave"
                    .GarageInPos = New Vector3(476.298F, -1543.223F, 28.85667F)
                    .GarageFootInPos = New Quaternion(472.2641F, -1543.804F, 28.28262F, 130.8779F)
                    .GarageOutPos = New Quaternion(476.3152F, -1543.203F, 28.85421F, 319.036F)
                    .CameraPos = New CameraPRH(New Vector3(480.868F, -1532.121F, 35.70432F), New Vector3(-11.52449F, -0.0000004356702F, 156.4929F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(471.0892F, -1543.831F, 27.78261F, -39.99994F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_0432DavisAveGrg}
                End With
                If Not buildings.Contains(_0432DavisAve) Then buildings.Add(_0432DavisAve)
            End If

            'Unit 1 Olympic Fwy
            If config.GetValue(Of Boolean)("APARTMENT", "U1OF", True) Then
                Dim unit1OlympicFwyGrg As New ApartmentClass()
                With unit1OlympicFwyGrg
                    .ID = 28
                    .Name = "MP_PROP_28"
                    .Description = "MP_PROP_28DES"
                    .Price = 70000
                    .GarageFilePath = "unit_1_olympic_fwy"
                    .SetAsGarage
                End With
                Dim unit1OlympicFwy As New BuildingClass()
                With unit1OlympicFwy
                    .Name = "Unit 1 Olympic Fwy"
                    .GarageInPos = New Vector3(846.7375F, -1161.708F, 24.6348F)
                    .GarageFootInPos = New Quaternion(844.5089F, -1164.21F, 24.26785F, 185.3277F)
                    .GarageOutPos = New Quaternion(846.4857F, -1158.326F, 24.64739F, 4.161697F)
                    .CameraPos = New CameraPRH(New Vector3(853.9076F, -1145.599F, 30.36782F), New Vector3(-7.591683F, -0.0000002153308F, 158.1503F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(857.97F, -1162.654F, 24.10904F, 0F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {unit1OlympicFwyGrg}
                End With
                If Not buildings.Contains(unit1OlympicFwy) Then buildings.Add(unit1OlympicFwy)
            End If

            '4531 Dry Dock St
            If config.GetValue(Of Boolean)("APARTMENT", "4531DST", True) Then
                Dim _4531DryDockStGrg As New ApartmentClass()
                With _4531DryDockStGrg
                    .ID = 61
                    .Name = "MP_PROP_61"
                    .Description = "MP_PROP_61DES"
                    .Price = 67500
                    .GarageFilePath = "4531_dry_dock_st"
                    .SetAsGarage
                End With
                Dim _4531DryDockSt As New BuildingClass()
                With _4531DryDockSt
                    .Name = "4531 Dry Dock St"
                    .GarageInPos = New Vector3(870.3314F, -2236.932F, 29.94405F)
                    .GarageFootInPos = New Quaternion(873.3058F, -2233.314F, 29.54612F, 353.5019F)
                    .GarageOutPos = New Quaternion(870.3288F, -2236.936F, 29.94228F, 175.8903F)
                    .CameraPos = New CameraPRH(New Vector3(857.2173F, -2248.946F, 36.59518F), New Vector3(-6.390676F, -0.000000214778F, -38.95956F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(867.7078F, -2232.023F, 29.03291F, -3.999995F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_4531DryDockStGrg}
                End With
                If Not buildings.Contains(_4531DryDockSt) Then buildings.Add(_4531DryDockSt)
            End If

            '8754 Route 68
            If config.GetValue(Of Boolean)("APARTMENT", "8754RT68", True) Then
                Dim _8754Route68Grg As New ApartmentClass()
                With _8754Route68Grg
                    .ID = 57
                    .Name = "MP_PROP_57"
                    .Description = "MP_PROP_57DES"
                    .Price = 65000
                    .GarageFilePath = "8754_route_68"
                    .SetAsGarage
                End With
                Dim _8754Route68 As New BuildingClass()
                With _8754Route68
                    .Name = "8754 Route 68"
                    .GarageInPos = New Vector3(-1132.307F, 2697.996F, 18.1674F)
                    .GarageFootInPos = New Quaternion(-1128.216F, 2697.274F, 17.80042F, 317.0885F)
                    .GarageOutPos = New Quaternion(-1133.526F, 2695.237F, 18.16751F, 153.9402F)
                    .CameraPos = New CameraPRH(New Vector3(-1141.256F, 2700.476F, 24.60046F), New Vector3(-25.61423F, 0F, -105.734F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1126.797F, 2697.011F, 17.32007F, 132.9994F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_8754Route68Grg}
                End With
                If Not buildings.Contains(_8754Route68) Then buildings.Add(_8754Route68)
            End If

            '870 Route 68 Approach
            If config.GetValue(Of Boolean)("APARTMENT", "870R68A", True) Then
                Dim _870Route68ApproachGrg As New ApartmentClass()
                With _870Route68ApproachGrg
                    .ID = 51
                    .Name = "MP_PROP_51"
                    .Description = "MP_PROP_51DES"
                    .Price = 62500
                    .GarageFilePath = "870_route_68_approach"
                    .SetAsGarage
                End With
                Dim _870Route68Approach As New BuildingClass()
                With _870Route68Approach
                    .Name = "870 Route 68 Approach"
                    .GarageInPos = New Vector3(189.8203F, 2787.067F, 45.13134F)
                    .GarageFootInPos = New Quaternion(186.1491F, 2789.476F, 44.52374F, 101.3071F)
                    .GarageOutPos = New Quaternion(191.7271F, 2787.343F, 45.13935F, 278.3973F)
                    .CameraPos = New CameraPRH(New Vector3(198.9475F, 2777.995F, 50.11591F), New Vector3(-13.59969F, -0.000000439201F, 62.03204F), 50.0F)
                    .GarageType = eGarageType.SixCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(187.0706F, 2781.539F, 44.40519F, -82.99966F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_870Route68ApproachGrg}
                End With
                If Not buildings.Contains(_870Route68Approach) Then buildings.Add(_870Route68Approach)
            End If
#End Region

#Region "Low End Garage"
            '0897 Mirror Park Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "0897MPBL", True) Then
                Dim _0897MirrorParkBlvdGrg As New ApartmentClass()
                With _0897MirrorParkBlvdGrg
                    .ID = 66
                    .Name = "MP_PROP_66"
                    .Description = "MP_PROP_66DES"
                    .Price = 35000
                    .GarageFilePath = "0897_mirror_park_blvd"
                    .SetAsGarage
                End With
                Dim _0897MirrorParkBlvd As New BuildingClass()
                With _0897MirrorParkBlvd
                    .Name = "0897 Mirror Park Blvd"
                    .GarageInPos = New Vector3(902.0117F, -144.1108F, 76.12101F)
                    .GarageFootInPos = New Quaternion(897.6833F, -145.4282F, 75.69653F, 154.2389F)
                    .GarageOutPos = New Quaternion(903.8691F, -141.0755F, 76.04897F, 327.2885F)
                    .CameraPos = New CameraPRH(New Vector3(903.6054F, -131.4019F, 79.95404F), New Vector3(-9.344264F, -0.0000002163138F, 167.8957F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(907.9774F, -148.0605F, 75.26352F, -31.99996F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_0897MirrorParkBlvdGrg}
                End With
                If Not buildings.Contains(_0897MirrorParkBlvd) Then buildings.Add(_0897MirrorParkBlvd)
            End If

            'Garage Innocence Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "GICB", True) Then
                Dim garageInnocenceBlvdGrg As New ApartmentClass()
                With garageInnocenceBlvdGrg
                    .ID = 64
                    .Name = "MP_PROP_64"
                    .Description = "MP_PROP_64DES"
                    .Price = 34000
                    .GarageFilePath = "garage_innocence_blvd"
                    .SetAsGarage
                End With
                Dim garageInnocenceBlvd As New BuildingClass()
                With garageInnocenceBlvd
                    .Name = "Garage Innocence Blvd"
                    .GarageInPos = New Vector3(-339.1225F, -1468.557F, 30.09063F)
                    .GarageFootInPos = New Quaternion(-342.0703F, -1466.63F, 29.61144F, 82.56173F)
                    .GarageOutPos = New Quaternion(-337.2308F, -1467.467F, 30.062F, 300.2791F)
                    .CameraPos = New CameraPRH(New Vector3(-333.1241F, -1460.864F, 31.57706F), New Vector3(-3.687999F, 0F, 122.8462F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-342.8009F, -1470.744F, 29.3594F, 90.00014F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {garageInnocenceBlvdGrg}
                End With
                If Not buildings.Contains(garageInnocenceBlvd) Then buildings.Add(garageInnocenceBlvd)
            End If

            '634 Blvd Del Perro
            If config.GetValue(Of Boolean)("APARTMENT", "634BDPR", True) Then
                Dim _634BlvdDelPerroGrg As New ApartmentClass()
                With _634BlvdDelPerroGrg
                    .ID = 65
                    .Name = "MP_PROP_65"
                    .Description = "MP_PROP_65DES"
                    .Price = 33500
                    .GarageFilePath = "634_blvd_del_perro"
                    .SetAsGarage
                End With
                Dim _634BlvdDelPerro As New BuildingClass()
                With _634BlvdDelPerro
                    .Name = "634 Blvd Del Perro"
                    .GarageInPos = New Vector3(-1243.404F, -256.8076F, 38.53205F)
                    .GarageFootInPos = New Quaternion(-1243.795F, -260.2426F, 37.94628F, 212.0998F)
                    .GarageOutPos = New Quaternion(-1243.391F, -256.8199F, 38.52877F, 29.32852F)
                    .CameraPos = New CameraPRH(New Vector3(-1238.922F, -248.5173F, 39.9842F), New Vector3(-5.98613F, 0.0000001073068F, 171.664F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-1236.848F, -257.6521F, 37.70773F, 27.99997F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_634BlvdDelPerroGrg}
                End With
                If Not buildings.Contains(_634BlvdDelPerro) Then buildings.Add(_634BlvdDelPerro)
            End If

            '1920 Senora Way
            If config.GetValue(Of Boolean)("APARTMENT", "1920SNRW", True) Then
                Dim _1920SenoraWayGrg As New ApartmentClass()
                With _1920SenoraWayGrg
                    .ID = 48
                    .Name = "MP_PROP_48"
                    .Description = "MP_PROP_48DES"
                    .Price = 32000
                    .GarageFilePath = "1920_senora_way"
                    .SetAsGarage
                End With
                Dim _1920SenoraWay As New BuildingClass()
                With _1920SenoraWay
                    .Name = "1920 Senora Way"
                    .GarageInPos = New Vector3(2465.267F, 1589.419F, 32.22708F)
                    .GarageFootInPos = New Quaternion(2461.664F, 1592.056F, 31.72033F, 86.26544F)
                    .GarageOutPos = New Quaternion(2467.958F, 1589.436F, 32.22805F, 270.5249F)
                    .CameraPos = New CameraPRH(New Vector3(2473.335F, 1593.019F, 36.72024F), New Vector3(-13.72779F, 0F, 116.5936F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(2463.053F, 1575.235F, 31.72031F, -89.99971F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1920SenoraWayGrg}
                End With
                If Not buildings.Contains(_1920SenoraWay) Then buildings.Add(_1920SenoraWay)
            End If

            '12 Little Bighorn Ave
            If config.GetValue(Of Boolean)("APARTMENT", "12LBHA", True) Then
                Dim _12LittleBighornAveGrg As New ApartmentClass()
                With _12LittleBighornAveGrg
                    .ID = 30
                    .Name = "MP_PROP_30"
                    .Description = "MP_PROP_30DES"
                    .Price = 32000
                    .GarageFilePath = "12_little_bighorn_ave"
                    .SetAsGarage
                End With
                Dim _12LittleBighornAve As New BuildingClass()
                With _12LittleBighornAve
                    .Name = "12 Little Bighorn Ave"
                    .GarageInPos = New Vector3(571.9946F, -1567.412F, 28.12461F)
                    .GarageFootInPos = New Quaternion(568.3764F, -1568.161F, 27.70673F, 144.2536F)
                    .GarageOutPos = New Quaternion(572.0132F, -1567.437F, 28.1225F, 322.0987F)
                    .CameraPos = New CameraPRH(New Vector3(584.3989F, -1566.764F, 31.58759F), New Vector3(-0.9105989F, 0F, 99.46441F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(574.5749F, -1574.473F, 27.25462F, -39.99994F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_12LittleBighornAveGrg}
                End With
                If Not buildings.Contains(_12LittleBighornAve) Then buildings.Add(_12LittleBighornAve)
            End If

            '2000 Great Ocean Highway
            If config.GetValue(Of Boolean)("APARTMENT", "2000GOHW", True) Then
                Dim _2000GreatOceanHighwayGrg As New ApartmentClass()
                With _2000GreatOceanHighwayGrg
                    .ID = 49
                    .Name = "MP_PROP_49"
                    .Description = "MP_PROP_49DES"
                    .Price = 31500
                    .GarageFilePath = "2000_great_ocean_highway"
                    .SetAsGarage
                End With
                Dim _2000GreatOceanHighway As New BuildingClass()
                With _2000GreatOceanHighway
                    .Name = "2000 Great Ocean Highway"
                    .GarageInPos = New Vector3(-2205.383F, 4247.596F, 47.16852F)
                    .GarageFootInPos = New Quaternion(-2201.966F, 4245.997F, 47.21652F, 222.9427F)
                    .GarageOutPos = New Quaternion(-2206.067F, 4248.496F, 47.0708F, 38.02222F)
                    .CameraPos = New CameraPRH(New Vector3(-2202.008F, 4252.098F, 48.62151F), New Vector3(-6.047786F, 0F, 170.3865F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-2198.185F, 4241.743F, 46.74387F, -52.99977F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_2000GreatOceanHighwayGrg}
                End With
                If Not buildings.Contains(_2000GreatOceanHighway) Then buildings.Add(_2000GreatOceanHighway)
            End If

            '0754 Roy Lowenstein Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "0754RLSB", True) Then
                Dim _0754RoyLowensteinBlvdGrg As New ApartmentClass()
                With _0754RoyLowensteinBlvdGrg
                    .ID = 29
                    .Name = "MP_PROP_29"
                    .Description = "MP_PROP_29DES"
                    .Price = 29500
                    .GarageFilePath = "0754_roy_lowenstein_blvd"
                    .SetAsGarage
                End With
                Dim _0754RoyLowensteinBlvd As New BuildingClass()
                With _0754RoyLowensteinBlvd
                    .Name = "0754 Roy Lowenstein Blvd"
                    .GarageInPos = New Vector3(526.0058F, -1601.133F, 28.46635F)
                    .GarageFootInPos = New Quaternion(526.5675F, -1604.765F, 28.28086F, 225.3262F)
                    .GarageOutPos = New Quaternion(522.8401F, -1598.508F, 28.5394F, 50.95364F)
                    .CameraPos = New CameraPRH(New Vector3(519.4299F, -1591.378F, 30.28123F), New Vector3(-0.887373F, 0F, -162.4248F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(528.0397F, -1595.592F, 28.31367F, -129.9995F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_0754RoyLowensteinBlvdGrg}
                End With
                If Not buildings.Contains(_0754RoyLowensteinBlvd) Then buildings.Add(_0754RoyLowensteinBlvd)
            End If

            '197 Route 68
            If config.GetValue(Of Boolean)("APARTMENT", "197RT68", True) Then
                Dim _197Route68Grg As New ApartmentClass()
                With _197Route68Grg
                    .ID = 50
                    .Name = "MP_PROP_50"
                    .Description = "MP_PROP_50DES"
                    .Price = 29000
                    .GarageFilePath = "197_route_68"
                    .SetAsGarage
                End With
                Dim _197Route68 As New BuildingClass()
                With _197Route68
                    .Name = "197 Route 68"
                    .GarageInPos = New Vector3(217.4353F, 2605.42F, 45.25777F)
                    .GarageFootInPos = New Quaternion(214.814F, 2601.883F, 44.76661F, 190.3705F)
                    .GarageOutPos = New Quaternion(215.8009F, 2612.181F, 46.02485F, 13.67587F)
                    .CameraPos = New CameraPRH(New Vector3(227.1874F, 2609.118F, 47.72932F), New Vector3(-9.736497F, 0F, 146.4485F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(221.7026F, 2603.319F, 44.76562F, -74.99998F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_197Route68Grg}
                End With
                If Not buildings.Contains(_197Route68) Then buildings.Add(_197Route68)
            End If

            '1200 Route 68
            If config.GetValue(Of Boolean)("APARTMENT", "1200RT68", True) Then
                Dim _1200Route68Grg As New ApartmentClass()
                With _1200Route68Grg
                    .ID = 52
                    .Name = "MP_PROP_52"
                    .Description = "MP_PROP_52DES"
                    .Price = 28000
                    .GarageFilePath = "1200_route_68"
                    .SetAsGarage
                End With
                Dim _1200Route68 As New BuildingClass()
                With _1200Route68
                    .Name = "1200 Route 68"
                    .GarageInPos = New Vector3(639.0682F, 2775.177F, 41.45542F)
                    .GarageFootInPos = New Quaternion(636.8033F, 2771.903F, 41.02551F, 183.2547F)
                    .GarageOutPos = New Quaternion(638.9866F, 2776.138F, 41.45025F, 4.862041F)
                    .CameraPos = New CameraPRH(New Vector3(647.4941F, 2782.823F, 42.97698F), New Vector3(-1.512628F, 0.00000005337945F, 140.1862F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(643.6212F, 2768.321F, 41.03106F, -84.99956F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1200Route68Grg}
                End With
                If Not buildings.Contains(_1200Route68) Then buildings.Add(_1200Route68)
            End If

            '1932 Grapeseed Ave
            If config.GetValue(Of Boolean)("APARTMENT", "1932GSAV", True) Then
                Dim _1932GrapeseedAveGrg As New ApartmentClass()
                With _1932GrapeseedAveGrg
                    .ID = 46
                    .Name = "MP_PROP_46"
                    .Description = "MP_PROP_46DES"
                    .Price = 27500
                    .GarageFilePath = "1932_grapeseed_ave"
                    .SetAsGarage
                End With
                Dim _1932GrapeseedAve As New BuildingClass()
                With _1932GrapeseedAve
                    .Name = "1932 Grapeseed Ave"
                    .GarageInPos = New Vector3(2553.352F, 4671.453F, 33.41243F)
                    .GarageFootInPos = New Quaternion(2556.039F, 4669.699F, 33.02306F, 204.3953F)
                    .GarageOutPos = New Quaternion(2552.85F, 4674.056F, 33.4055F, 14.16828F)
                    .CameraPos = New CameraPRH(New Vector3(2557.245F, 4681.927F, 36.7206F), New Vector3(-2.313836F, 0F, 172.4284F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(2552.022F, 4667.074F, 33.07679F, 23.99998F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1932GrapeseedAveGrg}
                End With
                If Not buildings.Contains(_1932GrapeseedAve) Then buildings.Add(_1932GrapeseedAve)
            End If

            '142 Paleto Blvd
            If config.GetValue(Of Boolean)("APARTMENT", "142PLTB", True) Then
                Dim _142PaletoBlvdGrg As New ApartmentClass()
                With _142PaletoBlvdGrg
                    .ID = 44
                    .Name = "MP_PROP_44"
                    .Description = "MP_PROP_44DES"
                    .Price = 26500
                    .GarageFilePath = "142_paleto_blvd"
                    .SetAsGarage
                End With
                Dim _142PaletoBlvd As New BuildingClass()
                With _142PaletoBlvd
                    .Name = "142 Paleto Blvd"
                    .GarageInPos = New Vector3(-70.95732F, 6428.574F, 30.90923F)
                    .GarageFootInPos = New Quaternion(-70.34654F, 6425.183F, 30.43957F, 226.7256F)
                    .GarageOutPos = New Quaternion(-74.37551F, 6432.063F, 30.91171F, 44.36166F)
                    .CameraPos = New CameraPRH(New Vector3(-82.28493F, 6428.63F, 32.48981F), New Vector3(-3.841596F, -0.000000106962F, -111.7737F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-65.19231F, 6429.667F, 30.48753F, 45.0001F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_142PaletoBlvdGrg}
                End With
                If Not buildings.Contains(_142PaletoBlvd) Then buildings.Add(_142PaletoBlvd)
            End If

            '1 Strawberry Ave
            If config.GetValue(Of Boolean)("APARTMENT", "1SBAV", True) Then
                Dim _1StrawberryAveGrg As New ApartmentClass()
                With _1StrawberryAveGrg
                    .ID = 45
                    .Name = "MP_PROP_45"
                    .Description = "MP_PROP_45DES"
                    .Price = 26000
                    .GarageFilePath = "1_strawberry_ave"
                    .SetAsGarage
                End With
                Dim _1StrawberryAve As New BuildingClass()
                With _1StrawberryAve
                    .Name = "1 Strawberry Ave"
                    .GarageInPos = New Vector3(-244.5432F, 6237.894F, 30.95915F)
                    .GarageFootInPos = New Quaternion(-249.1341F, 6237.605F, 30.48927F, 49.08922F)
                    .GarageOutPos = New Quaternion(-244.0274F, 6237.39F, 30.96051F, 225.6707F)
                    .CameraPos = New CameraPRH(New Vector3(-230.2499F, 6238.382F, 35.09702F), New Vector3(-13.30046F, 0F, 83.58285F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(-252.8173F, 6234.568F, 29.98922F, 45.99993F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {_1StrawberryAveGrg}
                End With
                If Not buildings.Contains(_1StrawberryAve) Then buildings.Add(_1StrawberryAve)
            End If

            'Unit 124 Popular St
            If config.GetValue(Of Boolean)("APARTMENT", "U124PS", True) Then
                Dim unit124PopularStGrg As New ApartmentClass()
                With unit124PopularStGrg
                    .ID = 31
                    .Name = "MP_PROP_31"
                    .Description = "MP_PROP_31DES"
                    .Price = 25000
                    .GarageFilePath = "unit_124_popular_st"
                    .SetAsGarage
                End With
                Dim unit124PopularSt As New BuildingClass()
                With unit124PopularSt
                    .Name = "Unit 124 Popular St"
                    .GarageInPos = New Vector3(724.9442F, -1193.347F, 23.74906F)
                    .GarageFootInPos = New Quaternion(726.8602F, -1190.521F, 23.27741F, 357.0051F)
                    .GarageOutPos = New Quaternion(724.9452F, -1193.348F, 23.74912F, 179.4612F)
                    .CameraPos = New CameraPRH(New Vector3(731.8636F, -1198.792F, 25.27797F), New Vector3(-6.987858F, 0.0000002150407F, 32.88501F), 50.0F)
                    .GarageType = eGarageType.TwoCarGarage
                    .SaleSign = New EntityVector(ForSaleSign, New Quaternion(723.0068F, -1189.81F, 23.28133F, 0F))
                    .SetAsGarage
                    .Apartments = New List(Of ApartmentClass) From {unit124PopularStGrg}
                End With
                If Not buildings.Contains(unit124PopularSt) Then buildings.Add(unit124PopularSt)
            End If
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

    Public Sub SpawnForSaleSignsAndLockDoors()
        Try
            For Each bd In buildings
                bd.SpawnForSaleSigns()

                Select Case bd.FrontDoor
                    Case eFrontDoor.DoubleDoors
                        bd.Door1.LockDoor()
                        bd.Door2.LockDoor()
                    Case eFrontDoor.StandardDoor
                        bd.Door1.LockDoor()
                End Select

                If bd.GarageDoor = eFrontDoor.StandardDoor Then bd.Door3.LockDoor()
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        Finally
            forSaleSignSpawned = True
        End Try
    End Sub

End Module
