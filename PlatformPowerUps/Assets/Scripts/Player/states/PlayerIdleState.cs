using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    // constructor
    public PlayerIdleState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    // state methods
    public override void EnterState()
    {
        GameManager.instance.canControlPlayer = true;
        stateManager.animator.Play("Idle");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckJump();
        CheckAttackCombo();
        CheckGunShoot();

        if(stateManager.isGrounded && stateManager.RB.velocity.x != 0)
        {
            stateManager.SetNextState(states.Running);
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
