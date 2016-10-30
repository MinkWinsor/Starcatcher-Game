using UnityEngine;
using System.Collections;
using System;

public class StarControl : MonoBehaviour {

    public float endTime = 3;
    
    public int forceRange = 10;
    public int torqueForceRange = 1;
    public float forceTime = 10;
    public bool addToList = true;

    private float forceDuration = 0.1f;
    private Rigidbody rigid;
    private Vector3 forceVector;
    private Vector3 torqueVector;


    public static Action<StarControl> ListAdd;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(addThisToList());
    }

    public IEnumerator addThisToList()
    {
        
        if (ListAdd != null && addToList)
        {
            ListAdd(this);
            yield return new WaitForSeconds(endTime);
            gameObject.SetActive(false);
        }
    }

    IEnumerator RunRandomForce()
    {
        forceVector.x = UnityEngine.Random.Range(-forceRange, forceRange);

        torqueVector.x = UnityEngine.Random.Range(-torqueForceRange, torqueForceRange);
        torqueVector.y = UnityEngine.Random.Range(-torqueForceRange, torqueForceRange);
        torqueVector.z = UnityEngine.Random.Range(-torqueForceRange, torqueForceRange);

        while (forceTime > 0)
        {

            rigid.AddForce(forceVector);
            rigid.AddTorque(torqueVector);

            forceTime -= 1;

            yield return new WaitForSeconds(forceDuration);
        }
    }

    void OnCollisionEnter()
    {
        forceTime = 0;
        StartCoroutine(addThisToList());
    }
}
