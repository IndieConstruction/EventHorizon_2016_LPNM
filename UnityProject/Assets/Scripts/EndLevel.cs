using UnityEngine;
using System.Collections;

namespace EH.LPNM{
public class EndLevel : MonoBehaviour {
		GameController gc;
		Player p;
	// Use this for initialization
	void Start () {
			gc = FindObjectOfType<GameController> ();
			p = FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		void OnTriggerEnter(Collider other)
		{
			if (p != null&&other.gameObject==p.gameObject){
				gc.StopPlay ();
				gc.GameOverActive ();
			}
		}

	}
}