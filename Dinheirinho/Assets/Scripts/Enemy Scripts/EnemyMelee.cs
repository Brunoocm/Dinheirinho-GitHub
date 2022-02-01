using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int damage;
    public float cooldown;

    float time;

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

    void Damage(Collider2D player)
    {
        //player.GetComponent<PlayerStats>().??(damage);
        time = cooldown;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerStats>() != null && canDamage())
        {
            Damage(collision);
        }
    }
}
