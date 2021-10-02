using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public PatrolState(MotherAI mother, StateMashine stateMashine) : base(mother, stateMashine) { }

    public override void Enter()
    {
        base.Enter();
        // mother.ChangeDir();
    }

    //    public override void Exit()
    //    {
    //        base.Exit();
    //    }

    //    public override void LogicUpdate()
    //    {
    //        base.LogicUpdate();
    //    }

    //    public override void PhysicsUpdate()
    //    {
    //        base.PhysicsUpdate();

    //        enemy.Patrol();
    //        if (enemy.detectTarget())
    //        {
    //            enemyStateMashine.ChangeState(enemy.chaseState);
    //        }
    //    }

}