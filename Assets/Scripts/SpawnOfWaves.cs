using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOfWaves: MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private int _maxWaveCount;
    [SerializeField] private int _winWave;
    public int _waveNum = 1;
    private EndWaveText _endWaveText;
    private int _enemyIncrement = 1;
    public int _maxWaveCounter = 0;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _endWaveText = FindObjectOfType<EndWaveText>();
    }

    public void Update()
    {
        SpawnChange();
        if (_maxWaveCounter == _maxWaveCount && _enemySpawner.counter == 0)
        {
            _endWaveText.ShowEndText();
            if (_waveNum == _winWave)
            {
                _player.EndGame(true);
                return;
            }
            _waveNum++;
            StartCoroutine(Stop());
            _enemySpawner.counter = -1;
            StartCoroutine(NextWavePause());
        }
    }

    private void SpawnChange()
    {
        if (_maxWaveCounter < _maxWaveCount / 3)
        {
            _enemySpawner.SpawnPoint(0);
            _enemySpawner.SpawnEnemy();
        }
        else if (_maxWaveCounter >= _maxWaveCount/3 && _maxWaveCounter < (_maxWaveCount / 3) * 2)
        {
            _enemySpawner.SpawnPoint(1);
            _enemySpawner.SpawnEnemy();
        }
        else if (_maxWaveCounter >= (_maxWaveCount / 3)*2 && _maxWaveCounter < _maxWaveCount)
        {
            _enemySpawner.SpawnPoint(2);
            _enemySpawner.SpawnEnemy();
        }
    }

    IEnumerator NextWavePause()
    {
        yield return new WaitForSeconds(7);
        _enemySpawner.counter = 0;
        _maxWaveCount += _enemyIncrement;
        _maxWaveCounter = 0;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);
        _endWaveText.ShowNextText();
    }
}
