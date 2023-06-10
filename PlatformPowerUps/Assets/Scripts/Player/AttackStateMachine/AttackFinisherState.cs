using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFinisherState : AttackState
{
    public override void EnterState(AttackStateManager stateManager)
    {
        //Debug.Log("ENTER FINISHER");
        attackDuration = 0.75f;

        stateManager.damageAmount = 40;
        stateManager.animator.SetTrigger("attack3");
    }

    public override void UpdateState(AttackStateManager stateManager)
    {
        base.UpdateState(stateManager);

        if (fixedTime >= attackDuration)
        {
            stateManager.SetNextState(new IdleState());
        }
    }

    public override void ExitState(AttackStateManager stateManager)
    {

    }
}
