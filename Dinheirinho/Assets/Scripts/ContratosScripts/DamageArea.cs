using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damageArea;
    public bool poision;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damageArea);

            if (poision) other.GetComponent<EnemyHealth>().TakePoision(damageArea);

        }
    }
}
