using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public GameObject player;
    float playTime = 0;

    public InventoryObject inventory;
    public GameObject conquest;
    public GameObject death;
    public GameObject satan;

    public bool conquestDead = false;
    public bool deathDead = false;
    public bool satanDead = false;
    bool conquestAward = true;
    bool deathAward = true;
    bool satanAward = true;

    public int currentBoss = 0;
    public bool gameWon = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        playTime += Time.deltaTime;

        if(playTime % 300000 >= 60)
        {
            Debug.Log("remove t/h" + playTime);
            playTime = 0;

            player.GetComponent<playerHunger>().removeHunger(5);
            player.GetComponent<playerThirst>().removeThirst(5);
        }

        if (conquestDead && conquestAward)
        {
            player.transform.position = new Vector3(0, 1.52f, 0);
            inventory.removeCoin(-50);
            conquestAward = false;
        }

        if (deathDead && deathAward)
        {
            player.transform.position = new Vector3(0, 1.52f, 0);
            inventory.removeCoin(-50);
            deathAward = false;
        }

        if (satanDead)
        {

        }

        if(currentBoss == 1 && !conquestDead)
        {
            conquest.SetActive(true);
        }

        if(currentBoss == 2 && !deathDead)
        {
            death.SetActive(true);
        }

        if(currentBoss == 3 && !satanDead)
        {
            satan.SetActive(true);
        }
    }
}
