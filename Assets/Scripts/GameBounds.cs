using UnityEngine;

public static class GameBounds
{
    const float xBounds = 4.5f;
    const float minBounds = -3f;
    const float maxBounds = 20f;
    const float playerMinBounds = 0;
    const float playerMaxBounds = 10;

    public static Vector3 ClampToBounds(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, -xBounds, xBounds);
        position.z = Mathf.Clamp(position.z, playerMinBounds, playerMaxBounds);
        return position;
    }
    public static Vector3 GetRandomSpawnPosition()
    {
        var x = Random.Range(-xBounds, xBounds);
        var z = maxBounds;
        return new Vector3(x, 0, z);
    }
    public static bool IsWithinBounds(Vector3 position)
    {
        return position.x >= -xBounds && position.x <= xBounds && position.z >= minBounds && position.z <= maxBounds;
    }
}