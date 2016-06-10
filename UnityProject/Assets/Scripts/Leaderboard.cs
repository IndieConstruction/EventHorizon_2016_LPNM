using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour {
	public string[] LeaderboardPoint= new string[10];
	private string Temp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void InitializeArray(){
		foreach (string Point in LeaderboardPoint) {
			Point = PlayerPrefs.GetString ();	
		}
	}
	/*
	void GetRegister(){
		Temp = PlayerPrefs.GetString ("Temp");
		string[] TempSplit = Temp.Split ("|");
		string TempName = TempSplit [0];
		string TempScore = TempSplit [1];
		int count = 0;
		foreach (string Point in LeaderboardPoint) {
			if (TempScore > Point) {
				
			}

			count++;
		}
	}
		void OrderArray()
		{
						
		}


	}

*/
}