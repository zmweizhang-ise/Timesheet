using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unknown Object", menuName = "Inventory System/Items/Unknown Object")]

public class ObjectUnknown : ItemObject
{
    public int quantity;

    public void Awake()
    {
        type = ItemType.Unknown;
    }
}
