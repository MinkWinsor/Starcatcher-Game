using UnityEngine;
using System.Collections;
using System;

public class SkyRecycler : MonoBehaviour
{
    //**Public variables**//

    public static Action<SkyRecycler> RecycleAction;
    public bool canBeRecycled = false;


    // Use this for initialization
    void Start()
    {
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
