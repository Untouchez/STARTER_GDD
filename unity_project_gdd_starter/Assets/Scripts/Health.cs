using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public bool canTakeDamage = true;
    public DamageNumber damageNumber;
    public float maxHealth;
    public float currentHealth;
    public float lookPercentage;

    public virtual void TakeDamage(int damage)
    {
        //damageNumber.DisplayText(damage.ToString(),transform);
        if (!canTakeDamage)
            return;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    public virtual void Die()
    {
        print("dead");
    }
}
