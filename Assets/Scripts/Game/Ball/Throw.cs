using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _ThrowForce = 5f;
    [SerializeField] private float _BallRotationY = 0f;
    public Vector3 Velocity;
    public float GroundFriction = 1;
    void Start()
    {
        Velocity = transform.forward * _ThrowForce;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Velocity.z *= GroundFriction;
        transform.position += Velocity * Time.deltaTime;
    }

    private void Input()
    {

    }
}
