using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerThirst : MonoBehaviour
{
    private int thirst;
    private int maxThirst;

    public playerThirst(int total)
    {
        thirst = total;
        maxThirst = total;
    }

    public int getThirst()
    {
        return thirst;
    }

    public int getMaxThirst()
    {
        return maxThirst;
    }

    public void removeThirst(int damage)
    {
        if (thirst - damage > 0)
        {

        }
        thirst -= damage;

    }

    public void addThirst(int drink)
    {
        if (thirst + drink < maxThirst)
        {
            thirst += drink;
        }
        else
        {
            thirst = maxThirst;
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
