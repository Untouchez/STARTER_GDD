using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health 
{
    // Define Animator object here:

    // Define Blink object here:

    public new void Start()
    {
        // Initialize components
    }
    public override void TakeDamage(int damage)
    {
        // Call the base class's TakeDamage function:
        
        // Play the animator's "TakeDamage" animation:

        // Call the Blink object's BlinkMe function:
    }
}
