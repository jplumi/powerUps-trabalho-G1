using UnityEngine;

public class Health
{
    public int currentHealth { get; private set; }
    public int maxHealth { get; private set; }

    public Health(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }
}
