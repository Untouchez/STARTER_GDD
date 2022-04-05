using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smallboss0 : Health
{
    public Animator anim;
    public NavMeshAgent agent;
    public Transform player;
    public Weapon sword;
    public EnemyHealthBar healthBarPrefab;
    private EnemyHealthBar _healthBar;

    public float attackRadius;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        _healthBar = Instantiate(healthBarPrefab, FindObjectOfType<WorldSpaceCanvas>().transform);
        _healthBar.target = transform;
        healthBar = _healthBar;
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
    public void Hit(int damage)
    {
        sword.damage = damage;
        sword.Enable();
    }
}
