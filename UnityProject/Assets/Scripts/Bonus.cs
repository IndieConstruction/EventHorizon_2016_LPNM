using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class Bonus : MonoBehaviour
    {
        GameController gc;
        public int BonusPoints;
        public int BonusMultiplier;
        // Use this for initialization
        void Awake()
        {
            gc = FindObjectOfType<GameController>();
        }

        // Update is called once per frame
        void Update()
        {
        }
        void OnTriggerEnter(Collider other) {
            gc.scoreCounter = +BonusPoints;
            gc.scoreCounter = +BonusMultiplier;
        }
    }
}
