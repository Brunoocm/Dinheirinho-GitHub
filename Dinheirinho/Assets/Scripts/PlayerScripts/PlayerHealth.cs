using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float maxHealth;
    public float currentHealth;

    PlayerStats playerStats => GetComponent<PlayerStats>();

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void UpdateHealth()
    {
        maxHealth = playerStats.maxHealth;
        currentHealth = playerStats.health;
    }
}
