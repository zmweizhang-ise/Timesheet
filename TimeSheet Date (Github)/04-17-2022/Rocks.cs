using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mars_Rover")
        {
            Destroy(gameObject);  
            Debug.Log("Rock picked");
        }
    }
}
