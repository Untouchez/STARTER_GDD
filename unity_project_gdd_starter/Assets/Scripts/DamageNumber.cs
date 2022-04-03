using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Vector3 startSize;
    public Vector3 endSize;
    public float scaleSpeed;

    Coroutine stopShowingCoroutine;
    public void DisplayText(string newText, Transform notMe)
    {
        if (stopShowingCoroutine != null)
            StopCoroutine(stopShowing());
        stopShowingCoroutine = StartCoroutine(stopShowing());
        transform.position = notMe.position + new Vector3(0, 2, 0);
        text.text = newText;
        DoAnimation();
        transform.LookAt(Camera.main.transform.position);

    }

    void DoAnimation()
    {
        Vector3 newPos = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
        transform.DOMove(transform.position + newPos,0.2f);
        transform.DOScale(startSize, 0);
        transform.DOScale(endSize, scaleSpeed);
    }

    public IEnumerator stopShowing()
    {
        yield return new WaitForSeconds(0.5f);
        this.text.text = string.Empty;
    }
}
