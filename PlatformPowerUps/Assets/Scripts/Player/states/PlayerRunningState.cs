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
        stateManager.movement_sfx.Play();
        stateManager.animator.Play("Running");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        // we should jump while running too
        CheckJump();
        CheckAttackCombo();
        CheckGunShoot();

        if(stateManager.RB.velocity.x == 0)
        {
            stateManager.movement_sfx.Stop();
            stateManager.SetNextState(states.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
