using UnityEngine;

public abstract class State
{
    // time since state entry
    protected float time { get; set; }
    protected float fixedTime { get; set; }

    public virtual void EnterState() { }

    public virtual void UpdateState()
    {
        time += Time.deltaTime;
    }

    public virtual void FixedUpdateState()
    {
        fixedTime += Time.fixedDeltaTime;
    }

    public virtual void ExitState()
    {
        time = 0f;
        fixedTime = 0f;
    }
}
