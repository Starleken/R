using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerWalker : MonoBehaviour
{
    private int playerSpeed;
    private Rigidbody2D rb;

    public void Init(int speed, Rigidbody2D rigidbody2D)
    {
        playerSpeed = speed;

        rb = rigidbody2D;
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        float direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * playerSpeed * Time.fixedDeltaTime, rb.velocity.y);

        if (direction > 0 & transform.localScale.x < 0)
            Flip();
        else if (direction < 0 & transform.localScale.x > 0)
            Flip();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
