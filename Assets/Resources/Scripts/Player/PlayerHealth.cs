using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int health;
    
    private UnityEvent OnPlayerDeath;
    
    public void Init(int health)
    {
        this.health = health;
        OnPlayerDeath = new UnityEvent();
    }

    public void RecieveDamage(int damage)
    {
        health -= damage;
        
        Debug.Log(health);
        
        TryDie();
    }

    private void TryDie()
    {
        if (health > 0)
            return;
        
        OnPlayerDeath.Invoke();
        OnPlayerDeath.RemoveAllListeners();

        Destroy(gameObject);
    }
}
