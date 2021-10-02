using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherAI : MonoBehaviour
{
    [SerializeField] private float patrolSpeed = 0.1f;
    [SerializeField] private float chaseSpeed = 3;
    [SerializeField] private float stopTime = 3;

    // Start is called before the first frame update

    private Rigidbody2D mainBody;

    #region StatesParameters
    public StateMashine stateMashine;
    public PatrolState patrolState;

    //public ChaseState chaseState;
    //public AtackState atackState;
    #endregion

    void Start()
    {
        stateMashine = new StateMashine();
        stateMashine.InitializeState(patrolState);
    }

    private void Update()
    {
        stateMashine.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMashine.CurrentState.PhysicsUpdate();
    }
}
