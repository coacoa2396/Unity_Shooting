using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCameraController : MonoBehaviour
{
    [SerializeField] Transform CameraRoot;
    [SerializeField] Transform Target;
    [SerializeField] float distance;
    [SerializeField] float sensitivity;

    Vector2 inputDir;
    float xRotation;

    


    private void Update()
    {
        SetTargetPos();
    }

    private void LateUpdate()
    {
        xRotation -= inputDir.y * sensitivity * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);


        transform.Rotate(Vector3.up, inputDir.x * sensitivity * Time.deltaTime);
        CameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }

    public void SetTargetPos()
    {
        Target.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void OnLook(InputValue value)
    {
        inputDir = value.Get<Vector2>();
    }
}
