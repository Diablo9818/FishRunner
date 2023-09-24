using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;

    [SerializeField] private int _scoreToAdd;
    [SerializeField] private int _secondsToAddScore;

    private int _score;
    private float _elapsedTime = 0;


    private void Start()
    {
        ScoreChanged?.Invoke(_score);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsToAddScore)
        {
            UpdateScore();
            _elapsedTime =0;
        }
    }

    private void UpdateScore()
    {
        _score += _scoreToAdd;
        ScoreChanged?.Invoke(_score);
    }
}
