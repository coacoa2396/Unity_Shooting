using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneFlow : MonoBehaviour
{
    [SerializeField] PooledObject bulletPrefab;
    [SerializeField] PooledObject effectPrefab;

    private void OnEnable()
    {
        Loading();
    }

    private void OnDisable()
    {
        UnLoading();
    }

    void Loading()
    {
        Manager.PoolManager.CreatePool(bulletPrefab, 5);
        Manager.PoolManager.CreatePool(effectPrefab, 5);
    }

    void UnLoading()
    {
        Manager.PoolManager.RemovePool(bulletPrefab);
        Manager.PoolManager.RemovePool(effectPrefab);
    }
}
