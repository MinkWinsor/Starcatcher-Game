using UnityEngine;
using System.Collections;

public class SunMovement : MonoBehaviour {

    public int startingTime;
    public TimerScript timeScript;
    public int speed = 10;

	// Use this for initialization
	void Start () {
        startingTime = timeScript.getStartingTime();

	}
	
	void Update ()
    {
        while (true)
        {
            if (timeScript.getCurrentTime() > (startingTime / 2))
                transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);

        }
        
    }
}
