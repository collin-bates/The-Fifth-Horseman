using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject player;
    playerHealth playerHealth;
    enemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<playerHealth>();
        enemyHealth = GetComponent<enemyHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && !player.GetComponent<player>().isDead)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;
        Debug.Log("attack");
        if (playerHealth.getHealth() > 0)
        {
            Debug.Log("damage");
            playerHealth.removeHealth(attackDamage);
        }
    }
}
