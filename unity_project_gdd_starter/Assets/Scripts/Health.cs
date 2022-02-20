using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour

{   [HideInInspector]
    public DamageNumber damageNumber;
    public float maxHealth;
    public float currentHealth;


    public virtual void TakeDamage(int damage)
    {
        damageNumber.DisplayText(damage.ToString(),transform);
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die()
    {
        print("dead");
    }
}
