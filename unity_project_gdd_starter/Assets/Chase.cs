using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public override State RunCurrentState()
    {
        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        agent.SetDestination(player.position);
        return this;
    }

}
