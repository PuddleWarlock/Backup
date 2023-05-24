using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] public int _experience = 0;
    public int _enemiesKilled;
    public int _playerLvl = 1;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <=  0)
        {
            _health = 0;
            print("Died");
        }
    }
}
