using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class Bonus : MonoBehaviour
    {
        Player p;
        HudManager hd;
        GameController gc;
        SoundController sc;

        public int BonusPoints;
        public int BonusMultiplier;
        public int DistancePoint = 1;
        public int DistanceSound = 2;
        public int LifeToAdd = 1;
        private int TakeBonus = 1;
        private int NearlyBonus = 2;
        private int Nothing = 0;
        
		public bool IsShield;
		float bonusShieldTimer = 0.0f;

		public bool IsMagnet;
		float bonusMagneticTimer = 0.0f;

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
			IsBonusShield();
			//IsBonusMagnetic();
        }
        
		void OnTriggerEnter(Collider other) {
            float Distance = CalculateDistance(Vector3.Distance(this.transform.position, p.transform.position));

            if (p != null && Distance == TakeBonus)
            {
                Debug.Log("Preso! "+ Vector3.Distance(this.transform.position, p.transform.position));
                sc.HandleOnBonusTaken();
                p.PlayerLife = p.PlayerLife + LifeToAdd;
                gc.scoreCounter = gc.scoreCounter + BonusPoints;//aumento lo score
                gc.Multiplier = gc.Multiplier + BonusMultiplier;//aumento del moltiplicatore
                hd.UpdateHud();//aggiorna l'hud
                gc.MultiplierLimiter();//non deve superare il 10
                this.gameObject.SetActive(false);
            }
            else if (Distance==NearlyBonus)
            {
                sc.OnNearBonus();
                Debug.Log("Quasi vicino "+ Vector3.Distance(this.transform.position, p.transform.position));
				this.gameObject.SetActive(false);
            }               

        }

//		public void IsBonusMagnetic() {
//			
//            if (IsMagnet == true) {
//				//GetComponentInChildren<SphereCollider>().enabled=true;
//				bonusMagneticTimer = bonusMagneticTimer +Time.deltaTime;
//                transform.Translate(new Vector3(p.transform.position.x, p.transform.position.y,this.transform.position.z));
//				if(bonusMagneticTimer >= 10){
//					IsMagnet = false;
//					bonusMagneticTimer = 0;
//				}
//            }
//        }
			
		public void IsBonusShield() {
			if(IsShield == true){
				bonusShieldTimer = bonusShieldTimer + Time.deltaTime;
				if (bonusShieldTimer >=10) {
				IsShield = false;
					bonusShieldTimer = 0;
				}
				//se collidi con unmalus non perdi ne vita ne moltiplicatore e perdi lo scudo

					

			}
		}

        /// <summary>
        /// Calcolo della distanza dal centro del Bonus e la collisione del player
        /// </summary>
        /// <param name="DistanceResult"></param>
        /// <returns></returns>
        int CalculateDistance(float DistanceResult)
        {
            if (DistanceResult <= DistancePoint)
            {
                return TakeBonus;
            }
            else if (DistanceResult <= DistanceSound)
            {
                return NearlyBonus;
            }
            else return Nothing;
        }
    }
}
