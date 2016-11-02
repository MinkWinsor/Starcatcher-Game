using UnityEngine;
using System.Collections;

public class groundCheckScript : MonoBehaviour {

    public bool isGrounded;

	// Use this for initialization
	void OnTriggerEnter () {
        isGrounded = true;
	}
	
	// Update is called once per frame
	void OnTriggerExit () {
        isGrounded = false;
	}
}
