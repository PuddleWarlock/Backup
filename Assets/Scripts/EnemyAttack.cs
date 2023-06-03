using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] public int _damage;
    [SerializeField] private float _cooldownAttack;
    private AudioSource _attacksound;
    [SerializeField] private AudioClip _attack;

    private float _timer;
    public bool CanAttack { get; private set;}

    private Player _player;

    public float AttackRange => _attackRange;


    private void Start()
    {
        _attacksound = GetComponent<AudioSource>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        UpdateCoolDown();
    }

    public void TryAttackPlayer()
    {
        _attacksound.clip = _attack;
        _attacksound.PlayOneShot(_attacksound.clip);
        _player.TakeDamage(_damage);
        CanAttack = false;
    }

    private void UpdateCoolDown()
    {
        if (CanAttack)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer <_cooldownAttack) 
        {
            return;
        }

        CanAttack = true;
        _timer = 0;
    }
}

