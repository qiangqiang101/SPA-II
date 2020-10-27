Imports GTA
Imports GTA.Math
Imports SPAII.INM

Module BuildingList

    Public Sub LoadBuildings()
        buildings.Clear()
        apartments.Clear()

        Try
            config = ScriptSettings.Load("scripts\SPA II\modconfig.ini")

#Region "High End Apartments"
            '3 Alta Street
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
                .EnterCam = New CameraPRH(New Vector3(-261.7339F, -966.8005F, 77.23132F), New Vector3(-6.462961F, 0F, 115.6255F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-262.7977F, -970.2361F, 77.23131F), New Vector3(-7.714643F, 0F, 26.30853F), 50.0F)
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
                .WardrobePos = New Quaternion(-277.7127, -960.4503, 86.3143, 328.5379)
                .GarageFilePath = "3_alta_st_apt_57"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-281.657F, -941.6938F, 92.51088F), New Vector3(-5.602437F, 0F, -60.74197F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-280.5514F, -938.1181F, 92.51088F), New Vector3(-8.184019F, 0F, -147.3312F), 50.0F)
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
                .GarageFootOutPos = New Quaternion(-291.675F, -991.4265F, 23.13705F, 247.8065F)
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
                .GarageDoorPos = New Quaternion(-290.6072F, -992.1369F, 22.65152F, 250.6259F)
                .EnterCamera3 = New CameraPRH(New Vector3(-288.8877F, -994.0138F, 24.12381F), New Vector3(-3.488037F, -0.0000001069198F, -100.3268F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-298.3831F, -990.7642F, 24.12381F), New Vector3(-3.879195F, -0.00000001337085F, -87.55238F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {_3AltaStreet10, _3AltaStreet57}
            End With
            If Not buildings.Contains(_3AltaStreet) Then buildings.Add(_3AltaStreet)

            '4 Integrity Way       
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
                .WardrobePos = New Quaternion(-37.8572, -583.7734, 83.9183, 255.3193)
                .GarageFilePath = "4_integrity_way_apt_30"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-19.07393F, -579.4979F, 90.1149F), New Vector3(-7.949333F, 0F, -156.2887F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-15.09218F, -580.9767F, 90.1149F), New Vector3(-8.653407F, 0F, 118.9272F), 50.0F)
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
                .EnterCam = New CameraPRH(New Vector3(-13.85419F, -606.1687F, 100.2328F), New Vector3(-6.495338F, 0F, 126.4813F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-15.87129F, -610.6494F, 100.2328F), New Vector3(-6.886484F, 0F, 11.51289F), 50.0F)
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
                .WardrobePos = New Quaternion(-38.1595, -589.3992, 78.8302, 336.2282)
                .GarageFilePath = "4_integrity_way_apt_28"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-21.91163F, -596.6729F, 80.03086F), New Vector3(-8.231552F, 0.0000002156653F, 102.6055F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-26.6074F, -595.4224F, 80.03078F), New Vector3(-7.214558F, 0.0000002151468F, -144.1773F), 50.0F)
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
                .GarageFootOutPos = New Quaternion(-39.67788F, -619.5405F, 34.08903F, 248.174F)
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
                .GarageDoorPos = New Quaternion(-38.24696F, -620.0452F, 33.59096F, 248.9837F)
                .EnterCamera3 = New CameraPRH(New Vector3(-39.21017F, -621.2138F, 35.66154F), New Vector3(-7.39955F, 0.00000005380897F, -94.96883F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-41.55785F, -620.5078F, 35.66154F), New Vector3(-7.634233F, 0.00000005383805F, -87.75737F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {_4IntegrityWay30, _4IntegrityWay35, _4IntegrityWay28}
            End With
            If Not buildings.Contains(_4IntegrityWay) Then buildings.Add(_4IntegrityWay)

            'Del Perro Hts
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
                .WardrobePos = New Quaternion(-1467.6958, -537.2778, 50.7325, 314.1525)
                .GarageFilePath = "del_perro_hts_apt_7"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-1460.763F, -519.9211F, 56.92899F), New Vector3(-3.242044F, 0F, -95.52348F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-1456.251F, -517.1392F, 56.92899F), New Vector3(-1.520989F, 0F, 165.6819F), 50.0F)
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
                .EnterCam = New CameraPRH(New Vector3(-1460.123F, -520.1954F, 69.55661F), New Vector3(2.432733F, 3.338062E-9F, -88.93969F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-1456.329F, -517.3151F, 69.55661F), New Vector3(2.354509F, 0F, 165.1574F), 50.0F)
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
                .WardrobePos = New Quaternion(-1449.6384, -549.0426, 72.8437, 122.2167)
                .GarageFilePath = "del_perro_hts_apt_4"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-1459.016F, -533.272F, 74.04427F), New Vector3(-3.006529F, 0.0000002137376F, -118.3033F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-1455.819F, -537.8351F, 74.04427F), New Vector3(-3.475906F, 0F, 8.203254F), 50.0F)
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
                .GarageDoorPos = New Quaternion(-1447.752F, -515.782F, 30.09689F, 34.72319F)
                .EnterCamera3 = New CameraPRH(New Vector3(-1451.946F, -515.6177F, 31.54084F), New Vector3(-5.834974F, 0F, 3.413804F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-1448.056F, -521.9968F, 31.54084F), New Vector3(-5.834974F, 0F, 3.413804F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {delPerroHts7, delPerroHts4, delPerroHts20}
            End With
            If Not buildings.Contains(delPerroHts) Then buildings.Add(delPerroHts)

            'Eclipse Towers
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
                .EnterCam = New CameraPRH(New Vector3(-779.3718F, 341.6851F, 207.621F), New Vector3(4.559001F, -0.0000002141209F, -124.4503F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-774.1694F, 341.8526F, 207.621F), New Vector3(0.02166957F, 0F, 126.6593F), 50.0F)
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
                .EnterCam = New CameraPRH(New Vector3(-777.0729F, 315.7802F, 176.8037F), New Vector3(2.772609F, 0.0000001068468F, 58.8126F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-781.7292F, 315.3671F, 176.8037F), New Vector3(4.102514F, 0F, -52.55024F), 50.0F)
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
                .WardrobePos = New Quaternion(-795.5802F, 332.1348F, 152.805F, 296.0995F)
                .GarageFilePath = "eclipse_towers_apt_31"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-779.7419F, 342.1838F, 160.0015F), New Vector3(3.189691F, -0.0000001068873F, -128.8085F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-774.5495F, 342.2296F, 160.0015F), New Vector3(0.6081049F, 0.00000002668193F, 123.6403F), 50.0F)
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
                .EnterCam = New CameraPRH(New Vector3(-776.9001F, 315.682F, 223.2576F), New Vector3(0.9605104F, -0.00000005336834F, 55.58452F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-781.786F, 315.2228F, 223.2576F), New Vector3(0.4129034F, 0F, -50.73047F), 50.0F)
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
                .WardrobePos = New Quaternion(-793.4239, 326.7805, 210.7966, 356.4841)
                .GarageFilePath = "eclipse_towers_apt_3"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-775.1635F, 325.3173F, 211.9971F), New Vector3(-3.812282F, 0F, 119.4265F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-780.6631F, 324.9863F, 211.9971F), New Vector3(0.0992108F, 0F, -122.1022F), 50.0F)
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
                .WardrobePos = New Quaternion(-796.9515, 328.2715, 220.4384, 359.5432)
                .GarageFilePath = "eclipse_towers_phs_1"
                .IPL = config.GetValue("IPL", .Name, "apa_v_mp_h_01_a")
                .AptStyleCam = New CameraPRH(New Vector3(-786.6251, 343.8772, 218.0287), New Vector3(-7.585561, 0, -163.3333), 50.0F)
                .EnterCam = New CameraPRH(New Vector3(-780.761F, 320.4848F, 217.6408F), New Vector3(1.187448F, 0.00000002668616F, 160.2057F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-780.725F, 314.4459F, 217.6385F), New Vector3(-0.6118351F, -0.00000001334097F, 16.64737F), 50.0F)
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
                .ApartmentDoorPos = New Quaternion(-781.6838F, 314.9191F, 186.9136F, 0F)
                .ApartmentInPos = New Vector3(-776.9169, 336.887, 196.4864)
                .ApartmentOutPos = New Vector3(-779.2371, 339.6224, 196.6866)
                .WardrobePos = New Quaternion(-763.9934, 329.6285, 199.4863, 178.7236)
                .GarageFilePath = "eclipse_towers_phs_2"
                .IPL = config.GetValue("IPL", .Name, "apa_v_mp_h_01_b")
                .AptStyleCam = New CameraPRH(New Vector3(-774.2443, 314.4292, 196.6641), New Vector3(-2.762131, 0, 16.02366), 50.0F)
                .EnterCam = New CameraPRH(New Vector3(-781.5266F, 317.5228F, 187.81F), New Vector3(-11.97619F, 0F, 138.1035F), 50.0F)
                .ExitCam = Nothing
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
                .ApartmentDoorPos = New Quaternion(-779.198F, 342.5551F, 195.6864F, 0F)
                .ApartmentInPos = New Vector3(-784.0712, 320.7265, 187.7136)
                .ApartmentOutPos = New Vector3(-781.9078, 318.1647, 187.9138)
                .WardrobePos = New Quaternion(-796.9515, 328.2715, 190.7134, 359.5432)
                .GarageFilePath = "eclipse_towers_phs_3"
                .IPL = config.GetValue("IPL", .Name, "apa_v_mp_h_01_c")
                .AptStyleCam = New CameraPRH(New Vector3(-786.7924, 343.3035, 187.8668), New Vector3(-1.956791, 0, -163.332), 50.0F)
                .EnterCam = New CameraPRH(New Vector3(-779.556F, 340.1265F, 196.386F), New Vector3(-10.70871F, 0F, -47.96682F), 50.0F)
                .ExitCam = Nothing
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
                .GarageInPos = New Vector3(-796.1685, 311.4121, 85.7088)
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
                .GarageDoorPos = New Quaternion(-798.2641F, 326.3963F, 84.21525F, 181.2166F)
                .EnterCamera3 = New CameraPRH(New Vector3(-798.883F, 321.1833F, 86.86268F), New Vector3(-4.817973F, 0.0000002142003F, -165.7958F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-801.0359F, 332.1553F, 86.86268F), New Vector3(-11.4675F, -0.000000871164F, -150.8577F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {eclipseTowers5, eclipseTowers9, eclipseTowers31, eclipseTowers40, eclipseTowers3, eclipseTowersPH1, eclipseTowersPH2, eclipseTowersPH3}
            End With
            If Not buildings.Contains(eclipseTowers) Then buildings.Add(eclipseTowers)

            'Richards Majestic
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
                .WardrobePos = New Quaternion(-904.1464, -369.6518, 79.2839, 112.4174)
                .GarageFilePath = "richards_majestic_apt_4"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-913.8183F, -385.6429F, 85.48054F), New Vector3(1.513178F, -0.00000002668973F, 80.01873F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-917.986F, -388.7605F, 85.48054F), New Vector3(-2.86769F, 0.0000001068555F, -25.52587F), 50.0F)
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
                .WardrobePos = New Quaternion(-926.0495F, -381.5455F, 102.2438F, 298.6485F)
                .GarageFilePath = "richards_majestic_apt_51"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-916.823F, -365.8321F, 109.4404F), New Vector3(-0.07243962F, -2.08441E-10F, -91.85226F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-911.9507F, -362.8972F, 109.4404F), New Vector3(-4.062161F, 0F, 154.1064F), 50.0F)
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
                .WardrobePos = New Quaternion(-903.3266, -364.2998, 113.074, 195.6396)
                .GarageFilePath = "richards_majestic_apt_2"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-920.3886F, -371.1837F, 114.2746F), New Vector3(1.278489F, 0F, -24.80474F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-915.5103F, -368.1128F, 114.2747F), New Vector3(-2.789463F, 0F, 89.33965F), 50.0F)
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
                .GarageDoorPos = New Quaternion(-885.1744F, -345.4747F, 33.05091F, 206.8757F)
                .EnterCamera3 = New CameraPRH(New Vector3(-882.0393F, -355.215F, 35.81071F), New Vector3(-6.46077F, 0F, -136.0225F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-889.6566F, -341.996F, 34.51073F), New Vector3(-6.46077F, 0F, -136.0225F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {richardsMajestic4, richardsMajestic2, richardsMajestic51}
            End With
            If Not buildings.Contains(richardsMajestic) Then buildings.Add(richardsMajestic)

            'Tinsel Towers
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
                .WardrobePos = New Quaternion(-583.9974, 50.5919, 87.4296, 79.9632)
                .GarageFilePath = "tinsel_towers_apt_29"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-599.6767F, 40.31644F, 93.62612F), New Vector3(-1.498387F, -0.0000001067582F, 50.53613F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-605.2601F, 40.26904F, 93.62612F), New Vector3(-2.202455F, 0F, -57.89299F), 50.0F)
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
                .WardrobePos = New Quaternion(-594.8418, 55.761, 96.9996, 173.2113)
                .GarageFilePath = "tinsel_towers_apt_42"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-613.3113F, 56.75812F, 98.00005F), New Vector3(-0.6294498F, -0.00000005336407F, -53.16898F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-606.5956F, 57.59918F, 98.20011F), New Vector3(-2.741654F, 0F, 66.74448F), 50.0F)
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
                .EnterCam = New CameraPRH(New Vector3(-601.9167F, 66.87601F, 108.0271F), New Vector3(-3.638038F, 0F, -123.861F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-596.4003F, 66.94935F, 108.0271F), New Vector3(-0.9782246F, -0.00000005336863F, 130.0301F), 50.0F)
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
                .GarageFootOutPos = New Quaternion(-622.0246F, 56.42989F, 42.73281F, 87.49985F)
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
                .GarageDoorPos = New Quaternion(-620.0411F, 59.18661F, 42.25226F, 102.8858F)
                .EnterCamera3 = New CameraPRH(New Vector3(-622.3945F, 59.88835F, 43.5915F), New Vector3(-3.644489F, 0F, 110.8087F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-615.8323F, 61.20481F, 43.5915F), New Vector3(-4.035642F, 0F, 126.1583F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {tinselTowers29, tinselTowers42, tinselTowers45}
            End With
            If Not buildings.Contains(tinselTowers) Then buildings.Add(tinselTowers)

            'Weazel Plaza
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
                .EnterCam = New CameraPRH(New Vector3(-883.6516F, -442.9665F, 95.46117F), New Vector3(-2.945535F, -0.00000002671572F, 176.752F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-880.672F, -447.7705F, 95.46117F), New Vector3(-1.146247F, 0F, 70.23095F), 50.0F)
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
                .WardrobePos = New Quaternion(-909.721, -445.5214, 115.7431, 296.1297)
                .GarageFilePath = "weazel_plaza_apt_70"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-900.7505F, -429.4271F, 121.6071F), New Vector3(-1.906329F, 0.0000000266952F, -100.7881F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-895.1754F, -426.8778F, 121.6071F), New Vector3(-2.688629F, 0.0000001068393F, 148.6731F), 50.0F)
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
                .EnterCam = New CameraPRH(New Vector3(-897.9183F, -460.169F, 126.5345F), New Vector3(-2.575239F, -6.676848E-9F, 90.77414F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-902.929F, -463.2002F, 126.5345F), New Vector3(-2.653472F, 0F, -28.72718F), 50.0F)
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
                .GarageFootOutPos = New Quaternion(-814.3434F, -431.3128F, 34.72047F, 120.534F)
                .GarageOutPos = New Quaternion(-825.2957F, -439.5938F, 35.17701F, 118.1855F)
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
                .GarageDoorPos = New Quaternion(-812.4279F, -427.9642F, 33.74161F, 150.2066F)
                .EnterCamera3 = New CameraPRH(New Vector3(-818.048F, -430.0121F, 36.71004F), New Vector3(-2.627478F, 0F, 154.9526F), 50.0F)
                .EnterCamera4 = New CameraPRH(New Vector3(-809.6729F, -418.2455F, 34.41008F), New Vector3(-5.75667F, 0.0000002145253F, 145.7837F), 50.0F)
                .Apartments = New List(Of ApartmentClass) From {weazelPlaza26, weazelPlaza70, weazelPlaza101}
            End With
            If Not buildings.Contains(weazelPlaza) Then buildings.Add(weazelPlaza)
