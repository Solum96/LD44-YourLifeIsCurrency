using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour, IDamageDealer
{
    public float Speed = 1f;
    public float OxygenDamage;
    private Rigidbody _rb;

    public GameObject DestructionPrefab = null;

    public float Damage { get { return OxygenDamage; } }

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

        if (DestructionPrefab != null)
        {
            GameObject.Instantiate(DestructionPrefab, transform.position, Quaternion.identity);
        }
    }
}