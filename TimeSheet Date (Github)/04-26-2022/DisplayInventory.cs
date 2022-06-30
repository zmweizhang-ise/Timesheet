using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private int xStart;
    [SerializeField] private int yStart;

    [SerializeField] private InventoryObject inventory;
    [SerializeField] private int xSpaceBetweenItems;
    [SerializeField] private int numberOfColumn;

    [SerializeField] private int ySpaceBetweenItems;

    Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        for(int x = 0; x < inventory.Container.Count; x++)
        {
            var obj = Instantiate(inventory.Container[x].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(x);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[x].amount.ToString("n0");
            itemDisplayed.Add(inventory.Container[x], obj);
        }
    }

    public Vector3 GetPosition(int x)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (x % numberOfColumn)), yStart + (-ySpaceBetweenItems * (x / numberOfColumn)), 0f);
    }


    private void UpdateDisplay()
    {
        for(int x = 0; x < inventory.Container.Count; x++)
        {
            if (itemDisplayed.ContainsKey(inventory.Container[x]))
            {
                itemDisplayed[inventory.Container[x]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[x].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[x].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(x);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[x].amount.ToString("n0");
                itemDisplayed.Add(inventory.Container[x], obj);
            }
        }
    }
}
