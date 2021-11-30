using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSettings : MonoBehaviour
{
    public Transform player;
    public float smoothing = 5f;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerCamPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, playerCamPos, smoothing * Time.deltaTime);
    }
}
