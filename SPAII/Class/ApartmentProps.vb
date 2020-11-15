Imports GTA
Imports GTA.Native
Imports NFunc = GTA.Native.Function
Imports INMNativeUI
Imports System.Runtime.CompilerServices

Module ApartmentProps

    Public ClosestTelly As Prop = Nothing

    Public TVModels As New List(Of Model) From {1036195894, 777010715, -1073182005, 1653710254, 170618079, -897601557, -1546399138, -1223496606, -1820646534, 608950395}
    Public TVOn As Boolean = False, IBOn As Boolean = False, SubtitleOn As Boolean = False, TVSound As Single = 0F, TVChannel As Integer = 0, rendertargetid, ex_rendertargetid As Integer, TVCamera As Camera
    Public TVChannelList As New List(Of Integer) From {0, 1}
    Public IBScaleform As New Scaleform("instructional_buttons")

    Public Sub TV_Tick()
        ClosestTelly = World.GetClosest(Of Prop)(Game.Player.Character.Position, World.GetNearbyProps(Game.Player.Character.Position, 3.0F).Where(Function(x) TVModels.Contains(x.Model)).ToArray)

        If Not ClosestTelly = Nothing Then
            If Not TVOn Then
                UI.ShowHelpMessage(Game.GetGXTEntry("MPTV_GRGE"))
                If Game.IsControlJustPressed(0, Control.Context) Then
                    rendertargetid = ClosestTelly.TurnOnTV("tvscreen", TVChannel, TVSound)
                    ex_rendertargetid = ClosestTelly.TurnOnTV("ex_tvscreen", TVChannel, TVSound)
                    TVOn = True
                    Script.Yield()
                End If
            Else
                If Not IBOn Then UI.ShowHelpMessage(Game.GetGXTEntry("TV_HLP5"))
                If Game.IsControlJustPressed(0, Control.Context) Then
                    TurnOffTV("tvscreen")
                    TurnOffTV("ex_tvscreen")
                    TVOn = False
                    IBOn = False
                    Script.Yield()
                ElseIf Game.IsControlJustPressed(0, Control.ScriptRUp) AndAlso IBOn = False Then
                    IBOn = True
                    Script.Yield()
                End If
            End If
            If IBOn Then
                If Game.IsControlJustPressed(0, Control.ScriptLeftAxisX) Then
                    Select Case TVChannel
                        Case 0
                            TVChannel = 1
                        Case 1
                            TVChannel = 0
                    End Select
                    NFunc.Call(Hash.SET_TV_CHANNEL, TVChannel)
                    Script.Yield()
                ElseIf Game.IsControlJustPressed(0, Control.ScriptRUp) AndAlso IBOn = True Then
                    IBOn = False
                    Script.Yield()
                End If
            End If
        End If

        If TVOn Then
            RenderTV(rendertargetid)
            RenderTV(ex_rendertargetid)
        End If
        If IBOn Then DrawTVControlInstructionalButtons()
        If ClosestTelly = Nothing Then IBOn = False
    End Sub

    Private Sub DrawTVControlInstructionalButtons()
        'IBScaleform.CallFunction("CLEAR_ALL")
        'IBScaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", 0)
        'IBScaleform.CallFunction("CREATE_CONTAINER")
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

End Module
