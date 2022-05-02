using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catbossprojectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float projectileSpeed;

    public UnityEngine.AI.NavMeshAgent agent;

    public Player player;
    public int damage;
    
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(player.transform.position);
    
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() && other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();
            if (!health.canTakeDamage)
                return;
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        print("hit player");
    }
}