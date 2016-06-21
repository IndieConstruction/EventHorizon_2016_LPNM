using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour {
	public string[] LeaderboardPoint= new string[10];
	private string Save;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
/*	void InitializeArray(){
		foreach (string Point in LeaderboardPoint) {
			Point = PlayerPrefs.GetString ();	
		}
	}*/

	void GetRegister(){
	/*	Temp = PlayerPrefs.GetString ("Temp");
		string[] TempSplit = Temp.Split ("|");
		string TempName = TempSplit [0];
		string TempScore = TempSplit [1];
*/
		string TempName="",TempScore="";
		SplitTemp("Temp",'|',TempName,TempScore);

		foreach (string Point in LeaderboardPoint) {
			string TempName2="", TempScore2="";
			SplitTemp (Point, '|', TempName2, TempScore2);

			if (int.Parse(TempScore) > int.Parse(TempScore2)) {
				Save = Point;
				break;
			}
		}





	}

		void OrderArray()
		{
						
		}

	void SplitTemp(string str, char del, string temp1, string temp2)
	{
		string temp = PlayerPrefs.GetString (str);
		string[] TempSplit = temp.Split (del);
		temp1 = TempSplit [0];
		temp2 = TempSplit [1];
	}


	}

