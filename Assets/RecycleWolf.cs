using UnityEngine;
using System.Collections;

public class RecycleWolf : MonoBehaviour {

    public WolfSpawn spawnScript;
    public GameObject wolfRef;


    public WolfHitPlayer hitScript;
    

    void OnTriggerEnter () {
        hitScript.triggerReady = true;
        wolfRef.SetActive(false);
        spawnScript.wolfReady = true;
	}

}
