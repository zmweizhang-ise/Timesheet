using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateSensor : MonoBehaviour
{
    [SerializeField] private GameObject sunSensor;
    [SerializeField] private GameObject slug;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(sunSensor, transform.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(slug, transform.position, transform.rotation);
        }
    }
}

