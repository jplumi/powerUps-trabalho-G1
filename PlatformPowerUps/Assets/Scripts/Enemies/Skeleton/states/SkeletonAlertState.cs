using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAlertState : SkeletonState
{
    Transform player;

    public SkeletonAlertState(Skeleton manager, SkeletonStateInstances states)
         : base(manager, states) { }

    public override void EnterState()
    {
        base.EnterState();

        stateManager.movementSpeed *= 1.5f;

        player = GameObject.Find("Player").transform;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();


        GetPlayerDirection();
        CheckDirection();
        stateManager.RB.velocity = direction * stateManager.movementSpeed;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    void GetPlayerDirection()
    {
        float enemyXPosition = stateManager.gameObject.transform.position.x;
        if(player.position.x < enemyXPosition)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }
    }

    void CheckDirection()
    {
        if(stateManager.RB.velocity.x < 0)
            stateManager.transform.eulerAngles = new Vector2(0, 180);
        else
            stateManager.transform.eulerAngles = new Vector2(0, 0);
    }
}
