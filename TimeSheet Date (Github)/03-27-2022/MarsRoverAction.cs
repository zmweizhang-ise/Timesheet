using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarsRoverAction : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private GameObject _rotateTracker;
    [SerializeField] private Animator _animator;

    private int _wayPointIndex;
 

    void FixedUpdate()
    {
        Patrol();

    }

    public void Patrol()
    {
        if (_agent.destination != _waypoints[_wayPointIndex].position)
        {
            NewRotation();
        }
        else
        {
            _rotateTracker.transform.position = transform.position;
            IncreaseIndex();
        }
    }

    public void NewRotation()
    {
 
        float _newRotate;

        _rotateTracker.transform.LookAt(_waypoints[_wayPointIndex].position);
 
        _newRotate = _rotateTracker.transform.rotation.y;

        if (_newRotate > 0)
        {
            if (transform.rotation.y < _newRotate)
            {
                transform.Rotate(0, 20 * Time.deltaTime, 0);
            }
            else
            {
                DriveForward();
            }
        } 
        else
        {
            if (transform.rotation.y > _newRotate)
            {
                transform.Rotate(0, -20 * Time.deltaTime, 0);
            }
            else
            {
                DriveForward();
            }
        }
    }

    public void DriveForward()
    {
        _agent.destination = _waypoints[_wayPointIndex].position;
    }

    void IncreaseIndex()
    {
        _wayPointIndex++;

        if (_wayPointIndex >= _waypoints.Length)
        {
            _wayPointIndex = 0;
        }
        _rotateTracker.transform.LookAt(_waypoints[_wayPointIndex].position);
    }

}
