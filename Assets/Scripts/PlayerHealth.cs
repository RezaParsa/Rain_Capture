using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public Image healthBar; // Assign this in the Inspector

    void Start()
    {
        health = maxHealth * 0.5f; // Start at 50% health
        UpdateHealthBar();
    }

    void Update()
    {
        UpdateHealthBar();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01(health / maxHealth);
        }
    }

    // Optional: Call this to change health from other scripts
    public void TakeDamage(float amount)
    {
        health -= amount;
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        UpdateHealthBar();
    }
}
