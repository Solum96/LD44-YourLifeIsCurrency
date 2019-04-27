using UnityEngine;
using System;

public class Hull : MonoBehaviour
{
    
    public float ArmorMultiplier = 1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateGuns(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdateGuns(false);
        }
    }
    void UpdateGuns(bool isfiring)
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
