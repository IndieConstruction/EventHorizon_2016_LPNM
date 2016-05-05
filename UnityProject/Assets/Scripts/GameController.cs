using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public class GameController : MonoBehaviour {
	
	Player p;
	Letter l;
	public int Level ;
	public int PlayerLife;
//	public GameObject[] ObstacleLettersPrefabs;
//	public GameObject[] PlayerPrefabs;
	Vector3 posPlayer;
	public float GameTimer;
	public int scoreCounter; // Punteggio del gioco
	public int Score4NextLevel;
	public string BonusScore; 
	public float DistanceResult; // Distanza tra il punto di collisone e la lettera
	public int Multiplier;// moltiplicatore generico
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
		//	TimerXObstacle = 0;
		//p = GetComponent<Player>();
			GameTimer = 0;
	}	
	
	// Update is called once per frame
	void Update () {
			if(GameTimer <=60){
				GameTimer = GameTimer + Time.deltaTime;
			}
			else {
				Debug.Log("Tempo Scaduto");
				GameTimer = 0;
			}
            //if (TimerXObstacle >= CounterXObstacle)
            //{
            //    RandomSpawnObstacle();
            //    Debug.Log("Sto Spawnando");

            //    TimerXObstacle = 0;
            //}
            //TimerXObstacle = TimerXObstacle + Time.deltaTime;
        }


        //Spawn generale
        public void Spawn(GameObject objectToSpawn, Vector3 positionToSpawn){
		Instantiate (objectToSpawn, positionToSpawn, objectToSpawn.transform.rotation);
			
	}
	/// <summary>
	/// Spawn Random degli Ostacoli
	/// </summary>
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
	public void PlayerLevelCompleted () {
				if(scoreCounter<=0){
				Application.LoadLevel("GameOver");
				Debug.Log("GameOver");
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

			switch (vote) {
			case CollisionController.Vote.Perfect :
				Multiplier = Multiplier +2;
				scoreCounter = scoreCounter +1000* Multiplier;
				BonusScore = "PERFECT!";
				Hd.UpdateHud();

				break;
			case CollisionController.Vote.Good:
				Multiplier = Multiplier +1;
				scoreCounter = scoreCounter +500*Multiplier;
				BonusScore = "GOOD!";
				Hd.UpdateHud();

				break;
			case CollisionController.Vote.Poor:
				Multiplier = 0;
				BonusScore = "POOR!";
				Hd.UpdateHud();
				break;
			case CollisionController.Vote.wrongLetter:
				Multiplier = 0;
				PlayerLife --;
				Hd.UpdateHud();
				BonusScore = "WRONG LETTER!";

				break;
			default:
				break;
			}
			Hd.OnCollisionVote(BonusScore, DistanceResult);
		}

	}
	}

	
					
