using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : Health 
{
    
    PlayerLocomotion player;
    Animator anim;
    Blink blink;
    public bool isDead;
    StateManager stateManager;
    public ParticleSystem deadEffect;
    public void Start()
    {
        anim = GetComponent<Animator>();
        blink = GetComponent<Blink>();
        stateManager = GetComponentInChildren<StateManager>();
        damageNumber = FindObjectOfType<WorldSpaceCanvas>().CreateDamageNumber(this.transform);
        player = FindObjectOfType<PlayerLocomotion>();
    }

    public override void TakeDamage(int damage)
    {
        if (isDead)
            return;
        print(this + "took damage");
        currentHealth -= damage;
        anim.Play("Take Damage", 0, 0.0f);
        blink.BlinkME(0.2f, 5f, Color.white);
        damageNumber.DisplayText(damage.ToString(),transform);
        if(currentHealth<=0)
        {
            StartCoroutine(Dead());
        }
    }

    public IEnumerator Dead()
    {
        stateManager.enabled = false;
        anim.Play("Die", 0, 0);
        isDead = true;
        player.lookDetection.selectables.Remove(this.transform);
        yield return new WaitForSeconds(0.5f);
        ParticleSystem duh = Instantiate(deadEffect, transform.position, transform.rotation);
        duh.Play(true);
        Destroy(duh, 3f);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    public void Hit(int damage)
    {
        player.anim.SetTrigger("take_damage");
        player.anim.SetFloat("direction", Vector3.Dot(transform.forward, player.transform.forward));
    }
}
