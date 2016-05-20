using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class LimitMalus : MonoBehaviour
    {
        Player p;
        GameController gc;
        HudManager hd;

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
            UpdateTime(gc.CountCollider);
        }

        void OnTriggerEnter(Collider other)
        {
            
            if (p != null)
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
        private void UpdateTime(float count)
        {
            countSave = (countSave - Time.deltaTime);
        }
    }
}