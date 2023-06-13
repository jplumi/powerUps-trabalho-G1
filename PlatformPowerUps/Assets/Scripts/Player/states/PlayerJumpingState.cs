using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState
{

    float jumpForce = 28;

    // constructor
    public PlayerJumpingState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    // state methods
    public override void EnterState()
    {
        base.EnterState();
        stateManager.animator.Play("Jump/Fall");
        stateManager.RB.velocity = new Vector2(stateManager.RB.velocity.x, jumpForce);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckAttackCombo();

        stateManager.animator.SetFloat("verticalMove", stateManager.RB.velocity.y);

        if (!stateManager.isGrounded && stateManager.RB.velocity.y <= 0)
        {
            stateManager.SetNextState(states.Falling);
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
