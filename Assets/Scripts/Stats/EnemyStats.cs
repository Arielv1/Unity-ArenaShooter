using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Threading.Tasks;

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        // Add ragdoll effect / death animation
        Destroy(gameObject);
        // FindObjectOfType<GameController>().checkGameOverForEnemies();
    }

    void OnDestroy()
    {
        FindObjectOfType<GameController>().checkGameOverForEnemies();
    }
    
}
