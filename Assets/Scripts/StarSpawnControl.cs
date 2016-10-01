using UnityEngine;
using System.Collections;
using System;

public class StarSpawnControl : MonoBehaviour {

    public Transform playerRef;

    private float lastDistance;
   

    // Use this for initialization
    void Start ()
    {

        lastDistance = playerRef.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {

	
	}

    void FixedUpdate ()
    {
        if (lastDistance < (playerRef.position.x - 1))
            SpawnStar();
    }

    private void SpawnStar()
    {
        if (UnityEngine.Random.Range(0, 100) > 75)
        {
            
        }
    }
}
