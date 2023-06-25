using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeathState : SkeletonState
{
    public SkeletonDeathState(Skeleton manager, SkeletonStateInstances states)
        : base(manager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateManager.audioSource.PlayOneShot(stateManager.death_sfx1);
        stateManager.audioSource.PlayOneShot(stateManager.death_sfx2);
        stateManager.animator.Play("Death");
        Object.Destroy(stateManager.gameObject, 2f);
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
