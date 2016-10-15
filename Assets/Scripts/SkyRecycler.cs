using UnityEngine;
using System.Collections;
using System;

public class SkyRecycler : MonoBehaviour
{

    public static Action<SkyRecycler> RecycleAction;
    public bool canBeRecycled = false;
    public Transform cube;


    // Use this for initialization
    void Start()
    {
        cube = this.GetComponent<Transform>();
        if (RecycleAction != null && canBeRecycled)
        {
            print("ran");
            RecycleAction(this);

        }

    }

    void OnTriggerEnter()
    {

        print("Sky Hit");
        canBeRecycled = true;
        Start();


    }

}
