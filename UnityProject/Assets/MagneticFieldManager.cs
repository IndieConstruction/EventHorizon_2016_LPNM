using UnityEngine;
using System.Collections;
namespace EH.LPNM{
	/// <summary>
	/// fa accadere il campo magnetico per il BonusMagnetico
	/// </summary>
	public class MagneticFieldManager : MonoBehaviour {

		float magneticFieldDuration;
		bool isMagneticFieldActive = false;

		void OnTriggerEnter(Collider other){
			// controllo se è un Bonus
			Bonus b = other.GetComponent<Bonus>();
			if(b != null){
				b.GoToPosition();
			} 	
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if(isMagneticFieldActive == false){
				return;
			}
			magneticFieldDuration = magneticFieldDuration-Time.deltaTime;
			if(magneticFieldDuration<= 0){
				GetComponent<SphereCollider>().enabled=false;
				isMagneticFieldActive = false;
				magneticFieldDuration = 0;
			}
		}

		#region API
		public void StartMagneticField(float MagneticFieldDuration){
			isMagneticFieldActive = true;
			GetComponent<SphereCollider>().enabled=true;
			magneticFieldDuration = MagneticFieldDuration;
		} 
		#endregion
	}
}