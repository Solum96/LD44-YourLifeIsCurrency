using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemySettings[] Enemies;
    public Vector2 SpawnTimer;
    public float DifficultyTime = 30f;
    public AnimationCurve DifficultyCurve;

    float _difficultyTimer = 0;
    float _timer;

    [System.Serializable]
    public struct EnemySettings
    {
        public GameObject Prefab;
        public float SpawnChance;
        public AnimationCurve SpawnCurve;
    }

    void Update()
    {
        _difficultyTimer += Time.deltaTime / DifficultyTime;

        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            var curveValue = DifficultyCurve.Evaluate(_difficultyTimer);
            var randomIndex = GetRandomEnemyToSpawn();
            var enemySettings = Enemies[randomIndex];
            var enemy = GameObject.Instantiate(enemySettings.Prefab, GameBounds.GetRandomSpawnPosition(), Quaternion.identity, transform).GetComponent<Enemy>();
            enemy.SetDifficulty(curveValue);
            var spawnTimer = Mathf.Lerp(SpawnTimer.x, SpawnTimer.y, curveValue);
            _timer = 1f / spawnTimer;
        }
    }

    int GetRandomEnemyToSpawn()
    {
        var spawnChances = new List<float>();

        foreach (var enemy in Enemies)
        {
            var chance = enemy.SpawnCurve.Evaluate(_difficultyTimer) * enemy.SpawnChance;
            spawnChances.Add(chance);
        }

        var sum = spawnChances.Sum();
        for (var i = 0; i < spawnChances.Count; ++i)
        {
            spawnChances[i] /= sum;
            if (i > 0)
            {
                spawnChances[i] += spawnChances[i - 1];
            }
        }

        var ran = Random.value;

        for (var i = 0; i < spawnChances.Count; ++i)
        {
            if (ran <= spawnChances[i])
            {
                return i;
            }
        }

        return 0;
    }
}