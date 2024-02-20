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

            Debug.Log("�¾Ҵ�!");

            IDamagable target = hitInfo.collider.GetComponent<IDamagable>();    // GetComponent�� �������̽��� ã���ش�

            target?.TakeDamage(damage);     // �Ʒ� if���� ����(������ nullüũ���)
            /*
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            */

            // ����ĳ��Ʈ ����� ���
            /*
            Debug.Log(hitInfo.collider.gameObject.name);
            Debug.Log(hitInfo.distance);
            hitPoint.position = hitInfo.point;
            */
        }
        else
        {
            Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.5f);
            Debug.Log("�ȸ¾Ҵ�!");
        }

    }
}
