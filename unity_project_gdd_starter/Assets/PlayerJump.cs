using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool isJumping;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        //we want this function to jump
        //1. check if jumping
        //2. check if grounded
        //3. if grounded and not jumping then jump
        //4.if i jump then i should turn on isJumping, and after a delay turn it off
    }
}
