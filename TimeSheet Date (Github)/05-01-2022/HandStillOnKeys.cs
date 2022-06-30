using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStillOnKeys : MonoBehaviour
{

    public bool stillPressingKey;


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            stillPressingKey = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            stillPressingKey = false;
        }
    }
}