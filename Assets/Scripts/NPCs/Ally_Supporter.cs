using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally_Supporter : NPC
{
    // Start is called before the first frame update
    private GameObject theCommander; 
    private NavMeshAgent agent;
    private GameObject[] enemies;
    public float shootingRange = 20f;
    public float pickUpRange = 1f;


    void Start()
    {
        theCommander = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update () {
        if(theCommander)
        {
            transform.LookAt(theCommander.transform);
            agent.destination = theCommander.transform.position;
            animator.SetBool("isWalking", true);
        }
        // search for enemy / weapon
        if(hasWeapon)
        {
            GameObject closestEnemy = FindClosestEnemy();
            if(closestEnemy)
            {
                attack(closestEnemy);             
            }
        }
        else
        {
            GameObject weapon = WeaponInRange(pickUpRange);
            if(weapon)
            {
                PickUpWeapon(weapon);
            }
        }
    }

     public GameObject FindClosestEnemy()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        GameObject enemyCommander = GameObject.FindWithTag("Enemy Commander");

        float enemyD = getdistance(enemy);
        float enemyCommanderD = getdistance(enemyCommander);
        float closestEnemyD = Mathf.Min(enemyD, enemyCommanderD);

        if(closestEnemyD < shootingRange)
        {
            if (closestEnemyD == enemyD)
            {
                return enemy;
            }
            else
            {
                return enemyCommander;
            }
        }
        return null;
    }
    
    public float getdistance(GameObject enemy)
    {
        if(enemy == null) return shootingRange + 1;
        Vector3 position = transform.position;
        Vector3 diff = enemy.transform.position - position;
        float distance = diff.sqrMagnitude;
        return distance;
    }
}