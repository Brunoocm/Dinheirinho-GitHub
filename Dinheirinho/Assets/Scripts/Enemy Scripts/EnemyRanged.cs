using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public float damage;
    public float fireRange;
    public float fireCooldown;
    public float bulletSpeed;
    public float accuracy;
    public Transform firePoint;
    public GameObject bullet;

    float time;
    float distanceToPlayer;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if(canFire())
        {
            Fire();
        }
    }

    bool canFire()
    {
        if(time <= 0)
        {
            return distanceToPlayer <= fireRange;
        }
        else
        {
            time -= Time.deltaTime;
            return false;
        }
    }

    void Fire()
    {
        //Quaternion spread = new Quaternion(0, 0, firePoint.rotation.z + Random.Range(-1f, 1f) * (1 - accuracy), firePoint.rotation.z);
        float num = Random.Range(-0.9f, 0.9f);
        Vector2 pos = new Vector2(player.transform.position.x - transform.position.x - num, player.transform.position.y - transform.position.y - num);

        GameObject b = Instantiate(bullet, firePoint.position, Quaternion.identity);

        b.GetComponent<EnemyBullet>().damage = damage;
        b.GetComponent<Rigidbody2D>().velocity = pos.normalized * bulletSpeed;

        time = fireCooldown;

    }

    void Shoot()
    {
    }
}
