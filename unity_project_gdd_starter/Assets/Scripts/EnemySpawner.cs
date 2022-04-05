using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius;
    public float spawnRate = 3f;
    public Health enemy;
    float fireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTime -= Time.deltaTime;

        if (fireTime <= 0)
        {
            fireTime = Random.Range(spawnRate/2,spawnRate*2);
            Vector3 newSpot = DetermineRandomSpot();
            if(newSpot != Vector3.zero)
                Instantiate(enemy, newSpot, enemy.transform.rotation);
        }
    }

    Vector3 DetermineRandomSpot()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, 1);
        if(hit.position.magnitude>100000f)      
            return Vector3.zero;
        
        return hit.position;
    }
}
