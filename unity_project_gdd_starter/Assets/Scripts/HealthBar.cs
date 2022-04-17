using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    public Transform whiteBar;
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
        StartCoroutine(DelayedHealth(sizeNormalized));
    }

    public IEnumerator DelayedHealth(float sizeNormalized)
    {
        yield return new WaitForSeconds(1f);
        SetSize(sizeNormalized);
    }

}


