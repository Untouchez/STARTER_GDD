using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            Attack();
    }

    void Attack()
    {
        //WE WANT THIS FUNCTION TO ATTACK (PLAY AN ANIMATION, SEE IF HITS ANYTHING)

        //1. find animation on mixamo we like for attack
        //2. import into unity, update the controller,
        //2.1 add it to player controller,
        //2.2 set up transitions from anystate exit,
        //2.3 add condition
        //we want this function to call the trigger
        anim.SetTrigger("attack");
 

    }
}
