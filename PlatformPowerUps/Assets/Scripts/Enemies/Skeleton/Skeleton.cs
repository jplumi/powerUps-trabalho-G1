using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Movement")]
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public float movementSpeed;

    [Header("Attack")]
    [SerializeField] int attackDamageAmount;

    Collider2D attackCollider;

    [HideInInspector] public Rigidbody2D RB;
    [HideInInspector] public Animator animator;

    SkeletonState currentState;
    public SkeletonStateInstances instances { get; private set; }


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackCollider = gameObject.transform.Find("AttackCollider")
            .GetComponent<Collider2D>();

        instances = new SkeletonStateInstances(this);

        currentState = instances.Patrol;
        currentState.EnterState();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void SetNextState(SkeletonState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }

    // called by attack animation events
    public void Attack()
    {
        Collider2D[] result = new Collider2D[1];

        ContactFilter2D attackFilter = new ContactFilter2D();
        attackFilter.SetLayerMask(playerLayer);

        attackCollider.OverlapCollider(attackFilter, result);

        if (result[0] != null && result[0].TryGetComponent<Damageable>(out Damageable damageable))
        {
            damageable.TakeDamage(attackDamageAmount, attackCollider);
        }
    }
}
