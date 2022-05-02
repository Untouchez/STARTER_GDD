using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catboss : Health
{
    // Start is called before the first frame update

    public float rotateSpeed;
    public Player player;
    private float lastAttack;
    public float attackRate;
    public bool isAttacking;
    public float attackRange;
    public float lastfired;
    public float FireRate;

    public Transform projectile;
    

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        if (Time.time - lastfired > 1 / FireRate)
         {
             Instantiate(projectile, transform.position, transform.rotation);
             lastfired = Time.time;
        }
    }

    public void LookAtPlayer()
    {

        // Determine which direction to rotate towards
        Vector3 targetDirection = player.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    
    }

    // public bool IsPlaying(string clipName)
    // {
    //     return this.anim.GetCurrentAnimatorStateInfo(0).IsName(clipName);
    // }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
