using UnityEngine;
using System.Collections;

public class Star_Collision : MonoBehaviour
{
    //References tocontrolling objects, and variable for the score given per star.
    public ScoreCounter levelControlScore;
    public int scorePerStar;
    private StarControl myStarControl;

    //Called once per initialization.
    void Start()
    {
        myStarControl = GetComponentInParent<StarControl>();
    }

    void OnTriggerEnter()
    {

        levelControlScore.AddToScore(scorePerStar);
        myStarControl.Deactivate();
        //Destroy(this.transform.parent.gameObject);
    }


}
