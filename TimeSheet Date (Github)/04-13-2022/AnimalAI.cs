using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{

    private enum State
    {
        Idle,
        Patrol,
        Follow,
    }

    private int _randomSpot;
    private float _detectionRadius = 20;

    [SerializeField] private State _state;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform[] _patrolPoints;
    [SerializeField] private LayerMask _playerLayer;
    private bool _playerDetected;
    private GameObject _player;

    private void Start()
    {
        _state = State.Patrol;
        _player = GameObject.FindGameObjectWithTag("Player");
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

        switch (_state)  //going to add more features later
        {
            case State.Idle:
                break;

            case State.Patrol:
                Patrol();
                break;

            case State.Follow:
                Follow();
                break;
        }
    }

    private void OnDrawGizmos() //shows physics.checksphere range and indicate if the animal detects the player
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);    

    }
    private void Patrol()
    {
        Vector3 patrolPointsPosition = new Vector3(_patrolPoints[_randomSpot].position.x, transform.position.y, _patrolPoints[_randomSpot].position.z);
        if (Vector3.Distance(transform.position, patrolPointsPosition) > 0.2f)
        {
            _agent.SetDestination(_patrolPoints[_randomSpot].position);
        }
        else
        {
            _randomSpot = Random.Range(0, _patrolPoints.Length);
        }

        if(_playerDetected == true)
        {
            _state = State.Follow;
        }
    }

    private void Follow()
    {
        _agent.SetDestination(_player.transform.position);

        if (_playerDetected == false)
        {
            _state = State.Patrol;
        }

    }

}
