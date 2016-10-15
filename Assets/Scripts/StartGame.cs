using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public void loadLevel()
    {
        print("Called");
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
            Application.Quit();
    }

    

}
