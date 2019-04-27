using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Prefab;

    void Start()
    {
        InvokeRepeating("Spawn", 1, 5);
    }

    // Update is called once per frame
    void Spawn()
    {
        GameObject.Instantiate(Prefab,GameBounds.GetRandomSpawnPosition(), Quaternion.identity, transform);
    }
}
