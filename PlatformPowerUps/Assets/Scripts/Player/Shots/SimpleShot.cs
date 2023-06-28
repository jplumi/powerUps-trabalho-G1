using UnityEngine;

public class SimpleShot : MonoBehaviour
{
    [SerializeField] private int _damage = 0;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _destroyTime = 0f;

    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _destroyTime);
    }

    void FixedUpdate()
    {
        RB.velocity = transform.right * _speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Damageable enemy = collision.gameObject.GetComponent<Damageable>();

            if(enemy != null)
                enemy.TakeDamage(_damage, collision);

            Destroy(gameObject);
        } else if(collision.CompareTag("Ground"))
            Destroy(gameObject);
    }
}
