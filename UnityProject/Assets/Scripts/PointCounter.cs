using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace EH.LPNM
{
    public class PointCounter : MonoBehaviour
    {
        GameController gc;
        public int Points { get { return gc.scoreCounter; } }
        public int PointsUI { get; set; }
        public Text PointLable;
        public string LablePrefix="Score: ";
        public int mult = 5;
        // Use this for initialization
        void Start()
        {
            gc = FindObjectOfType<GameController>();
            PointLable = this.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            //quando il punteggio nel gamecontroller è diverso da quello registrato in questa classe, ovvero la UI, aumenta il punteggio della UI gradualmente in base al valore di mult
            if (Points != PointsUI)
            {
				if (Points > PointsUI + (10 * mult)) {
					PointsUI = PointsUI + (10 * mult);
					PointLable.text = LablePrefix + PointsUI;
				}
			}

        }
    }
}