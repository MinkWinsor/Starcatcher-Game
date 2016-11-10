using UnityEngine;
using System.Collections;

public class RecycleWolf : MonoBehaviour {

    public TimerScript refTimer;
    public GameObject wolfRef;
    public WolfHitPlayer hitScript;

    // Use this for initialization
    void OnTriggerEnter () {
        hitScript.triggerReady = true;
        wolfRef.SetActive(false);
        refTimer.wolfReady = true;
	}
	
	// Update is called once per frame
	void Start () {
	
	}
}
