using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour {

    public float endTime = 3;
    
    public int forceRange = 10;
    public int torqueForceRange = 1;
    public float forceTime = 10;

    private float forceDuration = 0.1f;
    private Rigidbody rigid;
    private float torqueForce = 10;
    private Vector3 forceVector;
    private Vector3 torqueVector;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(RunRandomForce());
    }
	
	IEnumerator RunRandomForce()
    {
        forceVector.x = Random.Range(-forceRange, forceRange);

        torqueVector.x = Random.Range(-torqueForceRange, torqueForceRange);
        torqueVector.y = Random.Range(-torqueForceRange, torqueForceRange);
        torqueVector.z = Random.Range(-torqueForceRange, torqueForceRange);

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
        Destroy(gameObject, endTime);
    }
}
