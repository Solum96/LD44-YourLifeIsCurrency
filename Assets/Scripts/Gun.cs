using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Prefab;
    public float Rate;
    bool _isFiring;
    float _timer;

    public void StartFire()
    {
        _isFiring = true;
        _timer = 0;
    }
    public void StopFire()
    {
        _isFiring = false;
    }
    void Update()
    {
        if (_isFiring)
        {
            _timer -= Time.deltaTime * Rate;
            if (_timer < 0)
            {
                _timer++;
                GameObject.Instantiate(Prefab, transform.position, transform.rotation);
            }
        }
    }
}
