using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class Camera_Movement : MonoBehaviour {

    public float speed;
    public GameObject playerRef;

    private Camera thisCamera;
    private Vector3 movement;
    private Vector3 cameraCheck;

    void Start()
    {
        thisCamera = GetComponent<Camera>();
        movement = new Vector3(speed, 0, 0);
    }


	// Update is called once per frame
	void Update () {
        movement.y = (playerRef.transform.position.y - transform.position.y);
        transform.Translate(movement);
        OutsideCamera();
    }

    public void OutsideCamera()
    {
        
        cameraCheck = thisCamera.WorldToViewportPoint(playerRef.transform.position);
        if (cameraCheck.y < 0 || cameraCheck.y > 1 || cameraCheck.x < 0 || cameraCheck.x > 1)
        {
            Scene tempScene;
            tempScene = SceneManager.GetActiveScene();
            string scName = tempScene.name;
            SceneManager.LoadScene(scName);
        }
    }
}
