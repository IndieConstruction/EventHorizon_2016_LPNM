using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public class InputRayController : MonoBehaviour {
		public int speed = 5;
		public string TagName = "Terrain";
		Transform target;
		
		void Start() {
			target = transform;
		}

	void FixedUpdate(){
		//	if(Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				
				if (Physics.Raycast(ray, out hit)) {
					if(hit.collider.gameObject.tag != TagName){
						return;
					}
					target.position = hit.point;
				//	Debug.Log ("Sto Raycatando");
					
				}
			//}
			//Move ();
	}
//		void Move () {
//			float speed = 5.0f;
//			float translationZ = Input.GetAxisRaw("Vertical") *speed;
//			float translationX = Input.GetAxisRaw("Horizontal") * speed;
//			translationZ *= Time.deltaTime;
//			translationX *= Time.deltaTime;
//			
//			transform.Translate(translationX, 0, 0);
//			transform.Translate(0, translationZ, 0);
			
		}
	
	}
