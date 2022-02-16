using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }


    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
