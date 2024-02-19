using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform CameraRoot;
    
    [SerializeField] float sensitivity;
    

    Vector2 inputDir;
    float yRotation;

    

    private void LateUpdate()
    {
        yRotation -= inputDir.y * sensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);


        transform.Rotate(Vector3.up, sensitivity * inputDir.x * Time.deltaTime);
        CameraRoot.localRotation = Quaternion.Euler(yRotation, 0, 0);
        //CameraRoot.Rotate(Vector3.right, sensitivity * -inputDir.y * Time.deltaTime);
        
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
