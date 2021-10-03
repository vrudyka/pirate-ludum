using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeAtackState : EnemyState
{
    public LongRangeAtackState(MotherAI mother, StateMashine stateMashine) : base(mother, stateMashine) { }

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
        if (Vector2.Distance(mother.transform.position, mother.player.position) > mother.longRangeAtackDistance)
        {
            StateMashine.ChangeState(mother.patrolState);
        }

        if (mother.patrol.targetInRange(mother.player, mother.chaseRange) == true)
        {
            StateMashine.ChangeState(mother.chaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        mother.shotBomb.ShotOnDistance(this.mother.player, this.mother.bompPrefab);
    }
}