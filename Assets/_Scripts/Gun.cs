using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] int damage;
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask layerMask;

    [SerializeField] Transform hitPoint;

    public void Fire()
    {


        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hitInfo, maxDistance))
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.5f);

            Debug.Log("맞았다!");

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
