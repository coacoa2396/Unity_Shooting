using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField] int hp;
    [SerializeField] ParticleSystem particle;
    

    void Die()
    {
        Destroy(gameObject);        // gameObject : ������Ʈ�� �ް��ִ� �ڱ��ڽ�
        particle.Play();
        Destroy(particle.gameObject, 2f);
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
