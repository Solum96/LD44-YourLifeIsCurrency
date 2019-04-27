using UnityEngine;

public class DestroyIn : MonoBehaviour
{
    public float Delay;

    void Start()
    {
        Invoke("Kill", Delay);
    }

    void Kill()
    {
        GameObject.Destroy(gameObject);
    }
}