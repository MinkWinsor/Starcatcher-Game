using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RecycleLevelObject : MonoBehaviour {

    //private GameObject triggerParent;
    private Vector3 newPosition;
    public List<Recycler> recyclableList;
    private int i = 0;

    void Start()
    {
        recyclableList = new List<Recycler>();
        Recycler.RecycleAction += RecycleActionHandler;
       
    }

    private void RecycleActionHandler(Recycler _r)
    {
        if(_r.canBeRecycled)
        recyclableList.Add(_r);
    }

    // Use this for initialization
    void OnTriggerEnter()
    {

        i = UnityEngine.Random.Range(0, recyclableList.Count - 1);

        newPosition.x = StaticVariables.nextSectionDistance;
        newPosition.y = -10;

        recyclableList[i].transform.position = newPosition;
        StaticVariables.nextSectionDistance += StaticVariables.SectionDistance;
        if (recyclableList.Count > 0)
        {
            recyclableList[i].canBeRecycled = false;
            recyclableList.RemoveAt(i);
        }
           
        
        print("hit");


    }
}
