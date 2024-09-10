using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // the offset is needed so that we can see the player
    public Vector3 cameraOffset = new Vector3(0, 20, -12); // this keeps the camera behind the player
    

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraOffset; // changes the camera's position to the player's position + offset
    }
}
