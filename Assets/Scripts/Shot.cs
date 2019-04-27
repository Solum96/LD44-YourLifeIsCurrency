using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.MovePosition(_rb.position + transform.forward * Time.deltaTime * Speed);
        if (!GameBounds.IsWithinBounds(transform.position))
        {
            GameObject.Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(gameObject);
    }
}
