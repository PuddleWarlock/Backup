using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject _enemyPrefab;
    /*[SerializeField] public GameObject _enemyPrefab2;
    [SerializeField] public GameObject _enemyPrefab3;
    [SerializeField] public GameObject _enemyPrefab4;*/
    [SerializeField] public float _spawnInterval;
    [SerializeField] public int _minX;
    [SerializeField] public int _maxX;
    [SerializeField] public int _minY;
    [SerializeField] public int _maxY;
    [SerializeField] public float _height;
    [SerializeField] public int _maxspawn;
    private SpawnOfWaves _spawnOfWaves;
    private Data _data;
    //private GameObject enemyInstance;
    private float _currentSpawnTimer;
    public int counter = 0;
    private SpawnOfWaves _spawnOfWaves1;

    private void Start()
    {
        /*_data = FindObjectOfType<Data>();*/
        /*_spawnOfWaves1 = FindObjectOfType<SpawnOfWaves>();*/
        _spawnOfWaves = FindObjectOfType<SpawnOfWaves>();
    }

    private void Update()
    {
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
                /*switch (_data._dName)
                {
                    case "Easy":
                        enemyInstance = Instantiate(_enemyPrefab);
                        break;
                    case "Medium":
                        enemyInstance = Instantiate(_enemyPrefab2);
                        break;
                    case "Hard":
                        enemyInstance = Instantiate(_enemyPrefab3);
                        break;
                    case "Insane":
                        enemyInstance = Instantiate(_enemyPrefab4);
                        break;
                }*/
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