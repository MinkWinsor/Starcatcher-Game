using UnityEngine;
using System.Collections;

public class CloneStar : MonoBehaviour {

    public Transform[] spawnPoints;
    public float spawnFrequency;
    public bool canSpawnStars = true;

    public GameObject[] stars;

    private int i = 0;
    private int j = 0;

    IEnumerator SpawnStars()
    {
        while (canSpawnStars)
        {
            i = Random.Range(0, spawnPoints.Length - 1);
            stars[j].SetActive(true);
            stars[j].transform.position = spawnPoints[i].position;
            stars[j].GetComponent<StarControl>().addForces();
            //StartCoroutine(stars[j].GetComponent<StarControl>().RunRandomForce());

            if (j < stars.Length - 1)
            {
                j++;
            }
            else
            {
                j = 0;
            }
            //Instantiate(star, spawnPoints[i].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnFrequency);

        }
    }




    void Start()
    {
        StartCoroutine(SpawnStars());
    }
	    
}
