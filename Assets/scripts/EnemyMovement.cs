using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;

    //private GameObject player;
    NavMeshAgent nav;
    bool chaseToggle = true;
    Vector3 destination;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown("space"))
        //{
         //   if (chaseToggle)
         //   {
         //       chaseToggle = false;
          //  }
          //  else
          //  {
           //     chaseToggle = true;
           // }
        //}

        if (chaseToggle)
        {
            destination.Set(player.transform.position.x, 0, player.transform.position.z);

        }
        else
        {
            destination.Set(nav.transform.position.x - player.transform.position.x, 0, nav.transform.position.z - player.transform.position.z);
        }
        nav.SetDestination(destination);
    }
}