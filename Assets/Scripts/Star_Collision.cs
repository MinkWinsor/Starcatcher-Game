using UnityEngine;
using System.Collections;

public class Star_Collision : MonoBehaviour
{
    //References tocontrolling objects, and variable for the score given per star.
    private ScoreCounter levelControlScore;
    private GameObject levelControl;
    public int scorePerStar;

    //Called once per initialization.
    void Start()
    {
        //References set.
        levelControl = GameObject.FindGameObjectWithTag("GameController");
        levelControlScore = levelControl.GetComponent<ScoreCounter>();
    }

    void OnTriggerEnter()
    {

            levelControlScore.AddToScore(scorePerStar);
            Destroy(this.transform.parent.gameObject);
    }
}
