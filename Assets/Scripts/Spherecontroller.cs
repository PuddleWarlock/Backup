using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Spherecontroller : MonoBehaviour
{
    [SerializeField] private int _timeToDestroy;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private int _healhamount;
    private EffectsController _effectsController;
    private bool grabed = false;
    private Player _player;
    private float timer = 0;
    private void Start()
    {
       _player = FindObjectOfType<Player>();
       _effect = _effectsController._healEffect;
    }
    void Update()
    {
        DestroySphere();
    }

    private void DestroySphere()
    {
        if (!grabed)
        {
            timer += Time.deltaTime;
        }
        if (grabed == false && timer>_timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
    public void SphereGrab()
    {
        grabed = true;
        timer = 0;
        var meow = gameObject.GetComponent<Rigidbody>();
        meow.constraints = RigidbodyConstraints.None;
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
    public void RepeatDestroy()
    {
        grabed = false;
        _timeToDestroy = 10;
    }

    public void GetHealth()
    {
        _player.Heal(_healhamount);
        _effect.transform.position = transform.position;
        _effect.Play();
        Destroy(gameObject);
    }
}
