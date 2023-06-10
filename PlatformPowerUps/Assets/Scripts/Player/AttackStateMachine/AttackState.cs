using UnityEngine;

public abstract class AttackState
{
    protected float attackDuration = 0f;

    // time since state entry
    protected float fixedTime = 0f;

    // check whether the next attack in the sequence should be played or not
    protected bool shouldCombo;

    public abstract void EnterState(AttackStateManager stateManager);

    public virtual void UpdateState(AttackStateManager stateManager)
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            shouldCombo = true;
        }
    }

    public virtual void FixedUpdateState(AttackStateManager stateManager)
    {
        fixedTime += Time.fixedDeltaTime;
    }

    public abstract void ExitState(AttackStateManager stateManager);
}
