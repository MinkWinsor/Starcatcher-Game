using UnityEngine;
using System.Collections;
using System;

public class backgroundRecycler : MonoBehaviour {

    //**Public variables**//

    public static Action<backgroundRecycler> RecycleAction;
    public Vector3 movement;

    //**Private variables**//

    //private Transform cube;

    // Use this for initialization
    void Start()
    {
        //cube = this.GetComponent<Transform>();
    }

    void OnTriggerEnter()
    {
        print("Trigger");
        //cube.Translate(movement);
        this.transform.Translate(movement);
    }

}
