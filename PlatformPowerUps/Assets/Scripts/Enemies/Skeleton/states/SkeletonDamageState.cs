using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamageState : SkeletonState
{
    float stateDuration = 0.5f;

    public SkeletonDamageState(Skeleton manager, SkeletonStateInstances states)
        : base(manager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateManager.animator.Play("Damage");
        stateManager.audioSource.PlayOneShot(stateManager.damege_sfx);
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
