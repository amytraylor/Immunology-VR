using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

    public bool isBacteriaBoss;
    public ParticleSystem launcher;
    List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        //launcher = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>(); 
    }


    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(launcher, other, collisionEvents);

        for(int i = 0; i< collisionEvents.Count; i++)
        {
            if (other.transform.tag == "Bacteria")
            {

                Debug.Log("bacteria hit");

                if (other.GetComponent<EnemyHealth>())
                {
                    other.GetComponent<EnemyHealth>().GotHit();
                }

            }


            if (other.transform.tag == "Bacteria Sausage")
            {
                isBacteriaBoss = true;
                GameObject hitTarget = other.transform.gameObject;
                hitTarget.transform.parent.GetComponent<EnemyHealthSausageBacteria>().GotHit();

            }


            if (other.transform.tag == "Bacteria Bighead")
            {
                isBacteriaBoss = true;
                GameObject hitTarget = other.transform.gameObject;
                hitTarget.GetComponent<EnemyHealthSausageBacteria>().GotHit();

            }

        }

        

    }
}
