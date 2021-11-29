using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private enemyHealth healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new enemyHealth(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
