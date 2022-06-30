using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKeyIndicator : MonoBehaviour
{
    [SerializeField] private Color originalColor;
    [SerializeField] private GameObject key;
    [SerializeField] bool isPressed;
    GameObject presser;
    private void Start()
    {
        isPressed = false;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed == false && other.CompareTag("Hand"))
        {
            var cubeRenderer = key.transform.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);
            key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y - 0.03f, key.transform.position.z);
            presser = other.gameObject;
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPressed == true)
        {
            var cubeRenderer = key.transform.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", originalColor);
            key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.03f, key.transform.position.z);
            isPressed = false;

        }
    }
}
