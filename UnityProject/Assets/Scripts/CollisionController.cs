using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public class CollisionController : MonoBehaviour {
	
	public GameController gc;
	public int DistanceX = 1; 
	public int DistanceY = 2; 
	
	void OnTriggerEnter(Collider other){
			///
			Player p = gameObject.GetComponent<Player>();
			Letter letter = other.gameObject.GetComponent<Letter>();
			//
			if (letter != null){
			if(p.Letter == letter.IDLetter){

				float distanceResult = Vector3.Distance(p.transform.position, letter.transform.position);
				Vote vote = calculate(distanceResult);
					Debug.Log("Lettera è = ed è a distanza di : "  + distanceResult + "Punteggio è : " + vote);
			}else {
				float distanceResult = Vector3.Distance(p.transform.position, letter.transform.position);
				Vote vote = calculate(distanceResult);
				gc.OnPointsToAdd(Vote.wrongLetter,distanceResult);
				Debug.Log ("Lettera è sbagliata");
			}
			}
	}
		public enum Vote
		{Perfect,
			Good,
			Poor,
			wrongLetter,
			
		}


	Vote calculate (float distanceResult){
			gc.DistanceResult = distanceResult;
		if (distanceResult <= DistanceX) {
				Debug.LogFormat ("Perfect! {0} ", distanceResult); //format permette di mettere le graffe, e di riempirle con cio' che scrivo dopo
				gc.OnPointsToAdd(Vote.Perfect,distanceResult);
				return Vote.Perfect;
		}else if (distanceResult>DistanceX && distanceResult<DistanceY ) { 
				Debug.LogFormat ("Good! {0} ", distanceResult);
				gc.OnPointsToAdd(Vote.Good,distanceResult);
				return Vote.Good;	
		}else{
				gc.OnPointsToAdd(Vote.Poor,distanceResult);
				Debug.LogFormat ("Poor! {0}",distanceResult); 
				return Vote.Poor;
			}
		}

	}
	}

