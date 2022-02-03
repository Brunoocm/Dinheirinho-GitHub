using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;
    public float speed;

    GameObject player;
    Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 2f);

    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerHealth>() != null)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
