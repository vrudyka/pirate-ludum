using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public PatrolState(MotherAI mother, StateMashine stateMashine)
        : base(mother, stateMashine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (mother.patrol.targetInRange(mother.player, mother.longRangeAtackDistance) == true)
        {
            StateMashine.ChangeState(mother.longRangeAtackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        mother.patrol.PatrolTeretory(mother.patrolArea, mother.startWaitTime);
    }
}