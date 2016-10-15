using UnityEngine;
using System.Collections;
using System;

public class BackgroundMovement : MonoBehaviour {

    public Action MoveBackground;
    public float speed;

    private Vector3 movement;

    // Use this for initialization
    void Start () {
        movement = new Vector3(speed, 0, 0);
        KillControl.StopAllScripts += stopScript;
        MoveBackground += backgroundMoveHandler;
	}

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
