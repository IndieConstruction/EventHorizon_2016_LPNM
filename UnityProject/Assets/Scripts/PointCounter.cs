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
            if (Points != PointsUI)
            {
                PointsUI=PointsUI+(10*mult);
                PointLable.text = LablePrefix + PointsUI;
            }

        }
    }
}