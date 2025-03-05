using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BallManager _BallManager;

    [SerializeField] private float _ThrowForce = 5f;
    [SerializeField] private float _BallRotationY = 0f;
    void Start()
    {
        _BallManager.Velocity = transform.forward * _ThrowForce;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position += _BallManager.Velocity * Time.deltaTime;
    }

    private void Input()
    {

    }
}
