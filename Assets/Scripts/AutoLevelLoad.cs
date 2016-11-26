using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutoLevelLoad : MonoBehaviour {

    public float waitTime = 3;
    public int sceneNumber;

	// Use this for initialization
	void Start () {
        StartCoroutine(Pause());
	}
	
	// Update is called once per frame
	IEnumerator Pause () {

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneNumber);
	}
}
