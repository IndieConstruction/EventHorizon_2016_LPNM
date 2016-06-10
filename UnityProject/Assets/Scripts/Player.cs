using UnityEngine;
using System.Collections;
namespace EH.LPNM{
    public class Player : MonoBehaviour {

        public bool UseGraphic;
        public TextMesh DebugText;
		GameController gc;
        Animator animator;
	

	    public string Letter;
	    public MeshFilter[] MeshesLetter;
        public int PlayerLife;

   void Start(){
			
            animator = GetComponentInChildren <Animator>();
			gc = FindObjectOfType<GameController>();
		
	
	}
			
	void Update(){

		}
	void FixedUpdate(){

		}

		void OnTriggerEnter(Collider Other){
			RoadManager rm;
			rm = FindObjectOfType<RoadManager>();
			if(Other.tag == "EndLevel"){
				rm.speedA = 0;
				rm.speedB = 0;
				rm.speedC = 0; 
				rm.speedD = 0;
				rm.speedE = 0;
                gc.EndLevelComplete();
                gc.StopInputAndTime();
				gc.CompleteLevelActive ();
			}
		}


	public void MeshChange(string rightLetter)
        {
            DebugText.gameObject.SetActive(!UseGraphic);
            DebugText.text = rightLetter;

            if (UseGraphic==true)
            {
                SkinnedMeshRenderer rightMeshLetter;
                rightMeshLetter = GetComponentInChildren<SkinnedMeshRenderer>();
                switch (rightLetter)
                {
                    case "Q":
                        animator.SetInteger("LetterNumber", 1);
                        Debug.Log("Sto settando l'animazione");
                        //SharedMesh è il sottocomponente che mi permette di cambiare il MeshFilters.
                        //rightMeshLetter.sharedMesh = MeshesLetter[0].sharedMesh;
                        break;
                    case "W":
                        animator.SetInteger("LetterNumber", 2);
                        //rightMeshLetter.sharedMesh = MeshesLetter[1].sharedMesh;
                        break;
                    case "E":
                        animator.SetInteger("LetterNumber", 3);
                        //rightMeshLetter.sharedMesh = MeshesLetter[2].sharedMesh;
                        break;
                    case "A":
                        animator.SetInteger("LetterNumber", 4);
                        //rightMeshLetter.sharedMesh = MeshesLetter[3].sharedMesh;
                        break;
                    case "S":
                        animator.SetInteger("LetterNumber", 5);
                        //rightMeshLetter.sharedMesh = MeshesLetter[4].sharedMesh;
                        break;
                    case "D":
                        animator.SetInteger("LetterNumber", 6);
                        //rightMeshLetter.sharedMesh = MeshesLetter[5].sharedMesh;
                        break;
                    case "Z":
                        animator.SetInteger("LetterNumber", 7);
                        //rightMeshLetter.sharedMesh = MeshesLetter[6].sharedMesh;
                        break;
                    case "X":
                        animator.SetInteger("LetterNumber", 8);
                        //rightMeshLetter.sharedMesh = MeshesLetter[7].sharedMesh;
                        break;
                    case "C":
                        animator.SetInteger("LetterNumber", 9);
                        //rightMeshLetter.sharedMesh = MeshesLetter[8].sharedMesh;
                        break;
                    default:
                        Debug.Log("Non conosco la lettera");
                        break;
                }
            }
        }
		public void ActiveMagneticManager(float MagneticFieldDuration){
			MagneticFieldManager mfm = GetComponentInChildren<MagneticFieldManager>();
			if (!mfm) {
				return;
			}else {
				mfm.StartMagneticField(MagneticFieldDuration);
			}	

		}
    }
}
	
