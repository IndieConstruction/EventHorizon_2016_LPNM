using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class Bonus : MonoBehaviour
    {
        Player p;
        HudManager hd;
        GameController gc;
        public int BonusPoints;
        public int BonusMultiplier;
		SoundController sc;
        // Use this for initialization
        void Awake(){
			//GameController.OnBonusTaken += GameController_OnBonusTaken;
            p = FindObjectOfType <Player>();
            gc = FindObjectOfType<GameController>();
            hd = FindObjectOfType<HudManager>();
			sc= FindObjectOfType<SoundController>();
        }

		void Start(){
			
		}

//        void GameController_OnBonusTaken ()
//        {
//			
//        }

       

        // Update is called once per frame
        void Update()
        {
        }
        
		void OnTriggerEnter(Collider other) {
            if (p != null) {
			sc.HandleOnBonusTaken();
            gc.scoreCounter = gc.scoreCounter + BonusPoints;//aumento lo score
            gc.Multiplier = gc.Multiplier + BonusMultiplier;//aumento del moltiplicatore
            hd.UpdateHud();//aggiorna l'hud
            gc.MultiplierLimiter();//non deve superare il 10
            this.gameObject.SetActive(false);
            }
        }
    }
}
