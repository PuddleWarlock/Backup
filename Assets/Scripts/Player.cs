using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (_health - damage <=  0) 
        {
            Debug.Log("Died");
        }

        _health -= damage;
    }
}
