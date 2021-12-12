using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItem : MonoBehaviour
{
    public InventoryObject inventory;
    player playerScript;
    playerHealth healthScript;
    playerThirst thirstScript;
    playerHunger hungerScript;

    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GetComponent<player>();
        healthScript = GetComponent<playerHealth>();
        thirstScript = GetComponent<playerThirst>();
        hungerScript = GetComponent<playerHunger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if( playerScript.selectedItem < inventory.Container.Count)
            {
                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Food" )
                {
                    healthScript.addHealth(inventory.Container[playerScript.selectedItem].item.healthValue);
                    hungerScript.addHunger(inventory.Container[playerScript.selectedItem].item.hungerValue);
                }

                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Drink")
                {
                    healthScript.addHealth(inventory.Container[playerScript.selectedItem].item.healthValue);
                    thirstScript.addThirst(inventory.Container[playerScript.selectedItem].item.thirstValue);
                }
            }
        }
    }
}
