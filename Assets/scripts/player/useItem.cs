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

    int shootableMask;
    Ray shootRay = new Ray();
    RaycastHit shootHit;

    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GetComponent<player>();
        healthScript = GetComponent<playerHealth>();
        thirstScript = GetComponent<playerThirst>();
        hungerScript = GetComponent<playerHunger>();

        shootableMask = LayerMask.GetMask("Shootable", "Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (playerScript.selectedItem < inventory.Container.Count)
            {
                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Food" && inventory.Container[playerScript.selectedItem].amount > 0)
                {
                    healthScript.addHealth(inventory.Container[playerScript.selectedItem].item.healthValue);
                    hungerScript.addHunger(inventory.Container[playerScript.selectedItem].item.hungerValue);
                    inventory.Container[playerScript.selectedItem].amount -= 1;
                }

                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Drink" && inventory.Container[playerScript.selectedItem].amount > 0)
                {
                    healthScript.addHealth(inventory.Container[playerScript.selectedItem].item.healthValue);
                    thirstScript.addThirst(inventory.Container[playerScript.selectedItem].item.thirstValue);
                    inventory.Container[playerScript.selectedItem].amount -= 1;
                }
                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Gun")
                {
                    shoot();
                }
            }
        }
    }

    void shoot()
    {

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        Debug.Log("Shoot");
        if (Physics.Raycast(shootRay, out shootHit, inventory.Container[playerScript.selectedItem].item.range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            enemyHealth enemyHealth = shootHit.collider.GetComponent<enemyHealth>();

            // If the EnemyHealth component exist...
            
                // ... the enemy should take damage.
                enemyHealth.removeHealth(inventory.Container[playerScript.selectedItem].item.damage);

            Debug.Log("Boom");
            // Set the second position of the line renderer to the point the raycast hit.
            //gunLine.SetPosition(1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
