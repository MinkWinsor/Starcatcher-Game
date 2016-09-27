using UnityEngine;
using System.Collections;
using System;

public class UdpateDelegates : MonoBehaviour {

    int health = 250;

    Action DisplayHealth;
    Action KillThePlayer;
    Action EndTheGame;


    // Use this for initialization
    void Start () {
        //We assign the function DisplayHealthHandler to the action DisplayHealth
        DisplayHealth = DisplayHealthHandler;
    }
	
	// Update is called once per frame
	void Update () {
        //Check to see if any function is assigned to displayhealth
        //If one is assigned, DisplayHealth will not run.
        if(DisplayHealth != null)
            DisplayHealth();

        if (KillThePlayer != null)
            KillThePlayer();

        if(EndTheGame != null)
            EndTheGame();

	}

    //Displays health message.
    void DisplayHealthHandler()
    {
        print("health is good");
        //Sets action to null so it won't be called repeatedly.
        DisplayHealth = null;
        KillThePlayer = KillThePlayerHandler;
    }

    void KillThePlayerHandler()
    {
        health--;
        print(health);
        if(health < 0)
        {
            KillThePlayer = null;
            EndTheGame = EndTheGameHandler;
        }
    }

    void EndTheGameHandler()
    {
        print("You Die. You didn't even try.");
        EndTheGame = null;
    }
}
