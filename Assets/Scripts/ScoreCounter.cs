﻿using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

    //Public variable for score counter and reference to the text that displays the score.
    public int score;
    public UnityEngine.UI.Text scoreText;

    //Adds to score and changes text component to display new score.
    public void AddToScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = ("Score: " + score);
    }

    
}
