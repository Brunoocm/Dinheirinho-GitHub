using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private float dano;
    private float fireRate;
    private float range;
    private float bulletSpeed;

    private float m_fireRate;

    public int reduceMoney = 1;

    public GameObject dinheiroBullet;
    public GameObject attackMelee;
    public GameObject particleTiro;
    public GameObject gun;
    public Transform hand;
    Vector3 pos;

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
        if (Input.GetMouseButton(1) && fireRate <= 0)
        {
            AttackMelee();
            fireRate = m_fireRate;
        }
    }

    void MousePos()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector3 finalPos = new Vector3(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        pos = finalPos;

        anim.SetFloat("Horizontal", finalPos.x);
        anim.SetFloat("Vertical", finalPos.y);
    }

    void Shoot()
    {
        if (playerstats.money > 0)
        {
            FindObjectOfType<AudioManager>().Play("AttackRanged");

            StartCoroutine(ToggleGun());

            playerstats.money -= reduceMoney;
            playerstats.UpdateMoney();

            GameObject bullet = Instantiate(dinheiroBullet, transform.position, Quaternion.identity);
      
            bullet.GetComponent<BulletDamage>().damage = dano;
            bullet.GetComponent<Rigidbody2D>().velocity = pos.normalized * bulletSpeed;

            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            hand.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            GameObject particle = Instantiate(particleTiro, hand.transform.position, hand.transform.rotation, transform);

            Destroy(particle, 0.5f);
            Destroy(bullet, range);
        }


    }

    void AttackMelee()
    {
        FindObjectOfType<AudioManager>().Play("AttackMelee");

        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        hand.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        GameObject bullet = Instantiate(attackMelee, hand.transform.position, hand.transform.rotation, transform);
        bullet.GetComponentInChildren<BulletDamage>().damage = dano/2;
        Destroy(bullet, 0.5f);
        StartCoroutine(ToggleGun());
    }

    IEnumerator ToggleGun()
    {
        gun.SetActive(false);
        yield return new WaitForSeconds(0.35f);
        gun.SetActive(true);
    }

    public void UpdatePlayerAim()
    {
        dano = playerstats.dano;
        //fireRate = playerstats.fireRate;
        m_fireRate = playerstats.fireRate;
        range = playerstats.range;
        bulletSpeed = playerstats.bulletSpeed;
    }
}
