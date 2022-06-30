
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
 
public class ParentingGrabbedObject : XRGrabInteractable
{
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        SetParentToXRRig();
        base.OnSelectEntered(interactor);
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        SetParentToWorld();
        base.OnSelectExited(interactor);
    }

    [System.Obsolete]
    public void SetParentToXRRig()
    {
        transform.SetParent(selectingInteractor.transform);
    }

    public void SetParentToWorld()
    {
        transform.SetParent(null);
    }
}