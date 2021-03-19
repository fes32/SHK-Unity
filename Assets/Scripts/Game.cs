using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private EnemySpawner _spawner;

    private void OnEnable()
    {
        _spawner.AllEnemyDied += GameOver;
    }

    private void OnDisable()
    {
        _spawner.AllEnemyDied -= GameOver;
    }

    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }
}