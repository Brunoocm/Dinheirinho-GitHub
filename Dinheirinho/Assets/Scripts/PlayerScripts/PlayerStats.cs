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
    public float evadeChance;
    public float reducedDamage;

    [Header("Fire")]
    public float dano;
    public float fireRate;
    public float range;
    public float bulletSpeed;

    [Header("Shop")]
    public float money;

    [Header("World")]
    public bool fog;
    public GameObject fogImage;
    public bool blurVision;

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
        fogImage.SetActive(fog);
        UpdateAllStats();
    }

    public void UpdateAllStats()
    {
        playerHealth.UpdateHealth();
        playerMove.UpdateMove();
        playerAim.UpdatePlayerAim();
        UpdateStatsBar();
    }

    public void UpdateStatsBar()
    {
        if (speed < 0.5f) speed = 0.5f;
        if (dano < 0.5f) dano = 0.5f;
        if (fireRate < 0.1f) fireRate = 0.1f;
        if (range < 0.5f) range = 0.5f;
        if (bulletSpeed < 0.5f) bulletSpeed = 0.5f;
        if (money < 0) money = 0;

        statsBar[0].text = "" + speed;
        statsBar[1].text = "" + dano;
        statsBar[2].text = "" + fireRate;
        statsBar[3].text = "" + range;
        statsBar[4].text = "" + bulletSpeed;
        statsBar[5].text = "" + money;
    }
    public void UpdateMoney()
    {
        statsBar[5].text = "" + money;

    }
}
