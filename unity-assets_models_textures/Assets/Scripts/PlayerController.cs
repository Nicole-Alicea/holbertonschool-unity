using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    public float horizontalInput;
    public float verticalInput;
    private Rigidbody rb;
    private Vector3 startPosition; // Store the initial starting position
    private Transform cameraTransform; // Reference to the camera's transform


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Capture the initial position of the player
        cameraTransform = Camera.main.transform; // Capture the main camera's transform
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (transform.position.y < -10f)
        {
            ResetToStart();
        }

        Move();
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Function to reset the player's position to the start when they fall
    private void ResetToStart()
    {
        rb.velocity = Vector3.zero; // Reset velocity to avoid carrying fall speed
        transform.position = new Vector3(startPosition.x, startPosition.y + 10f, startPosition.z); // We add 10f to the y position so player falls from above
    }

    private void Move()
    {
        // Get the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Project forward and right vectors onto the XZ plane (no vertical movement)
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calculate the desired direction of movement based on input and camera direction
        Vector3 direction = forward * verticalInput + right * horizontalInput;

        // Move the player in the calculated direction
        if (direction.magnitude > 0.1f)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Rotate the player to face the direction they're moving
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
