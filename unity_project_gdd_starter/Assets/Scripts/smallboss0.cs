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
    public float rotateSpeed;
    public AudioSource maceHit;

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
        if (player == null)
            return;
        if (Time.time - lastAttack > 1 / attackRate)
        {
            if (!isAttacking)
            {
                //MAKE DECISION
                lastAttack = Time.time;

                if (DistanceToPlayer() <= attackRange)
                {
                    StartCoroutine(LookAtPlayer());
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
            agent.SetDestination(transform.position);
            isAttacking = true;
        }
        else
            isAttacking = false;

        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
    }

    public void OpenColliders()
    {
        sword.hitBox.enabled = true;
    }

    public void CloseColliders()
    {
        sword.hitBox.enabled = false;
    }

    public bool IsPlaying(string clipName)
    {
        return this.anim.GetCurrentAnimatorStateInfo(0).IsName(clipName);
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }

    public override void Die()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null && player.quest != null && player.quest.questID == 0)
        {
            player.quest.goal.EnemyKilled(); // should change to incrementProgress()
        }

        base.Die();
    }

    public IEnumerator LookAtPlayer()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = player.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toOther = player.position - transform.position;
        anim.SetTrigger("attack");
        maceHit.Play();
        agent.isStopped = true;
        yield return new WaitUntil(() => Vector3.Dot(forward, toOther) >=0.9f);
        anim.ResetTrigger("attack");
    }
}
