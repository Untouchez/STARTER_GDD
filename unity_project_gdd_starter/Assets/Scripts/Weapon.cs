using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ParticleSystem hitEffect;
    public Light weaponLight;
    public int damage;
    public Collider hitBox;
    string myTag;
    public void Awake()
    {
        hitBox = GetComponent<Collider>();
        myTag = transform.root.tag;
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

}
