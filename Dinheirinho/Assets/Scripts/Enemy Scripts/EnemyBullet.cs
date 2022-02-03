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
        target = player.transform.position - transform.position;
        Destroy(gameObject, 2f);

    }

    void Update()
    {
        transform.Translate(target * speed * Time.deltaTime);
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
