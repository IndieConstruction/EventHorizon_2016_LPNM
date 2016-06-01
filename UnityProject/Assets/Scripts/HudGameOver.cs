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

        public void LoadFirstScene()
        {
            SceneManager.LoadScene("ProjectLPNM");
        }

        public void LoadNextScene()
        {
			SceneManager.LoadScene(gc.LoadLevel);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}