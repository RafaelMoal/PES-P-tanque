using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _BallFactory;

    
    void Start()
    {
        EventBank.OnThrowFinished.AddListener(SpawnNewBall);

        if (transform.childCount < 1)
        {
            SpawnNewBall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnNewBall()
    {
        Instantiate(_BallFactory, transform);
    }

    private void OnDisable()
    {
        EventBank.OnThrowFinished.RemoveAllListeners();
    }
}
