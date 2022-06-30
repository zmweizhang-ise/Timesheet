using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CustomMultiInteractable : XRBaseInteractable
{

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if(HasOneInteractor())
        {
            Debug.Log("Is 1 hand grab");
        }
        else if(HasMultipleInteractor())
        {
            Debug.Log("Is 2 hand grab");
        }

    }


    private bool HasOneInteractor()
    {
        return interactorsSelecting.Count == 1;

    }

    private bool HasMultipleInteractor()
    {
        return interactorsSelecting.Count > 1;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        if(HasNoInteractors())
        {
            Debug.Log("Is no hand grab");
        }
    }

    private bool HasNoInteractors()
    {
        return interactorsSelecting.Count == 0;
    }
}
 