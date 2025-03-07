using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    [Space(10), Header("Gameobjects")]
    [SerializeField] private BallManager _BallManager;

    [Space(10), Header("Parameters")]
    [SerializeField] public float ThrowForce = 5f;
    [SerializeField] private float _BallRotationY = 0f;
    [SerializeField] private float _BallRotationX = 0f;
    [SerializeField] private float _RotationSpeed = 20;

    private const string X_INPUT = "Horizontal";
    private const string Y_INPUT = "Vertical";

    // Update is called once per frame
    void FixedUpdate()
    {
        InputControl();

        if (!_BallManager.Throwned) return;
        transform.position += _BallManager.Velocity * Time.deltaTime;
    }

    private void InputControl()
    {
        if (_BallManager.Throwned) return ;

        _BallRotationY += Input.GetAxis(X_INPUT) * _RotationSpeed * Time.deltaTime;
        _BallRotationX += Input.GetAxis(Y_INPUT) * _RotationSpeed * Time.deltaTime;
        _BallRotationX = Mathf.Clamp(_BallRotationX, -40f, -25f);

        ThrowForce += Input.GetAxis(Y_INPUT);
        ThrowForce = Mathf.Clamp(ThrowForce, 20f, 100f);

        transform.rotation = Quaternion.Euler(_BallRotationX, _BallRotationY, 0);

        if(Input.GetKey(KeyCode.Space))
        {
            _BallManager.Velocity = transform.forward * ThrowForce;
            
            _BallManager.Throwned = true;

        }
    }
}
