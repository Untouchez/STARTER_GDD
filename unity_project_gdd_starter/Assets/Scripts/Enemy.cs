using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health 
{
    Animator anim;
    Blink blink;

    public new void Start()
    {
        anim = GetComponent<Animator>();
        blink = GetComponent<Blink>();

        base.Start();
    }
    public override void TakeDamage(int damage)
    {
        print(this + "took damage");
        anim.Play("Take Damage", 0, 0.0f);
        blink.BlinkME(0.2f, 5f, Color.white);

        base.TakeDamage(damage);
    }
}
