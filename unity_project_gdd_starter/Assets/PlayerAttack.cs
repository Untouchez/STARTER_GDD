using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public ParticleSystem slashEffect;
    public GameObject weapon;
    PlayerRotation PR;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PR = GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
            PR.LookAtCamera();
        }

    }

    public void Hit(float rotation)
    {
        slashEffect.Play();
    }
}
