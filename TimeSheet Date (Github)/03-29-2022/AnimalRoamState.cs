using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRoamState : AnimalBaseState
{
    Vector3 startSize = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 growSize = new Vector3(0.1f, 0.1f, 0.1f);
    public override void EnterState(AnimalStateManager animal)
    {
        Debug.Log("Is roaming");

        animal.transform.localScale = startSize;
    }

    public override void UpdateState(AnimalStateManager animal)
    {
        if (animal.transform.localScale.x < 1)
        {
            animal.transform.localScale += growSize * Time.deltaTime;
        }
        else
        {
            animal.SwitchState(animal.ChaseState);
        }
    }

    public override void OnCollisionEnter(AnimalStateManager animal, Collision collision)
    {

    }
}
