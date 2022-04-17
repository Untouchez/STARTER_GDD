using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator anim;
    public ParticleSystem hitEffect;
    public Light weaponLight;
    public int damage;
    public Collider hitBox;
    string myTag;

    public float hitSpeed;
    public float hitDuration;
    public void Awake()
    {
        hitBox = GetComponent<Collider>();
        myTag = transform.root.tag;
        //anim = transform.root.GetComponent<Animator>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())   
        {
            Health health = other.GetComponent<Health>();
            if (!health.canTakeDamage || other.transform.root.CompareTag(myTag))
                return;
            health.TakeDamage(damage);
            Vector3 hitPoint = other.ClosestPoint(this.transform.position);
            hitEffect.transform.position = hitPoint;
            hitEffect.Play(true);
            print(other.transform);
        }
    }

    Coroutine hitStunCoroutine;
    public void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Health>() || other.transform.root.CompareTag(myTag))
            return;

        anim.speed = hitSpeed;
        if (hitStunCoroutine != null)
            StopCoroutine(HitStun());
        hitStunCoroutine = StartCoroutine(HitStun());
    }

    public IEnumerator HitStun()
    {
        yield return new WaitForSeconds(hitDuration);
        anim.speed = 1f;
    }
    

}
