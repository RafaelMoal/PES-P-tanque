using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [Space(10), Header("Gameobjects")]
    [SerializeField] private BallManager _BallManager;
    [SerializeField] private Throw _Throw;
    [SerializeField] private BallGravity _BallGravity;

    [Space(10), Header("Trajectory Settings")]
    [SerializeField] int _MaxSteps = 30;
    [SerializeField] float _TimeSteps = 0.1f;
    [SerializeField] LayerMask _GroundLayer;

    private LineRenderer _LineRenderer;

    private Vector3[] _TrajectoryPoints;
    private Vector3 _StartPosition;
    private Vector3 _StartVelocity;
    private float _Time;
    private Vector3 _Point;


    void Start()
    {
        _LineRenderer = GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if (_BallManager.Throwned) return;       
        DrawTrajectory();
    }

    private void DrawTrajectory()
    {
        _TrajectoryPoints = new Vector3[_MaxSteps];
        _StartPosition = transform.position;
        _StartVelocity = transform.forward * _Throw.ThrowForce;

        Debug.Log(_BallManager.Velocity + " - " + _StartVelocity);

        for (int i = 0; i < _MaxSteps; i++)
        {
            _Time = i * _TimeSteps;
            
            _Point = _StartPosition + _StartVelocity * _Time;
            _Point.y = _StartPosition.y + _StartVelocity.y * _Time + _BallGravity.Gravity * _BallGravity.Mass * Mathf.Pow(_Time, 2) / 2;
            

            _TrajectoryPoints[i] = _Point;

            if (Physics.Raycast(_Point, Vector3.down, out RaycastHit lHit, 1f, _GroundLayer))
            {
                _LineRenderer.positionCount = i + 1;
                _LineRenderer.SetPositions(_TrajectoryPoints);
                return;
            }
        }

        _LineRenderer.positionCount = _MaxSteps;
        _LineRenderer.SetPositions(_TrajectoryPoints);
    }
}
