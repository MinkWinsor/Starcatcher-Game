using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RecycleLevelObject : MonoBehaviour {

    private GameObject triggerParent;
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
        recyclableList.Add(_r);
    }

    // Use this for initialization
    void OnTriggerEnter()
    {

        StaticVariables.nextSectionDistance += StaticVariables.SectionDistance;
        newPosition.x = StaticVariables.nextSectionDistance;
        triggerParent = recyclableList[i].transform.parent.gameObject;
        triggerParent.transform.position = newPosition;
        
        print("hit");
        if (i < recyclableList.Count)
            i++;

    }
}
