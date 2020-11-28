Imports GTA
Imports GTA.Native
Imports NFunc = GTA.Native.Function
Imports INMNativeUI
Imports System.Runtime.CompilerServices
Imports GTA.Math
Imports SPAII.INM

Module ApartmentProps

    Public ClosestProp As Prop = Nothing
    Public ClosestPropList As New List(Of Model) From {"prop_tv_flat_01", "hei_heist_str_avunitl_03", "apa_mp_h_str_avunitm_03", "apa_mp_h_str_avunits_01", "apa_mp_h_str_avunits_04", "prop_tv_03", "apa_mp_h_str_avunitm_01", "apa_mp_h_str_avunitl_01_b", "apa_mp_h_str_avunitl_04", "ex_prop_ex_tv_flat_01", "v_res_mm_audio", "prop_mp3_dock", "prop_boombox_01", "prop_tapeplayer_01", "v_res_fh_speakerdock", "prop_radio_01", "prop_bong_01"}

#Region "Telly"
    Public TVModels As New List(Of Model) From {"prop_tv_flat_01", "hei_heist_str_avunitl_03", "apa_mp_h_str_avunitm_03", "apa_mp_h_str_avunits_01", "apa_mp_h_str_avunits_04", "prop_tv_03", "apa_mp_h_str_avunitm_01", "apa_mp_h_str_avunitl_01_b", "apa_mp_h_str_avunitl_04", "ex_prop_ex_tv_flat_01"}
    Public TVOn As Boolean = False, TIBOn As Boolean = False, SubtitleOn As Boolean = False, TVSound As Single = 0F, TVChannel As Integer = 0, rendertargetid, ex_rendertargetid As Integer, TVCamera As Camera
    Public TVChannelList As New List(Of Integer) From {0, 1}
    Public IBScaleform As New Scaleform("instructional_buttons")

    Public Sub DrawTVControlInstructionalButtons()
        IBScaleform.CallFunction("CLEAR_ALL")
        'IBScaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0)
        IBScaleform.CallFunction("CREATE_CONTAINER")
        IBScaleform.CallFunction("SET_DATA_SLOT", 0, GetControlInstructionalButton(Control.ScriptLeftAxisX), Game.GetGXTEntry("HUD_INPUT75"))
        IBScaleform.CallFunction("SET_DATA_SLOT", 1, GetControlInstructionalButton(Control.ScriptRUp), Game.GetGXTEntry("HUD_INPUT69"))
        IBScaleform.CallFunction("SET_DATA_SLOT", 2, GetControlInstructionalButton(Control.Context), Game.GetGXTEntry("HUD_INPUT82"))
        IBScaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1)
        IBScaleform.Render2D()
    End Sub

    <Extension>
    Public Function TurnOnTV(tv As Prop, tvscreen As String, channel As Integer, vol As Single) As Integer
        Dim result As Integer = 0
        NFunc.Call(Hash.ATTACH_TV_AUDIO_TO_ENTITY, tv)
        If Not NFunc.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, tvscreen) Then NFunc.Call(Hash.REGISTER_NAMED_RENDERTARGET, tvscreen, False)
        If Not NFunc.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_LINKED, tv.Model) Then
            NFunc.Call(Hash.LINK_NAMED_RENDERTARGET, tv.Model)
            result = NFunc.Call(Of Integer)(Hash.GET_NAMED_RENDERTARGET_RENDER_ID, tvscreen)
        End If
        NFunc.Call(Hash.SET_TV_CHANNEL, channel)
        NFunc.Call(Hash.SET_TV_VOLUME, vol)
        NFunc.Call(Hash.ENABLE_MOVIE_SUBTITLES, False)
        Return result
    End Function

    Public Sub TurnOffTV(tvscreen As String)
        NFunc.Call(Hash.SET_TV_CHANNEL, 2)
        Script.Wait(500)
        If NFunc.Call(Of Boolean)(Hash.IS_NAMED_RENDERTARGET_REGISTERED, tvscreen) Then NFunc.Call(Hash.RELEASE_NAMED_RENDERTARGET, tvscreen)
    End Sub

    Public Sub RenderTV(rtid As Integer)
        NFunc.Call(Hash.SET_TEXT_RENDER_ID, rtid)
        NFunc.Call(Hash.DRAW_TV_CHANNEL, 0.5, 0.5, 1.0, 1.0, 0.0, 255, 255, 255, 255)
        NFunc.Call(Hash.SET_TEXT_RENDER_ID, NFunc.Call(Of Integer)(Hash.GET_DEFAULT_SCRIPT_RENDERTARGET_RENDER_ID))
    End Sub

    <Extension>
    Public Function IsPropTelly(prop As Prop) As Boolean
        If prop = Nothing Then Return False Else Return TVModels.Contains(prop.Model)
    End Function

    Public Sub TellyTick()
        If ClosestProp.IsPropTelly Then
            If ClosestProp.Position.DistanceToSquared(Game.Player.Character.Position) <= 4.0F Then
                If Not TVOn Then
                    UI.ShowHelpMessage(Game.GetGXTEntry("MPTV_GRGE"))
                    If Game.IsControlJustPressed(0, Control.Context) Then
                        rendertargetid = ClosestProp.TurnOnTV("tvscreen", TVChannel, TVSound)
                        ex_rendertargetid = ClosestProp.TurnOnTV("ex_tvscreen", TVChannel, TVSound)
                        TVOn = True
                        Script.Yield()
                    End If
                Else
                    If Not TIBOn Then UI.ShowHelpMessage(Game.GetGXTEntry("TV_HLP5"))
                    If Game.IsControlJustPressed(0, Control.Context) Then
                        TurnOffTV("tvscreen")
                        TurnOffTV("ex_tvscreen")
                        TVOn = False
                        TIBOn = False
                        Script.Yield()
                    ElseIf Game.IsControlJustPressed(0, Control.ScriptRUp) AndAlso TIBOn = False Then
                        TIBOn = True
                        Script.Yield()
                    End If
                End If
                If TIBOn Then
                    If Game.IsControlJustPressed(0, Control.ScriptLeftAxisX) Then
                        Select Case TVChannel
                            Case 0
                                TVChannel = 1
                            Case 1
                                TVChannel = 0
                        End Select
                        NFunc.Call(Hash.SET_TV_CHANNEL, TVChannel)
                        Script.Yield()
                    ElseIf Game.IsControlJustPressed(0, Control.ScriptRUp) AndAlso TIBOn = True Then
                        TIBOn = False
                        Script.Yield()
                    End If
                End If
            Else
                If TIBOn Then TIBOn = False
            End If
        End If

        If TVOn Then
            RenderTV(rendertargetid)
            RenderTV(ex_rendertargetid)
        End If
        If TIBOn Then DrawTVControlInstructionalButtons()
        If ClosestProp = Nothing Then TIBOn = False
    End Sub
