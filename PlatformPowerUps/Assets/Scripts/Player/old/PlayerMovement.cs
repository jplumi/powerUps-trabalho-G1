using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 0f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private int _hasJumped = 0;
    [SerializeField] private Transform _groundCheck;

    public int maxJumps { get; set; } = 1;

    private Rigidbody2D RB;

    private Animator _animator;

    private float _horizontalMove = 0f;

    private bool _isGrounded = false;
    private bool _canJump = false;

    private GameManager GM;

    public float moveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        GM = GameManager.instance;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded || (_hasJumped < maxJumps))
                _canJump = true;
        }

        CheckIfGrounded();
        Animate();
        Flip();
    }

    void FixedUpdate()
    {
        if (GM.canControlPlayer)
        {
            Movement();
        }
    }

    private void Movement()
    {
        RB.velocity = new Vector2(_horizontalMove * _moveSpeed, RB.velocity.y);

        if (_canJump)
        {
            RB.velocity = new Vector2(RB.velocity.x, _jumpForce);
            _hasJumped++;
            _canJump = false;
        }
    }

    private void CheckIfGrounded()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

        if (_isGrounded)
            _hasJumped = 0;
    }

    private void Animate()
    {
        _animator.SetFloat("horizontalMove", Mathf.Abs(RB.velocity.x));
        _animator.SetFloat("verticalMove", RB.velocity.y);
        _animator.SetBool("isGrounded", _isGrounded);
    }

    private void Flip()
    {
        if (RB.velocity.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (RB.velocity.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
