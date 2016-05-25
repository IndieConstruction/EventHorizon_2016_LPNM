using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class LimitMalus : MonoBehaviour
    {
        Player p;
        GameController gc;
        HudManager hd;
        bool first = true;
        float countSave;
        // Use this for initialization
        void Start()
        {
            p = FindObjectOfType<Player>();
            gc = FindObjectOfType<GameController>();
            hd = FindObjectOfType<HudManager>();
            countSave = gc.CountCollider;
        }

        // Update is called once per frame
        void Update()
        {
            hd.UpdateHud();
            UpdateTime();
        }

        void OnTriggerEnter(Collider other)
        {
            
            if (p != null&&other.gameObject==p.gameObject)
            {

                Debug.Log("collisione limit");
                
                if (countSave <= 0)
                {
                    
                    countSave = gc.CountCollider;

                    if (gc.Multiplier >= 1)
                    {
                        Debug.Log("multiplier " + gc.Multiplier);
                        gc.Multiplier--;
                    }
                    else
                    {
                        Debug.Log("life " + p.PlayerLife);
                        p.PlayerLife--;
                    }
                }
                else
                {
                    //Attivare invulnerabilità
                }
            }

        }
        /// <summary>
        /// Aggiorna la variabile countSave della classe LimitMalus sottraendole il deltaTime
        /// </summary>
        /// <param name="count"></param>
        private void UpdateTime()
        {
            countSave = (countSave - Time.deltaTime);
        }
    }
}