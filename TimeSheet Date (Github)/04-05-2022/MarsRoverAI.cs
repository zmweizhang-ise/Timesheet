using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarsRoverAI : MonoBehaviour
{

    public enum STATE
    {
        Idle,
        Patrol,
        Collect,
    }


    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private GameObject _rotateTracker; // this one will always face the destination so the rover can rotate based on the value of this gameObject
    [SerializeField] private Animator _animator;

    public STATE state;

    private float _turnSpeed = 50f;
    private int _wayPointIndex;

    private float _startTimer = 3f;
    private float _timer = 3f;


    private void Start()
    {
        state = STATE.Patrol;
    }
    private void Update()
    {
        switch(state)
        {
            case STATE.Idle:
                Debug.Log("is idle");
                break;
            case STATE.Patrol:
                Patrol();
                break;
            case STATE.Collect:
                Debug.Log("collect rocks");
                break;
        }
    }
    private void Patrol()
    {
        Vector3 roverDistanceXZ = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 destinationDistanceXZ = new Vector3(_waypoints[_wayPointIndex].position.x, 0, _waypoints[_wayPointIndex].position.z);

        if (Vector3.Distance(roverDistanceXZ, destinationDistanceXZ) < .2f)     //checks if rover is getting close to destination. if yes, a timer is set before moving to next destination
        {
            if (_timer <= 0)
            {
                _timer = _startTimer;           
                IncreaseIndex();            
            }
            else
            {
                _timer -= Time.deltaTime;       //starts count down
            }
        }
        else
        {
            RotateAndMoveToDestination();
        }
    }
    private void RotateAndMoveToDestination()
    {
        float _rotateTrackerValue;
        _rotateTracker.transform.LookAt(_waypoints[_wayPointIndex].position); // tracker will keep facing the destination so it will follow rover's (the parent gameObject) roation
        _rotateTrackerValue = _rotateTracker.transform.rotation.y;  // getting y axis rotational value             
        if (_rotateTrackerValue > 0)      
        {
            if (transform.rotation.y < _rotateTrackerValue)                 //turns right
            {
                transform.Rotate(0, _turnSpeed * Time.deltaTime, 0);
            }
            else
            {
                DriveToDestination();
            }
        } 
        else
        {
            if (transform.rotation.y > _rotateTrackerValue)       //turns left
            {
                transform.Rotate(0, -(_turnSpeed) * Time.deltaTime, 0);
            }
            else
            {
                DriveToDestination();
            }
        }
    }
    private void DriveToDestination()
    {
        _agent.destination = _waypoints[_wayPointIndex].position;
    }
    private void IncreaseIndex()
    {
        if (_wayPointIndex >= _waypoints.Length-1) // goes back to first destination if final destination is reached
        {
            _wayPointIndex = 0;
        }
        else
        {
            _wayPointIndex++;       //else increase an index (or destination)
        }
        _rotateTracker.transform.position = transform.position;
    }

}