#End Region

#Region "Stilt Houses"
            '2862 Hillcrest Avenue
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
                .WardrobePos = New Quaternion(-671.645, 587.338, 141.5698, 213.4807)
                .GarageFilePath = "2862_hillcrest_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-681.9128F, 589.816F, 145.3796F), New Vector3(-1.456906F, 0.00000002668905F, 12.13189F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-685.3916F, 593.8347F, 145.3796F), New Vector3(-4.116713F, -0.0000002139955F, -109.7389F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2862HillcrestAveApt}
            End With
            If Not buildings.Contains(_2862HillcrestAve) Then buildings.Add(_2862HillcrestAve)

            '2868 Hillcrest Avenue
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
                .WardrobePos = New Quaternion(-767.4208, 611.0219, 140.3307, 113.3104)
                .GarageFilePath = "2868_hillcrest_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-761.1334F, 619.6977F, 144.1406F), New Vector3(-2.430274F, -0.0000001068178F, -102.2453F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-756.1354F, 621.3319F, 144.1404F), New Vector3(-1.169034F, -0.0000001067439F, 141.0267F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2868HillcrestAveApt}
            End With
            If Not buildings.Contains(_2868HillcrestAve) Then buildings.Add(_2868HillcrestAve)

            '2874 Hillcrest Avenue
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
                .WardrobePos = New Quaternion(-855.3519, 680.0969, 149.0531, 182.5082)
                .GarageFilePath = "2874_hillcrest_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-860.6671F, 688.2697F, 152.8574F), New Vector3(1.240028F, -0.00000002668667F, -10.4812F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-861.0671F, 693.5422F, 152.8527F), New Vector3(3.209681F, 0F, -152.4406F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2874HillcrestAveApt}
            End With
            If Not buildings.Contains(_2874HillcrestAve) Then buildings.Add(_2874HillcrestAve)

            '2113 Mad Wayne Thunder Drive
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
                .WardrobePos = New Quaternion(-1286.1141, 438.157, 94.0948, 177.5665)
                .GarageFilePath = "2113_mad_wayne_thunder_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-1290.829F, 446.7322F, 97.89904F), New Vector3(-4.749104F, 0.0000002141787F, -19.49026F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-1290.821F, 452.0313F, 97.89452F), New Vector3(-1.77637F, -0.0000000533865F, -154.4443F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2113MadWayneThunderDrApt}
            End With
            If Not buildings.Contains(_2113MadWayneThunderDr) Then buildings.Add(_2113MadWayneThunderDr)

            '2117 Milton Road
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
                .WardrobePos = New Quaternion(-571.277, 649.8883, 142.0322, 166.0936)
                .GarageFilePath = "2117_milton_rd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-573.2893F, 659.4885F, 145.8363F), New Vector3(-4.147635F, 0F, -26.64996F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-572.2256F, 664.2844F, 145.8319F), New Vector3(0.3896891F, 0F, -170.2575F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2117MiltonRdApt}
            End With
            If Not buildings.Contains(_2117MiltonRd) Then buildings.Add(_2117MiltonRd)

            '2044 North Conker Avenue
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
                .WardrobePos = New Quaternion(334.2987, 428.6485, 145.5708, 103.0573)
                .GarageFilePath = "2044_north_conker_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(339.4561F, 437.9623F, 149.3808F), New Vector3(1.555862F, 0F, -89.35435F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(343.9814F, 440.404F, 149.3806F), New Vector3(-1.573324F, 0.00000005338097F, 145.0662F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2044NorthConkerAveApt}
            End With
            If Not buildings.Contains(_2044NorthConkerAve) Then buildings.Add(_2044NorthConkerAve)

            '2045 North Conker Avenue
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
                .WardrobePos = New Quaternion()
                .GarageFilePath = "2045_north_conker_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(371.957F, 421.1223F, 145.9043F), New Vector3(-2.741305F, 0F, -31.85181F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(373.2456F, 426.2398F, 145.8999F), New Vector3(2.969471F, 0F, -169.3813F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2045NorthConkerAveApt}
            End With
            If Not buildings.Contains(_2045NorthConkerAve) Then buildings.Add(_2045NorthConkerAve)

            '3677 Whispymound Drive
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
                .WardrobePos = New Quaternion(122.0242, 548.9013, 180.4972, 182.3311)
                .GarageFilePath = "3677_whispymound_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(116.7523F, 557.5699F, 184.2982F), New Vector3(-0.2394818F, 6.670164E-9F, -6.879202F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(115.986F, 562.2002F, 184.2969F), New Vector3(2.263864F, -0.0000002136101F, -151.1049F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .HideObjects = {"apa_ch2_05c_b4", "ch2_05c_emissive_07", "ch2_05c_decals_05", "ch2_05c_B4_LOD"}
                .Apartments = New List(Of ApartmentClass) From {_3677WhispymoundDrApt}
            End With
            If Not buildings.Contains(_3677WhispymoundDr) Then buildings.Add(_3677WhispymoundDr)

            '3655 Wild Oats Drive
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
                .WardrobePos = New Quaternion(-167.5116, 487.8223, 133.8438, 103.0573)
                .GarageFilePath = "3655_wild_oats_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = New CameraPRH(New Vector3(-175.3813F, 495.4395F, 137.6537F), New Vector3(-3.876556F, 0F, -20.65905F), 50.0F)
                .ExitCam = New CameraPRH(New Vector3(-176.2728F, 500.246F, 137.6535F), New Vector3(-3.876556F, 0.0000004278658F, -142.1714F), 50.0F)
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
                .GarageDoorPos = QuaternionZero()
                .HideObjects = {"apa_ch2_05e_res5", "apa_ch2_05e_res5_LOD"}
                .Apartments = New List(Of ApartmentClass) From {_3655WildOatsDrApt}
            End With
            If Not buildings.Contains(_3655WildOatsDr) Then buildings.Add(_3655WildOatsDr)
