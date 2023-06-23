using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [Header("Jump Values")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _enemyLayer;
    public float moveSpeed = 0f;

    PlayerState _currentState;
    public PlayerStateInstances stateInstances { get; private set; }

    [HideInInspector] public Rigidbody2D RB { get; private set; }
    [HideInInspector] public Animator animator { get; private set; }

    [Header("Sounds")]
    [SerializeField] public AudioSource atack1_sfx;
    [SerializeField] public AudioSource atack2_sfx;
    [SerializeField] public AudioSource shot_sfx;
    [SerializeField] public AudioSource movement_sfx;
    [SerializeField] public AudioSource jump_sfx;
    [SerializeField] public AudioSource landing_sfx;


    [HideInInspector] public float horizontalMove = 0f;
    [HideInInspector] public bool isGrounded = false;

    Collider2D swordCollider;

    // this is changed on the attack states
    [HideInInspector] public int attackDamageAmount = 0;

    [Header("Shot")]
    public GameObject shotPrefab;
    public Transform shotSpawnPoint;

    // unity lifecycle
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        swordCollider = gameObject.transform.Find("SwordCollider")
            .GetComponent<Collider2D>();

        stateInstances = new PlayerStateInstances(this);

        _currentState = stateInstances.Idle;
    }

    void Update()
    {
        _currentState.UpdateState();
        CheckIfGrounded();
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdateState();
        Flip();

        // the horizontal movement is executed in every state
        HorizontalMovement();
    }

    // switch states
    public void SetNextState(PlayerState playerState)
    {
        _currentState.ExitState();
        _currentState = playerState;
        _currentState.EnterState();
    }

    private void HorizontalMovement()
    {
        if (GameManager.instance.canControlPlayer)
        {
            RB.velocity = new Vector2(horizontalMove * moveSpeed, RB.velocity.y);
        }
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void Flip()
    {
        if (horizontalMove < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (horizontalMove > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

    // called by attack animation events
    public void Attack()
    {
        Collider2D[] result = new Collider2D[5];

        ContactFilter2D attackFilter = new ContactFilter2D();
        attackFilter.SetLayerMask(_enemyLayer);

        swordCollider.OverlapCollider(attackFilter, result);
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] != null && result[i].TryGetComponent<Damageable>(out Damageable damageable))
            {
                damageable.TakeDamage(attackDamageAmount, swordCollider);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
