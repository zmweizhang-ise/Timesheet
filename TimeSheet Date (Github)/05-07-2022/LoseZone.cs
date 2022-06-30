using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour
{
    [SerializeField] private RedGreenLightTrigger redGreenLightTrigger;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
            foreach (Rigidbody player in redGreenLightTrigger.playerInGameRbList.ToArray())
            {
                if (other.CompareTag("Player") && (player.velocity.magnitude > 0))
                {
                    redGreenLightTrigger.playerInGameRbList.Remove(player);
                }
            }
    }
}
