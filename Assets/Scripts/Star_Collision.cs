using UnityEngine;
using System.Collections;

public class Star_Collision : MonoBehaviour
{
    //References tocontrolling objects, and variable for the score given per star.
    private ScoreCounter levelControlScore;
    private GameObject levelControl;
    public int scorePerStar;
    public StarControl myStarControl;

    //Called once per initialization.
    void Start()
    {
        //References set.
        myStarControl = gameObject.GetComponentInParent<StarControl>();
        levelControl = GameObject.FindGameObjectWithTag("GameController");
        levelControlScore = levelControl.GetComponent<ScoreCounter>();
    }

    void OnTriggerEnter()
    {

        levelControlScore.AddToScore(scorePerStar);
        StartCoroutine(myStarControl.addThisToList());
        //Destroy(this.transform.parent.gameObject);
    }
}
