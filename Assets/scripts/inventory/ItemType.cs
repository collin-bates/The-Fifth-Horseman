using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Weapon,
    Gun,
    Drink,
    Default
}


public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public int range;
    public int damage;
    public int rof;
    public int maxBullets;
    public int healthValue;
    public int hungerValue;
    public int thirstValue;

    [TextArea(15, 20)]
    public string description;

}