#End Region

#Region "Medium End Apartments"
            '0115 Bay City Ave
            Dim _0115BayCityAve45 As New ApartmentClass()
            With _0115BayCityAve45
                .ID = 14
                .Name = "MP_PROP_14"
                .Description = "MP_PROP_14DES"
                .Price = 150000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "0115_bay_city_ave_45"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0115BayCityAve45}
            End With
            If Not buildings.Contains(_0115BayCityAve) Then buildings.Add(_0115BayCityAve)

            'Dream Tower
            Dim dreamTower15 As New ApartmentClass()
            With dreamTower15
                .ID = 16
                .Name = "MP_PROP_16"
                .Description = "MP_PROP_16DES"
                .Price = 134000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "dream_tower_15"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {dreamTower15}
            End With
            If Not buildings.Contains(dreamTower) Then buildings.Add(dreamTower)

            '4 Hangman Ave
            Dim _4HangmanAveApt As New ApartmentClass()
            With _4HangmanAveApt
                .ID = 72
                .Name = "MP_PROP_72"
                .Description = "MP_PROP_72DES"
                .Price = 175000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "4_hangman_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_4HangmanAveApt}
            End With
            If Not buildings.Contains(_4HangmanAve) Then buildings.Add(_4HangmanAve)

            '0604 Las Lagunas Blvd
            Dim _0604LasLagunasBlvd4 As New ApartmentClass()
            With _0604LasLagunasBlvd4
                .ID = 10
                .Name = "MP_PROP_10"
                .Description = "MP_PROP_10DES"
                .Price = 126000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "0604_las_lagunas_blvd_4"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0604LasLagunasBlvd4}
            End With
            If Not buildings.Contains(_0604LasLagunasBlvd) Then buildings.Add(_0604LasLagunasBlvd)

            '0184 Milton Rd
            Dim _0184MiltonRd13 As New ApartmentClass()
            With _0184MiltonRd13
                .ID = 11
                .Name = "MP_PROP_11"
                .Description = "MP_PROP_11DES"
                .Price = 146000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "0184_milton_rd_13"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0184MiltonRd13}
            End With
            If Not buildings.Contains(_0184MiltonRd) Then buildings.Add(_0184MiltonRd)

            '1162 Power St
            Dim _1162PowerSt3 As New ApartmentClass()
            With _1162PowerSt3
                .ID = 8
                .Name = "MP_PROP_8"
                .Description = "MP_PROP_8DES"
                .Price = 130000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "1162_power_street_3"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_1162PowerSt3}
            End With
            If Not buildings.Contains(_1162PowerSt) Then buildings.Add(_1162PowerSt)

            '4401 Procopio Dr
            Dim _4401ProcopioDrApt As New ApartmentClass()
            With _4401ProcopioDrApt
                .ID = 75
                .Name = "MP_PROP_75"
                .Description = "MP_PROP_75DES"
                .Price = 165000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "4401_procopio_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_4401ProcopioDrApt}
            End With
            If Not buildings.Contains(_4401ProcopioDr) Then buildings.Add(_4401ProcopioDr)

            '4584 Procopio Dr
            Dim _4584ProcopioDrApt As New ApartmentClass()
            With _4584ProcopioDrApt
                .ID = 74
                .Name = "MP_PROP_74"
                .Description = "MP_PROP_74DES"
                .Price = 155000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "4584_procopio_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_4584ProcopioDrApt}
            End With
            If Not buildings.Contains(_4584ProcopioDr) Then buildings.Add(_4584ProcopioDr)

            '0504 S Mo Milton Dr
            Dim _0504SMoMiltonDrApt As New ApartmentClass()
            With _0504SMoMiltonDrApt
                .ID = 13
                .Name = "MP_PROP_13"
                .Description = "MP_PROP_13DES"
                .Price = 141000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "0504_s_mo_milton_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0504SMoMiltonDrApt}
            End With
            If Not buildings.Contains(_0504SMoMiltonDr) Then buildings.Add(_0504SMoMiltonDr)

            '0325 South Rockford Dr
            Dim _0325SouthRockfordDrApt As New ApartmentClass()
            With _0325SouthRockfordDrApt
                .ID = 15
                .Name = "MP_PROP_15"
                .Description = "MP_PROP_15DES"
                .Price = 137000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "0325_south_rockford_dr"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0325SouthRockfordDrApt}
            End With
            If Not buildings.Contains(_0325SouthRockfordDr) Then buildings.Add(_0325SouthRockfordDr)

            '0605 Spanish Ave
            Dim _0605SpanishAve1 As New ApartmentClass()
            With _0605SpanishAve1
                .ID = 9
                .Name = "MP_PROP_9"
                .Description = "MP_PROP_9DES"
                .Price = 128000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "0605_spanish_ave_1"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0605SpanishAve1}
            End With
            If Not buildings.Contains(_0605SpanishAve) Then buildings.Add(_0605SpanishAve)

            '12 Sustancia Rd
            Dim _12SustanciaRdApt As New ApartmentClass()
            With _12SustanciaRdApt
                .ID = 73
                .Name = "MP_PROP_73"
                .Description = "MP_PROP_73DES"
                .Price = 143000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "12_sustancia_rd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_12SustanciaRdApt}
            End With
            If Not buildings.Contains(_12SustanciaRd) Then buildings.Add(_12SustanciaRd)

            'The Royale
            Dim theRoyale19 As New ApartmentClass()
            With theRoyale19
                .ID = 12
                .Name = "MP_PROP_12"
                .Description = "MP_PROP_12DES"
                .Price = 125000
                .SavePos = MediumEndApartment.SavePos
                .ApartmentDoorPos = MediumEndApartment.DoorPos
                .ApartmentInPos = MediumEndApartment.InPos
                .ApartmentOutPos = MediumEndApartment.OutPos
                .WardrobePos = MediumEndApartment.WardrobePos
                .GarageFilePath = "the_royale_12"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = MediumEndApartment.EnterCam
                .ExitCam = MediumEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.MediumEnd
                .Door = MediumEndApartment.Door
            End With
            Dim theRoyale As New BuildingClass()
            With theRoyale
                .Name = "The Royale"
                .BuildingInPos = New Quaternion(-198.8772F, 86.29745F, 68.75475F, 161.634F)
                .BuildingOutPos = New Quaternion(-197.4334F, 88.22113F, 68.74056F, 346.0997F)
                .BuildingLobby = New Quaternion(-198.2083F, 82.97825F, 68.75932F, 350.151F)
                .GarageInPos = New Vector3(-216.1293F, 39.01434F, 58.21085F)
                .GarageFootInPos = New Quaternion(-212.3528F, 32.46584F, 58.8203F, 165.9531F)
                .GarageOutPos = New Quaternion(-215.8855, 75.07529, 66.78372, 81.58614)
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {theRoyale19}
            End With
            If Not buildings.Contains(theRoyale) Then buildings.Add(theRoyale)
