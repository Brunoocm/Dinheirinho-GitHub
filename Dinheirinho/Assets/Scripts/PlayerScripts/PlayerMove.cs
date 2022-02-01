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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

        anim.SetFloat("Speed", moveDir.sqrMagnitude);
    }

    public void UpdateMove()
    {
        speed = playerStats.speed;
    }
}
