using UnityEngine;
using System.Collections;

public class CloneStar : MonoBehaviour {

    public Transform[] spawnPoints;
        public Transform star;
    public float spawnFrequency;

    private int i = 0;

    IEnumerator SpawnStars()
    {
        while (i < spawnPoints.Length)
        {
            Instantiate(star, spawnPoints[i].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnFrequency);
            i++;

        }
    }
	// Use this for initialization
	void Start () {
	StartCoroutine(SpawnStars());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
