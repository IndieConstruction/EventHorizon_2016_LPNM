using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace EH.LPNM
{
    public class Start : MonoBehaviour
    {

        // Use this for initialization
        public Image ready;
        public Image steady;
        public Image go;

        // Update is called once per frame
        void Update()
        {

        }

       public void Ready_set()
        {
			ready.gameObject.SetActive(true);
        }

        public void Ready_unset()
        {
			ready.gameObject.SetActive(false);

        }

       public void Steady_set()
           {
			steady.gameObject.SetActive(true);

        }

      public  void Steady_unset()
        {
			steady.gameObject.SetActive(false);

        }

      public  void Go_set()
        {
			go.gameObject.SetActive(true);

        }

       public void Go_unset()
        {
			go.gameObject.SetActive(false);

        }


    }
}
