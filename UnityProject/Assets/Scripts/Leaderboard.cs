using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour {
    public ArrayList LeaderboardPoint=new ArrayList(10);
	private string Save;

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

public void GetRegister(){
	/*	Temp = PlayerPrefs.GetString ("Temp");
		string[] TempSplit = Temp.Split ("|");
		string TempName = TempSplit [0];
		string TempScore = TempSplit [1];
*/
		string TempName="",TempScore="";
		SplitTemp("Temp",'|',TempName,TempScore);
        int n = 0;
        if (LeaderboardPoint.Count>0)
        {
            foreach (string Point in LeaderboardPoint)
            {
                string TempPointScore = PlayerPrefs.GetString(Point);
                //	SplitTemp (Point, '|', TempPointName, TempPointScore);

                if (TempScore.CompareTo(TempPointScore)>0)
                {
                    // PlayerPrefs.SetString(NameArrayLeaderboard + n, TempScore+"|"+TempName);
                    Save = Point;
                    break;
                }
            }

            OrderArray(LeaderboardPoint, Save, TempName);
            PlayerPrefs.SetString(TempName, TempScore);
            PlayerPrefs.Save();
        }
        else
        {
            LeaderboardPoint.Add(TempName);
            PlayerPrefs.SetString(TempName, TempScore);
            PlayerPrefs.Save();
        }




	}

 public void StampArray()
    {
        GetRegister();

        //   foreach (string Point in LeaderboardPoint)
       for(int i=0;i<LeaderboardPoint.Count;i++)
        {
            Debug.Log("Name: "+LeaderboardPoint[i]+" Point: "+PlayerPrefs.GetString(LeaderboardPoint[i].ToString()));
        }

    }

		void OrderArray(ArrayList Array,string Obj,string ObjAdd)
		{
            Array.Insert(Array.IndexOf(Obj), ObjAdd);
        					
		}

	void SplitTemp(string str, char del, string temp1, string temp2)
	{
		string temp = PlayerPrefs.GetString (str);
		string[] TempSplit = temp.Split (del);
		temp1 = TempSplit [0];
		temp2 = TempSplit [1];
	}


	}

