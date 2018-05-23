using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NETS_CollisionTrigger : MonoBehaviour {

    public GameObject dnaChainL;
    public GameObject dnaChainR;
    private Animator animL;
    private Animator animR;

    private void Awake()
    {
        
        animL = dnaChainL.GetComponent<Animator>();
        animR = dnaChainR.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bacteria")
        {
            GameObject target = other.gameObject;
            other.gameObject.transform.parent = transform;
            target.GetComponent<EnemyHealth>().NetsHit();

            animL.SetTrigger("brokenDNA_Slowdown");
            animR.SetTrigger("fullDNA_Slowdown");

            ParticleSystem particleEffect = target.GetComponentInChildren<ParticleSystem>();
            if(particleEffect != null)
            {
                particleEffect.Play();
            }

            other.GetComponent<Collider>().enabled = false;
            other.gameObject.tag = "Captured Bacteria";
            
        }


        if(other.gameObject.tag == "Bacteria Sausage")
        {
            GameObject target = other.gameObject;
            target.transform.parent.GetComponent<EnemyHealthSausageBacteria>().NetsHit();
            target.transform.parent.parent = transform;

            other.GetComponent<Collider>().enabled = false;
            other.gameObject.tag = "Captured Bacteria";

            animL.SetTrigger("brokenDNA_Stop");
            animR.SetTrigger("fullDNA_Stop");
        }


        if (other.gameObject.tag == "Bacteria Bighead")
        {
            GameObject target = other.gameObject;
            other.gameObject.transform.parent = transform;
            target.GetComponent<EnemyHealthSausageBacteria>().NetsHit();

            animL.SetTrigger("brokenDNA_Stop");
            animR.SetTrigger("fullDNA_Stop");

            ParticleSystem particleEffect = target.GetComponentInChildren<ParticleSystem>();
            if (particleEffect != null)
            {
                particleEffect.Play();
            }

            other.GetComponent<Collider>().enabled = false;
            other.gameObject.tag = "Captured Bacteria";

        }
    }
}
