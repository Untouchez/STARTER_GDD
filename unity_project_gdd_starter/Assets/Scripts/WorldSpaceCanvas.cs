using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCanvas : MonoBehaviour
{
    public DamageNumber damageNumberPrefab;
    public DamageNumber CreateDamageNumber(Transform notMe)
    {
        return Instantiate(damageNumberPrefab, transform);
    }
}
