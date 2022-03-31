using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbag_Weapon : MonoBehaviour
{
    public int Weapon_Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.CompareTag("Player"))
        {
            print("HitPlayer");
            other.transform.GetComponent<Health>().TakeDamage(Weapon_Damage);
        }
    }
}
