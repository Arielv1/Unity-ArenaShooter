using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // public GameObject player;
    // Start is called before the first frame update
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetValue(currentHealth);
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        // end game
        Debug.Log("override called: "+transform.name + " Died.");
        FindObjectOfType<GameController>().GameOver("Enemy");

    }

}
