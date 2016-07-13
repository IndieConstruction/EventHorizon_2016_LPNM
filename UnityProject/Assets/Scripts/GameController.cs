using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace EH.LPNM{
public class GameController : MonoBehaviour {
	#region
	public delegate void GameEvent();
	//eventi base del gioco.
	
	public static event GameEvent OnPlayerDeath;
	public static event GameEvent OnPlayerShape;

	public static event GameEvent OnGamePause;
	public static event GameEvent OnGameStart;
	public static event GameEvent OnGameEnd;
	public static event GameEvent OnLoadLevel;
	public static event GameEvent OnPlayLevel;
	public static event GameEvent OnLevelEnd;
	public static event GameEvent OnGameWin;
	// evento che fa partire il gioco/livello

	public static event GameEvent OnGameOver;
	public static event GameEvent OnNextLevel;
	//eventi per i bonus
    public static event GameEvent IsBonusMagnetic;
    public static event GameEvent IsBOnusShield;
	public static event GameEvent IsBonusCoin;
	public static event GameEvent IsBonusX2;
	public static event GameEvent IsLifeBonus;

    //eventi per la collisione delle lettere
	public static event GameEvent OnPerfectCollision;
	public static event GameEvent OnGoodCollision;
	public static event GameEvent OnPoorCollision;
	public static event GameEvent OnWrongLetter;

    #endregion
	
	public bool GameIsFreeze;
    public static string LevelName;
	FMOD_SoundManager fm;
    HudManager Hd;
    SoundController sc;
	Player p;
	Letter l;
	InputController iC;
    Start st;

	public int Level ;
	
//	public GameObject[] ObstacleLettersPrefabs;
//	public GameObject[] PlayerPrefabs;
	Vector3 posPlayer;
	float timeToStart= 0.0f;
	public float StartGame=0; // 
	public int ScoreCounter; // Punteggio del gioco
	public int Score4NextLevel;
	private string BonusScore; 
	public float DistanceResult; // Distanza tra il punto di collisone e la lettera
	public int Multiplier;// moltiplicatore generico
    public float CountCollider; //Secondi di invulnerabilità dopo collisione col tubo 
    public string LoadLevel; //variabile nome scena livello successivo
    public bool StopInput = true; //variabile per fermare gli input
	public bool Complete = false; //livello superato o meno
    float timeDiv = 0f; //variabile per il calcolo del tempismo di ReadySteadyGo
    bool Ready = true;
    bool Steady = true;
    bool Go = true;



        //public Transform[] LettersSpawnPoints;
        //public float CounterXObstacle;
        //float TimerXObstacle;
        // Use this for initialization


        void Awake(){
			Multiplier = 0;
			DontDestroyOnLoad(this.gameObject);

			if(p==null){
				p =FindObjectOfType<Player>();
			}
			if(l == null){
				l = FindObjectOfType<Letter>();
			}
	}

	void Start () {
            if (StartGame != 0)
            {
                timeDiv = StartGame / 3;
            }
            st = FindObjectOfType<Start>();
			iC = FindObjectOfType<InputController>();
            Hd = FindObjectOfType <HudManager>();
			sc = FindObjectOfType<SoundController>();
            StartInputAndTime();
			iC.enabled = false;
			GameController_OnGameStart();
			fm = FindObjectOfType<FMOD_SoundManager>();
			fm.Ambience(Multiplier);
			fm.Music_Space(Multiplier,ScoreCounter,0);
		//	TimerXObstacle = 0;
		//  p = GetComponent<Player>();
		//	GameTimer = 0;
	}
		void OnDisbale(){
			GameController.OnGamePause -= GameController_OnGamePause;
			GameController.OnGameStart -= GameController_OnGameStart;
			GameController.OnGameOver -= GameController_OnGameOver;
			GameController.OnLevelEnd -= GameController_OnLevelEnd;
		}
		void OnEnable(){
			GameController.OnLevelEnd += GameController_OnLevelEnd;
			GameController.OnGamePause += GameController_OnGamePause;
			GameController.OnGameStart += GameController_OnGameStart;
			GameController.OnGameOver += GameController_OnGameOver;
		}

		void GameController_OnLevelEnd ()
		{
			fm.PlayerGoal();
		}

		void GameController_OnGameOver ()
		{
		//	fm.Music();
		}

		void GameController_OnGameStart ()
		{
			//fm.Countdown();
		}

		void GameController_OnGamePause ()
		{
			//fm.MenuPauseInOut();
		}


	
	
	// Update is called once per frame
	void Update () {
            if(StartGame!=0)
            {
                timeDiv = StartGame / 4;
            }

            if (timeToStart <= StartGame){
			//	fm.Countdown();
                StartReadyGo();
				//StartGame = StartGame + Time.deltaTime;
				timeToStart = timeToStart + Time.deltaTime;

			}

			else {
				GameIsFreeze= false;
				iC.enabled=true;

			}
		}


    void FixedUpdate() {
            if (p.PlayerLife <= 0)
            {
               // EndLevelComplete();
				p.GameController_OnPlayerDeath();
                StopInputAndTime();
                CompleteLevelActive();
                fm.Music_Space_Off();
                fm.Ambience_Off();
            }

    }


        void StartReadyGo()
        {
			if (timeDiv > timeToStart)
            {
                if(Ready)
                fm.Ready();
                st.Ready_set();
                Ready = false;
            }
			else if (timeDiv*2 > timeToStart)
            {
                st.Ready_unset();
                if(Steady)
                fm.Steady();
                st.Steady_set();
                Steady = false;
            }
			else if (timeDiv*3 > timeToStart)
            {
                st.Steady_unset();
                if(Go)
                fm.Go();
                st.Go_set();
                Go = false;

            }
			else if (timeDiv*4 > timeToStart)
            {
                st.Go_unset();
            }
                
        }

        //Spawn generale
    public static void Spawn(GameObject objectToSpawn, Vector3 positionToSpawn){
		Instantiate (objectToSpawn, positionToSpawn, objectToSpawn.transform.rotation);
			
	}
//	void RandomSpawnObstacle (){
//		// sceglie un indice a caso nell'array LettersPrefabs
//			int randomLetter = Random.Range(0, ObstacleLettersPrefabs.Length);
//		// assegna l'indice scelto al gameobject ItemToSpawn
//			GameObject LetterToSpawn = ObstacleLettersPrefabs [randomLetter];
//		// sceglie un indice a caso nell'array di spawnPoint
//		int randomIndex = Random.Range (0, LettersSpawnPoints.Length -1);
//		// assegna l'indice alla variabile spawnPosition
//		Vector3 spawnPosition = LettersSpawnPoints [randomIndex].transform.position;
//		// esegue lo spawn con i parametri ItemToSpawn e spawnPosition
//		Spawn (LetterToSpawn,spawnPosition);
//
//	}
    
    /// <summary>
    /// Setta la variabile Complete a true se il punteggio raggiunto è sufficiente per superare il livello
    /// </summary>
	public void EndLevelComplete () {
            //	if(p.PlayerLife<=0){
          if (ScoreCounter >= Score4NextLevel)
          {
            Complete = true;

		//	SceneManager.LoadScene("LevelTwo");
          }
				//}
         /*   if (scoreCounter >= Score4NextLevel)
            {
                SceneManager.LoadScene("LevelTwo");
               
                Debug.Log("LevelTwo");
            }
            */
        }
        /// <summary>
        /// Ferma input mouse e tempo del gioco
        /// </summary>
        public void StopInputAndTime()
		{ GameController_OnGamePause();
            StopInput = false;
               if (Time.timeScale == 1.0F)
                     Time.timeScale = 0F;
        }
        /// <summary>
        /// Starta input mouse e tempo del gioco
        /// </summary>
        public void StartInputAndTime()
		{ GameController_OnGamePause();
            StopInput = true;
            Time.timeScale = 1.0F;
        }

       /// <summary>
        /// Visualizza Hud Game Over 
        /// </summary>
   /*     public void CompleteLevelActive()
        {
            Hd.HudGameOver.gameObject.SetActive(true);
        }
        */
		public void CompleteLevelActive()
		{
			if(Complete==true)
			Hd.HudCompleteLevel.gameObject.SetActive(true);
			else
				Hd.HudGameOver.gameObject.SetActive(true);
		
		}

        /// <summary>
        /// Attiva la pausa se inattiva, la disabilita se attiva
        /// </summary>
       public void PauseActive()
        {
            if (Hd.Pa.gameObject.activeSelf==false)
            {
                StopInputAndTime();
				fm.MenuPauseInOut();
				fm.Music_Space(Multiplier, ScoreCounter, 1);
                fm.Ambience_Off();
                Hd.Pa.gameObject.SetActive(true);
            }
            else
            {              
                Hd.Pa.gameObject.SetActive(false);
				fm.MenuPauseInOut();
             
				fm.Music_Space(Multiplier, ScoreCounter,0);
                fm.Ambience(Multiplier);
                StartInputAndTime();
            }
        }
        enum OnCollisionPoint
		{Perfect,
			Good,
			Ouch
		}
		/// <summary>
		/// Valuta il punteggio e lo assegna in base al voto
		/// </summary>
		public void OnPointsToAdd (CollisionController.Vote vote, float distancePoint){
			Bonus b;
			b = FindObjectOfType<Bonus>();
			switch (vote) {
			case CollisionController.Vote.Perfect :
				p.GameController_OnPerfectCollision();

				Multiplier = Multiplier +2;
                MultiplierLimiter();
                ScoreCounter = ScoreCounter +1000* Multiplier;
				BonusScore = "PERFECT!";
				p.GameController_OnPerfectCollision();
				Hd.UpdateHud();
				break;
			case CollisionController.Vote.Good:
				p.GameController_OnGoodCollision();

                Multiplier = Multiplier +1;
                MultiplierLimiter();
                ScoreCounter = ScoreCounter +500*Multiplier;
				BonusScore = "GOOD!";
				p.GameController_OnGoodCollision();
				Hd.UpdateHud();
				break;
			case CollisionController.Vote.Poor:
				p.GameController_OnPoorCollision();
				Multiplier = 0;
				BonusScore = "POOR!";
				p.GameController_OnPoorCollision();
				Hd.UpdateHud();
				break;
			case CollisionController.Vote.wrongLetter:
				p.GameController_OnWrongLetter();
				if(b.IsShield == false){
				Multiplier = 0;
				p.PlayerLife --;
				p.GameController_OnWrongLetter();
				fm.PlayerDoorWrong();
				BonusScore = "WRONG LETTER!";}
					break;
			default:
				break;
			}
			Hd.OnCollisionVote(BonusScore, DistanceResult);
			fm.Ambience(Multiplier);
			fm.Music_Space (Multiplier, ScoreCounter, 0 );
		}

       public void MultiplierLimiter() {
            if (Multiplier >=10) {
                Multiplier = 10;
            }
        }
			

	}
	}

	
					
