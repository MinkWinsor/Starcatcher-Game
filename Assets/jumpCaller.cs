using UnityEngine;
using System.Collections;

public class jumpCaller : MonoBehaviour {


    public Enemy_Movement_Handler myScript;
    
	void OnTriggerEnter () {
        myScript.jumpHandler();
	}
	
}
