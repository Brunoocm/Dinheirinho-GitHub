using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI textHealth;
    public Material original;
    public Material effect;

    private float maxHealth;
    private float currentHealth;
    private float vulnerable;

    public bool canHeal;
    public bool extraLife;
    public GameObject evadeVFX;
    public GameObject derrota;

    PlayerStats playerStats => GetComponent<PlayerStats>();
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    Color col;

    private void Start()
    {
        UpdateHealth();

    }
    private void Update()
    {
        textHealth.text = currentHealth.ToString("F1") + "/" + maxHealth;

        vulnerable -= Time.deltaTime;

        if (currentHealth <= 0)
        {
            Die();
        }

        if(vulnerable > 0)
        {

        }

    }

    public void Heal(float amount)
    {
        if (canHeal)
        {
            currentHealth += amount;
        }
    }

    public void TakeDamage(float amount)
    {
        if(Random.Range(0, 100) > playerStats.evadeChance && vulnerable <= 0)
        {
            healthBar.value = currentHealth;

            if (playerStats.reducedDamage > 0)
            {
                float newAmount = amount * (playerStats.reducedDamage / 100);

                currentHealth -= newAmount;
            }
            else
            {
                currentHealth -= amount;
            }
            StartCoroutine(Vulnerable());
            playerStats.health = currentHealth;
            vulnerable = 1;

            FindObjectOfType<AudioManager>().Play("DanoLevado");
        }
        else if(vulnerable <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Evade");

            GameObject evade = Instantiate(evadeVFX, transform.position, Quaternion.identity);
            evade.transform.parent = transform;
        }
    }

    void Die()
    {
        if (extraLife)
        {
            currentHealth = maxHealth / 2;
            extraLife = false;
        }
        else
        {
            derrota.SetActive(true);

            Destroy(gameObject);
        }
    }

    public void UpdateHealth()
    {
        maxHealth = playerStats.maxHealth;
        currentHealth = playerStats.health;

        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
    }

    IEnumerator Vulnerable()
    {
        spriteRenderer.material = effect;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.material = original;

    }
}
