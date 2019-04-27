using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    public Vector2 AnimationSpeed = Vector2.zero;

    Vector3 _animationVector;
    float _animationSpeed;

    void Start()
    {
        transform.localRotation = Random.rotation;
        _animationVector = new Vector3(Random.value, Random.value, Random.value);
        _animationSpeed = Random.Range(AnimationSpeed.x, AnimationSpeed.y);
    }

    void Update()
    {
        transform.Rotate(_animationVector * _animationSpeed * Time.deltaTime, Space.Self);
    }
}