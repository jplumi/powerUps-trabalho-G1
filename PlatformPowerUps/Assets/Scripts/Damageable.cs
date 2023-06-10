using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;

    // getters and setters
    public int CurrentHealth
    {
        get { return _currentHealth; }
    }

    public int MaxHealth
    {
        get { return _maxHealth; }
    }

    // main methods
    public virtual void TakeDamage(int amount, Collider2D collider)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - amount);
    }

    public virtual void Heal(int amount)
    {
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
    }
}
