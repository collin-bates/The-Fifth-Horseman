using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public GameObject player;
    float playTime = 0;

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
    }
}
