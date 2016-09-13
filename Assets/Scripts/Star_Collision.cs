using UnityEngine;
using System.Collections;

public class Star_Collision : MonoBehaviour
{
    //References tocontrolling objects, and variable for the score given per star.
    private ScoreCounter levelControlScore;
    private GameObject levelControl;
    public string ControllerName;
    public int scorePerStar;

    //Called once per initialization.
    void Start()
    {
        //References set.
        levelControl = GameObject.Find(ControllerName);
        levelControlScore = levelControl.GetComponent<ScoreCounter>();
    }

    void OnTriggerEnter(Collider other)
    {
        //If collided with player, is destroyed and adds to the score.
        if (other.gameObject.CompareTag("Player"))
        {
            levelControlScore.AddToScore(scorePerStar);
            Destroy(gameObject);
        }
    }
}
