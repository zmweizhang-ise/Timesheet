using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryController : MonoBehaviour
{

    [SerializeField] private LayerMask moleLayerMask;
    [SerializeField] private Rigidbody hammer;
    [SerializeField] private Transform crosshair;
    [SerializeField] private Transform aimer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, moleLayerMask))
        {
            crosshair.position = hit.point;
        }
        aimer.LookAt(crosshair);
        if (Input.GetButtonDown("Fire1"))
        {
                Rigidbody clone;
                clone = Instantiate(hammer, aimer.position, aimer.rotation).GetComponent<Rigidbody>();
                clone.AddForce(aimer.forward * 50, ForceMode.Impulse);    
                
        }
    }
}
