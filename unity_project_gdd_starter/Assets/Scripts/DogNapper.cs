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
    public Weapon trashbag;
    public Weapon stomp;

    public bool isAttacking;

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
            if (!isAttacking)
            {
                lastAttack = Time.time;
                if (Vector3.Distance(transform.position, player.position) <= attackRange)
                {
                    anim.SetTrigger("attack");
                }
                else if (Vector3.Distance(transform.position, player.position) <= stompRange)
                {
                    anim.SetTrigger("stomp");
                }
                else
                {
                    agent.SetDestination(player.position);
                }
            }
        }
        /*
         * this.anim.GetCurrentAnimatorStateInfo(0).IsName(-= ANIMATION NAME =-) 
         * this line checks if the animator is playing an animation 
         * it will return true if the animation matches the -= ANIMATION NAME =- that you passed in
         * and it will return false if it doesnt
         * 
         */
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("trashbag_swing") || this.anim.GetCurrentAnimatorStateInfo(0).IsName("stomping"))
            isAttacking = true;
        else
            isAttacking = false;
        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
    }
    public void HitSwing(int damage)
    {
        trashbag.damage = damage;
        trashbag.Enable();
    }

    public void HitStomp(int damage)
    {    
        stomp.damage = damage;
        stomp.Enable();
        stompEffect.Play();
    }
}
