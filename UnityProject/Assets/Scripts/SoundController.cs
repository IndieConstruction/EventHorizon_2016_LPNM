using UnityEngine;
using System.Collections;
namespace EH.LPNM{
/// <summary>
/// Conferisce la capacità al player di emettere suoni
/// </summary>
public class SoundController : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip BonusTaken;
	public AudioClip GameOver;
	public AudioClip Win;
	public AudioClip NextLevel;
	public AudioClip Perfect;
	public AudioClip Good;
	public AudioClip WrongLetter;
	public AudioClip Poor;
	public Sounds DefaultSound;

	void Awake () {
		GameController.OnGameOver += HandleOnGameOver;
		GameController.OnGameWin += HandleOnGameWin;
		GameController.OnNextLevel += HandleOnNextLevel;
		GameController.OnBonusTaken += HandleOnBonusTaken;
		GameController.OnPerfectCollision += GameController_OnPerfectCollision;
		GameController.OnGoodCollision += GameController_OnGoodCollision;
		GameController.OnPoorCollision += GameController_OnPoorCollision;
		GameController.OnWrongLetter += GameController_OnWrongLetter;
		}

	public void GameController_OnWrongLetter ()
	{
			PlaySound(Sounds.WrongLetter);
	}

	public void GameController_OnPoorCollision ()
	{
			PlaySound(Sounds.Poor);
	}

	public void GameController_OnGoodCollision ()
	{
			PlaySound(Sounds.Good);
	}

	public void GameController_OnPerfectCollision ()
	{
			PlaySound(Sounds.Perfect);
	}

	public void HandleOnBonusTaken ()
	{
		PlaySound(Sounds.BonusTaken);
	}

	void HandleOnNextLevel ()
	{
		PlaySound(Sounds.NextLevel);
	}

	void HandleOnGameWin ()
	{
		PlaySound (Sounds.Win);
	}

	void HandleOnGameOver ()
	{
		PlaySound (Sounds.GameOver);
	}


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		if (audioSource == null) {
			audioSource = gameObject.AddComponent<AudioSource>(); 
		}

		PlaySound (DefaultSound); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(Sounds _soundToPlay){
		switch (_soundToPlay) {
		case Sounds.GameOver:
			audioSource.clip = GameOver;
			break;
		case Sounds.Win:
			audioSource.clip = Win;
			break;
		case Sounds.BonusTaken :
			audioSource.clip = BonusTaken;
			break;
		case Sounds.NextLevel:
			audioSource.clip = NextLevel;
			break;
		case Sounds.Perfect:
			audioSource.clip = Perfect;
			break;
		case Sounds.Good:
			audioSource.clip = Good;
			break;
		case Sounds.Poor:
			audioSource.clip = Poor;
			break;
		case Sounds.WrongLetter:
			audioSource.clip = WrongLetter;
			break;
		}

		audioSource.Play ();
	}

	public enum Sounds {
		Perfect,
		Good,
		Poor,
		WrongLetter,
		GameOver,
		Win,
		BonusTaken,
		NextLevel
	}
}
}