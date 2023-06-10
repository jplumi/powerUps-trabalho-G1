using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEntryState : AttackState
{
    public override void EnterState(AttackStateManager stateManager)
    {
        //Debug.Log("ENTER ENTRY");
        GameManager.instance.canControlPlayer = false;
        attackDuration = 0.55f;

        stateManager.damageAmount = 30;
        stateManager.animator.SetTrigger("attack1");
    }

    public override void UpdateState(AttackStateManager stateManager)
    {
        base.UpdateState(stateManager);

        if (fixedTime >= attackDuration)
        {
            if (shouldCombo)
                stateManager.SetNextState(new AttackComboState());
            else
            {
                stateManager.SetNextState(new IdleState());
            }
        }
    }

    public override void ExitState(AttackStateManager stateManager)
    {

    }
}
