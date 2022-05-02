using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCageWithKey : MonoBehaviour
{
    public Key key;
    public GameObject cage;
    //public GameObject freeDog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        print("nearCage");
        if (other.gameObject.CompareTag("Player") && GameManager.Instance.hasKey == true) 
        {
            print("unlockCage");
            cage.SetActive(false);
            //freeDog.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
