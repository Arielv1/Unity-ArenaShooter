using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFindWeaonState : AiState
{
    GameObject pickup;
    

    public void Enter(AiAgent agent)
    {
        pickup = null;
        agent.navMeshAgent.speed = agent.config.findWeaponSpeed;
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
        // Find Pickup
        if (!pickup)
        {
            pickup = FindPickup(agent);
            if (pickup)
            { 
                CollectPickup(agent, pickup);
            }
        }

        // Wander
        if (!agent.navMeshAgent.hasPath)
        {
            WorldBounds worldBounds = GameObject.FindObjectOfType<WorldBounds>();
            Vector3 min = worldBounds.min.position;
            Vector3 max = worldBounds.max.position;

            Vector3 randomPosition = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                Random.Range(min.z, max.z)
                );
            agent.navMeshAgent.destination = randomPosition;
        }


        if (agent.weapons.HasWeapon()) 
        {
            agent.stateMachine.ChangeState(AiStateId.AttackPlayer);
        }
    }

    GameObject FindPickup(AiAgent agent)
    {
        if(agent.sensor.Objects.Count > 0)
        {
            return agent.sensor.Objects[0];
        }
        return null;
    }

    void CollectPickup(AiAgent agent, GameObject pickup)
    {
        agent.navMeshAgent.destination = pickup.transform.position;
    }

}
