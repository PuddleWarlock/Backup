using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Features.Interactions;

public class PlayerInput : MonoBehaviour
{
    private const string GRIP = "Grip";
    private const string TRIGGER = "Trigger";
   [SerializeField] private Animator _animator;
   [SerializeField] private InputActionProperty _gripAction;
   [SerializeField] private InputActionProperty _activateAction;
   [SerializeField] private XRRayInteractor _xrRayInteractor;
   [SerializeField] private ActionBasedController _controller;

   /*private void Update()
   {
        var gripValue = _gripAction.action.ReadValue<float>();
        var actionValue = _activateAction.action.ReadValue<float>();

        _animator.SetFloat(GRIP, gripValue);
        _animator.SetFloat(TRIGGER, actionValue);

   }*/
   
   private float _timer;
   
   // Update is called once per frame
   void Update()
   {    
       /*var gripValue = _gripAction.action.ReadValue<float>();*/
       var actionValue = _activateAction.action.ReadValue<float>();
       _animator.SetFloat(TRIGGER, actionValue);
       if (_xrRayInteractor.selectActionTrigger == XRBaseControllerInteractor.InputTriggerType.Sticky)
       {
           _animator.SetFloat(GRIP, 1);
           if (!_xrRayInteractor.hasSelection)
           {
               _xrRayInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
           }
       }
       else
       {
           var gripValue = _gripAction.action.ReadValue<float>();
           _animator.SetFloat(GRIP, gripValue);
           
       }
       Switch();
   }

   private void Switch()
   {
       if (_controller.selectAction.action.phase == InputActionPhase.Performed)
       {
           _timer += Time.deltaTime;
           if (_timer > 0.3f)
           {
               _xrRayInteractor.selectActionTrigger = XRBaseControllerInteractor.InputTriggerType.StateChange;
               var gripValue = _gripAction.action.ReadValue<float>();
               _animator.SetFloat(GRIP, gripValue);
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
