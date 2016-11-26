using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    private Text scoreText;
    //private IEnumerator coroutine;
    //private bool coroutineRunning = false;

	// Use this for initialization
	void Start () {
        scoreText = GetComponentInChildren<Text>();
        //coroutine = scoreDisplayTimer();
        if(scoreText.gameObject.activeSelf)
            scoreText.gameObject.SetActive(false);
	}
	
	public void updateScore (int scoreChange) {
	
        if(scoreChange > 0)
        {
            scoreText.color = Color.green;
            scoreText.text = ("+" + scoreChange.ToString());
            /*if (coroutineRunning) {
                StopCoroutine(coroutine);
            }*/
            
            StartCoroutine(scoreDisplayTimer());
        }
        else
        {
            scoreText.color = Color.red;
            scoreText.text = (scoreChange.ToString());
            /**if (coroutineRunning)
            {
                StopCoroutine(coroutine);
            }*/

            StartCoroutine(scoreDisplayTimer());
        }
	}

    IEnumerator scoreDisplayTimer()
    {
        //coroutineRunning = true;
        //if (!scoreText.gameObject.activeSelf)
            scoreText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        //if (scoreText.gameObject.activeSelf)
            scoreText.gameObject.SetActive(false);
        //coroutineRunning = false;
    }
}
