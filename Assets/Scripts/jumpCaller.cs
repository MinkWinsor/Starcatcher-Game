using UnityEngine;
using System.Collections;

public class jumpCaller : MonoBehaviour {


    public Enemy_Movement_Handler myScript;
    private bool canTrigger = true;

	void OnTriggerEnter (Collider other) {
        if (canTrigger)
        {

            myScript.jumpHandler();
            canTrigger = false;
        }
        
	}

    void OnTriggerExit()
    {
        canTrigger = true;
    }
	
}
