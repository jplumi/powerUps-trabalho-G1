using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonState : State
{
    protected Skeleton stateManager;
    protected SkeletonStateInstances states;

    protected bool wallHit = false;
    protected bool stepHit = false;
    protected bool playerDetected = false;

    // direction the enemy is facing
    protected Vector2 direction = Vector2.right;

    public SkeletonState(Skeleton manager, SkeletonStateInstances states)
    {
        stateManager = manager;
        this.states = states;
    }

    public override void EnterState()
    {
        base.EnterState();
        stateManager.audioSource.Stop();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckStep();
        CheckWall();
        CheckPlayer();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    void CheckWall()
    {
        Vector2 origin = stateManager.gameObject.transform.position;
        //float raycastDistance = 1f;
        wallHit = Physics2D.Raycast(
            origin,
            direction,
            stateManager.wallCheckerDistance,
            stateManager.groundLayer);

        Debug.DrawRay(origin, direction * stateManager.wallCheckerDistance, Color.blue);
    }

    void CheckStep()
    {
        //float raycastDistance = 1.4f;
        Vector2 raycastOrigin = (Vector2) stateManager.transform.position + direction * 0.7f;

        stepHit = !Physics2D.Raycast(raycastOrigin, Vector2.down, stateManager.stepCheckerDistance, stateManager.groundLayer);

        Debug.DrawRay(raycastOrigin, Vector2.down * stateManager.stepCheckerDistance, Color.red);
    }

    void CheckPlayer()
    {
        Vector2 origin = stateManager.gameObject.transform.position;
        //float raycastDistance = 6f;
        playerDetected = Physics2D.Raycast(
            origin,
            direction,
            stateManager.playerCheckerDistance,
            stateManager.playerLayer);

        Debug.DrawRay(origin, direction * stateManager.playerCheckerDistance, Color.green);
    }

    protected void Flip()
    {
        if (direction.Equals(Vector2.right))
        {
            stateManager.transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.left;
        }
        else
        {
            stateManager.transform.eulerAngles = new Vector2(0, 0);
            direction = Vector2.right;
        }
    }
}
