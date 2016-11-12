using UnityEngine;
using System.Collections;

public class Enemy_Movement_Handler : MonoBehaviour {

    public float speed = 0;
    public float gravity = 10;
    public float jumpStrength = 5;


    public Animator anim;
    //public bool runToRight;
    public Transform charArt;
    private bool forward = true;

    //private float lastXPosition;
    private Vector3 movement;
    private CharacterController myCC;
    private Vector3 tempPos;
    public bool keepGoing = true;


    // Use this for initialization
    void Start () {
        Debug.Log("Running");
        myCC = GetComponent<CharacterController>();
        movement = new Vector3(speed, 0 ,0);
        
        KillControl.StopAllScripts += stopMoving;
    }





    /*public void SetDirection(bool runRight)
    {
        if (runRight)
        {
            movement = new Vector3(speed, 0, 0);
            if (!forward)
            {
                charArt.Rotate(0, 180, 0);
                forward = true;
            }
        }
        else
        {
            movement = new Vector3(-speed, 0, 0);
            if (forward)
            {
                charArt.Rotate(0, 180, 0);
                forward = false;
            }
        }
    }*/



    public void SetDirection(bool runRight)
    {
        if (runRight)
        {
            movement = new Vector3(speed, 0, 0);
            if (!forward)
            {
                charArt.Rotate(0, 180, 0);
                forward = true;
            }
        }
        else
        {
            movement = new Vector3(-speed, 0, 0);
            if (forward)
            {
                charArt.Rotate(0, 180, 0);
                forward = false;
            }
        }
    }




    public void stopMoving()
    {
        keepGoing = false;
        anim.enabled = false;
        KillControl.StopAllScripts -= stopMoving;
    }

	/* Update is called once per frame
	void Update () {


        /*if (transform.position.x <= (lastXPosition + (0.1f * Time.deltaTime)))
        {
            movement.y = jumpStrength;
            
        }*/


        /*movement.y -= gravity * Time.deltaTime;
        myCC.Move(movement * Time.deltaTime);

        if (transform.position.z != 0)
        {
            tempPos = transform.position;
            tempPos.z = 0;
            transform.position = tempPos;
        }


        //lastXPosition = transform.position.x;
    }*/


        public void moveReset()
    {
        movement = new Vector3(speed, 0, 0);
    }




    public void jumpHandler()
    {
        print("Jumping");
        movement.y = jumpStrength;
        anim.SetTrigger("Jump");
    }




    public IEnumerator MoveHandler()
    {
        
        while (keepGoing)
        {
            yield return new WaitForSeconds(.01f);
            
            movement.y -= gravity * Time.deltaTime;
            myCC.Move(movement * Time.deltaTime);

            /*if(movement.y > (gravity * 5))
            {
                movement.y = gravity * 5;
            }*/

            if (transform.position.z != 0)
            {
                tempPos = transform.position;
                tempPos.z = 0;
                transform.position = tempPos;
            }

        }

    }
}
