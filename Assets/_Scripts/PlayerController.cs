using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;


public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] CharacterController controller;
    [SerializeField] Camera MainCamera;
    [SerializeField] CinemachineVirtualCamera FPS;
    [SerializeField] CinemachineVirtualCamera TPS;
    


    [Header("Specs")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    CinemachineVirtualCamera curCamera;
    Vector3 moveDir;
    float ySpeed;

    private void Awake()
    {
        curCamera = FPS;
    }

    private void Update()
    {
        Move();
        JumpMove();
    }

    void Move()
    {
        //controller.Move(moveDir * moveSpeed * Time.deltaTime);        // ���� �������� �����δ�
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);

    }

    void JumpMove()
    {
        // ��ӵ� � : �ӵ��� �ð��� ���� ���� �����ϴ� ���
        //              -> m/sec^ -> �����̱� ������ ySpeed���ٰ� deltaTime�� �����ְ�
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            ySpeed = 0f;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);      // ���⼭ deltaTime�� �ѹ� �� �����ִϱ� ������ �ȴ�
    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }

    void OnJump(InputValue value)
    {
        ySpeed = jumpSpeed;
    }

    void OnChangeCamera(InputValue value)
    {
        if (curCamera == FPS)
        {
            TPS.Priority = 20;
            curCamera = TPS;
            //MainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Player");
            MainCamera.cullingMask = 36;
        }
        else
        {
            TPS.Priority = 0;
            curCamera = FPS;
            //MainCamera.cullingMask = MainCamera.cullingMask & ~(1 << LayerMask.NameToLayer("Player"));
            MainCamera.cullingMask = 9;
        }
    }
}
