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
            timeText.text = ("Time: " + (timeLeft / 60) + ":" + (timeLeft % 60) );
            if (timeLeft == 0)
            {

                KillControl.ResetLevel();
            }
        }
    }


    // Use this for initialization
    void Start () {

        StartCoroutine(Countdown());
    }
	
}
