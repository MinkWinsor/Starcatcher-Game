using UnityEngine;
using System.Collections;

public class RecycleWolf : MonoBehaviour {

    public TimerScript refTimer;
    public GameObject wolfRef;

    // Use this for initialization
    void OnTriggerEnter () {
        wolfRef.SetActive(false);
        refTimer.wolfReady = true;
	}
	
	// Update is called once per frame
	void Start () {
	
	}
}
