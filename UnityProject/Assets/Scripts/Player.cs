using UnityEngine;
using System.Collections;
namespace EH.LPNM{
public class Player : MonoBehaviour {

	public string Letter;
	public MeshFilter[] MeshesLetter;
	
	void Start(){
	//Letter = "A";
	}
	void Update(){

		}
	void FixedUpdate(){

		}


	public void MeshChange (string rightLetter){
	
	MeshFilter rightMeshLetter;
	rightMeshLetter = GetComponentInChildren<MeshFilter>();
	switch (rightLetter){ 
			case "M":
				//SharedMesh è il sottocomponente che mi permette di cambiare il MeshFilters.
				rightMeshLetter.sharedMesh = MeshesLetter[0].sharedMesh; 
				break;
			case "A":
				rightMeshLetter.sharedMesh = MeshesLetter[1].sharedMesh; 
				break;
			case "V":
				rightMeshLetter.sharedMesh = MeshesLetter[2].sharedMesh; 
				break;
			case "X":
				rightMeshLetter.sharedMesh = MeshesLetter[3].sharedMesh; 
				break;
			case "E":
				rightMeshLetter.sharedMesh = MeshesLetter[4].sharedMesh; 
				break;
			case "S":
				rightMeshLetter.sharedMesh = MeshesLetter[5].sharedMesh; 
				break;
			case "D":
				rightMeshLetter.sharedMesh = MeshesLetter[6].sharedMesh; 
				break;
			case "Z":
				rightMeshLetter.sharedMesh = MeshesLetter[7].sharedMesh; 
				break;
			case "W":
				rightMeshLetter.sharedMesh = MeshesLetter[8].sharedMesh; 
				break;
			case "C":
				rightMeshLetter.sharedMesh = MeshesLetter[9].sharedMesh; 
				break;
			default:
				Debug.Log("Non conosco la lettera");
				break;
			}
		}
	}
	}
