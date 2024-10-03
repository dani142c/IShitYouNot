using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Vector3 camOffset = new Vector3(0,0,-10);
    public Transform playerPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = playerPos.position + camOffset;
    }
}
