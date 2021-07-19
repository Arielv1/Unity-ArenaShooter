using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFindWeaonState : AiState
{
    public void Enter(AiAgent agent)
    {
        GameObject pickup = FindClosestWeapon(agent);
        agent.navMeshAgent.destination = pickup.transform.position;
        agent.navMeshAgent.speed = 5;
    }

    public void Exit(AiAgent agent)
    {

    }

    public AiStateId GetId()
    {
        return AiStateId.FindWeapon;
    }

    public void Update(AiAgent agent)
    {

    }

    private GameObject FindClosestWeapon(AiAgent agent)
    {
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("PickUpGun");
        Debug.Log("Weapons: " + weapons.Length);
        GameObject closestWeapon = null;
        float closestDistance = float.MaxValue;
        foreach (var weapon in weapons)
        {
            float distanceToWeapon = Vector3.Distance(agent.transform.position, weapon.transform.position);
            if (distanceToWeapon < closestDistance)
            {
                closestDistance = distanceToWeapon;
                closestWeapon = weapon;
            }
        }
        return closestWeapon;
    }

}
