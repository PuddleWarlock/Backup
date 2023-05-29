using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public double _health;
    [SerializeField] public int _experience = 0;
    public double _maxhealth;
    public int _enemiesKilled;
    public int _playerLvl = 1;
    private WristHealth _wristHealth;

    private void Start()
    {
        _wristHealth = FindObjectOfType<WristHealth>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <=  0)
        {
            _health = 0;
            print("Died");
        }
        _wristHealth.StatUpdate();
    }
    public void Heal(int _healhamount)
    {
        if (_health + _healhamount > _maxhealth)
        {
            _health = _maxhealth;
        }
        else
        {
            _health += _healhamount;
        }
        _wristHealth.StatUpdate();
    }
}
