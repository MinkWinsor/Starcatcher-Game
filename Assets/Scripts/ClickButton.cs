using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

    public KillControl myKillC;

void OnMouseDown()
    {
        ResetHandler.ResetLevel();
    }
}
