using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleSpawn : MonoBehaviour
{
    [SerializeField] private Transform bot;
    [SerializeField] private Transform top;
 
 
    private float deSpawnTim;
    private float spawnTim;
    private float timer;

    private bool isSpawn;
    private bool isDeSpawn;
    private bool immediateDeSpawn;

    private WhackAMoleScores scoreSystem;
    private void Awake()
    {
        spawnTim = Random.Range(0, 8);
        deSpawnTim = Random.Range(1, 4);
        timer = 0;
        isSpawn = true;

        scoreSystem = GameObject.Find("Scores").GetComponent<WhackAMoleScores>();
    }

    void Update()
    {

        if (isSpawn == true)
        {
            SpawnMole();
        }

        if (isDeSpawn == true)
        {
            DespawnMole();
        }
        if (immediateDeSpawn == true)
        {
            DespawnAfterHit();
        }
     }


    private void SpawnMole()
    {
        if (timer < spawnTim)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (transform.position.y < top.position.y)
            {
                transform.Translate(Vector3.up * 2 * Time.deltaTime);
            }
            else
            {
                timer = 0;
                isSpawn = false;
                isDeSpawn = true;
                deSpawnTim = Random.Range(1, 4);
            }
        }
    }


    private void DespawnMole()
    {
        if (timer < deSpawnTim)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (transform.position.y > bot.position.y)
            {
                transform.Translate(Vector3.down * 5 * Time.deltaTime);
            }
            else
            {
                timer = 0;
                isSpawn = true;
                isDeSpawn = false;
                spawnTim = Random.Range(0, 8);
            }
        }
    }

    private void DespawnAfterHit()
    {
        if (transform.position.y > bot.position.y)
        {
            transform.Translate(Vector3.down * 10 * Time.deltaTime);
        }
        else
        {
            timer = 0;
            isSpawn = true;
            immediateDeSpawn = false;
            spawnTim = Random.Range(0, 8);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            isSpawn = false;
            isDeSpawn = false;
            immediateDeSpawn = true;
            scoreSystem.addScore();
         }
    }
}
