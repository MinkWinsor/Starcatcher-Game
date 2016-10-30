using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CloneStar : MonoBehaviour {

    public Transform[] spawnPoints;
    public float spawnFrequency;
    public bool canSpawnStars = true;

    public List<StarControl> starList;

    private bool startRunning = true;
    private int i = 0;
    private int j = 0;

    IEnumerator SpawnStars()
    {
        while (canSpawnStars)
        {
            i = UnityEngine.Random.Range(0, spawnPoints.Length - 1);
            print(starList.Count);
            j = UnityEngine.Random.Range(0, starList.Count - 1);
            print(j);
            
            starList[j].gameObject.SetActive(true);
            starList[j].transform.position = spawnPoints[i].position;

            if (starList.Count > 0)
            {
                starList[i].addToList = true;
                starList.RemoveAt(i);
            }

            //Instantiate(star, spawnPoints[i].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnFrequency);

        }
    }
	// Use this for initialization
	void Start () {

        StarControl.ListAdd += ListAddHandler;
        
	}

    void ListAddHandler(StarControl _l)
    {
        if (_l.addToList)
            starList.Add(_l);
        
    }

    void Update()
    {
        if (startRunning == true)
        {
            startRunning = false;
            StartCoroutine(SpawnStars());
        }

    }
	    
}
