using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;


public class EndWaveText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private float _appearTime;
    private int _waveNum;
    private SpawnOfWaves _spawnOfWaves;
    private void Start()
    {
        _spawnOfWaves = FindObjectOfType<SpawnOfWaves>();
    }

    public void ShowEndText()
    {
        _waveNum = _spawnOfWaves._waveNum;
        _text.DOFade(0, 0);
        _text.text = $"Волна {_waveNum} пройдена\nПриготовтесь к следующей волне";
        _text.DOFade(1, 2);
        StartCoroutine(Timer(2));
    }
    public void ShowNextText()
    {
        _waveNum = _spawnOfWaves._waveNum;
        _text.DOFade(0, 0);
        _text.text = $"Волна {_waveNum}";
        _text.DOFade(1, 2);
        StartCoroutine(Timer(2));
    }

    IEnumerator Timer(int time)
    {
        yield return new WaitForSeconds(time);
        _text.DOFade(0, 2);
    }
}
