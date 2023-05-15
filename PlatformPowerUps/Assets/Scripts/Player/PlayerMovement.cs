using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 0f;
    [SerializeField] private LayerMask _groundLayer;

    public int maxJumps { get; set; } = 1;

    private Rigidbody2D RB;

    private Animator _animator;

    private float _horizontalMove = 0f;

    private float _groundCheckLength = 0.1f;
    private bool _isGrounded = false;
    private bool _canJump = false;
    [SerializeField] private int _hasJumped = 0;

    private GameManager GM;

    public float moveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        GM = GameManager.instance;
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
        Vector2 raycastOrigin = (Vector2) transform.position + Vector2.down * 0.9f;
        _isGrounded = Physics2D.Raycast(raycastOrigin, Vector2.down, _groundCheckLength, _groundLayer);

        if (_isGrounded)
            _hasJumped = 0;

        Debug.DrawRay(raycastOrigin, Vector2.down * _groundCheckLength, Color.red);
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
}
