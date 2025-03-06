using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallManager _BallManager;

    [SerializeField] private float _RaycastDistance = 2;
    [SerializeField] private float _RaycastOffset = 0.05f;
    [SerializeField] private float _BounceFactor = 0.8f;

    private RaycastHit _Hit;
    private GameObject _HitObject;
    private MeshRenderer _Renderer;
    private float _MeshRadius;
    private Vector3 _GroundRaycastOrigin;

    private const string WALL_TAG = "Wall";
    
    void Start()
    {
        _Renderer = GetComponent<MeshRenderer>();
        _MeshRadius = _Renderer.bounds.extents.x;
        _GroundRaycastOrigin = transform.position - new Vector3(0, _MeshRadius - _RaycastOffset, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastCollision();

        if (_BallManager.Throwned && _BallManager.Velocity == Vector3.zero)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            enabled = false;
            GetComponent<Throw>().enabled = false;
            GetComponent<BallGravity>().enabled = false;
        }
    }

    private void RaycastCollision()
    {
        if (Physics.Raycast(transform.position, _BallManager.Velocity, out _Hit, _RaycastDistance))
        {
            _HitObject = _Hit.collider.gameObject;

            if (_HitObject.CompareTag(WALL_TAG))
            {
                WallBounceHandler(_Hit);
            }
        }
    }

    private void WallBounceHandler(RaycastHit pHit)
    {
        Vector3 lReflectedVelocity = Vector3.Reflect(_BallManager.Velocity, pHit.normal);
        _BallManager.Velocity = lReflectedVelocity * _BounceFactor;
        transform.position = pHit.point + pHit.normal * 0.01f;
    }
}
