using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float OxygenReward;
    public Vector2 Speed;
    private Rigidbody _rb;
    float _difficulty = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetDifficulty(float difficulty)
    {
        _difficulty = difficulty;
    }

    void Update()
    {
        var speed = Mathf.Lerp(Speed.x, Speed.y, _difficulty);
        _rb.MovePosition(_rb.position + Vector3.back * Time.deltaTime * speed);
        if (!GameBounds.IsWithinBounds(transform.position))
        {
            GameObject.Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Oxygen.AddOxygen(OxygenReward);
        GameObject.Destroy(gameObject);
    }
}