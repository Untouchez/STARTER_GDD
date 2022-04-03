using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public Attack attack;
    public override State RunCurrentState()
    {
        if(Vector3.Distance(transform.position,player.position) <= attack.attackRange) {
            attack.AwakeCurrentState();
            return attack;
        }
        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        agent.SetDestination(player.position);
        return this;
    }

}
