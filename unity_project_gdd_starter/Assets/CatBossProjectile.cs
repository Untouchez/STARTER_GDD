using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBossProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float projectileSpeed;

    public UnityEngine.AI.NavMeshAgent agent;

    public Player player;
    
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
      //  transform.Translate(transform.forward * projectileSpeed * Time.deltaTime); 
    
    }
}
