using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutoSceneLoad : MonoBehaviour {

    public float waitTime = 3;
    public int sceneNumber;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Pause());
	}
	
	IEnumerator Pause ()
    {
        yield return new WaitForSeconds(waitTime);
        loadMenu();
	}

    public void loadMenu()
    {
        SceneManager.LoadScene(2);
    }
}
