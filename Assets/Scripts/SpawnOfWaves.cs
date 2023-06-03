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
    public int _maxWaveCounter = 1;
    private Player _player;
    public bool waveended;
    private Enemy _enemy;
    private Data _data;
    public int _dmgincr;
    private EnemyAttack _dmg;
    public int _perEnemyExpIncr;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _endWaveText = FindObjectOfType<EndWaveText>();
        _enemy = FindObjectOfType<Enemy>();
        _data = FindObjectOfType<Data>();
        _dmg = FindObjectOfType<EnemyAttack>();
        /*DiffSettings();*/
    }

    public void Update()
    {   
        SpawnChange();
        if (_maxWaveCounter == _maxWaveCount && _enemySpawner.counter == 0)
        {
            waveended = true;
            if (_waveNum == _winWave)
            {
                _player.EndGame(true);
                return;
            }
            _endWaveText.ShowEndText();
            _waveNum++;
            //_enemy._givenExperirence += _perEnemyExpIncr;
            /*_dmg._damage += _dmgincr;*/
            StartCoroutine(Stop());
            _enemySpawner.counter = -1;
            StartCoroutine(NextWavePause());
        }
    }

    private void SpawnChange()
    {
        if(_maxWaveCounter < _maxWaveCount)
        {
            if (_maxWaveCounter % 3 == 1)
            {
                _enemySpawner.SpawnPoint(0);
                _enemySpawner.SpawnEnemy();
            }
            else if (_maxWaveCounter % 3 == 2 ||_maxWaveCounter % 3 == 0)
            {
                _enemySpawner.SpawnPoint(1);
                _enemySpawner.SpawnEnemy();
            }
            else if (_maxWaveCounter % 3 == 3)
            {
                _enemySpawner.SpawnPoint(2);
                _enemySpawner.SpawnEnemy();
            }
        }
    }

    IEnumerator NextWavePause()
    {
        yield return new WaitForSeconds(7);
        _enemySpawner.counter = 0;
        waveended = false;
        _maxWaveCount += _enemyIncrement;
        _maxWaveCounter = 0;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);
        _endWaveText.ShowNextText();
    }

    /*public void DiffSettings()
    {
        switch(_data._dName)
        {
            case "Easy":
                _dmgincr = 2;
                _winWave = 3;
                _enemyIncrement = 1;
                _perEnemyExpIncr = 10;
                break;
            
            case "Medium":
                _dmgincr = 4;
                _winWave = 5;
                _enemyIncrement = 2;
                _perEnemyExpIncr = 20;
                break;
            
            case "Hard":
                _dmgincr = 6;
                _winWave = 7;
                _enemyIncrement = 3;
                _perEnemyExpIncr = 30;
                
                break;
            
            case "Insane":
                _dmgincr = 10;
                _winWave = 10;
                _enemyIncrement = 4;
                _perEnemyExpIncr = 40;
                break;
        }
    }*/
}
