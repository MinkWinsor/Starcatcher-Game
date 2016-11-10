﻿using UnityEngine;
using System.Collections;
using System;

public class TimerScript : MonoBehaviour {

    public int timeLeft;
    public bool timerRunning;
    public UnityEngine.UI.Text timeText;
    public GameObject wolfRef;
    public float wolfSpawnChance;
    public Transform cameraPosition;
    public bool wolfReady = true;
    public Enemy_Movement_Handler wolfScript;

    private const float X_OFFSET = 20;
    private const float Y_OFFSET = -1;

    IEnumerator Countdown()
    {
        while (timerRunning)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            dispTime();
            
            if (timeLeft == 0)
            {

                ResetHandler.ResetLevel();
            }

            if (wolfSpawnChance > UnityEngine.Random.Range(0, 100) && wolfReady)
            {
                Vector3 tempPos = cameraPosition.transform.position;
                if(UnityEngine.Random.Range(0, 100) > 50)
                {
                    tempPos.x -= X_OFFSET;
                    wolfScript.SetDirection(true);
                }
                else
                {
                    tempPos.x += X_OFFSET;
                    wolfScript.SetDirection(false);
                }

                tempPos.z = 0;
                tempPos.y += Y_OFFSET;
                wolfRef.transform.position = tempPos;
                wolfRef.SetActive(true);
                wolfReady = false;
            }
            

        }
        print("ERROR_LOOP");
    }


    // Use this for initialization
    void Start () {
        dispTime();
        StartCoroutine(Countdown());
    }
	
    void dispTime()
    {
        int secondsLeft = (timeLeft % 60);
        if (secondsLeft > 9)
        {
            timeText.text = ("Time: " + (timeLeft / 60) + ":" + secondsLeft);
        }
        else
        {
            timeText.text = ("Time: " + (timeLeft / 60) + ":0" + secondsLeft);
        }
    }
}
