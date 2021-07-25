using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;

        if (currentHealth <= 0.0f)
        {
            Die(direction);
        }

    }
    public void Die(Vector3 direction)
    {


    }
    public void Update()
    {


    }
}
