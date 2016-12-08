using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    private ButtonClick myClick;

    void Start()
    {
        myClick = GetComponentInParent<ButtonClick>();
    }

    public void loadLevel()
    {
        
        myClick.Clicked();
        StartCoroutine(loadDelayed(1));
        //SceneManager.LoadScene(1);
    }

    public void loadMenu()
    {
        myClick.Clicked();
        StartCoroutine(loadDelayed(2));
    }

    public void quitGame()
    {
        myClick.Clicked();
        StartCoroutine(loadDelayed(-1));
        //Application.Quit();
    }

    public IEnumerator loadDelayed(int index)
    {
        yield return new WaitForSeconds(0.5f);
        if(index >= 0)
        {
            SceneManager.LoadScene(index);
        }
        else
        {
            Application.Quit();
        }
        
    }
    
}
