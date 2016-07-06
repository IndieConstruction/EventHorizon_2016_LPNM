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
		FMOD_SoundManager fm;

        public int BonusPoints;
        public int BonusMultiplier;
		private int DistancePoint = 2;
        private int DistanceSound = 3;
        public int LifeToAdd = 1;
        private int TakeBonus = 2;
        private int NearlyBonus = 3;
        private int Nothing = 0;
        
		bool isBonusActive;

		public bool IsShield;
		float bonusShieldTimer = 0.0f;
		public float BonusShielTimer;

		public bool IsMagnetic;
		bool IsMoving;
        float bonusMagneticTimer = 0.0f;
		public float BonusMagneticTimer;

        // Use this for initialization
        void Awake(){
			//GameController.OnBonusTaken += GameController_OnBonusTaken;
            p = FindObjectOfType <Player>();
            gc = FindObjectOfType<GameController>();
            hd = FindObjectOfType<HudManager>();
			sc= FindObjectOfType<SoundController>();
			fm = FindObjectOfType<FMOD_SoundManager>();
        }

		void Start(){
			isBonusActive = false;
			
		}

//        void GameController_OnBonusTaken ()
//        {
//			
//        }

       

        // Update is called once per frame
        void Update(){
			// Sposta il Bonus verso il Player se IsMoving è = True.
			if (p.transform.position != this.transform.position && IsMoving == true) {
				bonusMagneticTimer = bonusMagneticTimer + Time.deltaTime;
				//transform.Translate(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z)*Time.deltaTime*0.1f);
				transform.position = Vector3.MoveTowards(this.transform.position, p.transform.position, 1);
				if(p.transform.position == this.transform.position){
					//IsMoving = false;
				
				if(bonusMagneticTimer >= BonusMagneticTimer){
					IsMoving = false;
					bonusMagneticTimer = 0;
					}}
			}
				if (isBonusActive == true && IsShield == true) {
					bonusShieldTimer = bonusShieldTimer + Time.deltaTime;
				if (bonusShieldTimer >= BonusShielTimer) {
						IsShield = false;
						bonusShieldTimer = 0;
					}
				}
       }
        
		void OnTriggerEnter(Collider other) {
			if(other.GetComponent<Player>() == null){
				return;
			}
			fm.PlayerCoin();
			int Distance = CalculateDistance(Vector3.Distance(this.transform.position, p.transform.position));
			if (IsMagnetic == true) {
				p.ActiveMagneticManager(BonusMagneticTimer);
			}
			if (IsShield == true) {
				IsBonusShield ();
			}
            if (p != null && Distance == TakeBonus)
            {
				Debug.Log("Preso! "+Distance);
                sc.HandleOnBonusTaken();
                if(p.PlayerLife<3)
                p.PlayerLife = p.PlayerLife + LifeToAdd;
                gc.scoreCounter = gc.scoreCounter + BonusPoints;//aumento lo score
                gc.Multiplier = gc.Multiplier + BonusMultiplier;//aumento del moltiplicatore
                hd.UpdateHud();//aggiorna l'hud
                gc.MultiplierLimiter();//non deve superare il 10
				//foreach (var item in gameObject.GetComponentsInChildren<MeshRenderer>()) 
				//{ 
				this.gameObject.SetActive(false);
				//}
            }
            else if (Distance==NearlyBonus)
            {
                sc.OnNearBonus();
                Debug.Log("Quasi vicino "+ Vector3.Distance(this.transform.position, p.transform.position));
				this.gameObject.SetActive(false);
            }               
			
        }
		#region API
		public void GoToPosition(){
			IsMoving= true;
		}
		#endregion
			
		public void IsBonusShield() {
				isBonusActive = true;

		}
				//se collidi con unmalus non perdi ne vita ne moltiplicatore e perdi lo scudo

					

//			}
//		}

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
