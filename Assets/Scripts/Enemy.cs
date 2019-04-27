using UnityEngine;

public class Enemy : MonoBehaviour, IDamageDealer
{
    public float OxygenReward;
    public float OxygenDamage;
    public Vector2 Speed;
    public GameObject DestructionPrefab = null;

    Rigidbody _rb;
    float _difficulty = 0f;
    Hull _hull;

    public float Damage { get { return OxygenDamage; } }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _hull = GetComponent<Hull>();
    }

    public void SetDifficulty(float difficulty)
    {
        _difficulty = difficulty;

        if (_difficulty > 0.25f)
        {
            _hull.Fire(true);
        }
    }

    void Update()
    {
        var speed = Mathf.Lerp(Speed.x, Speed.y, _difficulty);
        _rb.MovePosition(_rb.position + Vector3.back * Time.deltaTime * speed);
        if (!GameBounds.IsWithinBounds(transform.position))
        {
            GameObject.Destroy(gameObject);
        }

        //_hull.Fire(true); // TODO: FIRE
    }
    void OnCollisionEnter(Collision collision)
    {
        var damageDealer = collision.gameObject.GetComponentInChildren<IDamageDealer>();
        if (damageDealer != null)
        {
            Oxygen.AddOxygen(OxygenReward * damageDealer.Damage);
        }

        if (DestructionPrefab != null)
        {
            GameObject.Instantiate(DestructionPrefab, transform.position, Quaternion.identity);
        }

        GameObject.Destroy(gameObject);
    }
}