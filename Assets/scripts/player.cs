using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private playerHealth healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new playerHealth(100);
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

    // Update is called once per frame
    void Update()
    {

    }
}
