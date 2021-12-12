using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink Object", menuName = "Inventory System/Items/Drink")]
public class DrinkObject : ItemObject
{
    public int healthValue;
    public int hungerValue;
    public void Awake()
    {
        type = ItemType.Drink;
    }
}
