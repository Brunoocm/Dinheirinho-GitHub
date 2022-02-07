using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed;

    Vector2 moveDir;
    PlayerStats playerStats => GetComponent<PlayerStats>();
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    Animator anim => GetComponent<Animator>();

    public GameObject vx;
    private float timer = 0.5f;
    private float timeraa;
    void Start()
    {
        timeraa = timer;
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //if (playerStats.blurVision)
        //{
        //    float moveX = Input.GetAxis("Horizontal");
        //    float moveY = Input.GetAxis("Vertical");

        //    moveDir = new Vector2(moveX, moveY).normalized;

        //    rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        //}
        //else
        //{
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;

            rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        //}

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            GameObject v = Instantiate(vx, new Vector2(transform.position.x, transform.position.y - 0.8f), Quaternion.identity);
            timer = timeraa;
        }
        anim.SetFloat("Speed", moveDir.sqrMagnitude);
    }

    public void UpdateMove()
    {
        speed = playerStats.speed;
    }
}
