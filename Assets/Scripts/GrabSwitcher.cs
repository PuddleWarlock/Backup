using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Features.Interactions;

public class GrabSwitcher : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _xrRayInteractor;
    [SerializeField] private ActionBasedController _controller;
    //private HTCViveControllerProfile.ViveController HR = new HTCViveControllerProfile.ViveController();
    private float _timer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Switch();
        
    }

    private void Switch()
    {
        if (_controller.selectAction.action.phase == InputActionPhase.Performed)
        {
            _timer += Time.deltaTime;
            if (_timer > 0.2f)
            {
                _xrRayInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
            }
            else
            {
                _xrRayInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.Sticky;
            }
        }
        else
        {
            _timer = 0;
        }
    }
}
