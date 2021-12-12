using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool isDead = false;

    void Awake()
    {
        health = maxHealth;

    }

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }



    public void removeHealth(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            isDead = true;
        }

        Debug.Log("Hit");
    }

    public void addHealth(int heal)
    {
        if (health + heal < maxHealth)
        {
            health += heal;
        }
        else
        {
            health = maxHealth;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( isDead)
        {
            transform.Translate(-Vector3.up * 2.5f * Time.deltaTime);
            if (transform.position.y < -10f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
