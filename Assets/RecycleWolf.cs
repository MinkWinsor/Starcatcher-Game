using UnityEngine;
using System.Collections;

public class RecycleWolf : MonoBehaviour {

    public WolfSpawn spawnScript;
    public GameObject wolfRef;
    public Enemy_Movement_Handler moveScript;

    public WolfHitPlayer hitScript;
    

    void OnTriggerEnter () {
        hitScript.triggerReady = true;
        moveScript.keepGoing = false;
        wolfRef.SetActive(false);
        spawnScript.wolfReady = true;
	}

}
