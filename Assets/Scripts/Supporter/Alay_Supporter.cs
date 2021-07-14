using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alay_Supporter : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance= 5;
    public GameObject theCommander; 
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject TheNPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    private NavMeshAgent agent;
    private GameObject[] enemies;
    public bool hasWeapon = false;
    public float minDistance = 10;
    public float hitRange = 4f;


    void Start()
    {
        //  theCommander = GameObject.FindGameObjectWithTag("Enemy Commander");
        theCommander = PlayerManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = theCommander.transform.position;
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
            GameObject weapon = WeaponInRange(hitRange);
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
    
    public void attack(GameObject enemy)
    {
        Debug.Log(transform.name + " attacked " + enemy.transform.name);
        transform.LookAt(enemy.transform.position);
        // check if has weapon
        CharacterStats sn = enemy.GetComponent<CharacterStats>();
        sn.TakeDamage(50);
        // enemy.TakeDamage(50);
    }
    public float getdistance(GameObject enemy)
    {
        if(enemy == null) return minDistance + 1;
        Vector3 position = transform.position;
        Vector3 diff = enemy.transform.position - position;
        float distance = diff.sqrMagnitude;
        return distance;
    }
    public GameObject WeaponInRange(float range)
    {
        Debug.Log(" WeaponInRange called with range: " + range);
        var ray = new Ray(this.transform.position,this.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,range))
        {
            Debug.Log(" WeaponInRange we hit somthing: " + hit);
            if (hit.transform.gameObject.tag == "PickUpGun" || hit.transform.gameObject.tag == "PickUpGrenade")
            {
                return hit.transform.gameObject;
                // if (hit.transform.gameObject.tag == "PickUpGun")
                //     {
                //         Debug.Log(" WeaponInRange we hit a weapon: " + hit);
                //         return hit.transform.gameObject;
                //     }
            }
        }
        return null;

    }
    private void PickUpWeapon(GameObject weapon)
    {
         Debug.Log("PickUpWeapon called with weapon: " + weapon);
        hasWeapon = true;
    }
}