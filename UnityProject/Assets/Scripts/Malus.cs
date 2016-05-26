using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class Malus : MonoBehaviour{

        Player p;
        GameController gc;
        public int DamageToDo;
        // Use this for initialization
        void Start()
        {
            gc = FindObjectOfType<GameController>();
            p = FindObjectOfType<Player>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider other)   
        {
            if (p!= null)
            {
                if (gc.Multiplier >= 1) {
                    gc.Multiplier = 0;
                }
                else
                {
                    p.PlayerLife -= DamageToDo;
                }

            }
            this.gameObject.SetActive(false);
        }
    }
}