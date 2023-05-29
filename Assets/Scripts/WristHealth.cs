using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WristHealth : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _healthPercent;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void StatUpdate()
    {
        double percent = Math.Round(_player._health / _player._maxhealth, 2);
        _healthBar.fillAmount = (float)percent;
        _healthPercent.text = $"{percent*100}%";
    }
}
