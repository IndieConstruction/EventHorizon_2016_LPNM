using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EH.LPNM
{
    public class HudGameOver : MonoBehaviour
    {
        SaveScore ScoreS;
        public Text ScorePoint;
        public Text GameOver;
        public Button Next;
        // Use this for initialization
        void Start()
        {
            ScoreS = FindObjectOfType<SaveScore>();
            ScorePoint.text = ScoreS.Score;
            if (ScoreS.Complete == true)
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
            Destroy(ScoreS.gameObject);
            SceneManager.LoadScene("ProjectLPNM");
          
        }

        public void LoadNextScene()
        {
            Destroy(ScoreS.gameObject);
            SceneManager.LoadScene(ScoreS.LoadLev);

        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}