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
    public int stompDamage;
    public float stompAttackRadius;

    private float lastAttack;
    public float attackRate;
    public Weapon trashbag;

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
                    //MAKE DECISION
                    lastAttack = Time.time;

                    if (DistanceToPlayer() <= attackRange) 
                    {
                        anim.SetTrigger("attack");
                        agent.isStopped = true;
                    } else if (DistanceToPlayer() <= stompRange) 
                    {
                        anim.SetTrigger("stomp");
                        agent.isStopped = true;
                    } else 
                    {
                        agent.SetDestination(player.position);
                        agent.isStopped = false;
                    }
                }
        }

        if (IsPlaying("trashbag_swing") || IsPlaying("stomping"))
        {
            agent.isStopped = true;
            isAttacking = true;
        }
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
        if(DistanceToPlayer() < stompAttackRadius)
            player.GetComponent<Health>().TakeDamage(stompDamage);

        stompEffect.Play();
    }

    //HELPER FUNCTIONS

    /*
    * this.anim.GetCurrentAnimatorStateInfo(0).IsName(-= ANIMATION NAME =-) 
    * this line checks if the animator is playing an animation 
    * it will return true if the animation matches the -= ANIMATION NAME =- that you passed in
    * and it will return false if it doesnt
    */
    public bool IsPlaying(string clipName)
    {
        return this.anim.GetCurrentAnimatorStateInfo(0).IsName(clipName);
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}
