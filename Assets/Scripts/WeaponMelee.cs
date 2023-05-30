using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : MonoBehaviour
{
    [SerializeField] private int _damage;
    private float _pointspeed;
    private Rigidbody _point;
    private AudioSource _hitsound;
    [SerializeField] private ParticleSystem _effect;
    private void Start()
    {
        _point = gameObject.GetComponentInChildren<Rigidbody>();
        _hitsound = gameObject.GetComponent<AudioSource>();
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
            foreach (ContactPoint contact in collision.contacts)
            {
                _hitsound.Play();
                _effect.transform.position = contact.point;
                _effect.Play();
                
            }
            
            
            /*_effect.transform.position = collision.gameObject.transform.position;*/
            /*_effect.transform.rotation = Quaternion.LookRotation();*/
            
            /*_effect.Play();
            if (_effect.isPlaying)
            {
                Debug.Log("work");
            }*/
        }
    }
}
