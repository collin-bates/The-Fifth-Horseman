using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botScript : MonoBehaviour
{
    public GameObject player;
    public int startingHealth = 100;
    public float sinkSpeed = 2.5f;
    //public AudioClip deathClip;

    public int currentHealth;
    //Animator anim;
    //AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void OnEnable()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (IsDead())
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            if (transform.position.y < -10f)
            {
                currentHealth = startingHealth;
                transform.position = new Vector3(66, 1.477f, 37);
            }
        }
    }

    public bool IsDead()
    {
        return (currentHealth <= 0f);
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (!IsDead())
        {
            //enemyAudio.Play();
            currentHealth -= amount;

            if (IsDead())
            {
                Death();
            }
        }

        //hitParticles.transform.position = hitPoint;
        //hitParticles.Play();
    }

    void Death()
    {
        //EventManager.TriggerEvent("Sound", this.transform.position);
        //anim.SetTrigger("Dead");

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }
}

