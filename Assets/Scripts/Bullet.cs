using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _damage;
    private EffectsController _effectsController;

    private void Start()
    {
        _effectsController = FindObjectOfType<EffectsController>();
        _effect = _effectsController._bloodEffect;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
            foreach (ContactPoint contact in collision.contacts)
            {
                _effect.transform.position = contact.point;
                _effect.Play();
            }
        }

        if (!collision.gameObject.CompareTag("Pistol"))
        {
            Destroy(gameObject);
        }
    }
}
