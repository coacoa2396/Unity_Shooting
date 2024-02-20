using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    
    Gun curGun;

    private void Start()
    {
        curGun = guns[0];
    }

    public void Fire()
    {
        curGun.Fire();
    }
}
