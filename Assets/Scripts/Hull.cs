using System;
using UnityEngine;

public class Hull : MonoBehaviour
{
    public float ArmorMultiplier = 1f;

    public void Fire(bool isfiring)
    {
        var guns = GetComponentsInChildren<Gun>();
        foreach (var gun in guns)
        {
            if (isfiring)
            {
                gun.StartFire();
            }
            else
            {
                gun.StopFire();
            }
        }
    }
}