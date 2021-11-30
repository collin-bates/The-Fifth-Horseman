using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private playerHealth healthSystem;
    private playerThirst thirstSystem;
    private playerHunger hungerSystem;
    private playerInventory inventory;

    public float speed;
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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
