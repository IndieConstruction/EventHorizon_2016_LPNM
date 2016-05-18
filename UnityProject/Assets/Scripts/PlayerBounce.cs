using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class PlayerBounce : MonoBehaviour
    {
        Player p;
        Vector3 target;
        bool toCenter = false;
        public float speed = 0.1f;
        void Start()
        {
            p = FindObjectOfType<Player>();
        }
        void Update()
        {
            if (target == p.transform.position)
                toCenter = false;

            if (toCenter == true)
                p.transform.Translate(-target.x,0,0);
            
        }

        void OnTriggerExit(Collider other)
        {
            if (p != null)
            {
               // float step = speed * Time.deltaTime;
         
                Debug.Log("uscito dal limite");
                 target = Vector3.MoveTowards(p.transform.position, this.transform.position, speed).normalized;
                Debug.Log("pos " + target);
                //target=Vector3.n
                toCenter = true;
            }
        }



    }
}