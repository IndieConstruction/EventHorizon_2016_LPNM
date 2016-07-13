using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace EH.LPNM
{
	public class Register : MonoBehaviour {
    //Array con lettere per inserimento nome
    private string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int Indice = 0;
    public Text NamePlayer;
    private string LetterVisual;
    private string StringComplete ="";
	public GameController gc;
        FMOD_SoundManager fm;
    // Use this for initialization
    void Start () {
            fm = FindObjectOfType<FMOD_SoundManager>();
			gc=FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (StringComplete.Length < 3) {//limite di lettere possibili
			if (Input.GetKeyDown (KeyCode.UpArrow)) {//se entra, aumenta l'indice di riferimento all'array, cambiando di fatti lettera
                    fm.MenuSelect();
				if (Indice != Alphabet.Length - 1)
					Indice++;
				else // se l'indice raggiunge il limite, torna accapo
                    Indice = 0;
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {//se entra, diminuisce l'indice di riferimento all'array, cambiando di fatti lettera
                    fm.MenuSelect();
                    if (Indice != 0)
					Indice--;
				else // se l'indice raggiunge il limite, setta l'ultima lettera dell'array
                    Indice = Alphabet.Length - 1;

			}

			LetterVisual = Alphabet [Indice]; //Lettera attualmente selezionata
			NamePlayer.text = StringComplete + LetterVisual; //Visualizza sulla hud la stringa completa insieme alla lettera in selezione

			if (Input.GetKeyDown (KeyCode.KeypadEnter)) { // aggiunge alla stringa completa quella attualmente selezionata
				StringComplete = StringComplete + LetterVisual;
				NamePlayer.text = StringComplete;
			}
		} else {
				PlayerPrefs.SetString ("Temp", StringComplete + '|' + gc.ScoreCounter.ToString());
				PlayerPrefs.Save();
		}
      

    }

	}
}