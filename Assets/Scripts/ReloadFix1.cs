using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReloadFix1 : MonoBehaviour
{
    private XRSocketInteractor _socketInteractor;
    private IXRSelectInteractable gunClip;
  
    public void SocketSwitchIn()
    {
        _socketInteractor = GetComponent<XRSocketInteractor>();
        gunClip = _socketInteractor.GetOldestInteractableSelected();
        gunClip.transform.gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.NameToLayer("Default");
    }

    public void SocketSwitchOut()
    {
        gunClip.transform.gameObject.GetComponent<XRGrabInteractable>().interactionLayers = InteractionLayerMask.NameToLayer("Pistol Clip");
    }
}
