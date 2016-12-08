using UnityEngine;
using System.Collections;

public class Star_Collision : MonoBehaviour
{
    //References tocontrolling objects, and variable for the score given per star.
    public ScoreCounter levelControlScore;
    public int scorePerStar;
    private StarControl myStarControl;
    public bool hasHitGround = false;
    public PlayCrunch noise;

    //Called once per initialization.
    void Start()
    {
        myStarControl = GetComponentInParent<StarControl>();
    }

    public void groundHit()
    {
        hasHitGround = true;
    }

    void OnTriggerEnter()
    {
        noise.playCrunchNoise();
        if (hasHitGround)
        {
            levelControlScore.AddToScore(scorePerStar);
            
            myStarControl.Deactivate();
        }
        else
        {
            levelControlScore.AddToScore(scorePerStar * 2);
            myStarControl.Deactivate();
        }


        
        //Destroy(this.transform.parent.gameObject);
    }

    


}
