using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _Gravity = -9.81f;
    [SerializeField] private float _Mass = 10f;
    [SerializeField] private float _RaycastDistance = 3.1f;
    [SerializeField] private LayerMask _GroundLayer;

    private float _FallForce = 0f;    
    private RaycastHit _Hit;

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * _RaycastDistance, Color.black);
        if (Physics.Raycast(transform.position, Vector3.down, out _Hit, _RaycastDistance, _GroundLayer))
        {
            _FallForce = 0f;
            transform.position = new Vector3(transform.position.x, _Hit.point.y + transform.localScale.y / 2, transform.position.z);
        }
        else
        {
            _FallForce += _Gravity * _Mass * Time.deltaTime;
            transform.position += Vector3.up * _FallForce * Time.deltaTime;
        }
    }

    
}
