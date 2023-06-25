using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState
{

    float jumpForce = 28;

    // constructor
    public PlayerJumpingState(PlayerStateManager stateManager, PlayerStateInstances states)
        : base(stateManager, states) { }

    // state methods
    public override void EnterState()
    {
        base.EnterState();

        // o estado precisa de um tempo limite de duração, pois existem
        // casos de pulo em que a velocidade y é sempre positiva.
        // por exemplo: pulando para um lugar muito alto
        stateDuration = 0.4f;

        stateManager.audioSource.PlayOneShot(stateManager.jump_sfx);
        stateManager.animator.Play("Jump/Fall");
        stateManager.RB.velocity = new Vector2(stateManager.RB.velocity.x, jumpForce);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        CheckAttackCombo();
        CheckGunShoot();

        stateManager.animator.SetFloat("verticalMove", stateManager.RB.velocity.y);

        if (
            (!stateManager.isGrounded && stateManager.RB.velocity.y <= 0) ||
            fixedTime >= stateDuration
           )
        {
            stateManager.SetNextState(states.Falling);
        }
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
