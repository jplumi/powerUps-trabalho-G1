using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonState
{
    public SkeletonIdleState(Skeleton manager, SkeletonStateInstances states)
        : base(manager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateManager.animator.Play("Idle");
    }

    public override void UpdateState()
    {
        base.UpdateState();


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
