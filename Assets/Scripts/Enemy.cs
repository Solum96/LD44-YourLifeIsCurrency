using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.MovePosition(_rb.position+Vector3.back * Time.deltaTime * Speed);
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
