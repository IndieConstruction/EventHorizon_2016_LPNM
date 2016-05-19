using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class LimitMalus : MonoBehaviour
    {
        Player p;
        GameController gc;
        // Use this for initialization
        void Start()
        {
            p = FindObjectOfType<Player>();
            gc = FindObjectOfType<GameController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            
            if (p != null)
            {
                Debug.Log("collisione limit");

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

        }
    }
}