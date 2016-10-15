﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerCC : MonoBehaviour {

    private CharacterController myCC;
    public float speed = 1;
    public float gravity = 1;
    public float jumpSpeed = 1;

    public int jumpCount = 0;
    public int jumpCountMax = 2;

    public int slideDuration = 20;
    public float slideTime = 0.01f;
    private Vector3 tempPos;

    public Action jumpCheck;
    public Action runCheck;
    public Animator anim;
    private bool running = false;
    


    //CoRoutine for sliding character
    IEnumerator Slide ()
    {
        int durationTemp = slideDuration;

        float speedTemp = speed;
        speed += speed;
        while (slideDuration > 0)
        {
            //Decrement the slideDuration
            slideDuration--;

            yield return new WaitForSeconds(slideTime);
            print("sliding");
        }

        speed = speedTemp;
        slideDuration = durationTemp;
    }

    void StopScript()
    {
       UserInputs.MoveOnButtons -= Move;
       UserInputs.JumpOnButtons -= Jump;
    }

	// Use this for initialization
	void Start () {

        print("Started");
        myCC = GetComponent<CharacterController>();
        UserInputs.MoveOnButtons += Move;
        UserInputs.JumpOnButtons += Jump;
        KillControl.StopAllScripts += StopScript;

    }
	
	// Update is called once per frame
	void Update () {


        //Start Sliding
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            print("StartSliding");
            StartCoroutine(Slide());
        }

        if(jumpCheck != null)
        {
            jumpCheck();
        }
        if (runCheck != null)
        {
            runCheck();
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Slide());
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Slide());
        }

    }

    void Move(float _moveInY)
    {

        tempPos.y -= gravity;
        tempPos.x = speed * Input.GetAxis("Horizontal");
        if (tempPos.x != 0 && jumpCheck == null)
        {
            runCheck = runCheckHandler;
        }

        myCC.Move(tempPos * Time.deltaTime);
    }

    void Jump()
    {
        if (myCC.isGrounded)
        {
            jumpCount = 0;
        }

        if (jumpCount < jumpCountMax)
        {
            jumpCount++;
            tempPos.y = jumpSpeed;
            jumpCheck = jumpCheckHandler;
            anim.SetTrigger("jumpTrigger");
        }
    }


    void OnDestroy()
    {
        UserInputs.MoveOnButtons -= Move;
        UserInputs.JumpOnButtons -= Jump;
    }

    void jumpCheckHandler()
    {
        if (myCC.isGrounded)
        {
            anim.SetTrigger("idleTrigger");
            jumpCheck = null;
        }
    }

    void runCheckHandler()
    {
        if (running != true)
        {
            anim.SetTrigger("runTrigger");
            running = true;
            
        }

        
        if (Input.GetAxis("Horizontal") == 0 && running == true)
        {
            anim.SetTrigger("idleTrigger");
            running = false;
            runCheck = null;
        }
    }

}
