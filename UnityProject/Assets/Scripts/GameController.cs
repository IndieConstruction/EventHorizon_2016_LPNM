using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace EH.LPNM{
public class GameController : MonoBehaviour {
	#region
	public delegate void GameEvent();
	//eventi base del gioco.
	public static event GameEvent OnGameStart;
	public static event GameEvent OnGameEnd;
	public static event GameEvent OnLoadLevel;
	public static GameEvent OnLoadLevelComplete;
	public static event GameEvent OnPlayLevel;
	public static event GameEvent OnLevelEnd;

	public static event GameEvent OnGameWin;
	// evento che fa partire il gioco/livello

	public static event GameEvent OnGameOver;
	public static event GameEvent OnNextLevel;
	//eventi per i bonus
	public static event GameEvent OnBonusTaken;
    public static event GameEvent IsMagnetic;
    public static event GameEvent IsShield;

    //eventi per la collisione delle lettere
	public static event GameEvent OnPerfectCollision;
	public static event GameEvent OnGoodCollision;
	public static event GameEvent OnPoorCollision;
	public static event GameEvent OnWrongLetter;

    #endregion
    public static string LevelName;

    SoundController sc;
    SaveScore ScoreS;
	Player p;
	Letter l;
	public int Level ;
	
//	public GameObject[] ObstacleLettersPrefabs;
//	public GameObject[] PlayerPrefabs;
	Vector3 posPlayer;
	public float GameTimer;
	public int scoreCounter; // Punteggio del gioco
	public int Score4NextLevel;
	private string BonusScore; 
	public float DistanceResult; // Distanza tra il punto di collisone e la lettera
	public int Multiplier;// moltiplicatore generico
    public float CountCollider; //Secondi di invulnerabilità dopo collisione col tubo 
    public string LoadLevel;
    public bool Play=true;
//	public int ScoreCounter {
//			get{return scoreCounter;}
//			set{scoreCounter = value;
//				Hd.UpdateHud("Score :" +scoreCounter);
//			}
//		}
	public HudManager Hd;
	
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
			sc = FindObjectOfType<SoundController>();
            ScoreS = FindObjectOfType<SaveScore>();
            StartPlay();
		//	TimerXObstacle = 0;
		//  p = GetComponent<Player>();
		//	GameTimer = 0;
	}	
	
	// Update is called once per frame
	void Update () {
//			if(GameTimer <=60){
//				GameTimer = GameTimer + Time.deltaTime;
//			}
//			else {
//				Debug.Log("Tempo Scaduto");
//				GameTimer = 0;
			//}
            //if (TimerXObstacle >= CounterXObstacle)
            //{
            //    RandomSpawnObstacle();
            //    Debug.Log("Sto Spawnando");

            //    TimerXObstacle = 0;
            //}
            //TimerXObstacle = TimerXObstacle + Time.deltaTime;
        }

    void FixedUpdate() {
            if (p.PlayerLife <= 0)
            {
                ChangeScenes();
                StopPlay();
                GameOverActive();
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
    /// Funzione per cambiare la scena
    /// </summary>
	public void ChangeScenes () {
            //	if(p.PlayerLife<=0){
            if (scoreCounter >= Score4NextLevel)
            {
                ScoreS.Complete = true;
                ScoreS.LoadLev = LoadLevel;
            }
            Debug.Log("GameOver");

				//}
         /*   if (scoreCounter >= Score4NextLevel)
            {
                SceneManager.LoadScene("LevelTwo");
                // Application.LoadLevel("GameOver");
                Debug.Log("LevelTwo");
            }
            */
        }

        public void StopPlay()
        {
            Play = false;
               if (Time.timeScale == 1.0F)
                     Time.timeScale = 0F;
        }

        public void StartPlay()
        {
            Play = true;
            Time.timeScale = 1.0F;
        }

        public void GameOverActive()
        {
            Hd.HudGameOver.gameObject.SetActive(true);
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

			switch (vote) {
			case CollisionController.Vote.Perfect :
				sc.GameController_OnPerfectCollision();
				Multiplier = Multiplier +2;
                MultiplierLimiter();
                scoreCounter = scoreCounter +1000* Multiplier;
				BonusScore = "PERFECT!";
				Hd.UpdateHud();

				break;
			case CollisionController.Vote.Good:
				sc.GameController_OnGoodCollision();
                Multiplier = Multiplier +1;
                MultiplierLimiter();
                scoreCounter = scoreCounter +500*Multiplier;
				BonusScore = "GOOD!";
				Hd.UpdateHud();
				break;
			case CollisionController.Vote.Poor:
				sc.GameController_OnPoorCollision();
				Multiplier = 0;
				BonusScore = "POOR!";
				Hd.UpdateHud();
				break;
			case CollisionController.Vote.wrongLetter:
				sc.GameController_OnWrongLetter();
				Multiplier = 0;
				p.PlayerLife --;
				Hd.UpdateHud();
				BonusScore = "WRONG LETTER!";

				break;
			default:
				break;
			}
			Hd.OnCollisionVote(BonusScore, DistanceResult);
		}

       public void MultiplierLimiter() {
            if (Multiplier >=10) {
                Multiplier = 10;
            }
        }
	}
	}

	
					
