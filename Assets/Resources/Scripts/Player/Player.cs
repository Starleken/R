using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(PlayerWalker), typeof(PlayerHealth),
typeof(PlayerJumper))]
public class Player : MonoBehaviour
{
    [SerializeField] private int playerSpeed;
    [SerializeField] private int health;
    [SerializeField] private float jumpStrength;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        PlayerWalker playerWalker = GetComponent<PlayerWalker>();
        playerWalker.Init(playerSpeed, rb);

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        playerHealth.Init(health);
        
        PlayerJumper playerJumper = GetComponent<PlayerJumper>();
        playerJumper.Init(jumpStrength, rb);
    }
}
