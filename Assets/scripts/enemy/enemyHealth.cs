using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyHealth : MonoBehaviour
{
    public GameObject player;
    public int startingHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;
    public AudioClip hurtClip;
    NavMeshAgent nav;

    public int currentHealth;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    EnemyMovement enemyMovement;

    bool stillSinking = true;

    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        enemyMovement = this.GetComponent<EnemyMovement>();
    }

    void OnEnable()
    {
        currentHealth = startingHealth;
    }


    public void Restart()
    {
        Debug.Log("restarting enemy");

        currentHealth = startingHealth;
        this.gameObject.SetActive(false);
        stillSinking = true;
    }

    void Update()
    {
        if (IsDead() && stillSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            if (transform.position.y < -10f)
            {
                stillSinking = false;
            }
        }
    }

    public bool IsDead()
    {
        return (currentHealth <= 0f);
    }

    public void addHealth(int heal)
    {
        currentHealth += heal;
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (!IsDead())
        {
            currentHealth -= amount;

            enemyAudio.clip = hurtClip;
            enemyAudio.Play();

            if (IsDead())
            {
                Death();
            }
            
        }
    }

    void Death()
    {
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }
}

