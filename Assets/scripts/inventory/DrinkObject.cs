using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink Object", menuName = "Inventory System/Items/Drink")]
public class DrinkObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Drink;
    }
}
