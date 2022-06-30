using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlugHealth : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float lightReceivedValue = 0f;
    [SerializeField] private TMP_Text healthScoreText;
    [SerializeField] private TMP_Text healthConditionText;
    [SerializeField] private TMP_Text sunLightValueText;

    private string healthConditionString;

    private float defaultHealthScore = 100f; //Slug's max health
    [SerializeField] private float healthPercent;
    [SerializeField] private float slugDistance; // Represent distance between ocrean surface and slug current position

    private enum HealthSTATE
    {
        poor, 
        neutral,
        healthy,
    }

    [SerializeField] private HealthSTATE healthState;

    private void Start()
    {
    }
    private void Update()
    {
        
        if(healthPercent < 40)
        {
            healthState = HealthSTATE.poor;
        }else if(healthPercent >= 40 && healthPercent <= 59)
        {
            healthState = HealthSTATE.neutral;
        }else if(healthPercent >= 60)
        {
            healthState = HealthSTATE.healthy;
        }

        switch (healthState)
        {
            case HealthSTATE.poor:
                healthConditionString = "Poor";
                break;
            case HealthSTATE.neutral:
                healthConditionString = "Neutral";
                break;
            case HealthSTATE.healthy:
                healthConditionString = "Healthy";
                break;
        }
    }
    private void FixedUpdate()
    {
        // Formula for slug distance. 
        float slugLostSunlight;
        // Bit shift the index of the layer (17) to get a bit mask
        int layerMask = 1 << 17;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 17. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, layerMask))
        {
            healthPercent = 0;
            slugLostSunlight = 100;

            // DEBUG //
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //Debug.Log("There is something on top of the object!");
        }
        else
        {
            //Distance slug position that will only focus on y axis (for accurate height measurement between slug and ocean surface).
            Vector3 slugPositionY = new Vector3(0, transform.position.y, 0);

            //Approx position of ocrean surface only on y axis
            Vector3 oceanSurfacePositionY = new Vector3(0, 276, 0); 

            //Distance between slug position y and the position of raycast hits (going to be ocrean surface)
            slugDistance = Vector3.Distance(slugPositionY, oceanSurfacePositionY);

            // Slug's health starts at 100 % (default) and will decrease/increase depends slug's distance from the ocrean suface. 
            // 1000f in the formula is the limit that the sunlight can travel (1000 meters) in the depth of ocrean (based on research).

            healthPercent = defaultHealthScore - (slugDistance / 1000f * 100);   
            slugLostSunlight = (slugDistance / 1000f) * 100;
        }

        healthConditionText.text = "Health Condition: " + healthConditionString;
        healthScoreText.text = "Health Percent: " + healthPercent.ToString() + "%";
        sunLightValueText.text = "Sunlight Loss: " + slugLostSunlight + "%";
    }
}
