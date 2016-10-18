using UnityEngine;
using System.Collections;
using System;

public class UserInputs : MonoBehaviour {

    public static Action<KeyCode> FlipDirection;
    public static Action<float> MoveOnButtons;
    public static Action JumpOnButtons;

    // Update is called once per frame
    void Update () {


        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && FlipDirection != null)
        {
            FlipDirection(KeyCode.RightArrow);
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && FlipDirection != null)
        {
            FlipDirection(KeyCode.LeftArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            JumpOnButtons();

        if (MoveOnButtons != null)
            MoveOnButtons(Input.GetAxis("Horizontal"));



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}



