using UnityEngine;
using System.Collections;
namespace EH.LPNM{

public class Propeller : Malus  {

		public float speed = 1;

	// Use this for initialization
	void Start ()
        {
            gc = FindObjectOfType<GameController>();
            p = FindObjectOfType<Player>();

        }
	
	// Update is called once per frame
	void Update () {
			SpeedRotation();
	
	}

		void SpeedRotation(){
			Animator anm = GetComponent<Animator>();
			anm.speed = speed; 

		}
}
}