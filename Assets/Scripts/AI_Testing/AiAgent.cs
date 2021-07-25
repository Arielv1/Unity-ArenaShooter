using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{   
    public AiStateId initialState;
    public AiAgentConfig config;

    [HideInInspector] public AiStateMachine stateMachine;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Ragdoll ragdoll;
    [HideInInspector] public SkinnedMeshRenderer mesh;
    [HideInInspector] public UIHealthBar ui;
    [HideInInspector] public Transform playerTransform;
    [HideInInspector] public AiWeapons weapons;
    [HideInInspector] public AiSensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        mesh = GetComponent<SkinnedMeshRenderer>();
        ui = GetComponent<UIHealthBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        weapons = GetComponent<AiWeapons>();
        sensor = GetComponent<AiSensor>();
        playerTransform = GameObject.FindGameObjectWithTag("Allies").transform;

        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiFindWeaonState());
        stateMachine.RegisterState(new AiAttackPlayerState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
