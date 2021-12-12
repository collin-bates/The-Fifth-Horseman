using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHunger : MonoBehaviour
{
    private int hunger;
    private int maxHunger = 100;
    public Slider HungerSlider;

    void Awake()
    {
        ResetPlayer();
    }

    void Start()
    {
        ResetPlayer();
        HungerSlider.value = hunger;
    }

    public void ResetPlayer()
    {
        hunger = maxHunger / 5;
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
            hunger -= damage;
        }
        else
        {
            GetComponent<player>().isDead = true;
        }

        HungerSlider.value = hunger;
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
        HungerSlider.value = hunger;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
