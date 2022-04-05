using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : HealthBar
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position + offset;
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}