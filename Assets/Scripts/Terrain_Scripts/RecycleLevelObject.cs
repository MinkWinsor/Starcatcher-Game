using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//This code is used on an object that is a child of the camera, which will both control the terrain recycling and collide with the terrain.
public class RecycleLevelObject : MonoBehaviour {

    //**Public variables**//
    
    public List<Recycler> recyclableList;

    //**Private variables**//
    private int i = 0; //Used for random function.
    private Vector3 newPosition;
    private const float TERRAIN_Y_POS = -10;

    //When the game begins, the list is initialized, and this code subscribes to the RecycleAction in the terrain piece code.
    //Basically, this function will receive a reference to each terrain piece marked as recyclable.
    void Start()
    {
        recyclableList = new List<Recycler>();
        Recycler.RecycleAction += RecycleActionHandler;
    }

    //Terrain pieces will call up this action, sending a reference to themselves. When they do, they are added to the recyclable list.
    private void RecycleActionHandler(Recycler _r)
    {
        if(_r.canBeRecycled)
        recyclableList.Add(_r);
    }

    //When collissions with terrain occur, this function is used. It recycles on piece of terrain on the recyclable terrain list, 
    //then removes that piece from the list and marks it as non-recyclable.
    void OnTriggerEnter()
    {
        //Random terrain piece on list selected. variable 'i' used to represent index.
        i = UnityEngine.Random.Range(0, recyclableList.Count - 1);
        //The StaticVariables class holds the information for how far the terrain should be placed.
        //That information is used to determine the placement of the selected piece.
        newPosition.x = StaticVariables.nextSectionDistance;
        newPosition.y = TERRAIN_Y_POS;

        //Selected terrain moved to new position.
        recyclableList[i].transform.position = newPosition;
        //Static variable updated to next position.
        StaticVariables.nextSectionDistance += StaticVariables.SectionDistance;
        //As long as terrain is left in the list, terrain piece is removed from the list.
        if (recyclableList.Count > 0)
        {
            recyclableList[i].canBeRecycled = false;
            recyclableList.RemoveAt(i);
        }


    }
}
