using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public State chase;

    public override State RunCurrentState()
    {
        if(CanSeePlayer())
        {
            chase.AwakeCurrentState();
            return chase;
        }
        return this;
    }
}
