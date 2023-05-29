using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] public ParticleSystem _bloodEffect;
    [SerializeField] public ParticleSystem _healEffect;
    void Start()
    {
        /*Instantiate(_bloodEffect,new Vector3(0,0,0), new Quaternion());
        Instantiate(_healEffect,new Vector3(0,0,0), new Quaternion());*/
    }
}
