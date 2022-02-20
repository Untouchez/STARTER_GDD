using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    public State chase;
    public float attackRange;
    public override State RunCurrentState()
    {
        if (Vector3.Distance(transform.position, player.position) >= attackRange)
        {
            return chase;
        }
        return this;
    }
}

