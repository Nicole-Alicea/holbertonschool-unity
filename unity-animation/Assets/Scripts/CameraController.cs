using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float mouseSensitivity = 250f;  // Sensitivity of mouse movement
    public bool lockCursor = true;  // Whether to lock the cursor for camera rotation

    private Vector3 offset;  // Offset between the camera and the player
    private float yaw = 0f;  // Horizontal angle (left/right)
    public bool isInverted = false;    // Invert Y-axis flag

    private void Start()
    {
        // Calculate initial offset between the camera and the player
        offset = transform.position - player.position;

        // Set the initial yaw based on the camera's current rotation
        yaw = transform.eulerAngles.y;

        // Lock the cursor if necessary
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Load the saved invert Y-axis setting
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;
    }

    private void LateUpdate()
    {
        // Rotate the camera horizontally (yaw) when the right mouse button is held
        if (Input.GetMouseButton(1))
        {
            // Get the horizontal mouse movement input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            // Adjust the yaw (horizontal rotation) based on input
            yaw += mouseX;
        }

        // Calculate the new camera position based on yaw and offset
        Quaternion rotation = Quaternion.Euler(0, yaw, 0);  // Only rotate horizontally
        Vector3 newPosition = player.position + rotation * offset;

        // Apply the calculated position and make the camera look at the player
        transform.position = newPosition;
        transform.LookAt(player.position + Vector3.up * offset.y);
    }

    // Method to set the Y-axis inversion from OptionsMenu
    public void SetInvertY(bool invert)
    {
        isInverted = invert;
    }
}
