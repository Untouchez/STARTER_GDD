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
        //2.1 create a function called isGrounded and make it return true of false ( a boolean value )
        //2.2 shoot a raycast down from the player positon (like a laser which checks if it hit anythings ) 
        //2.3 honestly just google isGrounded function unity and you will find lots of resources

        //3. if grounded and not jumping then jump
        //3.1 To Jump we first have  to find an animation we like on mixamo and import it
        //3.2 after importing we should add it in the player animator controller
        //3.3 add transitions from anystate and exit along with a condition
        //3.3.1 to create a condition on the left side of the animator controller hit the plus button and click trigger
        //3.3.2 add the condition on the arrow from anystate to the jump state

        //4.if i jump then i should turn on isJumping, and after a delay turn it off
        //4.1 for the delay look up IEnumerators
    }
}
