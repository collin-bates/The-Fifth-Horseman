﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public GameObject player;
    public int startingHealth = 100;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    //public AudioClip deathClip;

    public int currentHealth;
    //Animator anim;
    //AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    EnemyMovement enemyMovement;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        //enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        enemyMovement = this.GetComponent<EnemyMovement>();
    }

    void OnEnable()
    {
        currentHealth = startingHealth;
        SetKinematics(false);
    }

    private void SetKinematics(bool isKinematic)
    {
        capsuleCollider.isTrigger = isKinematic;
        capsuleCollider.attachedRigidbody.isKinematic = isKinematic;
    }

    void Update()
    {
        if (IsDead())
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            if (transform.position.y < -10f)
            {
                Destroy(this.gameObject);
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
            else if(player.GetComponent<player>().inRing)
            {
                enemyMovement.GoToPlayer();
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

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        SetKinematics(true);

        //ScoreManager.score += scoreValue;
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }
}

