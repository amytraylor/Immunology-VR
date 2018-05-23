using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;


public class EnemyAItest : MonoBehaviour {

   
    GameObject target;
    public bool isAttacking;
    bool isAttacked;

    float speed = 5f;
    ParticleSystem particleLauncher;

    splineMove script;

    private void Awake()
    {
        script = GetComponent<splineMove>();
        particleLauncher = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bacteria")
        {
            target = other.gameObject;

            isAttacking = true;
            StartCoroutine(SplinePause());
            
        }
    }


    private void Update()
    {
        if(isAttacking == true)
        {
            TurnToTarget();
            //MoveToTarget();
            particleLauncher.Emit(1);


        }

        
    }

  
    void TurnToTarget()
    {
        if(target != null)
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2f);

        }

    }

    void MoveToTarget()
    {
        if((target.transform.position - transform.position).sqrMagnitude >5f)
        {
            transform.position += (target.transform.position - transform.position).normalized * Time.deltaTime * speed;
        }
        
    }

 

    IEnumerator SplinePause()
    {
        script.Pause();
        yield return new WaitForSeconds(8f);

        script.Resume();
        isAttacking = false;
    }
}
