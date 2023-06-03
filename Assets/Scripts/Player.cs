using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    [SerializeField] public double _health;
    [SerializeField] public int _experience = 0;
    [SerializeField] public int _nextLvlTreshhold = 200;
    [SerializeField] public Material win;
    [SerializeField] public  Material lose;
    [SerializeField] public  XRRayInteractor _leftController;
    [SerializeField] public  XRRayInteractor _righttController;
    public double _maxhealth;
    public int _enemiesKilled;
    public int _playerLvl = 1;
    private WristHealth _wristHealth;
    private AudioSource _lvlUpSound;
    private EffectsController _effectsController;
    private ParticleSystem _lvlUpEffect;
    public float damageMultiplier = 1f;
    private ResultScreenController _resultscreen;
    private GameObject _resScreenObj;
    public SpawnOfWaves startgamescript;

    private void Start()
    {
        _lvlUpSound = GetComponent<AudioSource>();
        _effectsController = FindObjectOfType<EffectsController>();
        _lvlUpEffect = _effectsController._playerLvlUp;
        _wristHealth = FindObjectOfType<WristHealth>();
        _resultscreen = FindObjectOfType<ResultScreenController>();
        _resScreenObj = GameObject.Find("ResultScreen");
        if (_resScreenObj != null)
        {
            _resScreenObj.SetActive(false);
        }
        //_resultscreen.transform.parent.gameObject.SetActive(false);
        startgamescript = FindObjectOfType<SpawnOfWaves>();
        if (startgamescript != null)
        {
            startgamescript.enabled = false;
        }
    }

    private void Update()
    {
        if (_lvlUpEffect != null)
        {
            _lvlUpEffect.transform.position = Vector3.MoveTowards(_lvlUpEffect.transform.position, transform.position, 1f);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <=  0)
        {
            _health = 0;
            EndGame(false);
        }
        _wristHealth.HealthStatUpdate();
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
        _wristHealth.HealthStatUpdate();
    }

    public void GetExp(int experience)
    {
        _experience += experience;
        if (_experience > _nextLvlTreshhold)
        {
            _lvlUpSound.PlayOneShot(_lvlUpSound.clip);
            _lvlUpEffect.Play();
            damageMultiplier += 0.1f;
            _playerLvl++;
            _maxhealth += 25;
            _health = _maxhealth;
            _experience -= _nextLvlTreshhold;
        }
        _wristHealth.ExpStatUpdate();
        _wristHealth.HealthStatUpdate();
    }
    public void EndGame(bool hasWon)
    {
        EnableHoverActivate();
        _resScreenObj.SetActive(true);
        if (hasWon)
        {
            RenderSettings.skybox = win;
            _resultscreen._gameResults.text = "Victory";
            _resultscreen._gameResults.color = Color.green;
        }
        else
        {
            RenderSettings.skybox = lose;
            _resultscreen._gameResults.text = "Defeat";
            _resultscreen._gameResults.color = Color.red;
        }
        Time.timeScale = 0;
        Vector3 targetPos = new Vector3(0, gameObject.transform.position.y, 0);
        transform.position = targetPos;
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,-1));
        _resultscreen.UpdStats();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("StartGame")) return;
        startgamescript.enabled = true;
        FindObjectOfType<EndWaveText>().ShowNextText();

    }

    private void EnableHoverActivate()
    {
        _leftController.allowHoveredActivate = true;
        _righttController.allowHoveredActivate = true;
    }
    
}
