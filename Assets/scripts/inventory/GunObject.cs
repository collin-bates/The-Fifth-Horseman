using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Object", menuName = "Inventory System/Items/Gun")]
public class GunObject : ItemObject
{
    public int range;
    public int damage;
    public int rof;
    public int maxBullets;

    public void Awake()
    {
        type = ItemType.Gun;
    }
}
