using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillControl : MonoBehaviour {
    
    public static void ResetLevel()
    {
        
        {
            Scene tempScene;
            tempScene = SceneManager.GetActiveScene();
            string scName = tempScene.name;
            SceneManager.LoadScene(scName);
            StaticVariables.nextSectionDistance = StaticVariables.startingDistance;
        }
            
	
	}
}
