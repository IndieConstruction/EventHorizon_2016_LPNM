using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace EH.LPNM
{
    public class SaveScore : MonoBehaviour
    {
        HudManager hd;
        public string Score;
        public bool Complete = false;
        public string LoadLev;
        // Use this for initialization
        void Start()
        {
            hd = FindObjectOfType<HudManager>();

        }
        // Use this for initialization
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            Score = hd.Score;
        }
    }
}