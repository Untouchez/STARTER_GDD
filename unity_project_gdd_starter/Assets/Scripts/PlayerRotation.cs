using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform root;
    public bool canRotate;
    public float turnSpeed;
    PlayerLocomotion PL;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        PL = GetComponent<PlayerLocomotion>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        if (!canRotate)
            return;
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.TransformDirection(calculatedInput)), turnSpeed * Time.fixedDeltaTime);

        if (PL.rawInput.magnitude != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    public void LookAtCamera()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, yawCamera, 0);
    }
}
