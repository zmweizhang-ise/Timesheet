using System;
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
        Follow,
    }


    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private GameObject _rotateTracker; // this one will always face the destination so the rover can rotate based on the value of this gameObject
    [SerializeField] private Animator _animator; // will include after 
    [SerializeField] private LayerMask _playerLayer; //variable to find player by layer
    [SerializeField] private LayerMask _rockLayer; //variable to find rock by layer

    private float _detectionRadius = 30; // rover detection range for player or rocks.
    public STATE state;

 //   private float _turnSpeed = 50f;
    private int _wayPointIndex;

    private float _startTimer = 3f;
    private float _timer = 3f;
    private bool _playerDetected;
    private bool _rockDetected;
    private GameObject _player;
    private GameObject _rock;

    private void Start()
    {
        state = STATE.Patrol;
        _player = GameObject.FindGameObjectWithTag("Player");
        _rock = GameObject.FindGameObjectWithTag("Rock");
    }
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, _detectionRadius, _playerLayer))
        {
            _playerDetected = true;
        }
        else
        {
            _playerDetected = false;
        }

        if (Physics.CheckSphere(transform.position, _detectionRadius, _rockLayer))
        {
            _rockDetected = true;
        }
        else
        {
            _rockDetected = false;
        }

        switch (state) //going to add more features later
        {
            case STATE.Idle:        //possibly a function to tell the rover to idle until player active the rover to do something else
                Debug.Log("is idle");
                break;
            case STATE.Patrol: // roams around given waypoints
                if (_playerDetected == true)
                {
                    state = STATE.Follow;
                }
                else if (_rockDetected == true)
                {
                    state = STATE.Collect;
                }
                else
                {
                    Patrol();
                }
                break;
            case STATE.Collect: // detects rocks and collect
                CollectRocks();
                if (_rockDetected == false)
                {
                    state = STATE.Patrol;
                }
                else if (_playerDetected == true)
                {
                    state = STATE.Follow;
                }
                break;
            case STATE.Follow: // goes to playerS
                if (Vector3.Distance(_agent.transform.position, _player.transform.position) > 15)     // This condition is to make sure player can get close to Rover without Rover movings
                {
                    _agent.destination = _player.transform.position;
                    _agent.stoppingDistance = 15; // Rover will move to player but will also keep some distance
                }
                if (_playerDetected == false)
                {
                    state = STATE.Patrol;
                    _agent.stoppingDistance = 0;
                }
                break;
        }
    }

    private void CollectRocks()         // Rover will detect nearby rocks
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _detectionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Rock")
            {
                ObtainsRock(hitCollider.transform);
            }
        }
    }

    private void ObtainsRock(Transform rock)  // Rover will move to detected rocks
    {
        _agent.destination = rock.transform.position;
    }

    private void Patrol()
    {
        Vector3 _roverDistanceXZ = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 _destinationDistanceXZ = new Vector3(_waypoints[_wayPointIndex].position.x, 0, _waypoints[_wayPointIndex].position.z);

        if (Vector3.Distance(_roverDistanceXZ, _destinationDistanceXZ) < .2f)     //checks if rover is getting close to destination. if yes, a timer is set before moving to next destination
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
            _agent.destination = _waypoints[_wayPointIndex].position;
        }
    }
    /*
    private void RotateAndMoveToDestination()  //Hard coded rover rotation movement (may not be necessary to use this method)
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
    */

    private void IncreaseIndex()
    {
        if (_wayPointIndex >= _waypoints.Length - 1) // goes back to first destination if final destination is reached
        {
            _wayPointIndex = 0;
        }
        else
        {
            _wayPointIndex++;       //else increase an index (or destination)
        }
        //      _rotateTracker.transform.position = transform.position;
    }

    private void OnDrawGizmos() //shows physics.checksphere range and indicate if the animal detects the player
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}