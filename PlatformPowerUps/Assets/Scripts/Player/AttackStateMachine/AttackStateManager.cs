using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateManager : MonoBehaviour
{

    AttackState currentState;

    Collider2D swordCollider;

    public Animator animator { get; private set; }

    public int damageAmount = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        swordCollider = gameObject.transform.Find("SwordCollider")
            .GetComponent<Collider2D>();

        currentState = new IdleState();

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void SetNextState(AttackState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

    public void Attack()
    {
        Collider2D[] result = new Collider2D[5];
        swordCollider.OverlapCollider(new ContactFilter2D(), result);
        for(int i = 0; i < result.Length; i++)
        {
            if(result[i] != null && result[i].TryGetComponent<Damageable>(out Damageable damageable))
            {
                damageable.TakeDamage(damageAmount, result[0]);
            }
        }
    }
}
