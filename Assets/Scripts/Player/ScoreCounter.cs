using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;

    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _secondsToAddScore;
    [SerializeField] private int _scoreToRiseSpeed;

    private WaitForSeconds _waitForUpdateScore;

    private void Awake()
    {
        _waitForUpdateScore = new WaitForSeconds(_secondsToAddScore);
    }

    public bool IsSpeedRising { get; private set; }

    private int _score;

    private void Start()
    {
        ScoreChanged?.Invoke(_score);
        StartCoroutine(UpdateScore());
    }
    private IEnumerator UpdateScore()
    {
        while(Time.timeScale != 0)
        {
            if (_score % _scoreToRiseSpeed == 0 && _score != 0)
            {
                Time.timeScale += 0.2f;
            }

            _score += _scoreToAdd;
            ScoreChanged?.Invoke(_score);

            yield return _waitForUpdateScore;
        }
    }
}
