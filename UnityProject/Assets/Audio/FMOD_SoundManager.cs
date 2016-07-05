using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;
namespace EH.LPNM{

public class FMOD_SoundManager : MonoBehaviour {
    // sound for player changing its shape from one letter to another
    [EventRef]
    public string SND_Player_Shape;
    // sound for player picking up coin
    [EventRef]
    public string SND_Player_Coin;
    
    // sounds for how good is the player at matching the letter and parameter names
    // parameters of type p_PlayerDoor... can have value from 0 to 2 and represent
    // 0 = space
    // 1 = tunnel
    // 2 = city
    [EventRef]
	public string SND_Player_DoorWrong;
  //  public string p_PlayerDoorWrong;
    [EventRef]
    public string SND_Player_DoorPoor;
    //public string p_PlayerDoorPoor;
    [EventRef]
    public string SND_Player_DoorGood;
    //public string p_PlayerDoorGood;
    [EventRef]
    public string SND_Player_DoorPerfect;
    //public string p_PlayerDoorPerfect;

    // sound for player hitting an object
    [EventRef]
    public string SND_Player_ObjectHit;
    
    // sound for when the player reaches the end of the level
    [EventRef]
    public string SND_Player_Goal;

    // sound for when player life goes to 0 and player dies
    [EventRef]
    public string SND_Player_Death;

    // UI sounds
//    [EventRef]
//    public string SND_Menu_Scroll;
    [EventRef]
    public string SND_Menu_Select;
    [EventRef]
//    public string SND_Menu_Back;
//    [EventRef]
    public string SND_Menu_Pause_InOut;     // sound to be played both when entering AND exiting the Pause state
    
    // sound for countdown at the beginning of the level
  //  [EventRef]
    //public string SND_VO_Countdown;

    // ambience sound and string for its parameter name
    // parameter p_Ambience_Setting values range from 0 to 2 and represent
    // 0 = space
    // 1 = tunnel
    // 2 = city
    [EventRef]
    public string SND_Ambience;
    //public string p_Ambience_Setting;

    // music and string for its parameter name
    // parameter p_Music_Setting values range from 0 to 2 and represent
    // 0 = space
    // 1 = tunnel
    // 2 = city
    //[EventRef]
   // public string SND_Music;
    //public string p_Music_Setting;
    // value relative to SND_Music for selecting in which state we are, and its values ranges from 0 to 3 (int)
    // 0 = main menu
    // 1 = in-game
    // 2 = end-game
    // 3 = leaderboard
    //public string p_Music_GameState;

    // music while in space and relative parameters
    // parameter p_MusicSpace_Multiplier values range from 0 to 4 (int) and represent the 5 steps of the score multiplier
    // parameter p_MusicSpace_Score values range from 0 to 4 (int) and each one is currentScore/musicScoreDelta, where the last int is defined below
    [EventRef]
    public string SND_Music_Space;
        //    public string p_MusicSpace_Multiplier;
        //    public string p_MusicSpace_Score;
        //    
        // music while in city and relative parameters
        // parameter p_MusicSpace_Multiplier values range from 0 to 4 (int) and represent the 5 steps of the score multiplier
        // parameter p_MusicSpace_Score values range from 0 to 4 (int) and each one is currentScore/musicScoreDelta, where the last int is defined below
        //    [EventRef]
        //    public string SND_Music_City;
        //    public string p_MusicCity_Multiplier;
        //    public string p_MusicCity_Score;

        //public int musicScoreDelta;

        /*
        // events for playing end of level music, menu music and leaderboard music
        // better use a parameter in SND_Music, which I added and it's called p_Music_GameState
        [EventRef]
        public string SND_Music_EndLevel;
        [EventRef]
        public string SND_Music_Menu;
        [EventRef]
        public string SND_Music_Leaderboard;
        */


        //[EventRef]
        //public string SND_PlayerDimensionChanged;

        [EventRef]
        public string SND_Steady;


        [EventRef]
        public string SND_Ready;


        [EventRef]
        public string SND_Go;

        [EventRef]
        public string SND_Music_End;

        [EventRef]
        public string SND_Music_Menu;


        void Start() {
 
		Sound_StartLevel();
    }

    public void CreateSoundEventInstance(string SND_eventName, EventInstance EVT_eventName){
        if (SND_eventName != null) {
           // EventInstance EVT_eventName = RuntimeManager.CreateInstance(SND_eventName);
        }

    }

