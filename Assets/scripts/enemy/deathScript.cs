using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deathScript : MonoBehaviour
{
    public GameObject gameHandler;
    public float visionRange = 10f;
    public float hearingRange = 20f;
    public float wanderDistance = 10f;
    public Vector2 idleTimeRange;
    [Range(0f, 1f)]
    public float psychicLevels = 0.2f;

    float currentVision;
    Transform player;
    playerHealth playerHealth;
    enemyHealth enemyHealth;
    NavMeshAgent nav;
    public float timer = 0f;

    Vector3 destination;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<playerHealth>();
        enemyHealth = GetComponent<enemyHealth>();
        nav = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        nav.enabled = false;
        ClearPath();
        ScaleVision(1f);
        IsPsychic();
        timer = 0f;
    }

    void ClearPath()
    {
        if (nav.hasPath)
            nav.ResetPath();
    }

    void Update()
    {
        if (enemyHealth.IsDead())
        {
            gameHandler.GetComponent<GameHandler>().deathDead = true;
            nav.enabled = false;
        }
        if ( !enemyHealth.IsDead() && enemyHealth.currentHealth > enemyHealth.startingHealth / 2)
        {
            nav.enabled = true;

            LookForPlayer();
            GoToPlayer();
            WanderOrIdle();
        }else if ( !enemyHealth.IsDead())
        {
            destination.Set(nav.transform.position.x - player.transform.position.x, 0, nav.transform.position.z - player.transform.position.z);
            SetDestination(destination);
        }
    }

    void OnDestroy()
    {
        nav.enabled = false;
    }


    private void LookForPlayer()
    {
        TestSense(player.position, currentVision);
    }

    private void HearPoint(Vector3 position)
    {
        TestSense(position, hearingRange);
    }

    private void TestSense(Vector3 position, float senseRange)
    {
        if (Vector3.Distance(this.transform.position, position) <= senseRange)
        {
            GoToPosition(position);
        }
    }

    public void GoToPlayer()
    {
        GoToPosition(player.position);
    }

    private void GoToPosition(Vector3 position)
    {
        timer = -1f;
        if (!enemyHealth.IsDead())
        {
            SetDestination(position);
        }
    }

    private void SetDestination(Vector3 position)
    {
        if (nav.isOnNavMesh)
        {
            nav.SetDestination(position);
        }
    }

    private void WanderOrIdle()
    {
        if (!nav.hasPath)
        {
            if (timer <= 0f)
            {
                SetDestination(GetRandomPoint(wanderDistance, 5));
                if (nav.pathStatus == NavMeshPathStatus.PathInvalid)
                {
                    ClearPath();
                }
                timer = Random.Range(idleTimeRange.x, idleTimeRange.y);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void IsPsychic()
    {
        GoToPlayer();
    }

    private Vector3 GetRandomPoint(float distance, int layermask)
    {
        Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * distance + this.transform.position; ;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, distance, layermask);

        return navHit.position;
    }

    public void ScaleVision(float scale)
    {
        currentVision = visionRange * scale;
    }

    private int GetCurrentNavArea()
    {
        NavMeshHit navHit;
        nav.SamplePathPosition(-1, 0.0f, out navHit);

        return navHit.mask;
    }
}