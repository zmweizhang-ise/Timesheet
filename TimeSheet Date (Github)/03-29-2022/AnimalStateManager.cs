using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStateManager : MonoBehaviour
{

    AnimalBaseState currentState;
    public AnimalRoamState RoamState = new AnimalRoamState();
    public AnimalChaseState ChaseState = new AnimalChaseState();


    void Start()
    {
        currentState = RoamState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AnimalBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
