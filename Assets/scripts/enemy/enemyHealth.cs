using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    private int health;
    private int maxHealth;

    public enemyHealth(int total)
    {
        health = total;
        maxHealth = total;
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

        }
        health -= damage;

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
        
    }
}
