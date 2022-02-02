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
        if(Random.Range(0, 100) > playerStats.evadeChance)
        {
            if(playerStats.reducedDamage > 0)
            {
                float newAmount = amount * (playerStats.reducedDamage / 100);

                currentHealth -= newAmount;
            }
            else
            {
                currentHealth -= amount;
            }
        }
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
