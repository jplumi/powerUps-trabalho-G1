using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerState
{
    public PlayerShootState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    public override void EnterState()
    {
        stateDuration = 0.4f;
        stateManager.animator.Play("GunShoot");
        InstantiateShot();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (fixedTime >= stateDuration)
        {
            stateManager.SetNextState(states.GunIn);
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

    void InstantiateShot()
    {
        Object.Instantiate(
            stateManager.shotPrefab,
            stateManager.shotSpawnPoint.transform.position,
            stateManager.shotSpawnPoint.rotation);
    }
}
