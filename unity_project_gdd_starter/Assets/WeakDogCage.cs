using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakDogCage : Health
{
    // Start is called before the first frame update
    public GameObject cage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TakeDamage(int damage)
    {
        if (!canTakeDamage)
            return;
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    public override void Die()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null && player.quest != null && player.quest.questID == 1)
        {
            player.quest.goal.EnemyKilled();
        }
        Destroy(cage);
    }
}
