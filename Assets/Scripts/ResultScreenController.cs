using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScreenController : MonoBehaviour
{
    private Player _player;
    [SerializeField] public TextMeshProUGUI _gameResults;
    [SerializeField] public TextMeshProUGUI _lvl;
    [SerializeField] public TextMeshProUGUI _kills;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void UpdStats()
    {
        _lvl.text = _player._playerLvl.ToString();
        _kills.text = _player._enemiesKilled.ToString();
    }
}
