using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class KillControl : MonoBehaviour {

    //Action that is subscribed to by many scripts needing  user input.
    public static Action StopAllScripts;
    //public static List<GameObject> deathScreen;

    //Sets static variables when game level begins. Not needed for the first use, but if the level resets this prevents errors.
    void Start ()
    {
        StaticVariables.nextSectionDistance = StaticVariables.startingDistance;
        StaticVariables.nextSkySectionDistance = StaticVariables.startingSkyDistance;
        StopAllScripts += ResetLevel;
    }

    //Calls the action when the player 'dies' by hitting a killplane. Scripts that subscribe to this are mainly the user input listeners, and movement scripts.
    void OnTriggerEnter()
    {
        StopAllScripts();
    }

    //This function can be called from everywhere, and completely reloads the level.
    public static void ResetLevel()
    {    
        SceneManager.LoadScene(1);
	}
    /*
    public static void DeathScreen(GameObject objectToShow)
    {
        deathScreen.Add(objectToShow);
    }


     public static void showObjects()
    {
        foreach (GameObject thisObject in deathScreen)
        {
            if(thisObject.GetComponent<Button>() != null)
            {
                thisObject.GetComponent<Button>().enabled = true;
            }
            if (thisObject.GetComponent<Image>() != null)
            {
                thisObject.GetComponent<Image>().enabled = true;
            }
            if (thisObject.GetComponent<Text>() != null)
            {
                thisObject.GetComponent<Text>().enabled = true;
            }
            if (thisObject.GetComponentInChildren<Text>() != null)
            {
                thisObject.GetComponentInChildren<Text>().enabled = true;
            }
        }
    }
    */
}
