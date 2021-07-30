using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public HealthBar healthBar;
    [HideInInspector]
    public float currentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);
    }

    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        Debug.Log("currentHealth = " + currentHealth);
        if (IsDead())
        {
            Die();
        }
        else
        {
            healthBar.SetValue(currentHealth);
        }

    }
    public void Die()
    {
        Debug.Log("The player is dead!");
        // end game
        GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        FindObjectOfType<GameController>().GameOver();
    }
    public void Update()
    {


    }

    public bool IsDead()
    {
        return currentHealth <= 0.0f;
    }

}
