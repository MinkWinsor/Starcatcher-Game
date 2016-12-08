using UnityEngine;
using System.Collections;

public class WolfHitPlayer : MonoBehaviour {

    public ScoreCounter mySC;
    public bool triggerReady = true;
    public CharacterFlipArt myCFA;

    private AudioSource ouchAudio;

    void Start()
    {
        ouchAudio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void OnTriggerEnter () {
        if (triggerReady)
        {
            mySC.PlayerHit();
            triggerReady = false;
            StartCoroutine(myCFA.flashCharacter());
            ouchAudio.Play();
        }
        
	}

}
