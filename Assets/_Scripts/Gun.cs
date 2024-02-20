using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] int damage;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] Transform hitPoint;

    public void Fire()
    {
        muzzleFlash.Play();

        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hitInfo, maxDistance))
        {
            // 레이캐스트 보이게 하기
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.5f);

            // 맞는 위치에 총자국 이펙트
            ParticleSystem partcl = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            partcl.transform.position = hitInfo.point;
            Destroy(partcl, 1.5f);

            // 맞았을 때 물리력 구현
            Rigidbody rigid = hitInfo.collider.GetComponent<Rigidbody>();
            if (rigid != null)
            {
                rigid.AddForceAtPosition(-hitInfo.normal * 10f, hitInfo.point, ForceMode.Impulse);
            }

            // 맞는 로그
            Debug.Log("맞았다!");

            // 인터페이스를 찾아서 데미지 넣기
            IDamagable target = hitInfo.collider.GetComponent<IDamagable>();    // GetComponent는 인터페이스도 찾아준다

            target?.TakeDamage(damage);     // 아래 if문과 동일(간단한 null체크방법)
            /*
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            */

            // 레이캐스트 디버깅 방법
            /*
            Debug.Log(hitInfo.collider.gameObject.name);
            Debug.Log(hitInfo.distance);
            hitPoint.position = hitInfo.point;
            */
        }
        else
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.5f);
            Debug.Log("안맞았다!");
        }

    }
}
