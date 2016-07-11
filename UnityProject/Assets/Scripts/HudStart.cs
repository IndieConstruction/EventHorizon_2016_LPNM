using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace EH.LPNM
{
    public class HudStart : MonoBehaviour
    {
		public GameObject Wall, BlackWall;
		bool AudioOFF;
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


		public void AudioSwitchOFF()
		{	
			if(AudioOFF == false){
			AudioOFF = true;
			GetComponentInChildren<Animator>().enabled = true;
			fm.MenuPauseInOut();
			fm.enabled = false;
			}
		}

		public void AudioSwitchON()
		{ if(AudioOFF == true ){ 
			GetComponentInChildren<Animator>().enabled = false;
			fm.MenuPauseInOut();
			fm.enabled = true;
			AudioOFF = false;
			}
		}

		public void Credits (){
			fm.MenuPauseInOut();
			if (BlackWall.gameObject.active == false) {
				BlackWall.SetActive (true);
				Wall.SetActive (false);
			} else {
				BlackWall.SetActive (false);
				Wall.SetActive (true);
			}
		}
		public void Levels (){
			fm.MenuPauseInOut();

		}
    }
}