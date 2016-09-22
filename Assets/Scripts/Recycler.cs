using UnityEngine;
using System.Collections;
using System;

public class Recycler : MonoBehaviour {

    public static Action<Recycler> RecycleAction;
    public bool canBeRecycled = false;
   // private Transform cube;


	// Use this for initialization
	void Start () {
        //cube = this.GetComponent<Transform>();
        if (RecycleAction != null && canBeRecycled)
            RecycleAction(this);
	}
	
    void OnTriggerEnter()
    {
        canBeRecycled = true;
        Start();
    }

}
