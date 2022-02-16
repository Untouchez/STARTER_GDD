using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Define members for currentHealth and maxHealth:

    public void Start()
    {
        // What should be initialized here?
    }


    public virtual void TakeDamage(int damage)
    {
        // The enemy should be able to take damage and die when its health is less than or equal to 0 
    }

    public virtual void Die()
    {
        // https://docs.unity3d.com/ScriptReference/Object.Destroy.html
    }
}
