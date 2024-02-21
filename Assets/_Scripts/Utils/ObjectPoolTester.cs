using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
    
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] PooledObject effectPrefab;

    private void Start()
    {
        Manager.PoolManager.CreatePool(bulletPrefab, 5);
        Manager.PoolManager.CreatePool(effectPrefab, 10);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Manager.PoolManager.GetPool(bulletPrefab, Random.insideUnitSphere * 10f, Quaternion.identity);
            //Manager.PoolManager.GetPool("bullet");
            //PooledObject instance = pooler.GetPool();
            //instance.transform.position = Random.insideUnitSphere * 10f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Manager.PoolManager.GetPool(bulletPrefab, Random.insideUnitSphere * 10f, Quaternion.identity);
        }

        
    }
}
