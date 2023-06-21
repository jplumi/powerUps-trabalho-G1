using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackingState : SkeletonState
{
    public SkeletonAttackingState(Skeleton manager, SkeletonStateInstances states)
        : base(manager, states) { }

    float stateDuration = 1f;

    public override void EnterState()
    {
        base.EnterState();

        stateManager.animator.Play("Attack");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(fixedTime >= stateDuration)
        {
            stateManager.SetNextState(states.Alert);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
