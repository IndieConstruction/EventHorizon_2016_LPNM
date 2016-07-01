using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class Malus : MonoBehaviour{

	    public	FMOD_SoundManager fm;
        public Player p;
        public GameController gc;
        public int DamageToDo;
        // Use this for initialization
        void Start()
        {
            gc = FindObjectOfType<GameController>();
            p = FindObjectOfType<Player>();
			fm = FindObjectOfType<FMOD_SoundManager>();
        }


        // Update is called once per frame
        void Update()
        {

        }
        public void OnTriggerEnter(Collider other)   {	
			Bonus b;
			b = FindObjectOfType<Bonus>();
			if (p!= null && b.IsShield == false)
            {
                if (gc.Multiplier >= 1) {
                    gc.Multiplier = 0;
                }
                else
                {
                    p.PlayerLife -= DamageToDo;
					fm.PlayerObjectHit();
                }

            }
            this.gameObject.SetActive(false);
        }
    }
}