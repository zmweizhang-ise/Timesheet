using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rock Object", menuName = "Inventory System/Items/Mars Rock")]

public class ObjectMarsRock : ItemObject
{

    public int Amount;

    public void Awake()
    {
        type = ItemType.Rock;
    }
}
