using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LookingDetection : MonoBehaviour
{
    public List<Transform> selectables;
    public float threshhold;

    public Transform selected;

    public Transform Check(Ray ray)
    {
        if (selectables.Count == 0)
            return null;
        selected = null;
        var closest = 0f;
        for(int i=0; i< selectables.Count; i++)
        {
            Vector3 cameraDirection = ray.direction;
            Vector3 directionToCurr = selectables[i].transform.position - ray.origin;

            //VALUE FROM -1,1 (1 DIRECTLY INFRONT, -1 DIRECTLY BEHIND)
            float lookPercentage = Vector3.Dot(cameraDirection.normalized, directionToCurr.normalized);

            if(lookPercentage >= threshhold && lookPercentage > closest) {
                closest = lookPercentage;
                selected = selectables[i];
            }
        }

        return selected;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>())
            selectables.Add(other.transform);
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Health>())
            selectables.Remove(other.transform);
    }
}
