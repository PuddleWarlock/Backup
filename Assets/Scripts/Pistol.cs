using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Quaternion = System.Numerics.Quaternion;

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
    private AudioSource _shootsound;
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _noammo;
    [SerializeField] private Animator _pistolanimator;
    [SerializeField] private GameObject _muzzleFlash;
    private static readonly int shot = Animator.StringToHash("Shoot");
    private bool readyToShoot = true;
    private void Start()
    {
        _socketInteractor = gameObject.transform.Find("Magazine").GetComponent<XRSocketInteractor>();
        _shootsound = GetComponent<AudioSource>();
        CheckGunClip();
    }

    private void Update()
    {
        _muzzleFlash.transform.position =
            Vector3.MoveTowards(_muzzleFlash.transform.position, bulletspawn1.position, 1f);
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
        if (_hasGunClip)
        {
            if (_GunClip.ammoCount == 0)
            {
                _shootsound.clip = _noammo;
                _shootsound.PlayOneShot(_shootsound.clip);
                _GunClip.DropOnEmpty();
                return;
            }
            if (_GunClip.ammoCount > 0 && readyToShoot)
            {
                readyToShoot = false;
                _pistolanimator.SetTrigger(shot);
                _GunClip.ammoCount--;
                _shootsound.clip = _shoot;
                _shootsound.PlayOneShot(_shootsound.clip);
                _newBullet = Instantiate(bullet, bulletspawn1.position, bulletspawn1.rotation);
                _muzzleFlash.transform.position = bulletspawn1.position;
                _muzzleFlash.transform.rotation = new UnityEngine.Quaternion(-90,bulletspawn1.rotation.y,bulletspawn1.rotation.z,bulletspawn1.rotation.w);
                _muzzleFlash.transform.localScale = new Vector3(1f,1f,1f);
                Debug.Log(bulletspawn1.transform.rotation);
                /*_muzzleFlash.transform.rotation = bulletspawn1.rotation.;*/
                _muzzleFlash.GetComponent<ParticleSystem>().Play();
                _newBullet.GetComponent<Rigidbody>().velocity = bulletspeed * bulletspawn2.forward;
                Destroy(_newBullet,3f);
                RoundRemove();
            }
        }
        else
        {
            _shootsound.clip = _noammo;
            _shootsound.PlayOneShot(_shootsound.clip);
        }
    }

    private void RoundRemove()
    {
        Transform Round = gunClip.transform.Find($"PT-9M Pistol 9mm Bullet_High ({_GunClip.ammoCount})");
        Destroy(Round.gameObject);
    }

    private void ShootDelay()
    {
        readyToShoot = true;
        Debug.Log("works");
    }
}
