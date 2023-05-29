using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField] public GameObject _enemyPrefab;
    [SerializeField] public float _spawnInterval;

    [SerializeField] public int _minX;
    [SerializeField] public int _maxX;

    [SerializeField] public int _minY;
    [SerializeField] public int _maxY;

    [SerializeField] public float _height;
    
    [SerializeField] public int _maxspawn;

    private SpawnOfWaves _spawnOfWaves;

    private float _currentSpawnTimer;
    public int counter = 0;
    private SpawnOfWaves _spawnOfWaves1;

    private void Start()
    {
        _spawnOfWaves1 = FindObjectOfType<SpawnOfWaves>();
    }

    private void Update()
    {
        _spawnOfWaves = _spawnOfWaves1;
        _currentSpawnTimer += Time.deltaTime;
    }


    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_minX,_maxX), _height, Random.Range(_minY, _maxY));
        return startPos;
    }

    public void SpawnEnemy()
    {
        if(_currentSpawnTimer >= _spawnInterval)
        {
            if(counter < _maxspawn) 
            { 
                var enemyInstance = Instantiate(_enemyPrefab);
                counter += 1;
                var newPosition = GenerateStartPosition();
                enemyInstance.transform.position = newPosition;
                _currentSpawnTimer = 0;
                _spawnOfWaves._maxWaveCounter++;
            }
        }
        
    }

    public void SpawnPoint(int PosNum)
    {
        switch (PosNum)
        {
            case 0:
                _maxX = 15;
                _minX = 5;
                _maxY = -25;
                _minY = -20;
                break;
            case 1:
                _maxX = 15;
                _minX = 5;
                _maxY = 25;
                _minY = 20;
                break;
            case 2:
                _maxX = 25;
                _minX = 20;
                _maxY = 5;
                _minY = -5;
                break;
        }
    }
}