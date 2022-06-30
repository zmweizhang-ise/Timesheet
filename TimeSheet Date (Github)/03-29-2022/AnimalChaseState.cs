using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalChaseState : AnimalBaseState
{
    public override void EnterState(AnimalStateManager animal)
    {
        Debug.Log("Animal will chase you");
    }

    public override void UpdateState(AnimalStateManager animal)
    {

    }

    public override void OnCollisionEnter(AnimalStateManager animal, Collision collision)
    {

    }
}
