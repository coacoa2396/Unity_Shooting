using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    Dictionary<string, ObjectPooler> poolDic = new Dictionary<string, ObjectPooler>();

    

    public void CreatePool(PooledObject prefab, int size)
    {
        GameObject poolObject = new GameObject($"Pool_{prefab.gameObject.name}");
        ObjectPooler pooler = poolObject.AddComponent<ObjectPooler>();
        pooler.CreatePool(prefab, size);

        poolDic.Add(prefab.gameObject.name, pooler);


    }

    public void RemovePool(PooledObject prefab)
    {
        ObjectPooler pooler = poolDic[prefab.gameObject.name];
        Destroy(pooler.gameObject);

        poolDic.Remove(prefab.gameObject.name);
    }

    public PooledObject GetPool(PooledObject prefab, Vector3 position, Quaternion rotation)
    {
        return poolDic[prefab.gameObject.name].GetPool(position, rotation);

    }
}
