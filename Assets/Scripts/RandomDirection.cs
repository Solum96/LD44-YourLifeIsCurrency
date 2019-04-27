using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    void Start()
    {
        transform.localRotation = Random.rotation;
    }
}