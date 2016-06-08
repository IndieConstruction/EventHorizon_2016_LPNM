using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EH.LPNM
{
    public class HudGameOver : MonoBehaviour
    {
		GameController gc;
		HudManager hd;
        public Text ScorePoint;
        public Text GameOver;
        public Button Next;
        // Use this for initialization
        void Start()
        {
			gc = FindObjectOfType<GameController>();
			hd = FindObjectOfType<HudManager>();

			ScorePoint.text = hd.ScoreText.text;

            //Se si ha superato il livello viene scritto Success! e abilita il bottone per il livello successivo, altrimenti Game Over
            if (gc.Complete == true)
            {
                GameOver.text = "Success!";
                Next.gameObject.SetActive(true);
            }
            else
            {
                GameOver.text = "Game Over";
                Next.gameObject.SetActive(false);
            }


        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Carica la prima scena
        /// </summary>
        public void LoadFirstScene()
        {
            SceneManager.LoadScene("ProjectLPNM");
        }
        /// <summary>
        /// carica la scena contenuto in LoadLevel
        /// </summary>
        public void LoadNextScene()
        {
			SceneManager.LoadScene(gc.LoadLevel);
        }
        /// <summary>
        /// Quitta il gioco
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}