using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EH.LPNM
{
    public class HudStart : MonoBehaviour
    {
        private FMOD_SoundManager fm;
        // Use this for initialization
        void Start()
        {
            fm = FindObjectOfType<FMOD_SoundManager>();
            fm.Music_Menu();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadFirstScene()
        {
            fm.MenuPauseInOut();
            SceneManager.LoadScene("LevelOne");
            fm.Music_Menu_Off();

        }
        

        public void QuitGame()
        {
            fm.MenuPauseInOut();
            Application.Quit();
        }
    }
}