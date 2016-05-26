using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EH.LPNM{
public class HudManager : MonoBehaviour {

    Player p;
	public Text PlayerLifeText;
	public Text ScoreText;
	public Text BonusVoteText;
	public Text PointDistanceText;
	public Text MultiplierText ;
	public GameController gc;
    public HudGameOver HudGameOver;
    public string Score;
	//public int scoreCounter;
	//public bool isEnable = false;

	void Start(){

            p = FindObjectOfType<Player>();
			ScoreText.text ="Score : " + gc.scoreCounter;
            MultiplierText.text = "Multiplier : " + gc.Multiplier;
            PlayerLifeText.text = "Life : " + p.PlayerLife;


	}
	void Awake(){
	}
	void Update () {
//			if(gc.scoreCounter == 10)
//				Debug.Log("YouWin");
		}
	
	public void UpdateHud (){
		ScoreText.text ="Score : " + gc.scoreCounter ;
		MultiplierText.text = "Multiplier : "+ gc.Multiplier;
            PlayerLifeText.text = "Life :" + p.PlayerLife;
            Score = ScoreText.text;

        }
	
	public void OnCollisionVote(string BonusText, float distanceResult){
		BonusVoteText.text = "  " + BonusText  ;
		PointDistanceText.text = "DistancePoint :  " + distanceResult;
		PlayerLifeText.text = "Life :" + p.PlayerLife;

		
	}

      

    }
}

