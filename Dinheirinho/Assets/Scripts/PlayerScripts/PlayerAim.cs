using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float dano;
    public float fireRate;
    public float range;
    public float bulletSpeed;

    private float m_fireRate;

    public GameObject dinheiroBullet;
    Vector2 pos;

    PlayerStats playerstats => GetComponent<PlayerStats>();
    Animator anim => GetComponent<Animator>();

    void Start()
    {
        m_fireRate = fireRate;
        fireRate = 0;
    }

    void Update()
    {
        MousePos();

        fireRate -= Time.deltaTime;
        if (Input.GetMouseButton(0) && fireRate <= 0)
        {
            Shoot();
            fireRate = m_fireRate;
        }
    }

    void MousePos()
    {
        Vector2 mouse = Input.mousePosition;

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 finalPos = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        pos = finalPos;

        anim.SetFloat("Horizontal", finalPos.x);
        anim.SetFloat("Vertical", finalPos.y);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(dinheiroBullet, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = pos.normalized * bulletSpeed;
        Destroy(bullet, range);

    }

    public void UpdatePlayerAim()
    {
        dano = playerstats.dano;
        fireRate = playerstats.fireRate;
        m_fireRate = playerstats.fireRate;
        range = playerstats.range;
        bulletSpeed = playerstats.bulletSpeed;
    }
}
