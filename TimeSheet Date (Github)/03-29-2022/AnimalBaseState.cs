using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalBaseState 
{
    public abstract void EnterState(AnimalStateManager animal);
    public abstract void UpdateState(AnimalStateManager animal);
    public abstract void OnCollisionEnter(AnimalStateManager animal, Collision collision);
}
