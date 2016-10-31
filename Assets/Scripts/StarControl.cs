using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour {

    public float endTime = 3;
    
    public int forceRange = 10;
    public int torqueForceRange = 1;
    private float forceTime = 10;
    public float startingForceTime = 10;

    private float forceDuration = 0.1f;
    private Rigidbody rigid;
    private Vector3 forceVector;
    private Animator anims;
    private Vector3 torqueVector;


    void Start()
    {
        
        anims = GetComponent<Animator>();
        
    }
    
    public void addForces()
    {
        StartCoroutine(RunRandomForce());
    }

    IEnumerator RunRandomForce()
    {
        if(rigid == null)
            rigid = GetComponent<Rigidbody>();
        forceTime = startingForceTime;
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

    public void Deactivate()
    {
        anims.SetBool("Destory", false);
        gameObject.SetActive(false);
    }

    void OnCollisionEnter()
    {
        forceTime = 0;
        anims.SetBool("Destory", true);
    }
}
