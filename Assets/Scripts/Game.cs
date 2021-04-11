using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private List<Enemy> _enemies;

    private int _liveEnemies;

    private void OnEnable()
    {
        _liveEnemies = _enemies.Count;

       foreach (var enemy in _enemies)
           enemy.Dying += EnemyDied;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.Dying -= EnemyDied;
    }

    private void EnemyDied(Enemy enemy)
    {
        _liveEnemies--;
        enemy.Dying -= EnemyDied;

        if (_liveEnemies<=0)
            GameOver();      
    }

    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }
}