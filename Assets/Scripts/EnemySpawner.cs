using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _countEnemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    private int _countDiedEnemies=0;

    public event UnityAction AllEnemyDied;

    private void OnEnable()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int _currentSpawnPointIndex = 0;

        for (int i = 0; i < _countEnemy; i++)
        {
            Enemy spawnedEnemy = Instantiate(_enemyPrefab, transform);

            spawnedEnemy.Spawn(_player);
            spawnedEnemy.transform.position = _spawnPoints[_currentSpawnPointIndex].position;
            spawnedEnemy.Dying += EnemyDying;

            _currentSpawnPointIndex++;

            if (_currentSpawnPointIndex >= _spawnPoints.Length)
                _currentSpawnPointIndex = 0;
        }
    }

    private void EnemyDying(Enemy enemy)
    {
        enemy.Dying -= EnemyDying;
        Destroy(enemy.gameObject);
        _countDiedEnemies++;

        if (_countEnemy == _countDiedEnemies)
            AllEnemyDied?.Invoke();
    }
}