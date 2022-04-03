using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    Animator anim;
    PlayerLocomotion PL;
    // Start is called before the first frame update
    void Start()
    {
        PL = GetComponent<PlayerLocomotion>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("dodge");
        }
    }
}
