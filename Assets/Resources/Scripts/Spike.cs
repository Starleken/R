using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int damageDelay;
    
    private Dictionary<IDamageable, Coroutine> allCoroutines;

    private void Start()
    {
        allCoroutines = new Dictionary<IDamageable, Coroutine>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out IDamageable obj))
        {
            allCoroutines.Add(obj,StartCoroutine(SendDamage(obj)));
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable obj))
        {
            StopCoroutine(allCoroutines[obj]);
            allCoroutines.Remove(obj);
        }
    }

    private IEnumerator SendDamage(IDamageable obj)
    {
        while (true)
        {
            obj.RecieveDamage(damage);
            yield return new WaitForSeconds(damageDelay);
        }
    }
}
