using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private playerHealth healthSystem;
    private playerThirst thirstSystem;
    private playerHunger hungerSystem;


    public float turnSpeed = 4.0f;
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

        float y = Input.GetAxis("Mouse X") * turnSpeed;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
