using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public string _dName = "Easy";
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
