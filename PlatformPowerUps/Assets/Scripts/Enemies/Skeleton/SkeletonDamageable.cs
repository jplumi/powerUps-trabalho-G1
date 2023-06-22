using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamageable : Damageable
{
    Skeleton skeleton;

    [SerializeField] float knockbackForce;

    void Start()
    {
        skeleton = GetComponent<Skeleton>();
    }

    public override void TakeDamage(int amount, Collider2D collider)
    {
        base.TakeDamage(amount, collider);

        Direction hitDirection;

        if (collider.transform.position.x > transform.position.x)
            hitDirection = Direction.LEFT;
        else
            hitDirection = Direction.RIGHT;

        Knockback(hitDirection);

        if (CurrentHealth == 0)
        {
            skeleton.SetNextState(skeleton.instances.Death);
            return;
        }

        skeleton.SetNextState(skeleton.instances.Damage);
    }

    void Knockback(Direction direction)
    {
        skeleton.RB.velocity = Vector2.zero;
        if (direction == Direction.RIGHT)
        {
            skeleton.RB.AddForce(new Vector2(1, 1) * knockbackForce, ForceMode2D.Impulse);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            skeleton.RB.AddForce(new Vector2(-1, 1) * knockbackForce, ForceMode2D.Impulse);
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

}
