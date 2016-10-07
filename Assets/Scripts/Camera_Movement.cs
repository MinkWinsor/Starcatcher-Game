using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class Camera_Movement : MonoBehaviour {

    public float speed;
    public GameObject playerRef;


    private Vector3 movement;
    private Vector3 cameraCheck;

    void Start()
    {
        movement = new Vector3(speed, 0, 0);
    }


	// Update is called once per frame
	void Update () {
        movement.y = (playerRef.transform.position.y - transform.position.y + 2);
        movement.y *= 2;
        transform.Translate(movement * Time.deltaTime);
    }


}
