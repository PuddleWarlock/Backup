using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoBagController : MonoBehaviour
{
    private XRSocketInteractor _socketInteractor;
    private int _bagAmmoCount = 0;
    private int _clipAmmoCount;
    private List<int> clips;

    private void Start()
    {
        clips = new List<int>();
        _socketInteractor = gameObject.GetComponent<XRSocketInteractor>();
    }

    public void ClearSocket()
    {
        _socketInteractor.interactablesSelected.Clear();
    }
    public void AddMag()
    {
        _clipAmmoCount = _socketInteractor.GetOldestInteractableSelected().transform.GetComponent<GunClip>().ammoCount;
        clips.Add(_clipAmmoCount);

    }
    public void TakeMag()
    {
        clips.RemoveAt(clips.Count-1);
    }
}
