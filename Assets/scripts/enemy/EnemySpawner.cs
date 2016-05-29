/*
 * By Floris de Haan @ June 2015
 * Free to use for all purposes.
 */

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Multifunctional enemy spawner class.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    #region Vars

    [SerializeField]
    private EnemySpawnInfo[] _enemySpawnInfo;
    [SerializeField]
    private Transform _enemyParent;
    [SerializeField]
    private Transform[] _enemySpawnPositions;

    private List<GameObject> _enemies;

    [SerializeField]
    private float _spawnInterval = 1f;
    private float _spawnIntervalDecreasement = 0.01f;
    private float _spawnIntervalMin = 0.2f;
    private float _spawnTimer = 0f;

    [SerializeField]
    private int _maxEnemies = 20;

    #endregion

    #region Methods

    private void Start()
    {
        _enemies = new List<GameObject>();
    }

    private void Update()
    {
        if (_spawnTimer < _spawnInterval)
        {
            _spawnTimer += Time.deltaTime;

            if (_enemies.Count < _maxEnemies && _spawnTimer > _spawnInterval)
            {
                _spawnTimer -= _spawnInterval;
                SpawnNext();
                if (_spawnInterval > _spawnIntervalMin) _spawnInterval -= _spawnIntervalDecreasement;
            }
        }
    }

    private void SpawnNext()
    {
        // Random percentage
        int rnd = Random.Range(0, 99);
        
        foreach (EnemySpawnInfo item in _enemySpawnInfo)
        {
            // Check if random is in chance
            if (rnd < item.chance)
            {
                SpawnEnemy(item.Enemy);
                break;
            }

            // Fix chance for next item
            rnd -= (int)item.chance;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        // Random spawn pos
        Transform rndSpawn = _enemySpawnPositions[Random.Range(0, _enemySpawnPositions.Length)];

        // Spawn
        GameObject newEnemy = (GameObject)Instantiate(enemy, rndSpawn.position, rndSpawn.rotation);
        if (_enemyParent != null) newEnemy.transform.parent = _enemyParent;
        _enemies.Add(newEnemy);

        // Wait untill dead
        EnemyHandler enemyHandler = newEnemy.GetComponent<EnemyHandler>();
        enemyHandler.GetDamageEvent += () => {
            RemoveEnemy(newEnemy);
        };
    }

    private void RemoveEnemy(GameObject enemy)
    {
        _enemies.Remove(enemy);

        // Reset timer to spawn next if already stopped
        if (_spawnTimer >= _spawnInterval) _spawnTimer = 0f;
    }

    #endregion

    #region Properties

    #endregion
}

[System.Serializable]
public struct EnemySpawnInfo
{
    public GameObject Enemy; // Prefab
    public short chance; // (0 to 99) %
}