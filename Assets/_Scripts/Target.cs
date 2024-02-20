using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField] int hp;

    void Die()
    {
        Destroy(gameObject);        // gameObject : 컴포넌트를 달고있는 자기자신
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
