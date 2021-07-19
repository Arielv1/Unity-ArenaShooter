using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
    public void Enter(AiAgent agent)
    {
        agent.ragdoll.ActivateRagdoll();
        //agent.ui.gameObject.SetActive(false);
        //agent.mesh.updateWhenOffscreen = true;
    }

    public void Exit(AiAgent agent)
    {

    }

    public AiStateId GetId()
    {
        return AiStateId.Death;
    }

    public void Update(AiAgent agent)
    {

    }
}
