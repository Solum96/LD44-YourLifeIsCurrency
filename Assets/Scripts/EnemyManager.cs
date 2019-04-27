using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Prefab;
    public Vector2 SpawnTimer;
    public float DifficultyTime = 30f;
    public AnimationCurve DifficultyCurve;

    float _difficultyTimer = 0;
    float _timer;

    void Update()
    {
        _difficultyTimer += Time.deltaTime / DifficultyTime;

        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            var curveValue = DifficultyCurve.Evaluate(_difficultyTimer);
            var spawnTimer = Mathf.Lerp(SpawnTimer.x, SpawnTimer.y, curveValue);
            _timer = 1f / spawnTimer;
            var enemy = GameObject.Instantiate(Prefab, GameBounds.GetRandomSpawnPosition(), Quaternion.identity, transform).GetComponent<Enemy>();
            enemy.SetDifficulty(curveValue);
        }
    }
}