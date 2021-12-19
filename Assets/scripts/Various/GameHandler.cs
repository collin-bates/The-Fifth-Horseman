using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject playScreen;
    public GameObject endScreen;
    public GameObject startScreen;

    public GameObject player;
    float playTime = 0;

    public InventoryObject inventory;
    public GameObject conquest;
    public GameObject death;
    public GameObject satan;

    public Slider bossHealth;
    public TMP_Text bossName;
    public TMP_Text infoText;

    public bool conquestDead;
    public bool deathDead;
    public bool satanDead;
    bool conquestAward;
    bool deathAward;
    bool satanAward;

    public int currentBoss;
    public bool gameRestart;
    public bool toggleEsc;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        currentBoss = 0;
        gameRestart = false;

        conquestDead = false;
        deathDead = false;
        satanDead = false;
        conquestAward = true;
        deathAward = true;
        satanAward = true;

        toggleEsc = true;

        playScreen.SetActive(false);
        endScreen.SetActive(false);
        startScreen.SetActive(true);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            if (toggleEsc)
            {
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                toggleEsc = true;
                playScreen.SetActive(false);
                startScreen.SetActive(true);
            }

        }



        playTime += Time.deltaTime;

        if(playTime % 300000 >= 60)
        {
            playTime = 0;

            player.GetComponent<playerHunger>().removeHunger(5);
            player.GetComponent<playerThirst>().removeThirst(5);
        }

        if (player.GetComponent<player>().isDead)
        {
            playScreen.SetActive(false);
            endScreen.GetComponentInChildren<TMP_Text>().text = "You Died";
            endScreen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
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
            playScreen.SetActive(false);

            endScreen.GetComponentInChildren<TMP_Text>().text = "You have vanquished The Devil";

            endScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if(currentBoss == 2 && !conquestDead)
        {
            conquest.SetActive(true);
            bossHealth.value = conquest.GetComponent<enemyHealth>().currentHealth;
            bossName.text = "Conquest";
        }

        if(currentBoss == 4 && !deathDead)
        {
            death.SetActive(true);
            bossHealth.maxValue = 200;
            bossHealth.value = death.GetComponent<enemyHealth>().currentHealth;
            bossName.text = "Death";
        }

        if(currentBoss == 6 && !satanDead)
        {
            satan.SetActive(true);
            bossHealth.maxValue = 300;
            bossHealth.value = satan.GetComponent<enemyHealth>().currentHealth;
            bossName.text = "The Devil";
        }

        updateSlider();
    }

    void updateSlider()
    {
        if (currentBoss == 2 && conquestDead)
        {
            bossHealth.value = 0;
        }

        if (currentBoss == 4 && deathDead)
        {
            bossHealth.value = 0;
        }
    }

    public void callInfo()
    {
        infoText.text = "Created By: Collin Bates, Mckenzie Sellers, and Ta'Lasha Winston";
    }

    public void callStart()
    {
        startScreen.SetActive(false);
        playScreen.SetActive(true);
        infoText.text = "";
        Cursor.lockState = CursorLockMode.Locked;
        toggleEsc = false;
    }
    public void Restart()
    {
        bossHealth.maxValue = 100;
        currentBoss = 0;
        conquestDead = false;
        deathDead = false;
        satanDead = false;
        conquestAward = true;
        deathAward = true;
        satanAward = true;

        player.transform.position = new Vector3(0, 1.52f, 0);

        conquest.GetComponent<enemyHealth>().Restart();
        conquest.transform.position = new Vector3(-11, 2.1f, 171);

        death.GetComponent<enemyHealth>().Restart();
        death.transform.position = new Vector3(19, 2.407418f, 152);

        satan.GetComponent<enemyHealth>().Restart();
        satan.transform.position = new Vector3(-68, 2.75f, 160);


        player.GetComponent<player>().Restart();
        player.GetComponent<playerHealth>().ResetPlayer();
        player.GetComponent<playerHunger>().ResetPlayer();
        player.GetComponent<playerThirst>().ResetPlayer();

        endScreen.SetActive(false);
        playScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void endGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}


