using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float damage;
    public float cooldown;

    private bool attacking;
    float time;

    public PlayerHealth playerHealth;
    EnemyMove enemyMove => GetComponent<EnemyMove>();
    private void Update()
    {
        if(attacking && canDamage())
        {
            playerHealth.TakeDamage(damage);
            time = cooldown;
        }

        if(!canDamage())
        {
            enemyMove.following = false;
        }
        else
        {
            enemyMove.following = true;
        }
    }
    bool canDamage()
    {
        if(time <= 0)
        {
            return true;
        }
        else
        {
            time -= Time.deltaTime;
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHealth>() != null)
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            attacking = true;
        }
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHealth>() != null)
        {
            attacking = false;
        }
    }
}
