using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;

    public GameObject vfx;
    public Material original;
    public Material effect;
    public Color poisionEffect;
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    EnemyMove enemyMove => GetComponent<EnemyMove>();
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    EnemySpawner es => GetComponent<EnemySpawner>();

    private float currentHealth;
    private bool delay;

    PlayerStats ps;

    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

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
        int moneyChance = Random.Range(0, 100);

        if(moneyChance <= 50)
        {
            ps.money += 2;
        }

        if(vfx != null)
        {
            Instantiate(vfx, transform.position, Quaternion.identity);
        }

        if(es != null)
        {
            es.Spawn();
        }

        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        StartCoroutine(EffectDamage());
        StartCoroutine(Knockback());
    }
    public void TakePoision(float amount)
    {

        if(!delay) StartCoroutine(Poision(amount));
    }

    IEnumerator EffectDamage()
    {
        spriteRenderer.material = effect;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.material = original;

    }   
    
    IEnumerator Knockback()
    {
        enemyMove.knockback = true;

        Vector2 pos = (enemyMove.player.transform.position - this.transform.position).normalized;
        rb.AddForce(-pos * 100);
        yield return new WaitForSeconds(0.2f);
        rb.AddForce(pos * 100);
        enemyMove.knockback = false;


    }

    IEnumerator Poision(float amount)
    {
        delay = true;
        spriteRenderer.color = poisionEffect;

        yield return new WaitForSeconds(1f);
        currentHealth -= amount / 4;
        StartCoroutine(EffectDamage());
        yield return new WaitForSeconds(1f);
        currentHealth -= amount / 4;
        StartCoroutine(EffectDamage());
        yield return new WaitForSeconds(1f); 
        currentHealth -= amount / 4;
        StartCoroutine(EffectDamage());
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
        delay = false;


    }
}
