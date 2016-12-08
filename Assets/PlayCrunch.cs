using UnityEngine;
using System.Collections;

public class PlayCrunch : MonoBehaviour {

    public AudioClip[] audioList;
    private AudioSource audioPlayer;

	// Use this for initialization
	public void playCrunchNoise () {

        audioPlayer.PlayOneShot(audioList[(Random.Range(0, 2))]);
	}
	
	// Update is called once per frame
	void Start () {
        audioPlayer = GetComponent<AudioSource>();
	}
}
