using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

public class WristSwitcher : MonoBehaviour
{
    //[SerializeField] private GameObject _canvas;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        var rotationEulerAngles = _transform.rotation.eulerAngles;
        var state = rotationEulerAngles.z is > 45 and < 135 && rotationEulerAngles.x is > 270 or < 180;
        transform.GetChild(0).gameObject.SetActive(state);
    }
}
