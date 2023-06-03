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
    private Player _player;
    [SerializeField] private ParticleSystem _effect;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
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
            
            foreach (ContactPoint contact in collision.contacts)
            {
                if (collision.gameObject.GetComponent<Enemy>().CanBeAttacked)
                {
                    _hitsound.PlayOneShot(_hitsound.clip);
                    _effect.transform.position = contact.point;
                    _effect.Play();
                    collision.gameObject.GetComponent<Enemy>().TakeDamage(_player.damageMultiplier*_damage* (_pointspeed / 10));
                }
                
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
