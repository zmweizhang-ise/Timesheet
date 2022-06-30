using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGreenLightTrigger : MonoBehaviour
{
    private bool spottedPlayer;


    private Rigidbody playerRb;
    [SerializeField] GameObject loseZone;
    private void Start()
    {
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if(spottedPlayer == true)
        {
            if (playerRb.velocity.magnitude > 0)
            {
                Debug.Log("Player moved");
                playerRb.position = loseZone.transform.position;
            }
            else
            {
                Debug.Log("Player did not move");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            spottedPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spottedPlayer = false;
            Debug.Log("Countdown");
        }
    }
}
