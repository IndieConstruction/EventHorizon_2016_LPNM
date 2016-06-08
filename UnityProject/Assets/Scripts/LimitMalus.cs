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
            UpdateTime(); //inizia a sottrarre il tempo a countsave
        }

        void OnTriggerEnter(Collider other)
        {
            
            if (p != null&&other.gameObject==p.gameObject) //entra solo se si scontra col player
            {

                Debug.Log("collisione limit");
                
                if (countSave <= 0) //se countsave arriva a 0, scade l'invincibilità e subisce la penalità
                {
                    
                    countSave = gc.CountCollider; //resetta il valore di countsave

                    if (gc.Multiplier >= 1) //se il moltiplicatore è almeno 1, viene tolto un punto a quest'ultimo
                    {
                        Debug.Log("multiplier " + gc.Multiplier);
                        gc.Multiplier--;
                    }
                    else // altrimenti viene tolta una vita
                    {
                        Debug.Log("life " + p.PlayerLife);
                        p.PlayerLife--;
                    }
                }
                else //se countSave non è ancora arrivato a 0
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