	public void Sound_StartLevel(){
        /*
		EventInstance SND_ControlledEvent = RuntimeManager.CreateInstance(SND_PlayerDeath);
		SND_ControlledEvent.start();		


		EventInstance SND_ControlledEvent_WithParameters = RuntimeManager.CreateInstance(SND_PlayerShoot);
		SND_ControlledEvent_WithParameters.setParameterValue("WeaponNumber", 1);
		SND_ControlledEvent_WithParameters.start();
		SND_ControlledEvent_WithParameters.setParameterValue("WeaponNumber", 2);
		SND_ControlledEvent_WithParameters.start();
        */
	}

	public void PlayerDimensionChanged(float _playerDimension, float _playerSpeed){
		/*
        EventInstance EVT_SND_PlayerDimensionChanged = RuntimeManager.CreateInstance(SND_PlayerDimensionChanged);
		EVT_SND_PlayerDimensionChanged.setParameterValue("Dimension", _playerDimension);
		EVT_SND_PlayerDimensionChanged.setParameterValue("Speed", _playerSpeed);
		EVT_SND_PlayerDimensionChanged.start();
		EVT_SND_PlayerDimensionChanged.stop();
		RuntimeManager.PlayOneShot(EVT_SND_PlayerDimensionChanged);
        */
	}

	public void PlayerShape(){
		EventInstance EVT_SND_Player_Shape = RuntimeManager.CreateInstance(SND_Player_Shape);
		EVT_SND_Player_Shape.start();
		//EVT_SND_Player_Shape.stop();
		//RuntimeManager.PlayOneShot(SND_Player_Shape);
	}

	public void PlayerCoin(){
		EventInstance EVT_SND_Player_Coin = RuntimeManager.CreateInstance(SND_Player_Coin);
		EVT_SND_Player_Coin.start();
		//EVT_SND_Player_Coin.stop();
		//RuntimeManager.PlayOneShot(SND_Player_Coin);
	}

	public void PlayerDoorWrong(){
		EventInstance EVT_SND_Player_DoorWrong = RuntimeManager.CreateInstance(SND_Player_DoorWrong);
		EVT_SND_Player_DoorWrong.start();
		//EVT_SND_Player_DoorWrong.stop();
		//RuntimeManager.PlayOneShot(SND_Player_Coin);
		
	}
	public void PlayerDoorPoor(){
		EventInstance EVT_SND_Player_DoorPoor = RuntimeManager.CreateInstance(SND_Player_DoorPoor);
		EVT_SND_Player_DoorPoor.start();
		//EVT_SND_Player_DoorPoor.stop();
		//RuntimeManager.PlayOneShot(SND_Player_DoorPoor);
	}
	public void PlayerDoorGood(){
		EventInstance EVT_SND_Player_DoorGood = RuntimeManager.CreateInstance(SND_Player_DoorGood);
		EVT_SND_Player_DoorGood.start();
		//EVT_SND_Player_DoorGood.stop();
		//RuntimeManager.PlayOneShot(SND_Player_DoorGood);
	}
	public void PlayerDoorPerfect(){
		EventInstance EVT_SND_Player_DoorPerfect = RuntimeManager.CreateInstance(SND_Player_DoorPerfect);
		EVT_SND_Player_DoorPerfect.start();
		//EVT_SND_Player_DoorPerfect.stop();
		//RuntimeManager.PlayOneShot(SND_Player_DoorPerfect);
	}
	public void PlayerObjectHit(){
		EventInstance EVT_SND_Player_ObjectHit = RuntimeManager.CreateInstance(SND_Player_ObjectHit);
		EVT_SND_Player_ObjectHit.start();
		//EVT_SND_Player_ObjectHit.stop();
		//RuntimeManager.PlayOneShot(SND_Player_ObjectHit);
	}
	public void PlayerGoal(){
		EventInstance EVT_SND_Player_Goal = RuntimeManager.CreateInstance(SND_Player_Goal);
		EVT_SND_Player_Goal.start();
		//EVT_SND_Player_Goal.stop();
		//RuntimeManager.PlayOneShot(SND_SND_Player_Goal);
	}
	public void PlayerDeath(){
		EventInstance EVT_SND_Player_Death = RuntimeManager.CreateInstance(SND_Player_Death);
		EVT_SND_Player_Death.start();
		//SND_Player_Death.stop();
		//RuntimeManager.PlayOneShot(SND_Player_Death);
	}
//	public void MenuScroll(){
//		EventInstance EVT_SND_Menu_Scroll = RuntimeManager.CreateInstance(SND_Menu_Scroll);
//		EVT_SND_Menu_Scroll.start();
//		//SND_Menu_Scroll.stop();
//		//RuntimeManager.PlayOneShot(SND_Menu_Scroll);
//	}
	public void MenuSelect(){
		EventInstance EVT_SND_Menu_Select = RuntimeManager.CreateInstance(SND_Menu_Select);
		EVT_SND_Menu_Select.start();
		//SND_Menu_Select;.stop();
		//RuntimeManager.PlayOneShot(SND_Menu_Select;;
	}
//	public void MenuBack(){
//		EventInstance EVT_SND_Menu_Back = RuntimeManager.CreateInstance(SND_Menu_Back);
//		EVT_SND_Menu_Back.start();
//		//SND_Menu_Back.stop();
//		//RuntimeManager.PlayOneShot(SND_Menu_Back);
//	}
	public void MenuPauseInOut(){
		EventInstance EVT_SND_Menu_Pause_InOut = RuntimeManager.CreateInstance(SND_Menu_Pause_InOut);
			EVT_SND_Menu_Pause_InOut.start();
		//SND_Menu_Pause_InOut.stop();
		//RuntimeManager.PlayOneShot(SND_Menu_Pause_InOut);
	}
 //   public void Countdown(){
//		EventInstance EVT_SND_VO_Countdown = RuntimeManager.CreateInstance(SND_VO_Countdown);
	//		EVT_SND_VO_Countdown.start();
		//SNDSND_VO_Countdown.stop();
		//RuntimeManager.PlayOneShot(SND_VO_Countdown);
	//}
		EventInstance EVT_SND_Ambience = null;
		public void Ambience(int Multiplier){
		
			EVT_SND_Ambience = RuntimeManager.CreateInstance(SND_Ambience);
			EVT_SND_Ambience.setParameterValue("Multiplier", Multiplier);
			EVT_SND_Ambience.start();
		//SND_Ambience.stop();
		//RuntimeManager.PlayOneShot(SND_Ambience);
			
		}

