using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AttackState
{
    public override void EnterState(AttackStateManager stateManager)
    {
        Debug.Log("ENTER IDLE");
        GameManager.instance.canControlPlayer = true;
    }

    public override void UpdateState(AttackStateManager stateManager)
    {
        base.UpdateState(stateManager);

        if (Input.GetKeyDown(KeyCode.J))
        {
            stateManager.SetNextState(new AttackEntryState());
        }
    }

    public override void ExitState(AttackStateManager stateManager) { }
    
}
