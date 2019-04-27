using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] Hulls;

    public float Speed = 5f;
    Rigidbody _rb;
    public Hull CurrentHull = null;

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