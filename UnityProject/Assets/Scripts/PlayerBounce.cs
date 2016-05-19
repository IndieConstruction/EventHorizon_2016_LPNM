using UnityEngine;
using System.Collections;
namespace EH.LPNM
{
    public class PlayerBounce : MonoBehaviour
    {
        public GameObject debugGO;

        Player p;
        Vector3 target;
        bool toCenter = false;
        public float speed = 5.0f;
        private float startTime;
        private float journeyLength;
        
        void Start()
        {
            p = FindObjectOfType<Player>();
        }
        void Update()
        {
            if (target == p.transform.position)
                toCenter = false;

            if (toCenter == true)
            {
                float distCovered = (Time.time - startTime) * speed;
                float fracJourney = distCovered / journeyLength;

                p.transform.position = Vector3.Lerp(startPoint, (startPoint + endPoint), fracJourney);
              //  p.transform.position = Vector3.Lerp(p.transform.position,target, 1);
            }
        }
        Vector3 startPoint;
        Vector3 endPoint;
        void OnTriggerExit(Collider other)
        {
            if (p != null)
            {
               Vector3 startPoint = p.transform.position;
                Vector3 endPoint = new Vector3(this.transform.position.x, startPoint.y, this.transform.position.z);
                // float step = speed * Time.deltaTime;
                startTime =Time.time;
                journeyLength=Vector3.Distance(p.transform.position,this.transform.position);
            
                Debug.Log("uscito dal limite");
                
              // target = ((this.transform.position.normalized-p.transform.position.normalized));
                //target = Vector3.Reflect(p.transform.position, this.transform.position).normalized;
                Debug.Log("pos " + target);
               // GameController.Spawn(debugGO, target);
               GameController.Spawn(debugGO, startPoint);
               GameController.Spawn(debugGO, (endPoint - new Vector3(startPoint.x, 0, startPoint.z)));


                //target=Vector3.n
                toCenter = true;
            }
        }



    }
}