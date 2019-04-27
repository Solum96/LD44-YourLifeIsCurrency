using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Movement och sånt
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movementVector = new Vector3(horizontal, 0, vertical).normalized;
        var wantedPosition = transform.position + movementVector * Time.deltaTime * Speed;
        _rb.MovePosition(GameBounds.ClampToBounds(wantedPosition));

        //Oxygen drop
        Oxygen.RemoveOxygen(Time.deltaTime * 0.04f);
    }
    void OnCollisionEnter(Collision collision)
    {
        var armorMultiplier = GetComponentInChildren<Hull>().ArmorMultiplier;
        Oxygen.RemoveOxygen(0.2f * armorMultiplier);
    }
}