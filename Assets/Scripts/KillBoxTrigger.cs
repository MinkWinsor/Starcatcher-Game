using UnityEngine;
using System.Collections;

public class KillBoxTrigger : MonoBehaviour
{

    // Use this for initialization
    void OnTriggerEnter()
    {
        
        KillControl.ResetLevel();
    }
}