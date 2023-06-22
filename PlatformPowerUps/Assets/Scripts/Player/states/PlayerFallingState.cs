using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    // constructor
    public PlayerFallingState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    // state methods
    public override void EnterState()
    {
        base.EnterState();

        stateManager.animator.Play("Jump/Fall");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckAttackCombo();
        CheckGunShoot();

        stateManager.animator.SetFloat("verticalMove", stateManager.RB.velocity.y);
        stateManager.landing_sfx.Play();

        if (stateManager.isGrounded)
        {
            stateManager.SetNextState(states.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
