using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ally_Supporter : NPC
{
    // Start is called before the first frame update
    public float distance= 5;
    public GameObject theCommander; 
    private NavMeshAgent agent;
    private GameObject[] enemies;
    public float minDistance = 10;
    public float pickUpRange = 10f;


    void Start()
    {
        //  theCommander = GameObject.FindGameObjectWithTag("Enemy Commander");
        theCommander = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = theCommander.transform.position;
        animator.SetBool("isWalking", true);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update () {
        if(theCommander)
        {
            transform.LookAt(theCommander.transform);
            agent.destination = theCommander.transform.position;
        }
        // check for weapon else check to pickup weapon
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
        GameObject Enemy = GameObject.FindWithTag("Enemy");
        GameObject theEnemyCommander = GameObject.FindWithTag("Enemy Commander");
        GameObject closest = null;
        float enemyDistance = getdistance(Enemy);
        float enemyCommanderDistance = getdistance(theEnemyCommander);
        if(enemyDistance < minDistance && enemyDistance < enemyCommanderDistance)
        {
            return Enemy;
        }
        if(enemyCommanderDistance < minDistance && enemyCommanderDistance <= enemyDistance)
        {
            return theEnemyCommander;
        }
        return closest;
    }
    
    public float getdistance(GameObject enemy)
    {
        if(enemy == null) return minDistance + 1;
        Vector3 position = transform.position;
        Vector3 diff = enemy.transform.position - position;
        float distance = diff.sqrMagnitude;
        return distance;
    }
}