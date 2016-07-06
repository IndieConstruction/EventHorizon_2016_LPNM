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
		if ((PlayerPrefs.GetString(LeaderboardPoint[9].ToString())).Length>1)
        {
			//int n = 0;
			int s = 0;
			int p = 0;
			int i = LeaderboardPoint.Count - 1;
			for (;i >= 0 ; i--)
            {
				if ((PlayerPrefs.GetString(LeaderboardPoint[i].ToString())).Length>1)
				{
					//string TempPointScore = PlayerPrefs.GetString (LeaderboardPoint.IndexOf (Point) + "");
					//	SplitTemp (Point, '|', TempPointName, TempPointScore);
					string TempPointScore =	ReturnScore (i + "", '|');
					//n++;
					p = int.Parse (TempPointScore);
					s = int.Parse (TempScore);
					if (s>p) {
						// PlayerPrefs.SetString(NameArrayLeaderboard + n, TempScore+"|"+TempName);
						Save = LeaderboardPoint[i].ToString();
						break;
					}
				}
            }
			if (Save != null) {
				RenamePrefs (LeaderboardPoint, Save);
				//OrderArray (LeaderboardPoint, Save, TempName);
				PlayerPrefs.SetString (LeaderboardPoint.IndexOf(Save)+"",TempName+'|'+ TempScore);
				PlayerPrefs.Save ();

			} else {
				//int count = LeaderboardPoint.Count+1;
				//LeaderboardPoint.Add(count);
					PlayerPrefs.SetString(i+1+"", TempName+'|'+ TempScore);
				PlayerPrefs.Save();
			}
		}
        else
        {
			//int count = LeaderboardPoint.Count;
			//LeaderboardPoint.Add(count);
			PlayerPrefs.SetString(9+"", TempName+'|'+ TempScore);
            PlayerPrefs.Save();
        }




	}

	public void RenamePrefs(ArrayList Array,string Obj){
		int ind = Array.IndexOf (Obj);
		foreach (string Ar in Array)
			Debug.Log (PlayerPrefs.GetString(Ar));
		for (int i = 0; i > ind; i++) {
			PlayerPrefs.SetString (Array [i].ToString(), Array [i + 1].ToString());	
		}
		foreach (string Ar in Array)
			Debug.Log (PlayerPrefs.GetString(Ar));

	}

 public void StampArray()
    {
        GetRegister();

        //   foreach (string Point in LeaderboardPoint)
       for(int i=0;i<LeaderboardPoint.Count-1;i++)
        {
			if ((PlayerPrefs.GetString(LeaderboardPoint[i].ToString())).Length>1)
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
		string[] TempSplit3 = temp.Split (del);
		temp1 = TempSplit3 [0];
		temp2 = TempSplit3 [1];
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
		string[] TempSplit2 = temp.Split (del);
		return TempSplit2 [1];
	}

	}

