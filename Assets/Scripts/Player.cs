using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public double _health;
    [SerializeField] public int _experience = 0;
    [SerializeField] public Material win;
    [SerializeField] public  Material lose;
    public double _maxhealth;
    public int _enemiesKilled;
    public int _playerLvl = 1;
    private WristHealth _wristHealth;
    private ResultScreenController _resultscreen;
    private GameObject _resScreenObj;

    private void Start()
    {
        _wristHealth = FindObjectOfType<WristHealth>();
        _resultscreen = FindObjectOfType<ResultScreenController>();
        _resScreenObj = GameObject.Find("ResultScreen");
        _resScreenObj.SetActive(false);
        //_resultscreen.transform.parent.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <=  0)
        {
            _health = 0;
            EndGame(false);
        }
        _wristHealth.StatUpdate();
    }
    public void Heal(int _healhamount)
    {
        if (_health + _healhamount > _maxhealth)
        {
            _health = _maxhealth;
        }
        else
        {
            _health += _healhamount;
        }
        _wristHealth.StatUpdate();
    }

    public void GetExp(int experience)
    {
        _experience += experience;
        if (experience % 700 == 0)
        {
            _playerLvl++;
        }
    }
    public void EndGame(bool hasWon)
    {
        _resScreenObj.SetActive(true);
        if (hasWon)
        {
            RenderSettings.skybox = win;
            _resultscreen._gameResults.text = "Победа";
        }
        else
        {
            RenderSettings.skybox = lose;
            _resultscreen._gameResults.text = "Поражение";
        }
        Time.timeScale = 0;
        transform.position = new Vector3(0, gameObject.transform.position.y, 0);
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,-1));
        _resultscreen.UpdStats();
    }
}
