using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RecycleSky : MonoBehaviour
{

    //private GameObject triggerParent;
    private Vector3 newPosition;
    public List<SkyRecycler> recyclableList;
    private int i = 0;

    void Start()
    {
        recyclableList = new List<SkyRecycler>();
        SkyRecycler.RecycleAction += RecycleActionHandler;


    }

    private void RecycleActionHandler(SkyRecycler _r)
    {
        if (_r.canBeRecycled)
            recyclableList.Add(_r);
    }

    // Use this for initialization
    void OnTriggerEnter()
    {

        i = UnityEngine.Random.Range(0, recyclableList.Count - 1);

        newPosition.x = StaticVariables.nextSkySectionDistance;
        newPosition.y = 2.65f;

        recyclableList[i].transform.position = newPosition;
        StaticVariables.nextSkySectionDistance += StaticVariables.SkySectionDistance;
        if (recyclableList.Count > 0)
        {
            recyclableList[i].canBeRecycled = false;
            recyclableList.RemoveAt(i);
        }


        print("hit");


    }
}
