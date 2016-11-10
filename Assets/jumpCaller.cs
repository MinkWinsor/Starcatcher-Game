using UnityEngine;
using System.Collections;

public class jumpCaller : MonoBehaviour {


    public Enemy_Movement_Handler myScript;

	// Use this for initialization
	void OnTriggerEnter () {
        myScript.jumpHandler();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
