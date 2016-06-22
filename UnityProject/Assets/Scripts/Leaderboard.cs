using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour {
    public ArrayList LeaderboardPoint=new ArrayList(10);
	private string Save;

    void Start () {
		for (int i = 0; i < 10; i++)
			LeaderboardPoint.Insert (i, i + "");
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
		TempName=	ReturnName ("Temp", '|');
		TempScore=	ReturnScore ("Temp", '|');
	//	SplitTemp("Temp",'|',TempName,TempScore);
    //    int n = 0;
        if (LeaderboardPoint.Count>0)
        {
			int n = 0;
            foreach (string Point in LeaderboardPoint)
            {
				string TempPointScore = PlayerPrefs.GetString(LeaderboardPoint.IndexOf(Point)+"");
                //	SplitTemp (Point, '|', TempPointName, TempPointScore);
				TempPointScore=	ReturnScore (n+"", '|');
				n++;
                if (TempScore.CompareTo(TempPointScore)>0)
                {
                    // PlayerPrefs.SetString(NameArrayLeaderboard + n, TempScore+"|"+TempName);
                    Save = Point;
                    break;
                }
            }
			if (Save != null) {
				
				OrderArray (LeaderboardPoint, Save, TempName);
				PlayerPrefs.SetString (LeaderboardPoint.IndexOf(Save)+"",TempName+'|'+ TempScore);
				PlayerPrefs.Save ();

			} else if (LeaderboardPoint.Count < 10) {
				int count = LeaderboardPoint.Count+1;
				LeaderboardPoint.Add(count);
				PlayerPrefs.SetString(count+"", TempName+'|'+ TempScore);
				PlayerPrefs.Save();
			}
		}
        else
        {
			int count = LeaderboardPoint.Count;
			LeaderboardPoint.Add(count);
			PlayerPrefs.SetString(count+"", TempName+'|'+ TempScore);
            PlayerPrefs.Save();
        }




	}

	public void RenamePrefs(){
	}

 public void StampArray()
    {
        GetRegister();

        //   foreach (string Point in LeaderboardPoint)
       for(int i=0;i<LeaderboardPoint.Count-1;i++)
        {
			Debug.Log("Name: "+ReturnName(i+"",'|')+" Point: "+ReturnScore(i+"",'|'));
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

	string ReturnName(string str, char del)
	{
		string temp = PlayerPrefs.GetString (str);
		string[] TempSplit = temp.Split (del);
		return TempSplit [0];
	}

	string ReturnScore(string str, char del)
	{
		string temp = PlayerPrefs.GetString (str);
		string[] TempSplit = temp.Split (del);
		return TempSplit [1];
	}

	}

