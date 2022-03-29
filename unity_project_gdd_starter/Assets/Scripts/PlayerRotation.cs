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
        Cursor.visible = false;
        Cursor.lockState= CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerFaceCameraForward();
    }

    //MAKE THE PLAYER FACE SAME DIRECTION AS CAMERA SLOWLY IF IN PRESSING INPUT
    void PlayerFaceCameraForward()
    {
        if (!canRotate)
            return;
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        if (PL.rawInput.magnitude != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }

    //MAKE PLAYER INSTANTLY FACE SAME DIRECTION AS CAMERA
    public void PlayerFaceCameraForwardFast()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0),1F); ;
    }

    //HAVE PLAYER FACE PASSED IN TARGET 
    public void LookAt(Transform target)
    {
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);
    }
}
