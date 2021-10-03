using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;

using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MotherAI : MonoBehaviour
{
    #region StatesParameters
    public StateMashine stateMashine;
    public PatrolState patrolState;
    public LongRangeAtackState longRangeAtackState;

    public ChaseState chaseState;

    //public ChaseState chaseState;
    //public AtackState atackState;
    #endregion

    [NonSerialized] public PatrolScript patrol;
    [NonSerialized] public ShotBomb shotBomb;
    [NonSerialized] public ChaseScript chase;


    [SerializeField] public float patrolSpeed = 0.1f;
    [SerializeField] public float chaseSpeed = 3;
    [SerializeField] public float stopTime = 3;

    [SerializeField] public float chaseRange = 3;
    [SerializeField] public float longRangeAtackDistance = 14;
    [SerializeField] public float startWaitTime = 5f;

    [SerializeField] public Rigidbody2D bompPrefab;

    [SerializeField] public float cooldown = 3f;
    public float cooldownTimer;

    public Collider2D patrolArea;

    private Rigidbody2D mainBody;
    public Transform player;

    private void Start()
    {
        patrolArea = GameObject.FindGameObjectWithTag("MotherArea").GetComponent<Collider2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        patrol = GetComponent<PatrolScript>();
        shotBomb = GetComponent<ShotBomb>();
        chase = GetComponent<ChaseScript>();

        stateMashine = new StateMashine();
        patrolState = new PatrolState(this, stateMashine);
        longRangeAtackState  = new LongRangeAtackState(this, stateMashine);
        chaseState = new ChaseState(this, stateMashine);

        stateMashine.InitializeState(patrolState);
    }

    private void Update()
    {
        stateMashine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
       stateMashine.CurrentState.PhysicsUpdate();
    }

}
