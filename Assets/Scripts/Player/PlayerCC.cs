using UnityEngine;
using System.Collections;

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
    
    //public void ReferenceSelf()
    //{
    //    myCC = GetComponent<CharacterController>();
    //}


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

	}
	
	// Update is called once per frame
	void Update () {


        //Start Sliding
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            print("StartSliding");
            StartCoroutine(Slide());
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
        }
    }


    void OnDestroy()
    {
        UserInputs.MoveOnButtons -= Move;
        UserInputs.JumpOnButtons -= Jump;
    }
}
