using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Update = UnityEngine.PlayerLoop.Update;

public class InstantToVelocity : MonoBehaviour
{
    private float _timer;
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<XRGrabInteractable>().movementType = XRBaseInteractable.MovementType.VelocityTracking;
        if (collision.collider.CompareTag("Enemy"))
        {
            Invoke("Supp",0.1f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<XRGrabInteractable>().movementType = XRBaseInteractable.MovementType.Instantaneous;
    }

    private void Supp()
    {
        GetComponent<XRGrabInteractable>().movementType = XRBaseInteractable.MovementType.Instantaneous;
    }
}
