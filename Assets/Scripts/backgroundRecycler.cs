using UnityEngine;
using System.Collections;
using System;

public class backgroundRecycler : MonoBehaviour {

    public static Action<backgroundRecycler> RecycleAction;
    private Transform cube;
    public Vector3 movement;

    // Use this for initialization
    void Start()
    {
        cube = this.GetComponent<Transform>();

    }

    void OnTriggerEnter()
    {


        cube.Translate(movement);


    }

}
