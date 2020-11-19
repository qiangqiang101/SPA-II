Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports GTA
Imports GTA.Math
Imports INMNativeUI
Imports SPAII.INM
Imports SPAII.INM.ClothingSet

Module Wardrobe

    Public Camera As Camera
    Public ScriptStatus As Integer = -1
    Public Memory As WardrobeMemory

    Public WithEvents gmMichael, gmFranklin, gmTrevor, gmFMM, gmFMF As UIMenu
    Public WithEvents mOutfitM, gmSuitM, mFullSuitsM, mSuitJacketsM, mSuitPantsM, mSuitVestsM, gmCasualJacketsM, mCasualJacketM As UIMenu
    Public WithEvents mOutfitF, gmSuitF, mFullSuitsF, mSuitJacketsF, mSuitJacketsButtonedF, mSuitPantsF, mSuitVestsF, mSuitTiesF, gmCasualJacketsF, mCasualJacketF As UIMenu
    Public WithEvents mOutfitT, gmSuitT, mFullSuitsT, mSuitJacketsT, mSuitPantsT As UIMenu
    Public WithEvents mOutfitFMM, mEarringsFMM, mGlassesFMM, mHatsFMM, mChainsFMM As UIMenu
    Public WithEvents mOutfitFMF, mEarringsFMF, mGlassesFMF, mHatsFMF, mChainsFMF As UIMenu
    Public WithEvents mCasualJacketTShirtM, gmGlassesM, mSportShadesM, mStreetShadesM, mHoodiesM, mJacketsM, mPantsM As UIMenu
    Public WithEvents mCasualJacketTShirtF, mEarringsF, gmGlassesF, mSportShadesF, mStreetShadesF, gmHatsF, mCapsForwardF, mCapsBackwardF, mHoodiesF, mJacketsF, mPantsF As UIMenu
    Public WithEvents gmGlassesT, mSportShadesT, mStreetShadesT, mCapsForwardT, mHoodiesT, mJacketsT, mPantsT As UIMenu
    Public WithEvents mShoesM, mShirtsM, mShortsM, mTShirtM, mTankTopsM, mTopsM, mGlassesM, mPoloShirtsM As UIMenu
    Public WithEvents mShoesF, mShirtsF, mShortsF, mSmartShoesF, mTShirtF, mTankTopsF, mTopsF, mVestsF As UIMenu
    Public WithEvents mShoesT, mShirtsT, mShortsT, mSmartShoesT, mTShirtT, mTankTopsT, mTopsT, mPoloShirtsT As UIMenu

    Public iOutfits, giSuits, iFullSuits, iSuitJackets, iSuitJacketsButtoned, iSuitPants, iSuitVests, iSuitTies, giCasualJackets, iOpenShirts, iCasualJackets As UIMenuItem
    Public iCasualJacketShirts, iCasualJacketTShirts, iEarrings, giGlasses, iGlasses, iSportShades, iStreetShades, giHats, iHats, iCapsForward, iCapsBackward As UIMenuItem
    Public iHoodies, iJackets, iPants, iShoes, iShirts, iShorts, iSmartShoes, iTShirt, iTankTops, iTops, iVests, iPoloShirt, iChains As UIMenuItem

    Public Sub LoadWardrobe()
        Try
            RequestAdditionalText("clo_mnu", "CSHOP_TITLE1")

            iOutfits = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM36")) With {.Tag = "Outfit"}
            giSuits = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM49")) With {.Tag = "Suit"}
            iFullSuits = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM125")) With {.Tag = "FullSuit"}
            iSuitJackets = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM46")) With {.Tag = "SuitJacket"}
            iSuitJacketsButtoned = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM126")) With {.Tag = "SuitJacketButtoned"}
            iSuitPants = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM47")) With {.Tag = "SuitPant"}
            iSuitVests = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM50")) With {.Tag = "Vest"}
            iSuitTies = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM81")) With {.Tag = "Tie"}
            giCasualJackets = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM79")) With {.Tag = "CasualJacket"}
            iOpenShirts = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM72")) With {.Tag = "OpenShirt"}

            iCasualJackets = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM79")) With {.Tag = "CasualJacketJacket"}
            iCasualJacketShirts = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM4")) With {.Tag = "CasualJacketShirt"}
            iCasualJacketTShirts = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM80")) With {.Tag = "CasualJacketTShirt"}
            iEarrings = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM74")) With {.Tag = "Earrings"}
            iGlasses = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM42")) With {.Tag = "Glasses"}
            giGlasses = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM42")) With {.Tag = "Glasses"}
            iSportShades = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM70")) With {.Tag = "SportShades"}
            iStreetShades = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM71")) With {.Tag = "StreetShades"}
            giHats = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM40")) With {.Tag = "Hat"}
            iHats = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM40")) With {.Tag = "HatsTrevor"}

            iCapsForward = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM127")) With {.Tag = "CapForward"}
            iCapsBackward = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM128")) With {.Tag = "CapBackward"}
            iHoodies = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM5")) With {.Tag = "Hoodie"}
            iJackets = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM2")) With {.Tag = "Jacket"}
            iPants = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM38")) With {.Tag = "Pants"}
            iShoes = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM39")) With {.Tag = "Shoes"}
            iShirts = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM4")) With {.Tag = "Shirt"}
            iShorts = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM51")) With {.Tag = "Shorts"}
            iSmartShoes = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM51")) With {.Tag = "SmartShoes"}
            iTShirt = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM3")) With {.Tag = "TShirt"}

            iTankTops = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM45")) With {.Tag = "TankTop"}
            iTops = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM37")) With {.Tag = "Tops"}
            iVests = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM51")) With {.Tag = "Vest"}
            iPoloShirt = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM8")) With {.Tag = "PoloShirt"}
            iChains = New UIMenuItem(Game.GetGXTEntry("CSHOP_ITEM51")) With {.Tag = "Chain"}

            CreateMichaelWardrobeMenu()
            mOutfitM = mOutfitM.LoadSetClothings("CSHOP_TITLE36", gmMichael, iOutfits, Michael_Outfits, MichaelBanner)
            mFullSuitsM = mFullSuitsM.LoadSetClothings("CSHOP_TITLE125", gmSuitM, iFullSuits, Michael_FullSuits, MichaelBanner)
            mSuitJacketsM = mSuitJacketsM.LoadSingleClothings("CSHOP_TITLE46", gmSuitM, iSuitJackets, Michael_SuitJackets, MichaelBanner)
            mSuitPantsM = mSuitPantsM.LoadSingleClothings("CSHOP_TITLE47", gmSuitM, iSuitPants, Michael_SuitPants, MichaelBanner)
            mSuitVestsM = mSuitVestsM.LoadSingleClothings("CSHOP_TITLE50", gmSuitM, iSuitVests, Michael_SuitVests, MichaelBanner)
            mGlassesM = mGlassesM.LoadSingleClothings("CSHOP_TITLE42", gmGlassesM, iGlasses, Michael_Glasses, MichaelBanner)
            mSportShadesM = mSportShadesM.LoadSingleClothings("CSHOP_TITLE70", gmGlassesM, iSportShades, Michael_SportShades, MichaelBanner)
            mStreetShadesM = mStreetShadesM.LoadSingleClothings("CSHOP_TITLE71", gmGlassesM, iStreetShades, Michael_StreetShades, MichaelBanner)
            mHoodiesM = mHoodiesM.LoadSingleClothings("CSHOP_TITLE5", gmMichael, iHoodies, Michael_Hoodies, MichaelBanner)
            mJacketsM = mJacketsM.LoadSingleClothings("CSHOP_TITLE2", gmMichael, iJackets, Michael_Jackets, MichaelBanner)
            mPantsM = mPantsM.LoadSingleClothings("CSHOP_TITLE38", gmMichael, iPants, Michael_Pants, MichaelBanner)
            mPoloShirtsM = mPoloShirtsM.LoadSingleClothings("CSHOP_TITLE8", gmMichael, iPoloShirt, Michael_Polos, MichaelBanner)
            mShoesM = mShoesM.LoadSingleClothings("CSHOP_TITLE39", gmMichael, iShoes, Michael_Shoes, MichaelBanner)
            mCasualJacketM = mCasualJacketM.LoadSingleClothings("CSHOP_TITLE79", gmCasualJacketsM, iCasualJackets, Michael_CasualJackets, MichaelBanner)
            mCasualJacketTShirtM = mCasualJacketTShirtM.LoadSingleClothings("CSHOP_TITLE3", gmCasualJacketsM, iCasualJacketTShirts, Michael_CasualTShirts, MichaelBanner)
            mShirtsM = mShirtsM.LoadSingleClothings("CSHOP_TITLE4", gmMichael, iShirts, Michael_Shirts, MichaelBanner)
            mShortsM = mShortsM.LoadSingleClothings("CSHOP_TITLE51", gmMichael, iShorts, Michael_Shorts, MichaelBanner)
            mTShirtM = mTShirtM.LoadSingleClothings("CSHOP_TITLE3", gmMichael, iTShirt, Michael_TShirts, MichaelBanner)
            mTankTopsM = mTankTopsM.LoadSingleClothings("CSHOP_TITLE45", gmMichael, iTankTops, Michael_TankTops, MichaelBanner)
            mTopsM = mTopsM.LoadSingleClothings("CSHOP_TITLE37", gmMichael, iTops, Michael_Tops, MichaelBanner)

            CreateFranklinWardrobeMenu()
            mOutfitF = mOutfitF.LoadSetClothings("CSHOP_TITLE36", gmFranklin, iOutfits, Franklin_Outfits, FranklinBanner)
            mFullSuitsF = mFullSuitsF.LoadSetClothings("CSHOP_TITLE125", gmSuitF, iFullSuits, Franklin_FullSuits, FranklinBanner)
            mSuitJacketsF = mSuitJacketsF.LoadSingleClothings("CSHOP_TITLE46", gmSuitF, iSuitJackets, Franklin_SuitJackets, FranklinBanner)
            mSuitJacketsButtonedF = mSuitJacketsButtonedF.LoadSingleClothings("CSHOP_TITLE126", gmSuitF, iSuitJacketsButtoned, Franklin_SuitJacketsButtoned, FranklinBanner)
            mSuitPantsF = mSuitPantsF.LoadSingleClothings("CSHOP_TITLE47", gmSuitF, iSuitPants, Franklin_SuitPants, FranklinBanner)
            mSuitVestsF = mSuitVestsF.LoadSingleClothings("CSHOP_TITLE50", gmSuitF, iSuitVests, Franklin_SuitVests, FranklinBanner)
            mSuitTiesF = mSuitTiesF.LoadSingleClothings("CSHOP_TITLE81", gmSuitF, iSuitTies, Franklin_Ties, FranklinBanner)
            mCasualJacketF = mCasualJacketF.LoadSingleClothings("CSHOP_TITLE79", gmCasualJacketsF, iCasualJackets, Franklin_CasualJackets, FranklinBanner)
            mCasualJacketTShirtF = mCasualJacketTShirtF.LoadSingleClothings("CSHOP_TITLE3", gmCasualJacketsF, iCasualJacketTShirts, Franklin_CasualTShirts, FranklinBanner)
            mEarringsF = mEarringsF.LoadSingleClothings("CSHOP_TITLE74", gmFranklin, iEarrings, Franklin_Earrings, FranklinBanner)
            mSportShadesF = mSportShadesF.LoadSingleClothings("CSHOP_TITLE70", gmGlassesF, iSportShades, Franklin_SportShades, FranklinBanner)
            mStreetShadesF = mStreetShadesF.LoadSingleClothings("CSHOP_TITLE71", gmGlassesF, iStreetShades, Franklin_StreetShades, FranklinBanner)
            mCapsForwardF = mCapsForwardF.LoadSingleClothings("CSHOP_TITLE131", gmHatsF, iCapsForward, Franklin_CapsForward, FranklinBanner)
            mCapsBackwardF = mCapsBackwardF.LoadSingleClothings("CSHOP_TITLE132", gmHatsF, iCapsBackward, Franklin_CapsBackward, FranklinBanner)
            mHoodiesF = mHoodiesF.LoadSingleClothings("CSHOP_TITLE5", gmFranklin, iHoodies, Franklin_Hoodies, FranklinBanner)
            mJacketsF = mJacketsF.LoadSingleClothings("CSHOP_TITLE2", gmFranklin, iJackets, Franklin_Jackets, FranklinBanner)
            mPantsF = mPantsF.LoadSingleClothings("CSHOP_TITLE38", gmFranklin, iPants, Franklin_Pants, FranklinBanner)
            mShoesF = mShoesF.LoadSingleClothings("CSHOP_TITLE39", gmFranklin, iShoes, Franklin_Shoes, FranklinBanner)
            mShirtsF = mShirtsF.LoadSingleClothings("CSHOP_TITLE4", gmFranklin, iShirts, Franklin_Shirts, FranklinBanner)
            mShortsF = mShortsF.LoadSingleClothings("CSHOP_TITLE51", gmFranklin, iShorts, Franklin_Shorts, FranklinBanner)
            mSmartShoesF = mSmartShoesF.LoadSingleClothings("CSHOP_TITLE32", gmFranklin, iSmartShoes, Franklin_SmartShoes, FranklinBanner)
            mTShirtF = mTShirtF.LoadSingleClothings("CSHOP_TITLE3", gmFranklin, iTShirt, Franklin_TShirts, FranklinBanner)
            mTankTopsF = mTankTopsF.LoadSingleClothings("CSHOP_TITLE45", gmFranklin, iTankTops, Franklin_TankTops, FranklinBanner)
            mTopsF = mTopsF.LoadSingleClothings("CSHOP_TITLE37", gmFranklin, iTops, Franklin_Tops, FranklinBanner)
            mVestsF = mVestsF.LoadSingleClothings("CSHOP_TITLE57", gmFranklin, iVests, Franklin_Vests, FranklinBanner)

            CreateTrevorWardrobeMenu()
            mOutfitT = mOutfitT.LoadSetClothings("CSHOP_TITLE36", gmTrevor, iOutfits, Trevor_Outfits, TrevorBanner)
            mFullSuitsT = mFullSuitsT.LoadSetClothings("CSHOP_TITLE125", gmSuitT, iFullSuits, Trevor_FullSuits, TrevorBanner)
            mSuitJacketsT = mSuitJacketsT.LoadSingleClothings("CSHOP_TITLE46", gmSuitT, iSuitJackets, Trevor_SuitJackets, TrevorBanner)
            mSuitPantsT = mSuitPantsT.LoadSingleClothings("CSHOP_TITLE47", gmSuitT, iSuitPants, Trevor_SuitPants, TrevorBanner)
            mSportShadesT = mSportShadesT.LoadSingleClothings("CSHOP_TITLE70", gmGlassesT, iSportShades, Trevor_SportShades, TrevorBanner)
            mStreetShadesT = mStreetShadesT.LoadSingleClothings("CSHOP_TITLE71", gmGlassesT, iStreetShades, Trevor_StreetShades, TrevorBanner)
            mCapsForwardT = mCapsForwardT.LoadSingleClothings("CSHOP_TITLE131", gmTrevor, iCapsForward, Trevor_CapsForward, TrevorBanner)
            mHoodiesT = mHoodiesT.LoadSingleClothings("CSHOP_TITLE5", gmTrevor, iHoodies, Trevor_Hoodies, TrevorBanner)
            mJacketsT = mJacketsT.LoadSingleClothings("CSHOP_TITLE2", gmTrevor, iJackets, Trevor_Jackets, TrevorBanner)
            mPantsT = mPantsT.LoadSingleClothings("CSHOP_TITLE38", gmTrevor, iPants, Trevor_Pants, TrevorBanner)
            mPoloShirtsT = mPoloShirtsT.LoadSingleClothings("CSHOP_TITLE8", gmTrevor, iPoloShirt, Trevor_Polos, TrevorBanner)
            mShoesT = mShoesT.LoadSingleClothings("CSHOP_TITLE39", gmTrevor, iShoes, Trevor_Shoes, TrevorBanner)
            mShirtsT = mShirtsT.LoadSingleClothings("CSHOP_TITLE4", gmTrevor, iShirts, Trevor_Shirts, TrevorBanner)
            mShortsT = mShortsT.LoadSingleClothings("CSHOP_TITLE51", gmTrevor, iShorts, Trevor_Shorts, TrevorBanner)
            mSmartShoesT = mSmartShoesT.LoadSingleClothings("CSHOP_TITLE32", gmTrevor, iSmartShoes, Trevor_SmartShoes, TrevorBanner)
            mTShirtT = mTShirtT.LoadSingleClothings("CSHOP_TITLE3", gmTrevor, iTShirt, Trevor_TShirts, TrevorBanner)
            mTankTopsT = mTankTopsT.LoadSingleClothings("CSHOP_TITLE45", gmTrevor, iTankTops, Trevor_TankTops, TrevorBanner)
            mTopsT = mTopsT.LoadSingleClothings("CSHOP_TITLE37", gmTrevor, iTops, Trevor_Tops, TrevorBanner)

            gmFMM = gmFMM.CreateFreemodeWardrobeMenu
            mOutfitFMM = mOutfitFMM.LoadSetClothings("CSHOP_TITLE36", gmFMM, iOutfits, FreemodeMale_Outfits)
            mGlassesFMM = mGlassesFMM.LoadSingleClothings("CSHOP_TITLE42", gmFMM, iGlasses, FreemodeMale_Glasses)
            mEarringsFMM = mEarringsFMM.LoadSingleClothings("CSHOP_TITLE74", gmFMM, iEarrings, FreemodeMale_Earrings)
            mHatsFMM = mHatsFMM.LoadSingleClothings("CSHOP_TITLE40", gmFMM, iHats, FreemodeMale_Hats)
            mChainsFMM = mChainsFMM.LoadSingleClothings("CSHOP_TITLE115", gmFMM, iChains, FreemodeMale_Chains)

            gmFMF = gmFMF.CreateFreemodeWardrobeMenu
            mOutfitFMF = mOutfitFMF.LoadSetClothings("CSHOP_TITLE36", gmFMF, iOutfits, FreemodeFemale_Outfits)
            mGlassesFMF = mGlassesFMF.LoadSingleClothings("CSHOP_TITLE42", gmFMF, iGlasses, FreemodeFemale_Glasses)
            mEarringsFMF = mEarringsFMF.LoadSingleClothings("CSHOP_TITLE74", gmFMF, iEarrings, FreemodeFemale_Earrings)
            mHatsFMF = mHatsFMF.LoadSingleClothings("CSHOP_TITLE40", gmFMF, iHats, FreemodeFemale_Hats)
            mChainsFMF = mChainsFMF.LoadSingleClothings("CSHOP_TITLE115", gmFMF, iChains, FreemodeFemale_Chains)
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub MakeCamera(ped As Ped, position As Vector3, heading As Single)
        Try
            Memory = New WardrobeMemory(ped)
            RefreshWardrobeMenus()
            ped.Position = position
            ped.Heading = heading
            Camera = World.CreateCamera(ped.Position + ped.ForwardVector * 5, GameplayCamera.Rotation, 30.0F)
            Camera.PointAt(ped)
            World.RenderingCamera = Camera
            ped.Task.StartScenario("PROP_HUMAN_STAND_IMPATIENT")
            HideHud = True
            Select Case GetPlayer()
                Case eOwner.Michael
                    gmMichael.Visible = True
                Case eOwner.Franklin
                    gmFranklin.Visible = True
                Case eOwner.Trevor
                    gmTrevor.Visible = True
                Case eOwner.Others
                    Select Case ped.Gender
                        Case Gender.Male
                            gmFMM.Visible = True
                        Case Gender.Female
                            gmFMF.Visible = True
                    End Select
            End Select
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub RefreshWardrobeMenus()
        Try
            Select Case GetPlayer()
                Case eOwner.Michael
                    mSuitJacketsM.RefreshSingle
                    mSuitPantsM.RefreshSingle
                    mSuitVestsM.RefreshSingle
                    mGlassesM.RefreshSingle
                    mSportShadesM.RefreshSingle
                    mStreetShadesM.RefreshSingle
                    mHoodiesM.RefreshSingle
                    mJacketsM.RefreshSingle
                    mPantsM.RefreshSingle
                    mPoloShirtsM.RefreshSingle
                    mShoesM.RefreshSingle
                    mCasualJacketM.RefreshSingle
                    mCasualJacketTShirtM.RefreshSingle
                    mShirtsM.RefreshSingle
                    mShortsM.RefreshSingle
                    mTShirtM.RefreshSingle
                    mTankTopsM.RefreshSingle
                    mTopsM.RefreshSingle
                Case eOwner.Franklin
                    mSuitJacketsF.RefreshSingle
                    mSuitJacketsButtonedF.RefreshSingle
                    mSuitPantsF.RefreshSingle
                    mSuitVestsF.RefreshSingle
                    mSuitTiesF.RefreshSingle
                    mCasualJacketF.RefreshSingle
                    mCasualJacketTShirtF.RefreshSingle
                    mEarringsF.RefreshSingle
                    mSportShadesF.RefreshSingle
                    mStreetShadesF.RefreshSingle
                    mCapsForwardF.RefreshSingle
                    mCapsBackwardF.RefreshSingle
                    mHoodiesF.RefreshSingle
                    mJacketsF.RefreshSingle
                    mPantsF.RefreshSingle
                    mShoesF.RefreshSingle
                    mShirtsF.RefreshSingle
                    mShortsF.RefreshSingle
                    mSmartShoesF.RefreshSingle
                    mTShirtF.RefreshSingle
                    mTankTopsF.RefreshSingle
                    mTopsF.RefreshSingle
                    mVestsF.RefreshSingle
                Case eOwner.Trevor
                    mSuitJacketsT.RefreshSingle
                    mSuitPantsT.RefreshSingle
                    mSportShadesT.RefreshSingle
                    mStreetShadesT.RefreshSingle
                    mCapsForwardT.RefreshSingle
                    mHoodiesT.RefreshSingle
                    mJacketsT.RefreshSingle
                    mPantsT.RefreshSingle
                    mPoloShirtsT.RefreshSingle
                    mShoesT.RefreshSingle
                    mShirtsT.RefreshSingle
                    mShortsT.RefreshSingle
                    mSmartShoesT.RefreshSingle
                    mTShirtT.RefreshSingle
                    mTankTopsT.RefreshSingle
                    mTopsT.RefreshSingle
                Case eOwner.Others
                    Select Case PP.Gender
                        Case Gender.Male
                            mGlassesFMM.RefreshSingle
                            mEarringsFMM.RefreshSingle
                            mHatsFMM.RefreshSingle
                            mChainsFMM.RefreshSingle
                        Case Gender.Female
                            mGlassesFMF.RefreshSingle
                            mEarringsFMF.RefreshSingle
                            mHatsFMF.RefreshSingle
                            mChainsFMF.RefreshSingle
                    End Select
            End Select
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub CreateMichaelWardrobeMenu()
        Try
            RequestAdditionalText("clo_mnu", "CSHOP_TITLE1")

            gmMichael = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE1"))
            With gmMichael
                .SetBannerType(MichaelBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmMichael)
                .AddItem(iOutfits)
                .AddItem(giSuits)
                .AddItem(giGlasses)
                .AddItem(iHoodies)
                .AddItem(giCasualJackets)
                .AddItem(iPants)
                .AddItem(iPoloShirt)
                .AddItem(iShoes)
                .AddItem(iOpenShirts)
                .AddItem(iShirts)
                .AddItem(iShorts)
                .AddItem(iTShirt)
                .AddItem(iTankTops)
                .AddItem(iTops)
                .RefreshIndex()
            End With

            gmSuitM = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE49"))
            With gmSuitM
                .SetBannerType(MichaelBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmSuitM)
                .AddItem(iFullSuits)
                .AddItem(iSuitJackets)
                .AddItem(iSuitPants)
                .AddItem(iSuitVests)
                .RefreshIndex()
                gmMichael.BindMenuToItem(gmSuitM, giSuits)
            End With

            gmGlassesM = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE42"))
            With gmGlassesM
                .SetBannerType(MichaelBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmGlassesM)
                .AddItem(iGlasses)
                .AddItem(iSportShades)
                .AddItem(iStreetShades)
                .RefreshIndex()
                gmMichael.BindMenuToItem(gmGlassesM, giGlasses)
            End With

            gmCasualJacketsM = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE79"))
            With gmCasualJacketsM
                .SetBannerType(MichaelBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmCasualJacketsM)
                .AddItem(iCasualJackets)
                .AddItem(iCasualJacketTShirts)
                .RefreshIndex()
                gmMichael.BindMenuToItem(gmCasualJacketsM, giCasualJackets)
            End With
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub CreateFranklinWardrobeMenu()
        Try
            RequestAdditionalText("clo_mnu", "CSHOP_TITLE1")

            gmFranklin = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE1"))
            With gmFranklin
                .SetBannerType(FranklinBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmFranklin)
                .AddItem(iOutfits)
                .AddItem(giSuits)
                .AddItem(giCasualJackets)
                .AddItem(iEarrings)
                .AddItem(giGlasses)
                .AddItem(giHats)
                .AddItem(iHoodies)
                .AddItem(iJackets)
                .AddItem(iPants)
                .AddItem(iShoes)
                .AddItem(iShirts)
                .AddItem(iShorts)
                .AddItem(iTShirt)
                .AddItem(iTankTops)
                .AddItem(iTops)
                .AddItem(iVests)
                .RefreshIndex()
            End With

            gmSuitF = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE49"))
            With gmSuitF
                .SetBannerType(FranklinBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmSuitF)
                .AddItem(iFullSuits)
                .AddItem(iSuitJackets)
                .AddItem(iSuitJacketsButtoned)
                .AddItem(iSuitPants)
                .AddItem(iSuitVests)
                .AddItem(iSuitTies)
                .RefreshIndex()
                gmFranklin.BindMenuToItem(gmSuitF, giSuits)
            End With

            gmCasualJacketsF = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE79"))
            With gmCasualJacketsF
                .SetBannerType(FranklinBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmCasualJacketsF)
                .AddItem(iCasualJackets)
                .AddItem(iCasualJacketTShirts)
                .RefreshIndex()
                gmFranklin.BindMenuToItem(gmCasualJacketsF, giCasualJackets)
            End With

            gmGlassesF = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE42"))
            With gmGlassesF
                .SetBannerType(FranklinBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmGlassesF)
                .AddItem(iSportShades)
                .AddItem(iStreetShades)
                .RefreshIndex()
                gmFranklin.BindMenuToItem(gmGlassesF, giGlasses)
            End With

            gmHatsF = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE40"))
            With gmHatsF
                .SetBannerType(FranklinBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmHatsF)
                .AddItem(iCapsForward)
                .AddItem(iCapsBackward)
                .RefreshIndex()
                gmFranklin.BindMenuToItem(gmHatsF, giHats)
            End With
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    Public Sub CreateTrevorWardrobeMenu()
        Try
            RequestAdditionalText("clo_mnu", "CSHOP_TITLE1")

            gmTrevor = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE1"))
            With gmTrevor
                .SetBannerType(TrevorBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmTrevor)
                .AddItem(iOutfits)
                .AddItem(giSuits)
                .AddItem(giGlasses)
                .AddItem(iHats)
                .AddItem(iHoodies)
                .AddItem(giCasualJackets)
                .AddItem(iPants)
                .AddItem(iPoloShirt)
                .AddItem(iShoes)
                .AddItem(iShirts)
                .AddItem(iShorts)
                .AddItem(iSmartShoes)
                .AddItem(iTShirt)
                .AddItem(iTankTops)
                .AddItem(iTops)
                .RefreshIndex()
            End With

            gmSuitT = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE49"))
            With gmSuitT
                .SetBannerType(TrevorBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmSuitT)
                .AddItem(iFullSuits)
                .AddItem(iSuitJackets)
                .AddItem(iSuitPants)
                .RefreshIndex()
                gmTrevor.BindMenuToItem(gmSuitT, giSuits)
            End With

            gmGlassesT = New UIMenu("", Game.GetGXTEntry("CSHOP_TITLE42"))
            With gmGlassesT
                .SetBannerType(TrevorBanner)
                .MouseEdgeEnabled = False
                MenuPool.Add(gmGlassesT)
                .AddItem(iSportShades)
                .AddItem(iStreetShades)
                .RefreshIndex()
                gmTrevor.BindMenuToItem(gmGlassesT, giGlasses)
            End With
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try
    End Sub

    <Extension>
    Public Function CreateFreemodeWardrobeMenu(menu As UIMenu) As UIMenu
        Try
            RequestAdditionalText("clo_mnu", "CSHOP_TITLE1")

            menu = New UIMenu(Game.Player.Name, Game.GetGXTEntry("CSHOP_TITLE1"))
            With menu
                .MouseEdgeEnabled = False
                MenuPool.Add(menu)
                .AddItem(iOutfits)
                .AddItem(iGlasses)
                .AddItem(iEarrings)
                .AddItem(giHats)
                .AddItem(iChains)
                .RefreshIndex()
            End With
        Catch ex As Exception
            Logger.Log($"{ex.Message} {ex.StackTrace}")
        End Try

        Return menu
    End Function

    <Extension>
    Public Function LoadSetClothings(menu As UIMenu, titleGXT As String, bindMenu As UIMenu, bindItem As UIMenuItem, list As List(Of ClothingSet), Optional banner As Object = Nothing) As UIMenu
        Try
            menu = New UIMenu(If(banner Is Nothing, Game.Player.Name, ""), Game.GetGXTEntry(titleGXT))
            With menu
                If Not banner Is Nothing Then .SetBannerType(banner)
                .MouseEdgeEnabled = False
                MenuPool.Add(menu)
                For Each outfit In list
                    menu.AddItem(New UIMenuItem(outfit.GetLocalizedName) With {.Tag = outfit})
                Next
                menu.RefreshIndex()
                bindMenu.BindMenuToItem(menu, bindItem)
            End With
        Catch ex As Exception
            Logger.Log($"{ex.Message} {list.First.LocalizedName}{vbNewLine}{ex.StackTrace}")
        End Try
        Return menu
    End Function

    <Extension>
    Public Function LoadSingleClothings(menu As UIMenu, titleGXT As String, bindMenu As UIMenu, bindItem As UIMenuItem, list As List(Of Clothing), Optional banner As Object = Nothing) As UIMenu
        Try
            menu = New UIMenu(If(banner Is Nothing, Game.Player.Name, ""), Game.GetGXTEntry(titleGXT))
            With menu
                If Not banner Is Nothing Then .SetBannerType(banner)
                .MouseEdgeEnabled = False
                MenuPool.Add(menu)
                For Each cloth In list
                    menu.AddItem(New UIMenuItem(cloth.GetLocalizedName) With {.Tag = cloth})
                Next
                menu.RefreshIndex()
                bindMenu.BindMenuToItem(menu, bindItem)
            End With
        Catch ex As Exception
            Logger.Log($"{ex.Message} {list.First.LocalizedName}{vbNewLine}{ex.StackTrace}")
        End Try
        Return menu
    End Function

    <Extension>
    Public Sub RefreshSingle(menu As UIMenu)
        Try
            For Each item As UIMenuItem In menu.MenuItems
                Dim ci As Clothing = item.Tag
                Select Case ci.Type
                    Case eClothingType.CapBackward, eClothingType.CapForward, eClothingType.Earrings, eClothingType.Glasses, eClothingType.Hat, eClothingType.SportShades, eClothingType.StreetShades
                        Select Case ci.ComponentID
                            Case 0
                                If Memory.Helmet Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 1
                                If Memory.Glasses Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 2
                                If Memory.Earrings Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                        End Select
                    Case eClothingType.CasualJacket, eClothingType.CasualTShirt, eClothingType.Chain, eClothingType.Hoodie, eClothingType.Jacket, eClothingType.Pants, eClothingType.Polo,
                         eClothingType.Shirt, eClothingType.Shoes, eClothingType.Shorts, eClothingType.SuitJacket, eClothingType.SuitJacketButtoned, eClothingType.SuitPants, eClothingType.SuitTie,
                         eClothingType.SuitVest, eClothingType.TankTop, eClothingType.Top, eClothingType.TShirt, eClothingType.Vest
                        Select Case ci.ComponentID
                            Case 0
                                If Memory.Face Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 1
                                If Memory.Beard Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 2
                                If Memory.Hair Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 3
                                If Memory.Torso Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 4
                                If Memory.Legs Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 5
                                If Memory.Hands Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 6
                                If Memory.Feet Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 7
                                If Memory.Eyes Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 8
                                If Memory.Accessories Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 9
                                If Memory.Props Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 10
                                If Memory.Textures Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                            Case 11
                                If Memory.AuxiliaryTorso Is ci.CS1 Then item.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
                        End Select
                End Select
            Next
        Catch ex As Exception
            Logger.Log($"{ex.Message} {menu.Subtitle.Caption}{vbNewLine}{ex.StackTrace}")
        End Try
    End Sub

    Private Sub SingleClothing_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles mCapsBackwardF.OnItemSelect, mCapsForwardF.OnItemSelect, mCapsForwardT.OnItemSelect,
        mCasualJacketF.OnItemSelect, mCasualJacketM.OnItemSelect, mCasualJacketTShirtF.OnItemSelect, mCasualJacketTShirtM.OnItemSelect, mChainsFMF.OnItemSelect, mChainsFMM.OnItemSelect,
        mEarringsF.OnItemSelect, mEarringsFMF.OnItemSelect, mEarringsFMM.OnItemSelect, mGlassesFMF.OnItemSelect, mGlassesFMM.OnItemSelect, mGlassesM.OnItemSelect, mHatsFMF.OnItemSelect,
        mHatsFMM.OnItemSelect, mHoodiesF.OnItemSelect, mHoodiesM.OnItemSelect, mHoodiesT.OnItemSelect, mJacketsF.OnItemSelect, mJacketsM.OnItemSelect, mJacketsT.OnItemSelect, mPantsF.OnItemSelect,
        mPantsM.OnItemSelect, mPantsT.OnItemSelect, mPoloShirtsM.OnItemSelect, mPoloShirtsT.OnItemSelect, mShirtsF.OnItemSelect, mShirtsM.OnItemSelect, mShirtsT.OnItemSelect, mShoesF.OnItemSelect,
        mShoesM.OnItemSelect, mShoesT.OnItemSelect, mShortsF.OnItemSelect, mShortsM.OnItemSelect, mShortsT.OnItemSelect, mSmartShoesF.OnItemSelect, mSmartShoesT.OnItemSelect, mSportShadesF.OnItemSelect,
        mSportShadesM.OnItemSelect, mSportShadesT.OnItemSelect, mStreetShadesF.OnItemSelect, mStreetShadesM.OnItemSelect, mStreetShadesT.OnItemSelect, mSuitJacketsButtonedF.OnItemSelect,
        mSuitJacketsF.OnItemSelect, mSuitJacketsM.OnItemSelect, mSuitJacketsT.OnItemSelect, mSuitPantsF.OnItemSelect, mSuitPantsM.OnItemSelect, mSuitPantsT.OnItemSelect, mSuitTiesF.OnItemSelect,
        mSuitVestsF.OnItemSelect, mSuitVestsM.OnItemSelect, mTankTopsF.OnItemSelect, mTankTopsM.OnItemSelect, mTankTopsT.OnItemSelect, mTopsF.OnItemSelect, mTopsM.OnItemSelect, mTopsT.OnItemSelect,
        mTShirtF.OnItemSelect, mTShirtM.OnItemSelect, mTShirtT.OnItemSelect, mVestsF.OnItemSelect
        Dim sc As Clothing = selectedItem.Tag

        Select Case sc.Type
            Case eClothingType.CapBackward, eClothingType.CapForward, eClothingType.Earrings, eClothingType.Glasses, eClothingType.Hat, eClothingType.SportShades, eClothingType.StreetShades
                PP.SetProps(sc.CS1)
                Memory.SetProps(sc.CS1)
            Case eClothingType.CasualJacket
                PP.SetClothes(sc.CS1)
                PP.SetClothes(sc.CS2)
                Memory.SetClothes(sc.CS1)
                Memory.SetClothes(sc.CS2)
            Case eClothingType.CasualTShirt, eClothingType.Chain, eClothingType.Pants, eClothingType.Shoes, eClothingType.SuitPants
                PP.SetClothes(sc.CS1)
                Memory.SetClothes(sc.CS1)
            Case eClothingType.Hoodie, eClothingType.Jacket, eClothingType.Polo, eClothingType.Shirt, eClothingType.TankTop, eClothingType.Top, eClothingType.TShirt
                PP.SetClothes(sc.CS1)
                Memory.SetClothes(sc.CS1)
                If GetPlayer() = eOwner.Franklin Then
                    PP.SetClothes(8, 14, 0)
                    Memory.SetClothes(New CS(8, 14, 0))
                Else
                    PP.SetClothes(8, 0, 0) 'Acc
                    Memory.SetClothes(New CS(8, 0, 0))
                End If
                PP.SetClothes(11, 0, 0) 'Vest
                PP.SetClothes(10, 0, 0) 'Logo
                Memory.SetClothes(New CS(11, 0, 0))
                Memory.SetClothes(New CS(10, 0, 0))
            Case eClothingType.Shorts
                If GetPlayer() = eOwner.Franklin Then
                    PP.SetProps(sc.CS1)
                    Memory.SetClothes(sc.CS1)
                Else
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(sc.CS2)
                    Memory.SetClothes(sc.CS1)
                    Memory.SetClothes(sc.CS2)
                End If
            Case eClothingType.SuitJacket, eClothingType.SuitJacketButtoned
                If GetPlayer() = eOwner.Franklin Then
                    Dim d8 = Memory.Accessories.DrawableID
                    Dim d11 = Memory.AuxiliaryTorso.DrawableID
                    If Not d8 = 14 Or Not d8 = 15 Then
                        PP.SetClothes(sc.CS1)
                        PP.SetClothes(8, 14, 0) 'Tie
                        PP.SetClothes(11, 3, 0) 'Vest
                        Memory.SetClothes(sc.CS1)
                        Memory.SetClothes(New CS(8, 14, 0))
                        Memory.SetClothes(New CS(11, 3, 0))
                    Else
                        PP.SetClothes(sc.CS1)
                        Memory.SetClothes(sc.CS1)
                    End If
                Else
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(sc.CS2)
                    Memory.SetClothes(sc.CS1)
                    Memory.SetClothes(sc.CS2)
                End If
            Case eClothingType.SuitTie
                Dim d8_withoutVest = sc.CS1
                Dim d8_withVest = sc.CS2
                Dim d3 = Memory.Torso.DrawableID
                Dim d11 = Memory.AuxiliaryTorso.DrawableID
                If Not d3 = 18 Or Not d3 = 23 Then
                ElseIf d11 = 5 Then 'No Vest
                    PP.SetClothes(d8_withoutVest)
                    Memory.SetClothes(d8_withoutVest)
                ElseIf d11 = 3 Then 'Got Vest
                    PP.SetClothes(d8_withVest)
                    Memory.SetClothes(d8_withVest)
                Else
                End If
            Case eClothingType.SuitVest
                If GetPlayer() = eOwner.Franklin Then
                    Dim d3 = Memory.Torso.DrawableID
                    If Not d3 = 18 Or Not d3 = 23 Then
                        PP.SetClothes(sc.CS1)
                        PP.SetClothes(3, 18, 0)
                        Memory.SetClothes(sc.CS1)
                        Memory.SetClothes(New CS(3, 18, 0))
                    Else
                        PP.SetClothes(sc.CS1)
                        Memory.SetClothes(sc.CS1)
                    End If
                Else
                    PP.SetClothes(sc.CS1)
                    Memory.SetClothes(sc.CS1)
                End If
            Case eClothingType.Vest
                Dim d11_withoutTie = sc.CS2
                Dim d11_withTie = sc.CS3
                Dim d8 = Memory.Accessories.DrawableID
                If Not d8 = 15 Then 'Got Tie
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(d11_withTie)
                    Memory.SetClothes(sc.CS1)
                    Memory.SetClothes(d11_withTie)
                Else 'No Tie
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(d11_withoutTie)
                    Memory.SetClothes(sc.CS1)
                    Memory.SetClothes(d11_withoutTie)
                End If
        End Select

        For Each item As UIMenuItem In sender.MenuItems
            item.SetRightBadge(UIMenuItem.BadgeStyle.None)
        Next

        selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Tick)
    End Sub

    Private Sub SingleClothing_OnIndexChange(sender As UIMenu, index As Integer) Handles mCapsBackwardF.OnIndexChange, mCapsForwardF.OnIndexChange, mCapsForwardT.OnIndexChange,
        mCasualJacketF.OnIndexChange, mCasualJacketM.OnIndexChange, mCasualJacketTShirtF.OnIndexChange, mCasualJacketTShirtM.OnIndexChange, mChainsFMF.OnIndexChange, mChainsFMM.OnIndexChange,
        mEarringsF.OnIndexChange, mEarringsFMF.OnIndexChange, mEarringsFMM.OnIndexChange, mGlassesFMF.OnIndexChange, mGlassesFMM.OnIndexChange, mGlassesM.OnIndexChange, mHatsFMF.OnIndexChange,
        mHatsFMM.OnIndexChange, mHoodiesF.OnIndexChange, mHoodiesM.OnIndexChange, mHoodiesT.OnIndexChange, mJacketsF.OnIndexChange, mJacketsM.OnIndexChange, mJacketsT.OnIndexChange,
        mPantsF.OnIndexChange, mPantsM.OnIndexChange, mPantsT.OnIndexChange, mPoloShirtsM.OnIndexChange, mPoloShirtsT.OnIndexChange, mShirtsF.OnIndexChange, mShirtsM.OnIndexChange,
        mShirtsT.OnIndexChange, mShoesF.OnIndexChange, mShoesM.OnIndexChange, mShoesT.OnIndexChange, mShortsF.OnIndexChange, mShortsM.OnIndexChange, mShortsT.OnIndexChange,
        mSmartShoesF.OnIndexChange, mSmartShoesT.OnIndexChange, mSportShadesF.OnIndexChange, mSportShadesM.OnIndexChange, mSportShadesT.OnIndexChange, mStreetShadesF.OnIndexChange,
        mStreetShadesM.OnIndexChange, mStreetShadesT.OnIndexChange, mSuitJacketsButtonedF.OnIndexChange, mSuitJacketsF.OnIndexChange, mSuitJacketsM.OnIndexChange, mSuitJacketsT.OnIndexChange,
        mSuitPantsF.OnIndexChange, mSuitPantsM.OnIndexChange, mSuitPantsT.OnIndexChange, mSuitTiesF.OnIndexChange, mSuitVestsF.OnIndexChange, mSuitVestsM.OnIndexChange, mTankTopsF.OnIndexChange,
        mTankTopsM.OnIndexChange, mTankTopsT.OnIndexChange, mTopsF.OnIndexChange, mTopsM.OnIndexChange, mTopsT.OnIndexChange, mTShirtF.OnIndexChange, mTShirtM.OnIndexChange, mTShirtT.OnIndexChange,
        mVestsF.OnIndexChange
        Dim sc As Clothing = sender.MenuItems(index).Tag

        Select Case sc.Type
            Case eClothingType.CapBackward, eClothingType.CapForward, eClothingType.Earrings, eClothingType.Glasses, eClothingType.Hat, eClothingType.SportShades, eClothingType.StreetShades
                PP.SetProps(sc.CS1)
            Case eClothingType.CasualJacket
                PP.SetClothes(sc.CS1)
                PP.SetClothes(sc.CS2)
            Case eClothingType.CasualTShirt, eClothingType.Chain, eClothingType.Pants, eClothingType.Shoes, eClothingType.SuitPants
                PP.SetClothes(sc.CS1)
            Case eClothingType.Hoodie, eClothingType.Jacket, eClothingType.Polo, eClothingType.Shirt, eClothingType.TankTop, eClothingType.Top, eClothingType.TShirt
                PP.SetClothes(sc.CS1)
                If GetPlayer() = eOwner.Franklin Then PP.SetClothes(8, 14, 0) Else PP.SetClothes(8, 0, 0) 'Acc
                PP.SetClothes(11, 0, 0) 'Vest
                PP.SetClothes(10, 0, 0) 'Logo
            Case eClothingType.Shorts
                If GetPlayer() = eOwner.Franklin Then
                    PP.SetProps(sc.CS1)
                Else
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(sc.CS2)
                End If
            Case eClothingType.SuitJacket, eClothingType.SuitJacketButtoned
                If GetPlayer() = eOwner.Franklin Then
                    Dim d8 = Memory.Accessories.DrawableID
                    Dim d11 = Memory.AuxiliaryTorso.DrawableID
                    If Not d8 = 14 Or Not d8 = 15 Then
                        PP.SetClothes(sc.CS1)
                        PP.SetClothes(8, 14, 0) 'Tie
                        PP.SetClothes(11, 3, 0) 'Vest
                    Else
                        PP.SetClothes(sc.CS1)
                    End If
                Else
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(sc.CS2)
                End If
            Case eClothingType.SuitTie
                Dim d8_withoutVest = sc.CS1
                Dim d8_withVest = sc.CS2
                Dim d3 = Memory.Torso.DrawableID
                Dim d11 = Memory.AuxiliaryTorso.DrawableID
                If Not d3 = 18 Or Not d3 = 23 Then
                ElseIf d11 = 5 Then 'No Vest
                    PP.SetClothes(d8_withoutVest)
                ElseIf d11 = 3 Then 'Got Vest
                    PP.SetClothes(d8_withVest)
                Else
                End If
            Case eClothingType.SuitVest
                If GetPlayer() = eOwner.Franklin Then
                    Dim d3 = Memory.Torso.DrawableID
                    If Not d3 = 18 Or Not d3 = 23 Then
                        PP.SetClothes(sc.CS1)
                        PP.SetClothes(3, 18, 0)
                    Else
                        PP.SetClothes(sc.CS1)
                    End If
                Else
                    PP.SetClothes(sc.CS1)
                End If
            Case eClothingType.Vest
                Dim d11_withoutTie = sc.CS2
                Dim d11_withTie = sc.CS3
                Dim d8 = Memory.Accessories.DrawableID
                If Not d8 = 15 Then 'Got Tie
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(d11_withTie)
                Else 'No Tie
                    PP.SetClothes(sc.CS1)
                    PP.SetClothes(d11_withoutTie)
                End If
        End Select
    End Sub

    Private Sub SetClothing_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles mFullSuitsF.OnItemSelect, mFullSuitsM.OnItemSelect, mFullSuitsT.OnItemSelect,
        mOutfitF.OnItemSelect, mOutfitM.OnItemSelect, mOutfitT.OnItemSelect
        Dim sc As ClothingSet = sender.MenuItems(index).Tag

        Select Case sc.Type
            Case eClothingType.FullSuit
                PP.SetClothes(sc.Set1)
                PP.SetClothes(sc.Set2)
                PP.SetClothes(sc.Set3)
                PP.SetClothes(sc.Set4)
                PP.SetClothes(sc.Set5)
                PP.SetClothes(sc.Set6)
                PP.SetClothes(sc.Set7)
                Memory.SetClothes(sc.Set1)
                Memory.SetClothes(sc.Set2)
                Memory.SetClothes(sc.Set3)
                Memory.SetClothes(sc.Set4)
                Memory.SetClothes(sc.Set5)
                Memory.SetClothes(sc.Set6)
                Memory.SetClothes(sc.Set7)
            Case eClothingType.Outfit
                PP.SetClothes(sc.Set1)
                PP.SetClothes(sc.Set2)
                PP.SetClothes(sc.Set3)
                PP.SetClothes(sc.Set4)
                PP.SetClothes(sc.Set5)
                PP.SetClothes(sc.Set6)
                PP.SetClothes(sc.Set7)
                PP.SetProps(sc.Set8)
                PP.SetProps(sc.Set9)
                PP.SetProps(sc.Set10)
                Memory.SetClothes(sc.Set1)
                Memory.SetClothes(sc.Set2)
                Memory.SetClothes(sc.Set3)
                Memory.SetClothes(sc.Set4)
                Memory.SetClothes(sc.Set5)
                Memory.SetClothes(sc.Set6)
                Memory.SetClothes(sc.Set7)
                Memory.SetProps(sc.Set8)
                Memory.SetProps(sc.Set9)
                Memory.SetProps(sc.Set10)
        End Select
    End Sub

    Private Sub SetClothing_OnIndexChange(sender As UIMenu, index As Integer) Handles mFullSuitsF.OnIndexChange, mFullSuitsM.OnIndexChange, mFullSuitsT.OnIndexChange, mOutfitF.OnIndexChange,
        mOutfitM.OnIndexChange, mOutfitT.OnIndexChange
        Dim sc As ClothingSet = sender.MenuItems(index).Tag

        Select Case sc.Type
            Case eClothingType.FullSuit
                PP.SetClothes(sc.Set1)
                PP.SetClothes(sc.Set2)
                PP.SetClothes(sc.Set3)
                PP.SetClothes(sc.Set4)
                PP.SetClothes(sc.Set5)
                PP.SetClothes(sc.Set6)
                PP.SetClothes(sc.Set7)
            Case eClothingType.Outfit
                PP.SetClothes(sc.Set1)
                PP.SetClothes(sc.Set2)
                PP.SetClothes(sc.Set3)
                PP.SetClothes(sc.Set4)
                PP.SetClothes(sc.Set5)
                PP.SetClothes(sc.Set6)
                PP.SetClothes(sc.Set7)
                PP.SetProps(sc.Set8)
                PP.SetProps(sc.Set9)
                PP.SetProps(sc.Set10)
        End Select
    End Sub

    Private Sub FMOutfit_OnItemSelect(sender As UIMenu, selectedItem As UIMenuItem, index As Integer) Handles mOutfitFMF.OnItemSelect, mOutfitFMM.OnItemSelect
        Dim sc As ClothingSet = sender.MenuItems(index).Tag
        PP.SetClothes(sc.Set1)
        PP.SetClothes(sc.Set2)
        PP.SetClothes(sc.Set3)
        PP.SetClothes(sc.Set4)
        PP.SetClothes(sc.Set5)
        PP.SetClothes(sc.Set6)
        PP.SetClothes(sc.Set7)
        PP.SetClothes(sc.Set8)
        PP.SetProps(sc.Set9)
        PP.SetProps(sc.Set10)
        PP.SetProps(sc.Set11)
        Memory.SetClothes(sc.Set1)
        Memory.SetClothes(sc.Set2)
        Memory.SetClothes(sc.Set3)
        Memory.SetClothes(sc.Set4)
        Memory.SetClothes(sc.Set5)
        Memory.SetClothes(sc.Set6)
        Memory.SetClothes(sc.Set7)
        Memory.SetClothes(sc.Set8)
        Memory.SetProps(sc.Set9)
        Memory.SetProps(sc.Set10)
        Memory.SetProps(sc.Set11)
    End Sub

    Private Sub FMOutfit_OnIndexChange(sender As UIMenu, index As Integer) Handles mOutfitFMF.OnIndexChange, mOutfitFMM.OnIndexChange
        Dim sc As ClothingSet = sender.MenuItems(index).Tag
        PP.SetClothes(sc.Set1)
        PP.SetClothes(sc.Set2)
        PP.SetClothes(sc.Set3)
        PP.SetClothes(sc.Set4)
        PP.SetClothes(sc.Set5)
        PP.SetClothes(sc.Set6)
        PP.SetClothes(sc.Set7)
        PP.SetClothes(sc.Set8)
        PP.SetProps(sc.Set9)
        PP.SetProps(sc.Set10)
        PP.SetProps(sc.Set11)
    End Sub

    Private Sub Main_OnMenuClose(sender As UIMenu) Handles gmFranklin.OnMenuClose, gmMichael.OnMenuClose, gmTrevor.OnMenuClose, gmFMM.OnMenuClose, gmFMF.OnMenuClose
        World.RenderingCamera = Nothing
        World.DestroyAllCameras()
        PP.Task.ClearAll()
        HideHud = False

        PP.SetClothes(Memory.Accessories)
        PP.SetClothes(Memory.AuxiliaryTorso)
        PP.SetClothes(Memory.Beard)
        PP.SetProps(Memory.Earrings)
        PP.SetClothes(Memory.Eyes)
        PP.SetClothes(Memory.Face)
        PP.SetClothes(Memory.Feet)
        PP.SetProps(Memory.Glasses)
        PP.SetClothes(Memory.Hair)
        PP.SetClothes(Memory.Hands)
        PP.SetProps(Memory.Helmet)
        PP.SetClothes(Memory.Legs)
        PP.SetClothes(Memory.Props)
        PP.SetClothes(Memory.Textures)
        PP.SetClothes(Memory.Torso)
    End Sub

End Module
