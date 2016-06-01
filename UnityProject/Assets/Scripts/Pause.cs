using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EH.LPNM
{
    public class Pause : MonoBehaviour
    {
        GameController gc;
        HudManager hd;
        // Use this for initialization
        void Start()
        {
            gc = FindObjectOfType<GameController>();
            hd = FindObjectOfType<HudManager>();
          
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ResumeGame()
        {
            gc.PauseActive();
        }
    }
}