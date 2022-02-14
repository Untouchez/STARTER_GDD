using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform hit;

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
        hit = other.transform;
        StartCoroutine(entered());
    }

    public IEnumerator entered()
    {
        yield return new WaitForSeconds(1f);
        hit = null;

    }
}
