using UnityEngine;
using System.Collections;
using System;

public class Recycler : MonoBehaviour {

    //**Public variables**//

    public static Action<Recycler> RecycleAction;
    public bool canBeRecycled = false;


	// When the game starts, and terrain pieces marked as recycled will be added to the Recycler list in the RecycleLevelObject script.
    //This allows added terrain pieces that aren't already placed in the game.
    //Start function is called whenever the terrain is triggered.
	void Start () {
        if (RecycleAction != null && canBeRecycled)
        {
            RecycleAction(this);
        }
	}
	
    //When the terrain collider hits the recycler object, it adds itself to the list of recyclable objects.
    void OnTriggerEnter()
    {
        canBeRecycled = true;
        Start();
    }

}
