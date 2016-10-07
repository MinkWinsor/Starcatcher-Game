using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class KillControl : MonoBehaviour {

    void Start ()
    {
        StaticVariables.nextSectionDistance = StaticVariables.startingDistance;
    }

    void OnTriggerEnter()
    {
        ResetLevel();
    }

    public static void ResetLevel()
    {
        
        {   
            //Scene tempScene;
            //tempScene = SceneManager.GetActiveScene();
            //string scName = tempScene.name;
            SceneManager.LoadScene(0);
            
        }
            
	
	}
}
