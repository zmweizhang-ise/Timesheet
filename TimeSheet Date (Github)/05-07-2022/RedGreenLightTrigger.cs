using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGreenLightTrigger : MonoBehaviour
{

    [SerializeField] private List<GameObject> playerList = new List<GameObject>();
    [SerializeField] public List<Rigidbody> playerInGameRbList = new List<Rigidbody>();
    [SerializeField] public List<Rigidbody> playerLostRbList = new List<Rigidbody>();

    [SerializeField] GameObject loseZone;
    private bool foundPlayerMove;


    private void Awake()
    {
        //      playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerList.Add(player);
        }
        for (int x = 0; x < playerList.Count; x++)
        {
            playerInGameRbList.Add(playerList[x].GetComponent<Rigidbody>());
        }
    }
    private void Update()
    {


    }

    private void OnTriggerStay(Collider other)
    {
        foreach (Rigidbody playerRb in playerInGameRbList.ToArray())
        {
            if (other.CompareTag("Player") && (playerRb.velocity.magnitude > 0))
            {
                playerRb.position = loseZone.transform.position;
            }
        }
    }
}
