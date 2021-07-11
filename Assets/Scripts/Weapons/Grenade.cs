using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject exposionEffect;
    private float countdown;
    private bool hasExploded = false;

    private AudioSource grenadeExplosionSFX;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        grenadeExplosionSFX = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            StartCoroutine(Explode());
            hasExploded = true;
        }
    }

    IEnumerator Explode()
    {
        grenadeExplosionSFX.Play();
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

        sr.color = new Color(0f, 0f, 0f, 0f);
        // Remove grenade
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

  
}
