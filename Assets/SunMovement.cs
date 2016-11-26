using UnityEngine;
using System.Collections;

public class SunMovement : MonoBehaviour {

    public static bool goDown = true;
    public int speed = 10;
    
	
    // Use this for initialization
	void Start () {
        KillControl.StopAllScripts += stopScript;
	}
	
	void Update ()
    {
        if (goDown)
            transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
           
        
    }

    void stopScript()
    {
        this.enabled = false;
    }
}
