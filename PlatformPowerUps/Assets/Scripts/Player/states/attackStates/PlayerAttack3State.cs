using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : AttackState
{
    // constructor
    public PlayerAttack3State(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    //state methods
    public override void EnterState()
    {
        base.EnterState();

        attackDuration = 0.75f;

        stateManager.attackDamageAmount = 40;
        stateManager.animator.Play("AttackSword_3");
        stateManager.audioSource.PlayOneShot(stateManager.atack2_sfx);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(fixedTime >= attackDuration)
        {
            stateManager.SetNextState(states.Idle);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
