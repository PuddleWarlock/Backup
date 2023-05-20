using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : MonoBehaviour
{
    [SerializeField] private int _damage;
    private float _pointspeed;
    private Rigidbody _point;
   

   

    private void Start()
    {
        _point = this.gameObject.GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        _pointspeed = _point.velocity.magnitude;
        
    }


    private void OnCollisionEnter(Collision collision)
    {   
        
        if (collision.gameObject.CompareTag("Enemy") && _pointspeed >= 1f)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage*_pointspeed/10);
        }
    }
    
   
}
