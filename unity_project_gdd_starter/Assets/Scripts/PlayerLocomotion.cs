using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public Animator anim;
    public LookingDetection lookDetection;
    public float acceleration;
    public float decceleration;

    public Vector3 rawInput;
    public Vector3 calculatedInput;

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        anim.SetFloat("Vertical", calculatedInput.z);
        anim.SetFloat("Horizontal", calculatedInput.x);
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
        rawInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (rawInput.magnitude != 0)
            calculatedInput = new Vector3(Mathf.MoveTowards(calculatedInput.x, rawInput.x, acceleration * Time.deltaTime), 0, Mathf.MoveTowards(calculatedInput.z, rawInput.z, acceleration * Time.deltaTime));
        else
            calculatedInput = new Vector3(Mathf.MoveTowards(calculatedInput.x, 0, acceleration * Time.deltaTime), 0, Mathf.MoveTowards(calculatedInput.z, 0, decceleration * Time.deltaTime));

        calculatedInput = Vector3.ClampMagnitude(calculatedInput, 1.5f);
    }
}
