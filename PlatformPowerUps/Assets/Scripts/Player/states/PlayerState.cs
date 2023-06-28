using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected PlayerStateManager stateManager;
    protected PlayerStateInstances states;

    protected float stateDuration;

    public PlayerState(PlayerStateManager playerStateManager, PlayerStateInstances states)
    {
        stateManager = playerStateManager;
        this.states = states;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    // call this method in any state the player should jump
    protected void CheckJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            stateManager.SetNextState(states.Jumping);
        }
    }

    protected void CheckAttackCombo()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stateManager.SetNextState(states.Attack1);
        }
    }

    protected void CheckGunShoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            stateManager.SetNextState(states.GunOut);
        }
    }
}
