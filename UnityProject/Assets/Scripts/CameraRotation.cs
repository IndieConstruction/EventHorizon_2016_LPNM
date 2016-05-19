using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

    public Transform target;
    public bool isRotating;

    void Update() {
        //transform.LookAt(target.position);

        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.forward);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBorder")
        {
           // float step = 10;
           // transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
            
            //transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

        }
    }
}
    

       
       