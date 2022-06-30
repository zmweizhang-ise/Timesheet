using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedKeyIndicator : MonoBehaviour
{
    [SerializeField] private Color originalColor;

    [SerializeField] private Transform keyPositionUp;
    [SerializeField] private Transform keyPositionDown;
     HandStillOnKeys handStillOnKeys;

    [SerializeField] private bool keyPressed;
 
     
    private void Awake()
    {
        handStillOnKeys = GameObject.Find("KeyAdditionalColliders").GetComponent<HandStillOnKeys>();
    }

    private void Update()
    {
        if (keyPressed == true)
        {
            if (transform.position.y >= keyPositionDown.position.y)
            {
                transform.Translate(Vector3.down * .15f * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y <= keyPositionUp.position.y)
            {
                transform.Translate(Vector3.up * .15f * Time.deltaTime);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (handStillOnKeys.stillPressingKey == true && collision.gameObject.CompareTag("Hand"))
        {
            var cubeRenderer = transform.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
 //           Debug.Log("Pressed");

            keyPressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            var cubeRenderer = transform.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", originalColor);
//            Debug.Log("Released");

            keyPressed = false;
        }
    }
}
