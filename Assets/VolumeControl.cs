using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {

    private AudioSource music;

	// Use this for initialization
	void Start () {
        music = GetComponent<AudioSource>();
        KillControl.StopAllScripts += QuietMusic;
	}
	
	// Update is called once per frame
	void QuietMusic () {
        music.volume = (music.volume / 4);
	}

    void OnDestroy()
    {
        KillControl.StopAllScripts -= QuietMusic;
    }
}
