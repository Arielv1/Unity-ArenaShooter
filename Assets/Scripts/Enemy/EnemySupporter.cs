using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySupporter : MonoBehaviour
{
     // Start is called before the first frame update
    public float distance= 5;
    public GameObject theCommander; 
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject TheNPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject[] enemies;
    public bool hasWeapon = false;
    public float minDistance = 10;
    public float hitRange = 4f;


    public Animator animator;

    void Start()
    {
        //  theCommander = GameObject.FindGameObjectWithTag("Enemy Commander");
        // theCommander = PlayerManager.instance.player;
        theCommander = GameObject.FindWithTag("Enemy Commander");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = theCommander.transform.position;
        animator.SetBool("isWalking", true);
        enemies = GameObject.FindGameObjectsWithTag("Allies");
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
        GameObject closest = null;
        float distance = minDistance +1;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            if(enemy != null)
            {
                Vector3 diff = enemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < minDistance)
                {
                    closest = enemy;
                    distance = curDistance;
                }
            }
        }
        return closest;
    }
    
    public void attack(GameObject enemy)
    {
        Debug.Log(transform.name + " attacked " + enemy.transform.name);
        transform.LookAt(enemy.transform.position);
        // check if has weapon
        CharacterStats sn = enemy.GetComponent<CharacterStats>();
        animator.SetBool("isShooting", true);
        sn.TakeDamage(50);
        // enemy.TakeDamage(50);
    }

    // public float getdistance(GameObject enemy)
    // {
    //     if(enemy == null) return minDistance + 1;
    //     Vector3 position = transform.position;
    //     Vector3 diff = enemy.transform.position - position;
    //     float distance = diff.sqrMagnitude;
    //     return distance;
    // }

    public GameObject WeaponInRange(float range)
    {
        // Debug.Log(" WeaponInRange called with range: " + range);
        var ray = new Ray(this.transform.position,this.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,range))
        {
            if (hit.transform.gameObject.tag == "PickUpGun" || hit.transform.gameObject.tag == "PickUpGrenade")
            {
                Debug.Log(" WeaponInRange we hit somthing: " + hit);
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
        // Disable pickupWeapon
        weapon.SetActive(false);
        // Enable Ally_handheldWeapon
        animator.SetBool("hasGun", true);
    }
}