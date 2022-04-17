using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Companion : MonoBehaviour
{
    Player player;
    NavMeshAgent agent;
    Animator anim;
    public Health target;
    float distanceToPlayer;

    public float followDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer >= followDistance)
            MoveToPlayer();
    }

    public void MoveToPlayer()
    {
        agent.SetDestination(GetRandomPoint(player.transform.position, followDistance));
    }

    public Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        return hit.position;
    }
}
