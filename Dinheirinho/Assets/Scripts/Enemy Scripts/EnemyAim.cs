using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    Animator anim;
    GameObject player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PlayerPosition();
    }

    void PlayerPosition()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 enemyAim = playerPos - (Vector2)transform.position;

        anim.SetFloat("Horizontal", enemyAim.x);
        anim.SetFloat("Vertical", enemyAim.y);
    }
}
