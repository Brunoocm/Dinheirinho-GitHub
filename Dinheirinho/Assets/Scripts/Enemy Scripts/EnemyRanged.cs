using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public float fireRange;
    public float fireCooldown;
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
        Instantiate(bullet, firePoint.position, Quaternion.identity);
        time = fireCooldown;
    }
}
