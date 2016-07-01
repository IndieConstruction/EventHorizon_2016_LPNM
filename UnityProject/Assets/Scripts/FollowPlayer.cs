using UnityEngine;
using System.Collections;

namespace EH.LPNM
{
    
    public class FollowPlayer : MonoBehaviour
    {
        public GameObject p;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            this.gameObject.transform.position = p.transform.position;
        }
    }
}