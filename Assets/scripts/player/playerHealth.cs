using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private int health;
    private int maxHealth = 100;
    public Slider healthSlider;

    public AudioClip deathClip;
    public AudioClip hurtClip;
    AudioSource playerAudio;

    void Awake()
    {
        ResetPlayer();
        playerAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        ResetPlayer();
        healthSlider.value = health;
    }

    public void ResetPlayer()
    {
        health = maxHealth / 5;
        healthSlider.value = health;
    }

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void removeHealth( int damage )
    {
        if (health - damage > 0)
        {
            health -= damage;
            playerAudio.clip = hurtClip;
            playerAudio.Play();
        }
        else
        {
            health -= damage;
            GetComponent<player>().isDead = true;
            playerAudio.clip = deathClip;
            playerAudio.Play();
        }
        healthSlider.value = health;
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
}
