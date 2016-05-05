using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public class OnNextLevel : MonoBehaviour {
	public GameController gc;
	

	void OnTriggerEnter(Collider other){

			if(gc.scoreCounter >= gc.Score4NextLevel ){
			Application.LoadLevel("LevelTwo");
			Debug.Log("Nextlevel");
	}
	}
}
}