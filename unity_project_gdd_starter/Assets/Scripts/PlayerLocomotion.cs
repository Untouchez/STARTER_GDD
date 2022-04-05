using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public Animator anim;
    public LookingDetection LD;
    public float acceleration;
    public float decceleration;

    public Vector2 input;
    public Vector2 rawInput;
    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        anim.SetFloat("Vertical", input.y);
        anim.SetFloat("Horizontal", input.x);
    }

    //CALCULATES AND SETS RAW INPUT AND CALCULATED INPUT
    //CHANGES ANIMATOR TO PLAY CORRECT ANIMATION
    void HandleInputs()
    {
        //GETS WASD INPUT
        // W = 1 Y
        // S = -1 Y
        // A = -1 X
        // D = 1 X
        anim.SetBool("sprint", Input.GetKey(KeyCode.LeftShift));
        rawInput.y = Input.GetAxisRaw("Vertical");
        rawInput.x = Input.GetAxisRaw("Horizontal");

        if (rawInput.x != 0)
            input.x = Mathf.MoveTowards(input.x, rawInput.x, acceleration * Time.deltaTime);
        else
            input.x = Mathf.MoveTowards(input.x, 0, decceleration * Time.deltaTime);

        if (rawInput.y != 0)
            input.y = Mathf.MoveTowards(input.y, rawInput.y, acceleration * Time.deltaTime);
        else
            input.y = Mathf.MoveTowards(input.y, 0, decceleration * Time.deltaTime);

        rawInput = Vector3.ClampMagnitude(rawInput, 1.5f);
    }
}
