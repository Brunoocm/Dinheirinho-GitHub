using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;
    public bool isMelee;
    public GameObject destroyFx;

    void Start()
    {
        //
    }

    void Update()
    {
        //
    }

    private void OnDestroy()
    {
        if(destroyFx != null)
        {
            Instantiate(destroyFx, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            if(!isMelee) Destroy(gameObject);
        }
    }
}
