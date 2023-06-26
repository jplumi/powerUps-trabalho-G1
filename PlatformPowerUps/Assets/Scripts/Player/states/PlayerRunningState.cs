using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerState
{
    // constructor
    public PlayerRunningState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    // state methods
    public override void EnterState()
    {
        base.EnterState();

        stateManager.audioSource.Play();
        stateManager.animator.Play("Running");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        // we should jump while running too
        CheckJump();
        CheckAttackCombo();
        CheckGunShoot();

        if(stateManager.horizontalMove == 0)
        {
            stateManager.audioSource.Stop();
            stateManager.SetNextState(states.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
