using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;


    Vector2 moveDir;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
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
    }
}
