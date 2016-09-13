using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillControl : MonoBehaviour {

    //Starts level over if player touches the killbox.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Fired");
        if (other.gameObject.CompareTag("Player"))
        {
            Scene tempScene;
            tempScene = SceneManager.GetActiveScene();
            string scName = tempScene.name;
            SceneManager.LoadScene(scName);
        }
            
	
	}
}
