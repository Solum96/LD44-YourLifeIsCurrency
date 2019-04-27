using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Hull CurrentHull = null;

    public GameObject[] Hulls;
    public Vector2 Speed;
    public float SpeedEase = 10f;

    Rigidbody _rb;
    Vector3 _rotation = Vector3.zero;
    Vector3 _cameraOffset;

    Vector3 _movementVector;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        SwapHull(0);
        _cameraOffset = Camera.main.transform.position;
    }

    void FixedUpdate()
    {
        //Movement och sånt
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _movementVector = Vector3.Lerp(_movementVector, new Vector3(horizontal, 0, vertical).normalized, Time.deltaTime * SpeedEase);
        var moveVec = new Vector3(_movementVector.x * Speed.x, 0f, _movementVector.z * Speed.y);
        var wantedPosition = GameBounds.ClampToBounds(_rb.position + (moveVec * Time.deltaTime));
        _rb.MovePosition(Vector3.Lerp(_rb.position, wantedPosition, Time.deltaTime * SpeedEase));
    }

    void Update()
    {
        // Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrentHull.Fire(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CurrentHull.Fire(false);
        }

        //Oxygen drop
        Oxygen.RemoveOxygen(Time.deltaTime * 0.04f);

        if (Oxygen.CurrentOxygen <= 0f)
        {
            GameObject.Destroy(gameObject);
        }

        // Animate ship
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var wantedRotation = new Vector3(vertical * 8f, 0f, -horizontal * 16f);
        _rotation = new Vector3(
            Mathf.Lerp(_rotation.x, wantedRotation.x, Time.deltaTime * (Mathf.Abs(vertical) + 0.5f) * 16f),
            0f,
            Mathf.Lerp(_rotation.z, wantedRotation.z, Time.deltaTime * (Mathf.Abs(horizontal) + 0.5f) * 8f)
        );
        transform.localRotation = Quaternion.Euler(_rotation);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _cameraOffset + (transform.position * 0.05f), Time.deltaTime * 2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        var oof = collision.gameObject.GetComponentInChildren<IPlayerOof>();
        if (oof != null)
        {
            var armorMultiplier = GetComponentInChildren<Hull>().ArmorMultiplier;
            Oxygen.RemoveOxygen(oof.Damage * armorMultiplier);
        }
    }

    public void SwapHull(int index)
    {
        if (CurrentHull != null)
        {
            GameObject.Destroy(CurrentHull.gameObject);
        }
        CurrentHull = GameObject.Instantiate(Hulls[index], Vector3.zero, Quaternion.identity, transform).GetComponent<Hull>();
        CurrentHull.transform.localPosition = Vector3.zero;
        CurrentHull.transform.localRotation = Quaternion.identity;
        CurrentHull.HullIndex = index;
        Oxygen.RemoveOxygen(CurrentHull.OxygenCost);
    }

    public int GetMaxHulls()
    {
        return Hulls.Length;
    }
}