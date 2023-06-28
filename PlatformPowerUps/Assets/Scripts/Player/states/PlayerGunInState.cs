using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunInState : PlayerState
{
    public PlayerGunInState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        GameManager.instance.canControlPlayer = true;
        stateDuration = 0.3f;
        stateManager.animator.Play("GunIn");

        stateManager.secondShotMade = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (PlayerIsMoving() || fixedTime >= stateDuration)
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

    bool PlayerIsMoving()
    {
        return stateManager.horizontalMove != 0;
    }
}
