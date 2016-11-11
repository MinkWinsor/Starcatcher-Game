using UnityEngine;
using System.Collections;
using System;

public class TimerScript : MonoBehaviour {

    public int timeLeft;
    public bool timerRunning;
    public UnityEngine.UI.Text timeText;
    
    
    

    

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
