using UnityEngine;
using System.Collections;

public class Enemy_Movement_Handler : MonoBehaviour {

    public float speed = 0;
    public float gravity = 10;
    public float jumpStrength = 5;
    public Animator anim;
    public Transform charArt;
    public bool keepGoing = true;

    private bool forward = true;
    private Vector3 movement;
    private CharacterController myCC;
    private Vector3 tempPos;
    private AudioSource running;
    


    // Use this for initialization
    void Start () {
        running = GetComponent<AudioSource>();
        myCC = GetComponent<CharacterController>();
        movement = new Vector3(speed, 0 ,0);
        
        KillControl.StopAllScripts += stopMoving;
    }


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
        running.Stop();
        keepGoing = false;
        anim.enabled = false;
        KillControl.StopAllScripts -= stopMoving;
    }
    


        public void moveReset()
    {
        movement = new Vector3(speed, 0, 0);
    }




    public void jumpHandler()
    {
        movement.y = jumpStrength;
        anim.SetTrigger("Jump");
    }




    public IEnumerator MoveHandler()
    {
        
        while (keepGoing)
        {
            yield return new WaitForSeconds(.01f);
            
            movement.y -= gravity * Time.deltaTime;
            if(gameObject.activeSelf)
                myCC.Move(movement * Time.deltaTime);
            

            if (transform.position.z != 0)
            {
                tempPos = transform.position;
                tempPos.z = 0;
                transform.position = tempPos;
            }

        }

    }
}
