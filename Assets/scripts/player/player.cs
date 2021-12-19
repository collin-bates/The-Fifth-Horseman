using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public TMP_Text saloonText;

    public InventoryObject inventory;
    public bool pauseMovement = false;
    public float turnSpeed = 4.0f;
    public float speed;
    public float initialSpeed;
    Vector3 movement;
    Rigidbody playerRigidbody;
    public int selectedItem = 1;
    int cost;
    int quantity;

    public bool inRing = false;
    public bool isDead;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        for(int i = inventory.Container.Count - 1; i > 0; i--)
        {
            inventory.Container.RemoveAt(i);
        }
        inventory.Container[0].amount = 150;
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

    void OnTriggerEnter( Collider other )
    {
        if (other.CompareTag("saloon"))
        {
            saloonText.text = "Welcome to the saloon, grab what you want.";
        }

        if (other.CompareTag("shop"))
        {
            saloonText.text = "I've got guns, yes I do. I've got guns, how 'bout you.";
        }

        if (other.CompareTag("purchase"))
        {


            if(other.GetComponent<Item>().item.type == ItemType.Gun)
            {
                cost = 100;
                quantity = 1;
            }

            if (other.GetComponent<Item>().item.type == ItemType.Food)
            {
                cost = 15;
                quantity = 5;
            }

            if (other.GetComponent<Item>().item.type == ItemType.Drink)
            {
                cost = 5;
                quantity = 1;
            }


            if ( inventory.Container[0].amount >= cost)
            {
                inventory.removeCoin(cost);
                inventory.AddItem(other.GetComponent<Item>().item, quantity);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("saloon"))
        {
            saloonText.text = "";
        }

        if (other.CompareTag("shop"))
        {
            saloonText.text = "";
        }
    }

}
