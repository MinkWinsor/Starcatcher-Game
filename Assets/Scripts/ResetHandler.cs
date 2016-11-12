using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetHandler : MonoBehaviour {

    public GameObject[] deathScreen;

    // Use this for initialization
    void Start () {
        //KillControl.StopAllScripts += fixList;
	}
	
	// Update is called once per frame
	/*void onDestroy () {

        deathScreen = null;

    }*/

    public void showObjects()
    {
        foreach (GameObject thisObject in deathScreen)
        {
            if (thisObject.GetComponent<Button>() != null)
            {
                thisObject.GetComponent<Button>().enabled = true;
            }
            if (thisObject.GetComponent<Image>() != null)
            {
                thisObject.GetComponent<Image>().enabled = true;
            }
            if (thisObject.GetComponent<Text>() != null)
            {
                thisObject.GetComponent<Text>().enabled = true;
            }
            if (thisObject.GetComponentInChildren<Text>() != null)
            {
                thisObject.GetComponentInChildren<Text>().enabled = true;
            }
        }
    }

    //This function can be called from everywhere, and completely reloads the level.
    public static void ResetLevel()
    {
        SceneManager.LoadScene(1);
    }

}
