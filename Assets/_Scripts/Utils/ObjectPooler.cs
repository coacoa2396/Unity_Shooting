using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] PooledObject prefab;
    [SerializeField] int poolSize;

    Stack<PooledObject> objectPool;

    
    public void CreatePool(PooledObject prefab, int poolSize)
    {
        objectPool = new Stack<PooledObject>(poolSize);
        this.prefab = prefab;
        this.poolSize = poolSize;


        objectPool = new Stack<PooledObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            instance.pooler = this;
            instance.transform.parent = transform;
            objectPool.Push(instance);
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)
    {
        if (objectPool.Count > 0)
        {
            PooledObject instance = objectPool.Pop();

            instance.transform.parent = null;
            instance.transform.position = position;
            instance.transform.rotation = rotation;

            instance.gameObject.SetActive(true);
            return instance;
        }
        else
        {
            PooledObject instance = Instantiate(prefab);
            instance.pooler = this;
            return instance;
        }
    }

    public void ReturnPool(PooledObject instance)
    {
        if(objectPool.Count < poolSize)
        {
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
            objectPool.Push(instance);
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
}
