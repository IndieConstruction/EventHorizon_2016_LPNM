using UnityEngine;
using System.Collections;

public class CoroutinesTest : MonoBehaviour {
    int counter = 0;
    int counterLimit = 1000;
   
	// Use this for initialization
	void Start () {
        //StartCoroutine("TestCoroutine");
        TestRoutine();
	}
    IEnumerator TestCoroutine() {
        {
            while (counter < counterLimit){
                counter++;
                Debug.Log("Coroutine " + counter);
                yield return null;
            }
        }
    }

    void TestRoutine(){
        while (counter < counterLimit)
        {
            counter++;
            Debug.Log("Coroutine " + counter);
        }
    }
}
