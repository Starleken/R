using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    private float jumpStrength;
    private Rigidbody2D rb;

    public void Init(float jumpPower, Rigidbody2D rigidbody2D)
    {
        jumpStrength = jumpPower;
        
        rb = rigidbody2D;
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpStrength);
    }
}
