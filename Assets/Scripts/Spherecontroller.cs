using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spherecontroller : MonoBehaviour
{
    [SerializeField] private int _timeToDestroy;
    [SerializeField] private int _healhamount;
    private bool grabed = false;
    private Player _player;
    private float timer = 0;


    private void Start()
    {
       _player = FindObjectOfType<Player>();
    }

    public void SphereGrab()
    {
        grabed = true;
        timer = 0;
        var meow = gameObject.GetComponent<Rigidbody>();
        meow.constraints = RigidbodyConstraints.None;
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

     void Update()
     {
         DestroySphere();
         
     }
        
    
    public void DestroySphere()
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

    public void RepeatDestroy()
    {
        grabed = false;
        _timeToDestroy = 10;
        DestroySphere();
    }

    public void Health()
    {
        if (_player._health + _healhamount > 100)
        {
            _player._health = 100;
            Debug.Log("Здоровье максимальное");
        }
        else
        {
            _player._health += _healhamount;
        }
        Destroy(gameObject);
        
        
    }
}
