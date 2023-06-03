using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WristHealth : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _expBar;
    [SerializeField] private TextMeshProUGUI _healthPercent;
    [SerializeField] private TextMeshProUGUI _lvl;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void HealthStatUpdate()
    {
        double percent = Math.Round(_player._health / _player._maxhealth, 2);
        _healthBar.fillAmount = (float)percent;
        _healthPercent.text = $"{_player._health}/{_player._maxhealth}";
    }
    public void ExpStatUpdate()
    {
        double percent = Math.Round(_player._experience / (float)_player._nextLvlTreshhold, 2);
        _expBar.fillAmount = (float)percent;
        _lvl.text = $"{_player._playerLvl}";
    }
}
