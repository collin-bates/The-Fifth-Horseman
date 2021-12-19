using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHunger : MonoBehaviour
{
    private int hunger;
    private int maxHunger = 100;
    public Slider HungerSlider;

    public AudioClip deathClip;
    AudioSource playerAudio;

    void Awake()
    {
        ResetPlayer();
        playerAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        ResetPlayer();
        HungerSlider.value = hunger;
    }

    public void ResetPlayer()
    {
        hunger = maxHunger / 5;
        HungerSlider.value = hunger;
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
            hunger -= damage;
            GetComponent<player>().isDead = true;
            playerAudio.clip = deathClip;
            playerAudio.Play();
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
