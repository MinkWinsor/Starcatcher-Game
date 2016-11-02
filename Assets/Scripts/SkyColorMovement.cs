using UnityEngine;
using System.Collections;

public class SkyColorMovement : MonoBehaviour {

    public int lowExtreme;
    public int highExtreme;
    public TimerScript sCounter;

    //private Vector3 lowVector;
    //private Vector3 highVector;

    //private int timeMax;

	// Use this for initialization
	void Start () {
        //timeMax = sCounter.timeLeft;
        //lowVector = new Vector3(0, 0, lowExtreme);
        //highVector = new Vector3(0, 0, highExtreme);
    }
	
	void Update () {
	/*if(sCounter.timeLeft < timeMax / 2)
        {
            transform.position = (Vector3.Lerp(lowVector, highVector, ((sCounter.timeLeft - (timeMax / 2)) / (timeMax / 2))));
        }

    if (sCounter.timeLeft > timeMax / 2)
        {
            transform.position = (Vector3.Lerp(lowVector, highVector, ((sCounter.timeLeft - (timeMax / 2)) / (timeMax / 2))));
        }*/
    }
}
