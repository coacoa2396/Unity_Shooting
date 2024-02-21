using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    public class ObjectPool : MonoBehaviour
    {
        //========================================
        //##		������ ���� ObjectPool		##
        //========================================
        /*
            ������Ʈ Ǯ�� ���� :
            ���α׷� ������ ����ϰ� ��Ȱ��Ǵ� �ν��Ͻ����� ����&�������� �ʰ�
            �̸� �����س��� �ν��Ͻ����� ������ ��ü����(Ǯ)����
            �ν��Ͻ��� �뿩&�ݳ��ϴ� ������� ����ϴ� ���

            ���� :
            1. �ν��Ͻ����� ������ ��ü����(Ǯ)�� ����
            2. ���α׷��� ���۽� ��ü����(Ǯ)�� �ν��Ͻ����� �����Ͽ� ����
            3. �ν��Ͻ��� �ʿ�� �ϴ� ��Ȳ���� ��ü����(Ǯ)�� �ν��Ͻ��� �뿩�Ͽ� ���
            4. �ν��Ͻ��� �ʿ�� ���� �ʴ� ��Ȳ���� ��ü����(Ǯ)�� �ν��Ͻ��� �ݳ��Ͽ� ����

            ���� :
            1. ����ϰ� ����ϴ� �ν��Ͻ��� ������ �ҿ�Ǵ� ������带 ����
            2. ����ϰ� ����ϴ� �ν��Ͻ��� ������ ������ �ݷ��� �δ��� ����

            ���� :
            1. �̸� �����س��� �ν��Ͻ��� ���� ������� �ʴ� ��쿡�� �޸𸮸� �����ϰ� ����
            2. �޸𸮰� �˳����� ���� ��⿡�� �ʹ� ���� ������Ʈ Ǯ���� ����ϴ� ���,
               �������� ���������� �پ��� ������ ���α׷��� �δ��� �Ǵ� ��찡 ����
        */

        public class ObjectPooler : MonoBehaviour
        {
            PooledObject prefab;
            Stack<PooledObject> objectPool;         // ť, ����Ʈ�ε� �����ϱ� �ѵ� ������ ���� ������ ������
            int poolSize = 100;

            public void CreatePool()            // Pool ä���
            {
                objectPool = new Stack<PooledObject>();
                for (int i = 0; i < poolSize; i++)
                {
                    PooledObject instance = Instantiate(prefab);
                    instance.gameObject.SetActive(false);
                    objectPool.Push(instance);
                }
            }

            public PooledObject GetPool()       // �ν��Ͻ� �뿩�ϱ�
            {
                PooledObject instance = objectPool.Pop();
                instance.gameObject.SetActive(true);
                return instance;
            }

            public void ReturnPool(PooledObject instance)   // �ν��Ͻ� �ݳ��ϱ�
            {
                instance.gameObject.SetActive(false);
                objectPool.Push(instance);
            }
        }

        public class PooledObject : MonoBehaviour
        {
            // ����&������ ����� Ŭ����
        }
    }
}

