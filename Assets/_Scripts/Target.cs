using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField] int hp;

    void Die()
    {
        Destroy(gameObject);        // gameObject : ������Ʈ�� �ް��ִ� �ڱ��ڽ�
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }
}
