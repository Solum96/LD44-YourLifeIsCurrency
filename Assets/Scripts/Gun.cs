using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Prefab;
    public float Rate;
    bool _isFiring;
    float _timer;
    float _oxygenDamageMultiplier = 1f;

    public void StartFire(float dmgMultiplier)
    {
        _isFiring = true;
        _oxygenDamageMultiplier = dmgMultiplier;
    }
    public void StopFire()
    {
        _isFiring = false;
    }
    void Update()
    {
        _timer -= Time.deltaTime * Rate;
        if (_isFiring)
        {
            if (_timer < 0)
            {
                _timer = 1f;
                var shot = GameObject.Instantiate(Prefab, transform.position, transform.rotation).GetComponent<Shot>();
                shot.OxygenDamage *= _oxygenDamageMultiplier;
            }
        }
    }
}