#End Region

#Region "Radio"
    Public RadioModels As New List(Of Model) From {"v_res_mm_audio", "prop_mp3_dock", "prop_boombox_01", "prop_tapeplayer_01", "v_res_fh_speakerdock", "prop_radio_01"}
    Public RadioOn As Boolean = False, RadioChannel As Integer = 0
    Public RadioEmitter As Prop = Nothing

    Public Function GetPlayerRadioStation() As Integer
        Return NFunc.Call(Of Integer)(Hash.GET_PLAYER_RADIO_STATION_INDEX)
    End Function

    Public Sub TurnOnRadio(radio As Prop, Optional emitter As String = "SE_DLC_APT_Yacht_Bar")
        RadioChannel = GetPlayerRadioStation()
        If RadioEmitter = Nothing Then
            RadioEmitter = CreateRadioPropNoOffset("prop_boombox_01", radio.Position, False)
        Else
            RadioEmitter.Position = radio.Position
        End If
        UpdateRadio(RadioChannel)
        NFunc.Call(Hash.SET_STATIC_EMITTER_ENABLED, emitter, True)
        NFunc.Call(&HE0CD610D5EB6C85, emitter, RadioEmitter)
    End Sub

    Public Sub TurnOffRadio(Optional emitter As String = "SE_DLC_APT_Yacht_Bar")
        NFunc.Call(Hash.SET_STATIC_EMITTER_ENABLED, emitter, False)
    End Sub

    Public Sub UpdateRadio(station As RadioStation, Optional emitter As String = "SE_DLC_APT_Yacht_Bar")
        If station = 22 Then station = 0
        If station = 256 Then station = 0
        RadioChannel = station
        Dim stationName As String = NFunc.Call(Of String)(Hash.GET_RADIO_STATION_NAME, station)
        NFunc.Call(Hash.SET_EMITTER_RADIO_STATION, emitter, stationName)
    End Sub

    Public Sub DrawRadioControlInstructionalButtons()
        IBScaleform.CallFunction("CLEAR_ALL")
        'IBScaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0)
        IBScaleform.CallFunction("CREATE_CONTAINER")
        IBScaleform.CallFunction("SET_DATA_SLOT", 0, GetControlInstructionalButton(Control.ScriptRUp), $"{Game.GetGXTEntry("HUD_INPUT80")} ({Game.GetGXTEntry(NFunc.Call(Of String)(Hash.GET_RADIO_STATION_NAME, RadioChannel))})") 'Select Station
        IBScaleform.CallFunction("SET_DATA_SLOT", 1, GetControlInstructionalButton(Control.Context), Game.GetGXTEntry("HUD_INPUT82")) 'Turn Off
        IBScaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", -1)
        IBScaleform.Render2D()
    End Sub

    Public Function CreateRadioPropNoOffset(model As Model, position As Vector3, dynamic As Boolean) As Prop
        Dim newProp As New Prop(NFunc.Call(Of Integer)(Hash.CREATE_OBJECT_NO_OFFSET, model.Hash, position.X, position.Y, position.Z, True, True, dynamic))
        With newProp
            .IsInvincible = True
            .FreezePosition = True
            .HasCollision = False
            .IsVisible = False
        End With
        Return newProp
    End Function

    <Extension>
    Public Function IsPropRadio(prop As Prop) As Boolean
        If prop = Nothing Then Return False Else Return RadioModels.Contains(prop.Model)
    End Function

    Public Sub RadioTick()
        If ClosestProp.IsPropRadio Then
            If Not RadioEmitter = Nothing Then RadioEmitter.Position = ClosestProp.Position

            If ClosestProp.Position.DistanceToSquared(PP.Position) <= 2.0F Then
                If Not RadioOn Then
                    UI.ShowHelpMessage(Game.GetGXTEntry("MPRD_CTXT"))
                    If Game.IsControlJustPressed(0, Control.Context) Then
                        TurnOnRadio(ClosestProp)
                        UpdateRadio(RadioChannel)
                        RadioOn = True
                        Script.Yield()
                    End If
                Else
                    DrawRadioControlInstructionalButtons()
                    If Game.IsControlJustPressed(0, Control.ScriptRUp) Then
                        UpdateRadio(RadioChannel + 1)
                        Script.Yield()
                    ElseIf Game.IsControlJustPressed(0, Control.Context) Then
                        TurnOffRadio()
                        UpdateRadio(255)
                        RadioOn = False
                        Script.Yield()
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Bong"
    Public BongModels As New List(Of Model) From {"prop_bong_01"}
    Public BongTaskScriptStatus As Integer = -1
    Public BongStage As Integer = 1
    Public BongProp As Prop = Nothing, LighterProp As Prop = Nothing
    Public BongMemory As PropMemory
    Public LighterMemory As PropMemory

    <Extension>
    Public Function IsPropBong(prop As Prop) As Boolean
        If prop = Nothing Then Return False Else Return BongModels.Contains(prop.Model)
    End Function

    Public Sub BongTick()
        If ClosestProp.IsPropBong Then
            If ClosestProp.Position.DistanceToSquared(PP.Position) <= 2.0F Then
                If BongTaskScriptStatus = -1 Then
                    UI.ShowHelpMessage(Game.GetGXTEntry("SA_BONG2"))
                    If Game.IsControlJustPressed(0, Control.Context) Then
                        BongProp = ClosestProp
                        BongMemory = New PropMemory(BongProp)
                        LighterProp = GetClosestProp(BongProp.Position, 10.0F, "p_cs_lighter_01", False)
                        LighterMemory = New PropMemory(LighterProp)
                        BongTaskScriptStatus = 0
                    End If
                End If
            End If
        End If

        If BongTaskScriptStatus <> -1 Then
            Select Case BongTaskScriptStatus
                Case 0
                    If BongStage > 4 Then
                        BongStage = 1
                        PP.Task.PlayAnimation("anim@safehouse@bong", $"bong_stage{BongStage}")
                    Else
                        PP.Task.PlayAnimation("anim@safehouse@bong", $"bong_stage{BongStage}")
                        BongStage += 1
                    End If
                    Script.Wait(1500)
                    BongProp.AttachTo(PP, PP.GetBoneIndex(Bone.PH_L_Hand), Vector3.Zero, Vector3.Zero)
                    LighterProp.AttachTo(PP, PP.GetBoneIndex(Bone.PH_R_Hand), New Vector3(0F, 0F, -0.05F), Vector3.Zero)
                    BongTaskScriptStatus = 1
                Case 1
                    If BongProp.IsAttachedTo(PP) Then
                        Script.Wait(10000)
                        BongProp.Detach()
                        BongProp.Position = BongMemory.Position
                        BongProp.Rotation = BongMemory.Rotation
                        LighterProp.Detach()
                        LighterProp.Position = LighterMemory.Position
                        LighterProp.Rotation = LighterMemory.Rotation
                        BongTaskScriptStatus = 2
                    End If
                Case 2
                    StartScreenFx("DrugsDrivingIn", 5000, False, True)
                    StartScreenFx("DrugsDrivingOut", 5000, False, True)
                    BongProp = Nothing
                    LighterProp = Nothing
                    BongTaskScriptStatus = -1
            End Select
        End If
    End Sub
#End Region

    Public Sub PropOnTick()
        ClosestProp = World.GetClosest(Of Prop)(Game.Player.Character.Position, World.GetNearbyProps(Game.Player.Character.Position, 20.0F).Where(Function(x) ClosestPropList.Contains(x.Model)).ToArray)

        'Telly
        TellyTick()

        'Radio
        RadioTick()

        'Bong
        BongTick()
    End Sub

End Module
