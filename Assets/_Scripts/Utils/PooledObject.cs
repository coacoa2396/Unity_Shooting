using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPooler pooler;
    [SerializeField] bool autoRelease;
    [SerializeField] float releaseTime;
    Coroutine coroutine;

    private void OnEnable()
    {
        if (autoRelease)
        {
            coroutine = StartCoroutine(ReleaseRoutine());
        }
    }

    private void OnDisable()
    {
        if (autoRelease)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator ReleaseRoutine()
    {
        yield return new WaitForSeconds(releaseTime);
        Release();
    }

    public void Release()
    {
        if (pooler != null)
        {
            pooler.ReturnPool(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
