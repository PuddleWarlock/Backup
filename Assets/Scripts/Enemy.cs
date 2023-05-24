using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _givenExperirence;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _addHealthBar;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private GameObject _expSphere;
    private float _healthMax = 100f;
    private GameObject _thisEnemy;
    private Player _player;
    private float _timer;
    public bool CanBeAttacked { get; private set;}
    
    [SerializeField] private float _cooldownAttack;

    
    public void Start()
    {
        _player = FindObjectOfType<Player>();
        CanBeAttacked = true;
        _thisEnemy = gameObject;
    }
    public void Update()
    {
        UpdateCoolDown();
    }

    public void TakeDamage(float damage)
    {
        if (_health - damage <=  0)
        {
            EnemyDeath();
        }
        if (CanBeAttacked)
        {
            _health -= damage;
            HealthBarUpdate();
            CanBeAttacked = false;
        }
    }

    private void HealthBarUpdate()
    {
        _healthBar.fillAmount = _health / _healthMax;
        float duration = 0.75f;
        _addHealthBar.DOFillAmount( _health / _healthMax, duration);
    }

    private void EnemyDeath()
    {
        _enemyAnimator.IsDead(true);
        _enemyAnimator.IsWalking(false);
        _enemyAnimator.IsRunning(false);
        _player._experience += _givenExperirence;
        _thisEnemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        _thisEnemy.GetComponent<EnemyAttack>()._damage = 0;
        _thisEnemy.GetComponent<MeshCollider>().enabled = false;
        Vector3 position = _thisEnemy.transform.position;
        position = new Vector3(position.x,0.5f,position.z);
        _thisEnemy.transform.position = position;
        _healthBar.enabled = false;
        _thisEnemy.GetComponentInChildren<Canvas>().enabled = false;
        StartCoroutine(Meow());
        _thisEnemy.GetComponent<Rigidbody>().isKinematic = true;
        ExpSphere(position);
        
    }

    //dsdsdsdsdsdsdsdsgsa[gqg[2qrglp2rrplgh,[lrph
    IEnumerator Meow()
    {
       yield return new WaitForSeconds(5);
       Destroy(_thisEnemy);
       FindObjectOfType<EnemySpawner>().counter--;
       
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
