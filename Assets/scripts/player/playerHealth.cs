using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private int health;
    private int maxHealth = 100;
    public Slider healthSlider;

    void Awake()
    {
        ResetPlayer();
        
    }
    void Start()
    {
        ResetPlayer();
        healthSlider.value = health;
    }

    public void ResetPlayer()
    {
        health = maxHealth / 5;
    }

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void removeHealth( int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            GetComponent<player>().isDead = true;
        }
        
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
        healthSlider.value = health;
    }

    void Update()
    {
    }
}
