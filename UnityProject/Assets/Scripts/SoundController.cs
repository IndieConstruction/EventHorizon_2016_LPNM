using UnityEngine;
using System.Collections;
namespace EH.LPNM{
/// <summary>
/// Conferisce la capacità al player di emettere suoni
/// </summary>
public class SoundController : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip MagneticBonus;
	public AudioClip CoinBonus;
	public AudioClip LifeBonus;
	public AudioClip ShieldBonus;
	public AudioClip PowerUpX2;
	public Sounds DefaultSound;

	void Awake () {
		GameController.IsBonusCoin += GameController_IsBonusCoin;
		GameController.IsBonusMagnetic += GameController_IsBonusMagnetic;
		GameController.IsBOnusShield += GameController_IsBOnusShield;
		GameController.IsBonusX2 += GameController_IsBonusX2;
		GameController.IsLifeBonus += GameController_IsLifeBonus;
		}

	void GameController_IsLifeBonus ()
	{
			PlaySound (Sounds.LifeBonus);
	}

	void GameController_IsBonusX2 ()
	{
			PlaySound (Sounds.PowerUpX2);
	}

	void GameController_IsBOnusShield ()
	{
			PlaySound (Sounds.ShieldBonus);
	}

	void GameController_IsBonusMagnetic ()
	{
			PlaySound (Sounds.MagneticBonus);
	}

	void GameController_IsBonusCoin ()
	{
			PlaySound (Sounds.CoinBonus);
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
			case Sounds.MagneticBonus:
				audioSource.clip = MagneticBonus;
			break;
			case Sounds.CoinBonus:
				audioSource.clip = CoinBonus;
			break;
			case Sounds.LifeBonus :
				audioSource.clip = LifeBonus;
			break;
			case Sounds.ShieldBonus:
				audioSource.clip = ShieldBonus;
			break;
			case Sounds.PowerUpX2:
				audioSource.clip = PowerUpX2;
			break;
		}

		audioSource.Play ();
	}

	public enum Sounds {
		MagneticBonus,
		CoinBonus,
		LifeBonus,
		ShieldBonus,
		PowerUpX2,
	}
}
}