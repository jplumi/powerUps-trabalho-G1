using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : AttackState
{
    // constructor
    public PlayerAttack2State(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    //state methods
    public override void EnterState()
    {
        base.EnterState();

        attackDuration = 0.55f;

        stateManager.attackDamageAmount = 30;
        stateManager.animator.Play("AttackSword_2");
        stateManager.audioSource.PlayOneShot(stateManager.atack2_sfx);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (fixedTime >= attackDuration)
        {
            if (shouldCombo)
                stateManager.SetNextState(states.Attack3);
            else
            {
                stateManager.SetNextState(states.Idle);
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
