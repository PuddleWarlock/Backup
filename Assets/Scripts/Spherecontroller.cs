using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Spherecontroller : MonoBehaviour
{
    [SerializeField] private int _timeToDestroy;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private int _healhamount;
    [SerializeField] private Transform _leftAttach;
    [SerializeField] private Transform _rightAttach;
    /*private GameObject _left;
    private GameObject _right;*/
    private EffectsController _effectsController;
    private bool grabed = false;
    private Player _player;
    [SerializeField] private int _exp;
    private float timer = 0;
    private string currenthand;
    private ActionBasedController actualhand;
    
    private void Start()
    {
        _effectsController = FindObjectOfType<EffectsController>();
       _player = FindObjectOfType<Player>();
       _effect = _effectsController._healEffect;
       /*_right = GameObject.Find("RightHand Controller");
       _left = GameObject.Find("LeftHand Controller");
       leftcontroller = _left.GetComponent<ActionBasedController>();
       rightcontroller = _right.GetComponent<ActionBasedController>();*/

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
            _player.GetExp(_exp);
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

    public void AttachSwitch(HoverEnterEventArgs arg)
    {
        var _grab = gameObject.GetComponent<XRGrabInteractable>();
        if (arg.interactorObject.transform.name == "LeftHand Controller")
        {
            /*actualhand = arg.interactorObject.transform.GetComponent<ActionBasedController>();
            currenthand = arg.interactorObject.transform.name;*/
            _grab.attachTransform = _leftAttach;
        }
        else if (arg.interactorObject.transform.name == "RightHand Controller")
        {
            /*actualhand = arg.interactorObject.transform.GetComponent<ActionBasedController>();
            currenthand = arg.interactorObject.transform.name;*/
            _grab.attachTransform = _rightAttach;
        }
        
    }

    public void GetHealth()
    {
        _player.Heal(_healhamount);
        _effect.transform.position = transform.position;
        _effect.Play();
        Destroy(gameObject);
    }
    
    /*public void GetExp()
    {
        if (currenthand == "LeftHand Controller")
        {   
            if (actualhand.uiPressAction.action.phase == InputActionPhase.Performed)
            {
                print("meowLEFT");
            }
        }
        if (currenthand == "RightHand Controller")
        {   
            if (actualhand.activateAction.action.phase == InputActionPhase.Performed)
            {
                print("meowRIGHT");
            }
        }
    }*/
    
}
