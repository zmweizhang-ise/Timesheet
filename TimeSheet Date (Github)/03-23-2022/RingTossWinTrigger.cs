    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossWinTrigger : MonoBehaviour
{

    private bool collideOnce;

    [SerializeField] GameObject stick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collideOnce == true)
        {
            Debug.Log("Win");
            collideOnce = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "RingWinTrigger")
        {
            collideOnce = true;

            var renderStick = stick.GetComponent<Renderer>();
            renderStick.material.SetColor("_Color", Color.green);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RingWinTrigger")
        {
            collideOnce = false;

            var renderStick = stick.GetComponent<Renderer>();
            renderStick.material.SetColor("_Color", Color.white);
        }
    }
}
