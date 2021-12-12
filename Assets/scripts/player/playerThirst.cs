using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerThirst : MonoBehaviour
{
    private int thirst;
    private int maxThirst = 100;
    public Slider thirstSlider;

    void Awake()
    {
        ResetPlayer();
    }

    void Start()
    {
        ResetPlayer();
        thirstSlider.value = thirst;
    }

    void ResetPlayer()
    {
        thirst = maxThirst / 5;
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
            thirst -= damage;
        }
        else
        {
            GetComponent<player>().isDead = true;
        }
        thirstSlider.value = thirst;
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
        thirstSlider.value = thirst;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
