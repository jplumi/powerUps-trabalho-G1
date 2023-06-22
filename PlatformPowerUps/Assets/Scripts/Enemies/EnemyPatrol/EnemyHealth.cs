using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Damageable
{
    public override void TakeDamage(int amount, Collider2D collider)
    {
        base.TakeDamage(amount, collider);
        if(CurrentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
