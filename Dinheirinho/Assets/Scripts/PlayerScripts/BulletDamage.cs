using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;
    public bool isMelee;
    public bool isPoision;
    public bool isArea;
    public GameObject destroyFx;
    public GameObject destroyFxArea;

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
        if(destroyFx != null && !isArea)
        {
            Instantiate(destroyFx, transform.position, transform.rotation);
        }
        if(destroyFxArea != null && isArea)
        {
            GameObject obj = Instantiate(destroyFxArea, transform.position, transform.rotation);
            if (isPoision) obj.GetComponent<DamageArea>().poision = true;
            obj.GetComponent<DamageArea>().damageArea = damage / 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);

            if(isPoision) other.GetComponent<EnemyHealth>().TakePoision(damage);

            if (!isMelee) Destroy(gameObject);
        }
    }
}
