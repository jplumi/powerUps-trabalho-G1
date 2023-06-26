using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
    public PlayerHitState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    float stopKnockbackTime = 0.15f;

    public override void EnterState()
    {
        base.EnterState();

        stateDuration = 0.7f;

        GameManager.instance.canControlPlayer = false;
        GameManager.instance.MakePlayerInvincible();
        stateManager.animator.Play("Hit");
        stateManager.audioSource.PlayOneShot(stateManager.damege_sfx);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (fixedTime >= stopKnockbackTime)
            stateManager.RB.velocity = new Vector2(0, stateManager.RB.velocity.y);

        if (fixedTime >= stateDuration)
        {
            stateManager.SetNextState(states.Idle);
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
