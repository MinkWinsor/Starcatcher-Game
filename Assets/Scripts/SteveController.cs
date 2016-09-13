using UnityEngine;
using System.Collections;

public class SteveController : MonoBehaviour {


    //Public variables for movement speeds. Change via the editor.
    public float moveForce;
    public float maxSpeed;
    public float jumpForce;
    //Public reference to groundcheck transform, child of the player object. Used for raycasting.
    public Transform groundCheck;

    //Private reference variables.
    private bool grounded = false;
    private Rigidbody rb3d;
    private bool jump = false;
    private bool doubleJump = false;
   


    // Use this for initialization
    void Start ()
    {
        //Reference set.
        rb3d = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Linecast from player to transform node, if there is an object in the 'ground' layer, player will be marked as grounded.
        grounded = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (grounded == true)
            doubleJump = true;

        //If jump is pressed and player is grounded, jump is set to true for next physics update.
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        else if (Input.GetButtonDown("Jump") && doubleJump == true) //Player can jump once while in the air, in other words, double jump.
        {
            jump = true;
            doubleJump = false;
        }
            

	}

    //Called once per physics update.
    void FixedUpdate()
    {
        //Input from keyboard taken. Only right movement is allowed as there are no valid input keys for left movement.
        float h = Input.GetAxis("Horizontal");
        
        //Force added.
        if (h * rb3d.velocity.x < maxSpeed)
            rb3d.AddForce(Vector2.right * h * moveForce);

        //Checked to make sure force is max speed or lower.
        if (Mathf.Abs(rb3d.velocity.x) > maxSpeed)
            rb3d.velocity = new Vector2(Mathf.Sign(rb3d.velocity.x) * maxSpeed, rb3d.velocity.y);


        //Jump force added if needed.
        if (jump)
        {
            rb3d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }



}
