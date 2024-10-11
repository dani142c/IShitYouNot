using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50;          // Max health af enemy
    private float currentHealth;          // Current health af enemy (hvad den har NU)
    private float baseHealth = 50;        // Base health (brugt for scaling når der er nye waves)

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        baseHealth = maxHealth;       
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);

        // checker om enemy health rammer 0, if so == død
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method til at set health, called fra WaveManager
    public void SetHealth(float newHealth)
    {
        maxHealth = newHealth;            // Set ny max health value
        currentHealth = newHealth;        // Set current health til vores new max health
        Debug.Log("Enemy health set to: " + currentHealth);
    }

    // Method til at få base health, called fra WaveManager
    public float GetBaseHealth()
    {
        return baseHealth;
    }

    void Die()
    {
        // logic for hvis vores enemy dør (might not need to be in this file)
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
