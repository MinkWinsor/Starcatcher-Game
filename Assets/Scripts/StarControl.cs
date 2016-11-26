using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour {

    public float endTime = 3;
    public int forceRange = 10;
    public int torqueForceRange = 1;
    public float startingForceTime = 10;

    private float forceTime = 10;
    private float forceDuration = 0.1f;
    private Rigidbody rigid;
    private Vector3 forceVector;
    private Animator anims;
    private Vector3 torqueVector;
    private Star_Collision mySC;


    void Start()
    {
        mySC = GetComponentInChildren<Star_Collision>();
        anims = GetComponent<Animator>();
        anims.SetBool("Destory", false);
        
    }
    
    public void addForces()
    {
        StartCoroutine(RunRandomForce());
    }

    IEnumerator RunRandomForce()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody>();

        forceTime = startingForceTime;
        forceVector.x = UnityEngine.Random.Range(-forceRange, forceRange);
        forceVector.y = UnityEngine.Random.Range(-forceRange * 2, 0);

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
        rigid.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    void OnCollisionEnter()
    {
        forceTime = 0;
        mySC.groundHit();
        anims.SetBool("Destory", true);
    }
}
