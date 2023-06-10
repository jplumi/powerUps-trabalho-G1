using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComboState : AttackState
{
    public override void EnterState(AttackStateManager stateManager)
    {
        //Debug.Log("ENTER COMBO");
        attackDuration = 0.55f;

        stateManager.damageAmount = 30;
        stateManager.animator.SetTrigger("attack2");
    }

    public override void UpdateState(AttackStateManager stateManager)
    {
        base.UpdateState(stateManager);

        if (fixedTime >= attackDuration)
        {
            if (shouldCombo)
                stateManager.SetNextState(new AttackFinisherState());
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
