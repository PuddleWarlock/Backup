using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunClip : MonoBehaviour
{
    public int ammoCount;
    private XRGrabInteractable _grabInteractable;

    private void Start()
    {
        _grabInteractable = gameObject.GetComponent<XRGrabInteractable>();
    }

    public void SnapSwap(SelectEnterEventArgs args)
    {
        if (args.interactorObject.ToString() == "Socket (UnityEngine.XR.Interaction.Toolkit.XRSocketInteractor)")
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void DropOnEmpty()
    {
        _grabInteractable.interactionLayers = InteractionLayerMask.NameToLayer("Used Pistol Clip");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor") && ammoCount == 0)
            Destroy(gameObject);
    }
}
