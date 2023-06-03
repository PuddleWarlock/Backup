using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class ResultScreenController : MonoBehaviour
{
    private Player _player;
    [SerializeField] public TextMeshProUGUI _gameResults;
    [SerializeField] public TextMeshProUGUI _lvl;
    [SerializeField] public TextMeshProUGUI _kills;
    [SerializeField] public TextMeshProUGUI _time;
    private Stopwatch timer;
    private void Start()
    {
        timer = new Stopwatch();
        timer.Start();
        _player = FindObjectOfType<Player>();
    }

    public void UpdStats()
    {
        _lvl.text = _player._playerLvl.ToString();
        _kills.text = _player._enemiesKilled.ToString();
        timer.Stop();
        var minutes = timer.ElapsedMilliseconds / 60000;
        var seconds = (timer.ElapsedMilliseconds - minutes * 60000) / 1000;
        _time.text = $"{minutes}m {seconds}s";
    }
}
