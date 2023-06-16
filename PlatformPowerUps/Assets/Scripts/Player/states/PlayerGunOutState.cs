using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunOutState : PlayerState
{
    public PlayerGunOutState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    public override void EnterState()
    {
        GameManager.instance.canControlPlayer = false;
        stateDuration = 0.3f;
        stateManager.animator.Play("GunOut");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (fixedTime >= stateDuration)
        {
            stateManager.SetNextState(states.Shoot);
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
