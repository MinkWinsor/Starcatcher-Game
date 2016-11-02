using UnityEngine;
using System.Collections;
using System;

//This script moves background pieces at a set speed as determined in the Unity Inspector. This script is mainly used to create a parallax movement appearance, and as such 
public class BackgroundMovement : MonoBehaviour {

    //**Public variables**//

    public Action MoveBackground;
    public float speed;

    //**Private variables**//

    private Vector3 movement;

    // Use this for initialization
    void Start () {
        movement = new Vector3(speed, 0, 0);
        KillControl.StopAllScripts += stopScript;
        MoveBackground += backgroundMoveHandler;
	}

    //Background moves
    void Update()
    {
        if (MoveBackground != null)
            MoveBackground();
    }


    void backgroundMoveHandler()
    {

        transform.Translate(movement * Time.deltaTime);
    }


    void stopScript()
    {
        MoveBackground -= backgroundMoveHandler;
    }
}
