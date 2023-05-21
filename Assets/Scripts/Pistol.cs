using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    
    [Header("Shooting")]
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform bulletspawn1;
    [SerializeField] public Transform bulletspawn2;
    [SerializeField] public int bulletspeed;
    private XRSocketInteractor _socketInteractor;
    private GameObject _newBullet;
    private IXRSelectInteractable gunClip;
    private bool _hasGunClip;
    private GunClip _GunClip;


    private void Start()
    {
        _socketInteractor = gameObject.transform.Find("Magazine").GetComponent<XRSocketInteractor>();
        CheckGunClip();
    }
    
    public void CheckGunClip()
    {
        gunClip = _socketInteractor.GetOldestInteractableSelected();
        if (gunClip != null)
        {
            _hasGunClip = true;
            _GunClip = gunClip.transform.gameObject.GetComponent<GunClip>();
        }
        else
        {
            _hasGunClip = false;
        }
    }

    public void Shoot()
    {
        if (_hasGunClip && _GunClip.ammoCount != 0)
        {
            _GunClip.ammoCount--;
            if (_GunClip.ammoCount >= 0)
            {
                RoundRemove();
            }
            _newBullet = Instantiate(bullet, bulletspawn1.position, bulletspawn1.rotation);
            _newBullet.GetComponent<Rigidbody>().velocity = bulletspeed * bulletspawn2.forward;
            Destroy(_newBullet,2);
        }
    }

    private void RoundRemove()
    {
        Transform Round = gunClip.transform.Find($"PT-9M Pistol 9mm Bullet_High ({_GunClip.ammoCount})");
        Destroy(Round.gameObject);
    }
}
