using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smallboss0 : Health
{
    [Space(10)]
    public Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public Weapon sword;
    public EnemyHealthBar healthBarPrefab;
    private EnemyHealthBar _healthBar;
    private float lastAttack;
    public float attackRate;
    public bool isAttacking;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (healthBarPrefab != null)
        {
            _healthBar = Instantiate(healthBarPrefab, FindObjectOfType<WorldSpaceCanvas>().transform);
            _healthBar.target = transform;
            healthBar = _healthBar;

        }
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
                    transform.LookAt(player);
                    anim.SetTrigger("attack");
                    agent.isStopped = true;
                }
                else
                {
                    agent.SetDestination(player.position);
                    agent.isStopped = false;
                }
            }
        }

        if (IsPlaying("attack"))
        {
            agent.isStopped = true;
            isAttacking = true;
        }
        else
            isAttacking = false;

        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
    }
    public void Hit(int damage)
    {
        sword.damage = damage;
        sword.Enable();
    }

    public bool IsPlaying(string clipName)
    {
        return this.anim.GetCurrentAnimatorStateInfo(0).IsName(clipName);
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }
}
