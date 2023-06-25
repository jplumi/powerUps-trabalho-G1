using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
    public PlayerHitState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateDuration = 0.7f;

        GameManager.instance.canControlPlayer = false;
        stateManager.animator.Play("Hit");
        stateManager.audioSource.PlayOneShot(stateManager.damege_sfx);
        GameManager.instance.MakePlayerInvincible();
    }

    public override void UpdateState()
    {
        base.UpdateState();

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
