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

    public AudioClip drinkClip;
    public AudioClip eatClip;
    public AudioClip gunClip;
    AudioSource playerAudio;

    int shootableMask;
    Ray shootRay = new Ray();
    RaycastHit shootHit;

    void Awake()
    {
        playerScript = GetComponent<player>();
        healthScript = GetComponent<playerHealth>();
        thirstScript = GetComponent<playerThirst>();
        hungerScript = GetComponent<playerHunger>();
        playerAudio = GetComponent<AudioSource>();

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

                    playerAudio.clip = eatClip;
                    playerAudio.Play();

                }

                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Drink" && inventory.Container[playerScript.selectedItem].amount > 0)
                {
                    healthScript.addHealth(inventory.Container[playerScript.selectedItem].item.healthValue);
                    thirstScript.addThirst(inventory.Container[playerScript.selectedItem].item.thirstValue);
                    inventory.Container[playerScript.selectedItem].amount -= 1;

                    playerAudio.clip = drinkClip;
                    playerAudio.Play();
                }
                if (inventory.Container[playerScript.selectedItem].item.type.ToString() == "Gun")
                {
                    shoot();

                    playerAudio.clip = gunClip;
                    playerAudio.Play();
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
            enemyHealth enemyHealth = shootHit.collider.GetComponent<enemyHealth>();

                enemyHealth.TakeDamage(inventory.Container[playerScript.selectedItem].item.damage, shootHit.point);

            Debug.Log("Boom");
        }
    }
}
