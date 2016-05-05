using UnityEngine;
using System.Collections;
namespace EH.LPNM{
	public class InputController : MonoBehaviour {

	Player p;
	private string TagName = "Terrain";
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the gameobject
	private float yAxis;
	
	void Start(){
		//save the y axis value of gameobject
		yAxis = gameObject.transform.position.y;
		if(p==null){
			p =FindObjectOfType<Player>();
		}
	}
	
	// Update is called once per frame
	void Update () {
			ChangeShape ();
		//check if the screen is touched / clicked   
	//	if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
		//{
			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the tapped / clicked position
			Ray ray = new Ray();
			//for unity editor
			#if UNITY_EDITOR
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//for touch device
			#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			#endif
			
			//Check if the ray hits any collider
			if(Physics.Raycast(ray,out hit))
			{
				if(hit.collider.gameObject.tag == TagName){
				//set a flag to indicate to move the gameobject
				flag = true;
				//save the click / tap position
				endPoint = hit.point;
		
				//as we do not want to change the y axis value based on touch position, reset it to original y axis value
				endPoint.y = yAxis;
				//Debug.Log(endPoint);
				}
			}
			
		//}
		//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
		if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){ //&& !(V3Equal(transform.position, endPoint))){
			//move the gameobject to the desired position
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag = false;
			//Debug.Log("I am here");
		}
		
	}
	void ChangeShape(){
		
		if (Input.GetKeyUp (KeyCode.A)) {
			p.Letter = ("A");
			p.MeshChange("A");
			Debug.Log(KeyCode.A.ToString());
		}
		if (Input.GetKeyUp (KeyCode.M)) {
			p.Letter = ("M");
			p.MeshChange(KeyCode.M.ToString());
			Debug.Log(KeyCode.M.ToString());
		}
		if (Input.GetKeyUp (KeyCode.V)) {
			p.Letter =("V");
			p.MeshChange("V");
			Debug.Log(KeyCode.V.ToString());
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			p.MeshChange(KeyCode.W.ToString());
			Debug.Log(KeyCode.W.ToString());
		}
		if (Input.GetKeyUp (KeyCode.E)) {
			p.MeshChange("E");
			Debug.Log(KeyCode.E.ToString());
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			p.MeshChange(KeyCode.S.ToString());
			Debug.Log(KeyCode.S.ToString());
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			p.MeshChange("D");
			Debug.Log(KeyCode.D.ToString());
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			p.MeshChange(KeyCode.Z.ToString());
			Debug.Log(KeyCode.Z.ToString());
			
		}
		if (Input.GetKeyUp (KeyCode.X)) {
			p.Letter = ("X");
			p.MeshChange("X");
			Debug.Log(KeyCode.X.ToString());
		}
		if (Input.GetKeyUp (KeyCode.C)) {
			p.MeshChange(KeyCode.C.ToString());
			Debug.Log(KeyCode.C.ToString());
		}
	}
}
}