using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Pathfinding;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float _health;
    [SerializeField] public int _givenExperirence;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _addHealthBar;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private GameObject _expSphere;
    [SerializeField] private GameObject _ammo;
    [SerializeField] private AudioClip _goofyahhdeath;
    [SerializeField] private float _cooldownAttack;
    public float _healthMax = 100f;
    private GameObject _thisEnemy;
    private Player _player;
    private bool isDead = false;
    private float _timer;
    private bool statsIncreased;
    private AudioSource _deathsound;
    private EnemySpawner _enemySpawner;
    private SpawnOfWaves _spawnOfWaves;
    private EnemyAttack _enemyAttack;
    public bool CanBeAttacked { get; private set;}


    public void Start()
    {
        _enemyAttack = gameObject.GetComponent<EnemyAttack>();
        _spawnOfWaves = FindObjectOfType<SpawnOfWaves>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _player = FindObjectOfType<Player>();
        CanBeAttacked = true;
        _thisEnemy = gameObject;
        _deathsound = GetComponent<AudioSource>();
    }
    public void Update()
    {
        UpdateCoolDown();
        CheckWaveEnd(_spawnOfWaves.waveended);
    }

    public void TakeDamage(float damage)
    {
        if (_health - damage <=  0 && !isDead)
        {
            isDead = true;
            EnemyDeath();
            _enemySpawner.counter--;
            _player._enemiesKilled++;
        }
        if (CanBeAttacked)
        {
            _health -= damage;
            HealthBarUpdate();
            CanBeAttacked = false;
        }
    }

    private void CheckWaveEnd(bool wave)
    {
        if (wave)
        {
            if (statsIncreased) return;
            _enemyAttack._damage += _spawnOfWaves._dmgincr;
            _givenExperirence += _spawnOfWaves._perEnemyExpIncr;
            statsIncreased = true;
        }
    }

    private void HealthBarUpdate()
    {
        if(_healthBar != null)
        {
            _healthBar.fillAmount = _health / _healthMax;
            float duration = 0.75f;
            _addHealthBar.DOFillAmount(_health / _healthMax, duration);
        }
    }

    private void EnemyDeath()
    {
        /*_enemyAnimator.IsDead(true);*/
        /*_enemyAnimator.IsWalking(false);
        _enemyAnimator.IsRunning(false);*/
        _player.GetExp(_givenExperirence);
        /*_thisEnemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        _thisEnemy.GetComponent<EnemyAttack>()._damage = 0;*/
        /*_thisEnemy.GetComponent<MeshCollider>().enabled = false;*/
        Vector3 position = _thisEnemy.transform.position;
        position = new Vector3(position.x,0.5f,position.z);
        _thisEnemy.transform.position = position;
        _healthBar.enabled = false;
        _thisEnemy.GetComponentInChildren<Canvas>().enabled = false;
        StartCoroutine(Meow());
        _thisEnemy.GetComponent<Rigidbody>().isKinematic = true;
        ExpSphere(position);
        position.y = 0.7f;
        Instantiate(_ammo, position, _thisEnemy.transform.rotation);
        /*_thisEnemy.GetComponent<Seeker>().enabled = false;
        _thisEnemy.GetComponent<AIPath>().enabled = false;
        _thisEnemy.GetComponent<AIDestinationSetter>().enabled = false;*/
        _thisEnemy.GetComponent<EnemyAI>()._currentState = EnemyAI.EnemyStates.Death;

    }
    IEnumerator Meow()
    {
        _deathsound.clip = _goofyahhdeath;
        _deathsound.PlayOneShot(_deathsound.clip);
        yield return new WaitForSeconds(5);
        Destroy(_thisEnemy);
    }

    private void UpdateCoolDown()
    {
        if (CanBeAttacked)
        {
            return;
        }
        _timer += Time.deltaTime;
        if (_timer <_cooldownAttack) 
        {
            return;
        }
        CanBeAttacked = true;
        _timer = 0;
    }

    private void ExpSphere(Vector3 pos)
    {
        pos.y = 1.5f;
        Instantiate(_expSphere, pos, _thisEnemy.transform.rotation);
    }
}
