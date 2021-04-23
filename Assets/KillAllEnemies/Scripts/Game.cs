using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private List<Enemy> _enemies;

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
            enemy.Dying += OnEnemyDied;
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemy.Dying -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDied;
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);

        if (_enemies.Count <= 0)
            GameOver();
    }

    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}