using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;

    public Material original;
    public Material effect;
    public Color poisionEffect;
    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    EnemyMove enemyMove => GetComponent<EnemyMove>();
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private float currentHealth;
    private bool delay;

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
