using UnityEngine;
using System.Collections;

public class WolfHitPlayer : MonoBehaviour {

    public ScoreCounter mySC;
    public bool triggerReady = true;
    public CharacterFlipArt myCFA;

	// Use this for initialization
	void OnTriggerEnter () {
        if (triggerReady)
        {
            mySC.PlayerHit();
            triggerReady = false;
            StartCoroutine(myCFA.flashCharacter());
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
