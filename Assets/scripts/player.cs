using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private playerHealth healthSystem;
    private playerThirst thirstSystem;
    private playerHunger hungerSystem;
    private playerInventory inventory;


    public float playerRotate;
    public float speed;
    public float smoothing = 2f;
    Vector3 movement;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new playerHealth(100);
        thirstSystem = new playerThirst(100);
        hungerSystem = new playerHunger(100);
    }

    private void Awake()
    {
        inventory = new playerInventory(5);
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void debugHealth()
    {
        Debug.Log("Max Health: " + healthSystem.getMaxHealth());
        Debug.Log("Current Health: " + healthSystem.getHealth());
    }

    public void debugDamage( int damage)
    {
        healthSystem.removeHealth(damage);
    }

    public void debugHeal( int heal)
    {
        healthSystem.addHealth(10);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void FixedUpdate()
    {

        float h = 0.0f;
        float v = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.position += transform.forward * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.position += transform.forward * Time.deltaTime * speed * -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.position += transform.right * Time.deltaTime * speed * -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.position += transform.right * Time.deltaTime * speed;
        }

        float y = smoothing * Input.GetAxis("Mouse Y");
        playerRotate = smoothing * Input.GetAxis("Mouse X");
        transform.Rotate(0, playerRotate, 0);

        Debug.Log("H" + h);
        Debug.Log("V" + v);

       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
