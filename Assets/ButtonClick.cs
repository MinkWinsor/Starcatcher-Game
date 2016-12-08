using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

    private AudioSource buttonClickNoise;

    // Use this for initialization
    void Start () {
        buttonClickNoise = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	public void Clicked () {
        buttonClickNoise.Play();
	}
}
