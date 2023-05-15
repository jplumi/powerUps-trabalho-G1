using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private float _knockbackForce = 0f;

    private Rigidbody2D RB;
    private GameManager GM;
    private Animator _animator;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        GM = GameManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1, Direction.LEFT);
        }
    }

    void TakeDamage(int dmgAmount, Direction direction)
    {
        GM.playerIsInvincible = true;
        GM.canControlPlayer = false;
        GM.playerHealth.TakeDamage(dmgAmount);

        _animator.SetTrigger("damage");

        RB.velocity = Vector2.zero;
        if(direction == Direction.RIGHT)
            RB.AddForce(new Vector2(1, 1) * _knockbackForce, ForceMode2D.Impulse);
        else
            RB.AddForce(new Vector2(-1, 1) * _knockbackForce, ForceMode2D.Impulse);

        Debug.Log("Player Health: " + GM.playerHealth.currentHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !GM.playerIsInvincible)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            Direction direction;

            if (collision.transform.position.x > transform.position.x)
                direction = Direction.LEFT;
            else
                direction = Direction.RIGHT;

            TakeDamage(enemy.damage, direction);
        }
    }

    // called by "PlayerDamage" animation event
    public void OnPlayerDamageAnimationEnd()
    {
        KnockbackFlip();
        if (GM.playerHealth.currentHealth == 0)
            Die();
        GM.playerIsInvincible = false;
        GM.canControlPlayer = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void KnockbackFlip()
    {
        if (transform.eulerAngles.Equals(Vector2.zero))
            transform.eulerAngles = new Vector2(0, 180);
        else
            transform.eulerAngles = Vector2.zero;

    }

}


