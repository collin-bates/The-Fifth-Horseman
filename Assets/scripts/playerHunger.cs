using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHunger : MonoBehaviour
{
    private int hunger;
    private int maxHunger;

    public playerHunger(int total)
    {
        hunger = total;
        maxHunger = total;
    }


    public int getHunger()
    {
        return hunger;
    }

    public int getMaxHunger()
    {
        return maxHunger;
    }



    public void removeHunger(int damage)
    {
        if (hunger - damage > 0)
        {

        }
        hunger -= damage;

    }

    public void addHunger(int food)
    {
        if (hunger + food < maxHunger)
        {
            hunger += food;
        }
        else
        {
            hunger = maxHunger;
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
