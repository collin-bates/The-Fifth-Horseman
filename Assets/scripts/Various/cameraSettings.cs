using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSettings : MonoBehaviour
{

    public GameObject gameHandler;
    public GameObject player;
    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    public bool pauseMovement = false;

    Vector3 offset;

    void Awake()
    {
        offset = new Vector3(0, 1.6f, 0.0f);
    }

    void FixedUpdate()
    {
        if (!gameHandler.GetComponent<GameHandler>().toggleEsc)
        { 
        transform.position = player.transform.position + offset;
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed / 2;
        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        }
    }
}
