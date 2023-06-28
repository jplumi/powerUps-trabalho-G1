using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : PlayerState
{
    public PlayerShootState(PlayerStateManager playerStateManager, PlayerStateInstances states)
        : base(playerStateManager, states) { }

    bool secondShot = false;

    public override void EnterState()
    {
        base.EnterState();

        stateDuration = 0.4f;
        stateManager.animator.Play("GunShoot");
        stateManager.audioSource.PlayOneShot(stateManager.shot_sfx);
        InstantiateShot();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckSecondShot();

        if (fixedTime >= stateDuration)
        {
            if (!stateManager.secondShotMade && secondShot)
            {
                secondShot = false;
                stateManager.secondShotMade = true;
                stateManager.SetNextState(states.Shoot);
            } else
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

    void CheckSecondShot()
    {
        if(stateManager.canDoubleShot && Input.GetMouseButtonDown(1))
        {
            secondShot = true;
        }
    }
}
