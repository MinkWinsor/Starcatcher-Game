using UnityEngine;
using System.Collections;
using System;

public class DelegatesGeneral : MonoBehaviour {

    Action<int> Move;
    Action Idle;
    Action Jump;

    void moveHandler(int _speed)
    {
        print("Moving at " + _speed + " mph.");
        Idle = idleHandler;
        Move = null;
    }

    void idleHandler()
    {
        print("Idling");
        Jump = jumpHandler;
        Idle = null;
    }

    void jumpHandler()
    {
        print("Jumping");
        Jump = null;
    }


	// Use this for initialization
	void Start () {
        Move = moveHandler;

	}
	
	// Update is called once per frame
	void Update () {
        if (Move != null)
            Move(20);
        if (Idle != null)
            Idle();
        if (Jump != null)
            Jump();
	}
}
