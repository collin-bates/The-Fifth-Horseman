using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerThirst : MonoBehaviour
{
    private int thirst;
    private int maxThirst = 100;
    public Slider thirstSlider;

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
        thirstSlider.value = thirst;
    }

    public void ResetPlayer()
    {
        thirst = maxThirst / 5;
        thirstSlider.value = thirst;
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
            thirst -= damage;
            GetComponent<player>().isDead = true;
            playerAudio.clip = deathClip;
            playerAudio.Play();

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
}
