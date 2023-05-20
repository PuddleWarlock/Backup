using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class Shooting : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform bulletspawn1;
    [SerializeField] public Transform bulletspawn2;
    [SerializeField] public int bulletspeed;
    private GameObject _newBullet;

    public void Shoot()
    {
        _newBullet = Instantiate(bullet, bulletspawn1.position, bulletspawn1.rotation);
        _newBullet.GetComponent<Rigidbody>().velocity = bulletspeed * bulletspawn2.forward;
        Destroy(_newBullet,2);
    }
}
