using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ParticleSystem hitEffect;
    public int damage;
    Coroutine enableCoroutine;
    Collider collider;
    bool isAttacking;

    public void Awake()
    {
        collider = GetComponent<Collider>();
    }

    public void Enable()
    {
        if (enableCoroutine != null)
            StopCoroutine(turnOff());
        enableCoroutine = StartCoroutine(turnOff());
        isAttacking = true;
        collider.enabled = true;
    }

    public IEnumerator turnOff()
    {
        yield return new WaitForSeconds(0.15f);
        collider.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        {
            other.GetComponent<Health>().TakeDamage(damage);
            Vector3 hitPoint = other.ClosestPoint(this.transform.position);
            hitEffect.transform.position = hitPoint;
            hitEffect.Play(true);
        }
    }

}
