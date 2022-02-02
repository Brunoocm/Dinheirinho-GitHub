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
    void Start()
    {
        
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
        if (playerStats.blurVision)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;

            rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        }
        else
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDir = new Vector2(moveX, moveY).normalized;

            rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        }

        anim.SetFloat("Speed", moveDir.sqrMagnitude);
    }

    public void UpdateMove()
    {
        speed = playerStats.speed;
    }
}
