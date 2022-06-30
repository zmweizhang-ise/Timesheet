using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleTeleport : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "MarbleTeleporterPoint")
        {
            transform.position = new Vector3(8.34200001f, 7.67399979f, -3.00600004f);
        }
    }
}
 