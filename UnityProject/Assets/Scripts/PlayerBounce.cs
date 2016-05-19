using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class PlayerBounce : MonoBehaviour
    {
        Player p;
        Transform target;
        //bool toCenter = false;
        public float speed = 0.1f;
        void Start()
        {
            p = FindObjectOfType<Player>();
        }
        void Update()
        {
           
            
        }

        void OnTriggerExit(Collider other)
        {
            if (p != null)
            {
                float step = speed * Time.deltaTime;
                Debug.Log("uscito dal limite");
                target.position = this.transform.position;
                transform.position = Vector3.MoveTowards(p.transform.position, target.position, step);
               // target = this.transform.position;
               //transform.Translate(target);
               //target=Vector3.n
               //toCenter = true;
            }
        }



    }
}