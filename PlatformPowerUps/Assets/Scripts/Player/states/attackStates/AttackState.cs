using UnityEngine;

public abstract class AttackState : PlayerState
{
    // constructor
    public AttackState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    protected float attackDuration = 0f;

    // check whether the next attack in the sequence should be played or not
    protected bool shouldCombo = false;

    public override void UpdateState()
    {
        base.UpdateState();

        if (Input.GetKeyDown(KeyCode.J))
        {
            shouldCombo = true;
        }
    }

    public override void ExitState()
    {
        base.ExitState();

        shouldCombo = false;
    }
}