#End Region

#Region "Low End Apartments"
            '1115 Blvd Del Perro
            Dim _1115BlvdDelPerro18 As New ApartmentClass()
            With _1115BlvdDelPerro18
                .ID = 23
                .Name = "MP_PROP_23"
                .Description = "MP_PROP_23DES"
                .Price = 93000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "1115_blvd_del_perro_18"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_1115BlvdDelPerro18}
            End With
            If Not buildings.Contains(_1115BlvdDelPerro) Then buildings.Add(_1115BlvdDelPerro)

            '1561 San Vitas St
            Dim _1561SanVitasSt2 As New ApartmentClass()
            With _1561SanVitasSt2
                .ID = 18
                .Name = "MP_PROP_18"
                .Description = "MP_PROP_18DES"
                .Price = 99000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "1561_san_vitas_st_2"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_1561SanVitasSt2}
            End With
            If Not buildings.Contains(_1561SanVitasSt) Then buildings.Add(_1561SanVitasSt)

            '1237 Prosperity St
            Dim _1237ProsperitySt21 As New ApartmentClass()
            With _1237ProsperitySt21
                .ID = 22
                .Name = "MP_PROP_22"
                .Description = "MP_PROP_22DES"
                .Price = 105000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "1237_prosperity_st_21"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_1237ProsperitySt21}
            End With
            If Not buildings.Contains(_1237ProsperitySt) Then buildings.Add(_1237ProsperitySt)

            '0069 Cougar Ave
            Dim _0069CougarAve19 As New ApartmentClass()
            With _0069CougarAve19
                .ID = 21
                .Name = "MP_PROP_21"
                .Description = "MP_PROP_21DES"
                .Price = 112000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "0069_cougar_ave_19"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0069CougarAve19}
            End With
            If Not buildings.Contains(_0069CougarAve) Then buildings.Add(_0069CougarAve)

            '2143 Las Lagunas Blvd
            Dim _2143LasLagunasBlvd9 As New ApartmentClass()
            With _2143LasLagunasBlvd9
                .ID = 17
                .Name = "MP_PROP_17"
                .Description = "MP_PROP_17DES"
                .Price = 115000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "2143_las_lagunas_blvd_9"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2143LasLagunasBlvd9}
            End With
            If Not buildings.Contains(_2143LasLagunasBlvd) Then buildings.Add(_2143LasLagunasBlvd)

            '1893 Grapeseed Ave
            Dim _1893GrapeseedAveApt As New ApartmentClass()
            With _1893GrapeseedAveApt
                .ID = 78
                .Name = "MP_PROP_78"
                .Description = "MP_PROP_78DES"
                .Price = 118000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "1893_grapeseed_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_1893GrapeseedAveApt}
            End With
            If Not buildings.Contains(_1893GrapeseedAve) Then buildings.Add(_1893GrapeseedAve)

            '0232 Paleto Blvd
            Dim _0232PaletoBlvdApt As New ApartmentClass()
            With _0232PaletoBlvdApt
                .ID = 76
                .Name = "MP_PROP_76"
                .Description = "MP_PROP_76DES"
                .Price = 121000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "0232_poleto_blvd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0232PaletoBlvdApt}
            End With
            If Not buildings.Contains(_0232PaletoBlvd) Then buildings.Add(_0232PaletoBlvd)

            '0112 S Rockford Dr
            Dim _0112SRockfordDr13 As New ApartmentClass()
            With _0112SRockfordDr13
                .ID = 19
                .Name = "MP_PROP_19"
                .Description = "MP_PROP_19DES"
                .Price = 80000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "0112_s_rockford_dr_13"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_0112SRockfordDr13}
            End With
            If Not buildings.Contains(_0112SRockfordDr) Then buildings.Add(_0112SRockfordDr)

            '2057 Vespucci Blvd
            Dim _2057VespucciBlvd1 As New ApartmentClass()
            With _2057VespucciBlvd1
                .ID = 20
                .Name = "MP_PROP_20"
                .Description = "MP_PROP_20DES"
                .Price = 87000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "2057_vespucci_blvd"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
                .Apartments = New List(Of ApartmentClass) From {_2057VespucciBlvd1}
            End With
            If Not buildings.Contains(_2057VespucciBlvd) Then buildings.Add(_2057VespucciBlvd)

            '140 Zancudo Ave
            Dim _140ZancudoAveApt As New ApartmentClass()
            With _140ZancudoAveApt
                .ID = 77
                .Name = "MP_PROP_77"
                .Description = "MP_PROP_77DES"
                .Price = 121000
                .SavePos = LowEndApartment.SavePos
                .ApartmentDoorPos = LowEndApartment.DoorPos
                .ApartmentInPos = LowEndApartment.InPos
                .ApartmentOutPos = LowEndApartment.OutPos
                .WardrobePos = LowEndApartment.WardrobePos
                .GarageFilePath = "140_zancudo_ave"
                .IPL = Nothing
                .AptStyleCam = Nothing
                .EnterCam = LowEndApartment.EnterCam
                .ExitCam = LowEndApartment.ExitCam
                .GarageElevatorPos = Vector3.Zero
                .GarageMenuPos = Vector3.Zero
                .ApartmentType = eApartmentType.LowEnd
                .Door = LowEndApartment.Door
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
                .GarageDoorPos = QuaternionZero()
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
