using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject enemy;
    private Animator enemyAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enemy.transform.position += new Vector3(0, 1, 0);
            //enemy.transform.Rotate(90f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            enemy.transform.position -= new Vector3(0, 1, 0);
            //enemy.transform.Rotate(-90f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            enemyAnimator.Play("Take Damage");
        }
    }
}
