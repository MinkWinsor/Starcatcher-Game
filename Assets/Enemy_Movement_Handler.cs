using UnityEngine;
using System.Collections;

public class Enemy_Movement_Handler : MonoBehaviour {

    public float speed = 0;
    public float gravity = 10;
    public float jumpStrength = 5;
    public Animator anim;

    private float lastXPosition;
    private Vector3 movement;
    private CharacterController myCC;
    private Vector3 tempPos;


    // Use this for initialization
    void Start () {
        myCC = GetComponent<CharacterController>();
        movement = new Vector3(speed, 0 ,0);
        lastXPosition = transform.position.x;
        //StartCoroutine(MoveHandler());
    }
	
	// Update is called once per frame
	void Update () {
        //yield return new WaitForSeconds(0.1f);
        movement.y -= gravity * Time.deltaTime;
        myCC.Move(movement * Time.deltaTime);
        //lastXPosition += (0.1f * Time.deltaTime);
        if (transform.position.x <= (lastXPosition + (0.1f * Time.deltaTime)))
        {
            movement.y = jumpStrength;
            anim.SetTrigger("Jump");
        }
        //else
        //{
        //    print(lastXPosition);
        //    print(transform.position.x);
        //}
        if (transform.position.z != 0)
        {
            tempPos = transform.position;
            tempPos.z = 0;
            transform.position = tempPos;
        }
            
        
        lastXPosition = transform.position.x;
    }

    IEnumerator MoveHandler()
    {
        while (true)
        {
            
        }
        
    }
}
