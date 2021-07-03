using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject exposionEffect;
    float countdown;
    bool hasExploded = false;
    

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // Show effect
        Instantiate(exposionEffect, transform.position, transform.rotation);
         // Get nearby objects
         Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

         foreach(Collider nearbyObject in colliders)
         {
             // Add force
             Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
             if(rb != null)
             {
                 rb.AddExplosionForce(force, transform.position, radius);
             }

             // Damage
         }
        // Remove grenade
        Destroy(gameObject);
    }

  
}