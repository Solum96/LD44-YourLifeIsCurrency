using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 1f;
   

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * Speed;
        if (!GameBounds.IsWithinBounds(transform.position))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
