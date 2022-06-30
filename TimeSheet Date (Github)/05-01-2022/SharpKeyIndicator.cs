using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpKeyIndicator : MonoBehaviour
{
    [SerializeField] private Color originalColor;

    [SerializeField] private Transform keyPositionUp;
    [SerializeField] private Transform keyPositionDown;
    [SerializeField] private HandStillOnKeys handStillOnKeys;

    private void Awake()
    {
    }

    private void Update()
    {
        if (handStillOnKeys.stillPressingKey == true)
        {
            var cubeRenderer = transform.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
            if (transform.position.y >= keyPositionDown.position.y)
            {
                transform.Translate(Vector3.down * .15f * Time.deltaTime);
            }
        }
        else
        {
            var cubeRenderer = transform.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", originalColor);
            if (transform.position.y <= keyPositionUp.position.y)
            {
                transform.Translate(Vector3.up * .15f * Time.deltaTime);
            }
        }
    }
}
