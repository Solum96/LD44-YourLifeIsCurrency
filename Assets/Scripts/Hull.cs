using System;
using UnityEngine;

public class Hull : MonoBehaviour
{
    [HideInInspector] public int HullIndex;
    public float OxygenCost = 0.1f;
    public float ArmorMultiplier = 1f;
    public float Lifetime = 10f;
    public float OxygenDamageMultiplier = 1f;

    float _lifeTimeTimer = 0f;

    void Awake()
    {
        _lifeTimeTimer = Lifetime;
    }

    public void Fire(bool isfiring)
    {
        var guns = GetComponentsInChildren<Gun>();
        foreach (var gun in guns)
        {
            if (isfiring)
            {
                gun.StartFire(OxygenDamageMultiplier);
            }
            else
            {
                gun.StopFire();
            }
        }
    }

    void Update()
    {
        _lifeTimeTimer -= Time.deltaTime;
    }

    public float GetLifetime()
    {
        return Mathf.Clamp01(_lifeTimeTimer / Lifetime);
    }
}