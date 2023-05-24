using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReloadFix : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor _socketInteractor;
    private GameObject _gunClip;
    private XRGrabInteractable _gunClipGrab;

    /*private void OnTriggerEnter(Collider other)
    {
        _gunClip = other.gameObject;
        _gunClipGrab = _gunClip.GetComponent<XRGrabInteractable>();
        _gunClipGrab.interactionLayers = InteractionLayerMask.NameToLayer("Default");
    }

    private void OnTriggerExit(Collider other)
    {
        _gunClipGrab.interactionLayers = InteractionLayerMask.NameToLayer("Pistol Clip");
    }*/
    public void Deploy()
    {
        if (_socketInteractor.GetOldestInteractableSelected() != null)
        {
            //print(_gunClipGrab.interactionLayers.value);
            _gunClip = _socketInteractor.GetOldestInteractableSelected().transform.gameObject;
            _gunClipGrab = _gunClip.GetComponent<XRGrabInteractable>();
            _gunClipGrab.interactionLayers = 3;
            
        }
    }
    
    public void DeployOut()
    {
        /*HoverExitEventArgs args = new HoverExitEventArgs();
        args.interactableObject.*/
        _gunClip = _socketInteractor.GetOldestInteractableSelected().transform.gameObject;
        _gunClipGrab = _gunClip.GetComponent<XRGrabInteractable>();
        //_socketInteractor.interactablesSelected.Clear();
        _gunClipGrab.interactionLayers = 2;
    }
}
