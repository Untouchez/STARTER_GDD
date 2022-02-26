using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int Health; 

    // Start is called before the first frame update
    void Start()
    {
        Heal(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
    }

    public void Heal(int healAmount)
    {
        Health = Health + healAmount;
    }
}
