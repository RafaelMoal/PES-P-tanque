using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _Ball;
    [SerializeField] private GameObject _Cochonnet;

    [SerializeField] public int BallsNumber = 3;
    public int BallsCount = 0;
    void Start()
    {
        EventBank.OnThrowFinished.AddListener(SpawnNewBall);

        if (transform.childCount < 1)
        {
            SpawnCochonnet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCochonnet()
    {
        Instantiate(_Cochonnet, transform);
    }
    private void SpawnNewBall()
    {
        if (BallsCount > BallsNumber - 1)
        {
            EventBank.OnGameFinished.Invoke();
            return;
        }
        Instantiate(_Ball, transform); 
        BallsCount++;
    }

    private void OnDisable()
    {
        EventBank.OnThrowFinished.RemoveAllListeners();
    }
}
