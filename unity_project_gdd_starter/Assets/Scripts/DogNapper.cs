using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogNapper : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public ParticleSystem stompEffect;
    public float attackRange;
    public float stompRange;
    private float lastAttack;
    public float attackRate;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAttack > 1 / attackRate)
        {
            lastAttack = Time.time;
            print("cooldown");

            //transform.LookAt(player);
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                anim.SetTrigger("attack");
                print("attack");
                agent.SetDestination(transform.position);
            }
            else if (Vector3.Distance(transform.position, player.position) <= stompRange)
            {
                anim.SetTrigger("stomp");
                print("stomp");
                
            }
            else
            {
                agent.SetDestination(player.position);
            }
        }
         anim.SetFloat("speed", agent.velocity.magnitude /  agent.speed);   

    }
    public void Hit()
    {
        print("true");
    }

    public void StompEffect()
    {
        print("StompEffect");
        stompEffect.Play();
    }
}
