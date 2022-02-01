using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI[] statsBar;

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
        UpdateStatsBar();
    }

    public void UpdateStatsBar()
    {
        if (speed < 0.5f) speed = 0.5f;
        if (dano < 0.5f) dano = 0.5f;
        if (fireRate < 0.5f) fireRate = 0.5f;
        if (range < 0.5f) range = 0.5f;
        if (money < 0) money = 0;

        statsBar[0].text = "" + speed;
        statsBar[1].text = "" + dano;
        statsBar[2].text = "" + fireRate;
        statsBar[3].text = "" + range;
    }
}
