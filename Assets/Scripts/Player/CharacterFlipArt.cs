
using UnityEngine;
using System.Collections;

public class CharacterFlipArt : MonoBehaviour
{

    private Transform characterArt;
    public bool forward = true;

    //This function flips the art and sets that the art has been flipped.

    void FlipCharacter(KeyCode _keyCode)
    {
        
        switch (_keyCode)
        {
            case KeyCode.RightArrow:
                if (!forward)
                {
                    characterArt.Rotate(0, 180, 0);
                    forward = true;
                }
                
                break;
            case KeyCode.LeftArrow:
                if (forward)
                {
                    characterArt.Rotate(0, 180, 0);
                    forward = false;
                }
                break;
        }
    }

    void Start()
    {
        UserInputs.FlipDirection += FlipCharacter;
        KillControl.StopAllScripts += stopScript;
        characterArt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void stopScript()
    {
        UserInputs.FlipDirection -= FlipCharacter;

    }

    void OnDestroy()
    {
        UserInputs.FlipDirection -= FlipCharacter;
    }

}