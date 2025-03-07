using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    [SerializeField] private Transform _BallSpawner;
    [SerializeField] private float _Coeff = 100;

    public float FinalScore;
    void Start()
    {
        _BallSpawner = transform.parent;
        EventBank.OnGameFinished.AddListener(CalculateScore);
    }

    private void CalculateScore()
    {
        float lDistance = 0;

        for (int i = 0; i < _BallSpawner.GetComponent<BallSpawner>().BallsNumber; i++)
        {
            lDistance = (transform.position - _BallSpawner.GetChild(i + 1).position).magnitude;
            FinalScore += _Coeff / lDistance;
        }

        EventBank.OnScoreCalculated.Invoke(Mathf.RoundToInt(FinalScore));
    }
}
