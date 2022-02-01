using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player")]
    public float health;
    public float maxHealth;
    public float speed;

    [Header("Fire")]
    public float dano;
    public float fireRate;
    public float range;

    [Header("Shop")]
    public float money;

    PlayerAim playerAim => GetComponent<PlayerAim>();
    PlayerMove playerMove => GetComponent<PlayerMove>();
    PlayerHealth playerHealth => GetComponent<PlayerHealth>();
    void Start()
    {
        UpdateAllStats();
    }

    void Update()
    {
        
    }

    public void UpdateAllStats()
    {
        playerHealth.UpdateHealth();
        playerMove.UpdateMove();
    }
}
