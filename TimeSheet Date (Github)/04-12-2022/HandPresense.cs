using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresense : MonoBehaviour
{
    [SerializeField] private bool showController = false;
    [SerializeField] private InputDeviceCharacteristics controllerCharacteristics;
    [SerializeField] private List<GameObject> controllerPrefab;
    [SerializeField] private GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefab.Find(controller => controller.name == targetDevice.name);

            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefab[0], transform);
            }

            spawnedController = Instantiate(handModelPrefab, transform);  
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            Debug.Log("Pressing Primary Button");    
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            Debug.Log("Trigger pressed " + triggerValue);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Trigger pressed " + primary2DAxisValue);
        }
        
        */
        /*

                if(showController)
                {
                    spawnedHandModel.SetActive(false);
                    spawnedController.SetActive(true);
                }
                else
                {
                    spawnedHandModel.SetActive(true);
                    spawnedController.SetActive(false);
                }

                */
    }
}
