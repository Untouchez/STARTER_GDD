using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    public Transform whiteBar;
    public bool ChangeBar;

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
        StartCoroutine(SetSizeDelay(sizeNormalized));
    }

    public IEnumerator SetSizeDelay(float sizeNormalized)
    {
        yield return new WaitForSeconds(0.5f);
        whiteBar.localScale = new Vector3(sizeNormalized, 1f);
    }
}


