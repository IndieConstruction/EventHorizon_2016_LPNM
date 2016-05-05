using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public class Letter : MonoBehaviour {

	public GameController gc;
	public string IDLetter ;
	public float speed ;
	// Use this for initialization
	void Start () {
			gc =FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
//			if(gc.Multiplier ==0 && gc.Multiplier <= 2){
//				speed = 3;
//			}
//			if (gc.Multiplier >=3 && gc.Multiplier <= 5) {
//				speed = 5;
//			}
//			if 
//			(gc.Multiplier >= 5){
//				speed = 10;
//			}
//			transform.Translate (Vector3.back * Time.deltaTime * speed);
	}
	
		void OnTriggerEnter(Collider other){
			this.gameObject.SetActive(false);
		}
}
}