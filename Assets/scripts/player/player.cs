using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public InventoryObject inventory;
    public bool pauseMovement = false;
    public float turnSpeed = 4.0f;
    public float speed;
    public float initialSpeed;
    Vector3 movement;
    Rigidbody playerRigidbody;
    public int selectedItem = 1;

    public bool isDead;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (pauseMovement)
            {
                pauseMovement = false;
            }
            else
            {
                pauseMovement = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = initialSpeed * 2;
        }
        else
        {
            speed = initialSpeed;
        }

        if (!pauseMovement)
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

        if(Input.GetKey(KeyCode.Alpha1))
        {
            selectedItem = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedItem = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            selectedItem = 3;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            selectedItem = 4;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            selectedItem = 5;
        }
    }
}
