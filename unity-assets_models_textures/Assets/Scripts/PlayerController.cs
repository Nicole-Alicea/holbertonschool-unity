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


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0, 0, verticalInput) * speed * Time.deltaTime);
        }

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            transform.Translate(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