        public void Ambience_Off()
        {
            EVT_SND_Ambience.stop(STOP_MODE.ALLOWFADEOUT);
            //EVT_Music_Space.stop(STOP_MODE.IMMEDIATE);
            //EVT_Music_Space.stop();
            //RuntimeManager.PlayOneShot(EVT_Music_Space);



        }
//        	public void Music(){
//        		EventInstance EVT_SND_Music = RuntimeManager.CreateInstance(SND_Music);
//        		EVT_SND_Music.start();
//        		//SND_Music.stop();
//        		//RuntimeManager.PlayOneShot(SND_Music);
//        		}

        EventInstance EVT_Music_Space = null;
        public void Music_Space(int Multiplier,int Pause)
        {
            if (EVT_Music_Space == null)
            {
                EVT_Music_Space = RuntimeManager.CreateInstance(SND_Music_Space);
                EVT_Music_Space.setParameterValue("Multiplier", Multiplier);
                EVT_Music_Space.setParameterValue("pause", Pause);
                EVT_Music_Space.start();
            }
            else
            {
                EVT_Music_Space.setParameterValue("Multiplier", Multiplier);
                EVT_Music_Space.setParameterValue("pause", Pause);
            }
        }
            public void Music_Space_Off()
        {
            EVT_Music_Space.stop(STOP_MODE.ALLOWFADEOUT);
           //EVT_Music_Space.stop(STOP_MODE.IMMEDIATE);
            //EVT_Music_Space.stop();
            //RuntimeManager.PlayOneShot(EVT_Music_Space);



        }

        public void Steady()
        {
            EventInstance EVT_SND_Steady = RuntimeManager.CreateInstance(SND_Steady);
            EVT_SND_Steady.start();
           
        }

        public void Ready()
        {
            EventInstance EVT_SND_Ready = RuntimeManager.CreateInstance(SND_Ready);
            EVT_SND_Ready.start();

        }

        public void Go()
        {
            EventInstance EVT_SND_Go = RuntimeManager.CreateInstance(SND_Go);
            EVT_SND_Go.start();

        }

        public void Music_End()
        {
            EventInstance EVT_SND_Music_End = RuntimeManager.CreateInstance(SND_Music_End);
            EVT_SND_Music_End.start();

        }

        EventInstance EVT_SND_Music_Menu = null;
        public void Music_Menu()
        {
            if (EVT_SND_Music_Menu == null)
            {
                EVT_SND_Music_Menu = RuntimeManager.CreateInstance(SND_Music_Menu);
                EVT_SND_Music_Menu.start();
            }

        }

        public void Music_Menu_Off()
        {
            EVT_SND_Music_Menu.stop(STOP_MODE.ALLOWFADEOUT);
        }

    }
}