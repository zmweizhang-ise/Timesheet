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

    [SerializeField] private GameObject detector;

    private int greenLightTimer;
    private int yellowLightTimer;
    private int redLightTimer;

    private void Awake()
    {
    }
    void Start()
    {
        currentCoroutine = Timer();
        greenLightTimer = Random.Range(4, 5);
        yellowLightTimer = Random.Range(1, 3);
        redLightTimer = Random.Range(6, 10);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            startTimer = !startTimer;
            if (startTimer)
            {
                StartCoroutine(currentCoroutine);
            }
            else
            {
                StopCoroutine(currentCoroutine); //Stops timer
            }
        }

        switch (changeLight)
        {
            case 0:
                var cubeRenderer = transform.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.green);
                detector.SetActive(false);
                break;
            case 1:
                cubeRenderer = transform.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.yellow);
                break;
            case 2:
                cubeRenderer = transform.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.red);
                detector.SetActive(true);

                break;
            default:
                changeLight = 0;
                Debug.Log("Reset");
                break;
        }
    }

    private IEnumerator Timer()
    {
        randomSeconds = Random.Range(3, 5);

        while (randomSeconds > 0)
        {
            randomSeconds -= Time.deltaTime;
            Debug.Log(randomSeconds);

            if(randomSeconds <= 0)
            {
                changeLight += 1;

                if (changeLight == 1)
                {
                    randomSeconds = yellowLightTimer;
                    Debug.Log("Yellow");
                }
                else if (changeLight == 2)
                {
                    randomSeconds = redLightTimer;
                    Debug.Log("Red");
                }
                else
                {
                    randomSeconds = greenLightTimer;
                    Debug.Log("Back to Green");

                }
            }
            yield return null;
        }
    }
}
