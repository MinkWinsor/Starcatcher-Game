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


	// Use this for initialization
	void Start () {

        myCC = GetComponent<CharacterController>();


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpCountMax - 1)
        {
            jumpCount++;
            tempPos.y = jumpSpeed;
        }
        //Start Sliding
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            print("StartSliding");
            StartCoroutine(Slide());
        }

        if (myCC.isGrounded)
        {
            jumpCount = 0;
        }


        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Slide());
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Slide());
        }

        tempPos.y -= gravity;
        tempPos.x = speed * Input.GetAxis("Horizontal");
        myCC.Move(tempPos * Time.deltaTime);
    }
}
