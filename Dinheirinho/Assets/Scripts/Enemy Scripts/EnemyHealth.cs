using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
