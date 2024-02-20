using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System.Xml.Serialization;
using UnityEngine.Animations.Rigging;


public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] CharacterController controller;
    [SerializeField] Camera MainCamera;
    [SerializeField] CinemachineVirtualCamera FPS;
    [SerializeField] CinemachineVirtualCamera TPS;
    [SerializeField] Animator animator;
    [SerializeField] TwoBoneIKConstraint LeftHandIK;
    [SerializeField] MultiAimConstraint FPSoffset;
    [SerializeField] WeaponHolder WeaponHolder;



    [Header("Specs")]    
    [SerializeField] float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float jumpSpeed;

    CinemachineVirtualCamera curCamera;
    Vector3 moveDir;
    Vector3 TPSOffset;
    Vector3 FPSOffset;
    float ySpeed;
    bool isWalk;


    private void Awake()
    {
        curCamera = FPS;
        TPSOffset = new Vector3(-45, 0, 0);
        FPSOffset = new Vector3(0,0,0);
    }

    

    private void Update()
    {
        Move();
        JumpMove();
    }

    void Move()
    {

        if (isWalk)
        {
            controller.Move(transform.right * moveDir.x * walkSpeed * Time.deltaTime);
            controller.Move(transform.forward * moveDir.z * walkSpeed * Time.deltaTime);
            animator.SetFloat("XSpeed", moveDir.x * walkSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("YSpeed", moveDir.z * walkSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("MoveSpeed", moveDir.magnitude * walkSpeed, 0.1f, Time.deltaTime);
        }
        else
        {
            //controller.Move(moveDir * moveSpeed * Time.deltaTime);        // ���� �������� �����δ�
            controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
            controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
            animator.SetFloat("XSpeed", moveDir.x * moveSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("YSpeed", moveDir.z * moveSpeed, 0.1f, Time.deltaTime);
            animator.SetFloat("MoveSpeed", moveDir.magnitude * moveSpeed, 0.1f, Time.deltaTime);
        }


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
            MainCamera.cullingMask = 9;
            FPSoffset.data.offset = TPSOffset;
        }
        else
        {
            TPS.Priority = 0;
            curCamera = FPS;
            //MainCamera.cullingMask = MainCamera.cullingMask & ~(1 << LayerMask.NameToLayer("Player"));
            MainCamera.cullingMask = 1;
            FPSoffset.data.offset = FPSOffset;
        }
    }

    void OnWalk(InputValue value)
    {
        if (value.isPressed)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
    }

    public void Fire()
    {
        WeaponHolder.Fire();
        animator.SetTrigger("Fire");

    }

    public void Reload()
    {
        animator.SetTrigger("Reload");
        StartCoroutine(IKChange());
    }

    IEnumerator IKChange()
    {
        LeftHandIK.weight = 0;
        yield return new WaitForSeconds(2f);
        LeftHandIK.weight = 1;
    }

    void OnFire(InputValue value)
    {
        Fire();
    }

    void OnReload(InputValue value)
    {
        Reload();
    }
}
