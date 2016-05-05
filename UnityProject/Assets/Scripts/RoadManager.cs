using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace EH.LPNM{
public class RoadManager : MonoBehaviour   {



        /// <summary>
        /// Indica il numero di Road in scena
        /// </summary>
        //public int MaxRoadsInGame = 6;
        //public GameObject [] RoadMesh;
        public GameController gc;
        float RoadLenght = 10;
		public int speedA ;
		public int speedB ;
		public int speedC ;
		public int speedD ;
		public int speedE ;
		int speed;
		/// <summary>
		/// Lista di GameObject in scena.
		/// </summary>
		List <GameObject> Roads = new List<GameObject>();
 
        void Awake (){

		}
		
		void Start(){
			
		}
		
		void Update(){
			if(gc.Multiplier ==0 && gc.Multiplier <= 2){
				speed = speedA;
			}
			if (gc.Multiplier >=3 && gc.Multiplier <= 4) {
				speed = speedB;
			}
			if (gc.Multiplier >=5 && gc.Multiplier <= 6) {
				speed = speedC;
			}
			if (gc.Multiplier >=7 && gc.Multiplier <= 8) {
				speed = speedD;
			}
			if (gc.Multiplier >=9 && gc.Multiplier <= 10) {
				speed = speedE;
			}
			transform.Translate (Vector3.back * Time.deltaTime * speed);
			}

		

		/// <summary>
		/// Calcolo il punto di riposizionamento della Road da riposizionare calcolandola così: posizione della road + (lunghezzaRoad * (lunghezza della lista delle roads -1)).
		/// </summary>
		/// <param name="objectToReposition">Object to reposition.</param>
		/// <param name="newPosition">New position.</param>
		public void Reposition(GameObject objectToReposition){
			int ListRoadsLenght = Roads.Count -1;
			Vector3 ActualRoadPosition = objectToReposition.transform.position;
			objectToReposition.transform.position =new Vector3 (ActualRoadPosition.x,ActualRoadPosition.y- (RoadLenght*2), ActualRoadPosition.z );
		}
		
//		public void OnTriggerEnter(Collider other){
//
//			Reposition (this.gameObject);
//		}

		
		
	}
}
