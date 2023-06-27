using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Movement")]
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public float movementSpeed;
    public float wallCheckerDistance;
    public float stepCheckerDistance;
    public float playerCheckerDistance;
    public float attackDistance;

    [Header("Attack")]
    [SerializeField] int attackDamageAmount;

    [Header("Sounds")]
    [SerializeField] public AudioClip atack_sfx;
    [SerializeField] public AudioClip damege_sfx;
    [SerializeField] public AudioClip death_sfx1;
    [SerializeField] public AudioClip death_sfx2;

    public AudioSource audioSource { get; private set; }

    Collider2D attackCollider;

    [HideInInspector] public Rigidbody2D RB;
    [HideInInspector] public Animator animator;

    SkeletonState currentState;
    public SkeletonStateInstances instances { get; private set; }


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(atack_sfx);
    }
}
