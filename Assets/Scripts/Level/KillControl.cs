using UnityEngine;
using System.Collections;
using System;

public class KillControl : MonoBehaviour {

    //Action that is subscribed to by many scripts needing  user input.
    public static Action StopAllScripts;
    
    public ResetHandler myReset;

    //Sets static variables when game level begins. Not needed for the first use, but if the level resets this prevents errors.
    void Start ()
    {
        StaticVariables.nextSectionDistance = StaticVariables.startingDistance;
        StopAllScripts += StartReset;
    }

    //Calls the action when the player 'dies' by hitting a killplane. Scripts that subscribe to this are mainly the user input listeners, and movement scripts.
    void OnTriggerEnter()
    {
        StopAllScripts();
    }




    public void StartReset()
    {
        myReset.showObjects();
        StopAllScripts -= StartReset;
    }



    
    
}
