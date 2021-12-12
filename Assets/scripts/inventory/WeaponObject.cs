using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class WeaponObject : ItemObject
{
    public int range;
    public int damage;
    public int rof;

    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
