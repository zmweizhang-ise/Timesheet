using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedGreenLight : MonoBehaviour
{
    private IEnumerator currentCoroutine;
    private float randomSeconds;
    private bool startTimer;
    private int changeLight = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentCoroutine = Timer();
    }
    // Update is called once per frame

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            startTimer = !startTimer;
            if (startTimer)
            {
                StartCoroutine(currentCoroutine);
                Debug.Log("start");
            }
            else
            {
                StopCoroutine(currentCoroutine); //Reset timer
                Debug.Log("reset");
            }
            Debug.Log(randomSeconds);
        }

        switch (changeLight)
        {
            case 0:
                var cubeRenderer = transform.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.green);
                break;
            case 1:
                cubeRenderer = transform.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.yellow);
                break;
            case 2:
                cubeRenderer = transform.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.red);
                break;
            case 3:
                changeLight = 0;
                break;
        }
    }

    private IEnumerator Timer()
    {
        randomSeconds = Random.Range(5, 10);

        while (randomSeconds > 0)
        {
            randomSeconds -= Time.deltaTime;
            Debug.Log(randomSeconds);

            if(randomSeconds <= 0)
            {
                changeLight += 1;
                randomSeconds = Random.Range(5, 10);
            }
            yield return null;
        }

    }
}
