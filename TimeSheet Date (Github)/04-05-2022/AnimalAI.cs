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

    private State _state;
    private int _randomSpot;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform[] _patrolPoints;
    private float _detectionRadius;
    private LayerMask _playerLayer;
    private Transform _player;

    private void Start()
    {
        _state = State.Patrol;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Idle:
                break;

            case State.Patrol:
                Patrol();
                if (Physics.CheckSphere(transform.position, _detectionRadius, _playerLayer))
                {
                    _state = State.Follow;
                }
                break;

            case State.Follow:
                Follow();
                break;
        }
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
    }

    private void Follow()
    {
            _agent.SetDestination(_player.position);
    }

}
