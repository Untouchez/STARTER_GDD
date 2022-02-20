using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    [HideInInspector]
    public Transform player;
    [HideInInspector]
    public Transform me;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody rigid;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public StateManager stateManager;

    float currentAngle;
    public float lookDetectionAngle;
    public float updateRate;

    public abstract State RunCurrentState();

    public virtual void AwakeCurrentState()
    {
        stateManager.updateRate = updateRate;
    }

    public bool IsPlayerInfrontOfMe()
    {
        currentAngle = Vector3.Angle(me.forward, player.position - me.position);
        //CHECK IF PLAYER IS INFRONT OF ME
        if (currentAngle < lookDetectionAngle)
        {
            return true;
        }
        return false;
    }

    public bool CanSeePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, 100f))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
            return false;
        }
        return false;
    }

}
