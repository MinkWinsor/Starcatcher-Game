﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class Camera_Movement : MonoBehaviour {

    //**Public variables**//

    public Action MoveCamera;
    public float speed;
    public GameObject playerRef;

    //**Private variables**//

    private Text[] gameOverText;
    private MeshRenderer button;
    private Vector3 movement;

    void Start()
    {
        movement = new Vector3(speed, 0, 0);
        MoveCamera += cameraShift;
        KillControl.StopAllScripts += stopScript;
        //button = GameObject.FindGameObjectWithTag("Buttons").GetComponent<MeshRenderer>();
        //GameObject[] textObjects = GameObject.FindGameObjectsWithTag("Death Screen");
        //gameOverText = new Text[textObjects.Length];
        //int count = 0;
        //foreach (GameObject textObject in textObjects)
        //{
        //    gameOverText[count] = textObject.GetComponent<Text>();
        //    count++;
        //}

    }
    
    void stopScript()
    {
        MoveCamera -= cameraShift;
        //foreach (Text printThis in gameOverText)
        //{
        //    printThis.enabled = true;
        //}
        
        //button.enabled = true;
    }


	// Update is called once per frame
	void Update () {
        if(MoveCamera != null)
        MoveCamera();
    }

    void cameraShift()
    {
        transform.Translate(movement * Time.deltaTime);
    }


    void OnDestroy()
    {
        KillControl.StopAllScripts -= stopScript;
        MoveCamera -= cameraShift;
    }
}
