using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LookingDetection : MonoBehaviour
{
    //THINGS INSIDE RADIUS WITH HEALTH
    public List<Transform> selectables;

    //LOOK THRESHHOLD ( LOOK VALUE NEEDS TO BE THIS OR IGNORED )
    public float threshhold;

    public Transform selected;

    //CHECK SELECTABLES FOR OBJECT WHERE PLAYER IS MOST LOOKING AT
    public Transform Check(Ray ray)
    {
        if (selectables.Count == 0)
            return null;
        selected = null;
        var closest = 0f;
        for(int i=0; i< selectables.Count; i++)
        {
            if (selectables[i] == null)
                return null;
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

    //OBJECTS THAT ENTER SPHERE TRIGGER 
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>())
            selectables.Add(other.transform);
    }

    //OBJECTS THAT EXIT SPHERE TRIGGER 
    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Health>())
            selectables.Remove(other.transform);
    }
}
