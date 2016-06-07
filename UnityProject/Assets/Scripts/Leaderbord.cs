using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderbord : MonoBehaviour {
    private string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int Indice = 0;
    public Text Name;
    private string backup;
    private string backup2 ="";
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Indice != Alphabet.Length-1)
                Indice++;
            else
                Indice = 0;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Indice != 0)
                Indice--;
            else
                Indice = Alphabet.Length-1;

        }

        backup = Alphabet[Indice];
        Name.text = backup2 + backup;
        Debug.Log(Alphabet[Indice]);

        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            backup2 = backup2 + backup; 
        }

        Name.text = backup2;

    }
}
