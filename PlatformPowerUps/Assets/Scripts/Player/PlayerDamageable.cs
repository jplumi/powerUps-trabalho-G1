using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    PlayerStateManager stateManager;

    [SerializeField] float knockbackForce;

    void Start()
    {
        stateManager = GetComponent<PlayerStateManager>();
    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
    }

    public override void TakeDamage(int amount, Collider2D collider)
    {
        if (!GameManager.instance.playerIsInvincible)
        {
            base.TakeDamage(amount, collider);
            Debug.Log("HEALTH " + CurrentHealth);

            Direction hitDirection;

            if (collider.transform.position.x > transform.position.x)
                hitDirection = Direction.LEFT;
            else
                hitDirection = Direction.RIGHT;

            Knockback(hitDirection);

            if(CurrentHealth == 0)
            {
                stateManager.SetNextState(stateManager.stateInstances.Death);
                return;
            }

            stateManager.SetNextState(stateManager.stateInstances.Hit);
        }
    }

    void Knockback(Direction direction)
    {
        stateManager.RB.velocity = Vector2.zero;
        if (direction == Direction.RIGHT)
        {
            stateManager.RB.AddForce(new Vector2(1, 1) * knockbackForce, ForceMode2D.Impulse);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            stateManager.RB.AddForce(new Vector2(-1, 1) * knockbackForce, ForceMode2D.Impulse);
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

}
