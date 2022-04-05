using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp_Effect_Damage : MonoBehaviour
{
    public int StompEffectDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider sphereCollider)
    {
        if (sphereCollider.transform.gameObject.CompareTag("Player"))
        {
            sphereCollider.transform.GetComponent<Health>().TakeDamage(StompEffectDamage);
        }
    }
}
