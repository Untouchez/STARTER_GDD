using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smallboss0 : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public Transform player;

    public float attackRadius;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRadius) {
            anim.SetTrigger("attack");
        } else {
            agent.SetDestination(player.position);
        }
    }

    public void Hit() {
        print("testing");
    }


}
