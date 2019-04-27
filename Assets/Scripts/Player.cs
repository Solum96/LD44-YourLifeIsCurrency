using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] Hulls;

    public float Speed = 5f;
    Rigidbody _rb;
    Hull _currentHull = null;
    int _currentHullIndex = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        SwapHull(0);
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

        // Sawp hull
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapHull(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwapHull(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwapHull(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwapHull(4);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var armorMultiplier = GetComponentInChildren<Hull>().ArmorMultiplier;
        Oxygen.RemoveOxygen(0.2f * armorMultiplier);
    }

    void SwapHull(int index)
    {
        if (_currentHull != null)
        {
            GameObject.Destroy(_currentHull.gameObject);
        }
        _currentHull = GameObject.Instantiate(Hulls[index], Vector3.zero, Quaternion.identity, transform).GetComponent<Hull>();
        _currentHull.transform.localPosition = Vector3.zero;
        _currentHull.transform.localRotation = Quaternion.identity;
        _currentHullIndex = index;
    }
}