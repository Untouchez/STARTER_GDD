using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    Health health;
    Animator anim;
    PlayerLocomotion PL;
    // Start is called before the first frame update
    void Start()
    {
        PL = GetComponent<PlayerLocomotion>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("dodge");
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Dodge"))
            health.canTakeDamage = false;
        else
            health.canTakeDamage = true;
    }
}
