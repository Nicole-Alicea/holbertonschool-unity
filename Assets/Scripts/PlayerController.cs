using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput; // Stores horizontal input values from the player(sphere)
    public float verticalInput; // Stores vertical input values from the player(sphere)
    public float speed = 10f; // Value to move player
    private int score = 0; // Stores the player's score
    public int health = 5; // Stores the player's health
    public TMP_Text scoreText;
    public TMP_Text healthText;
    // private Transform lastTeleporter;

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void FixedUpdate()
    {
        // read values from keyboard
        horizontalInput = Input.GetAxis("Horizontal"); // works with WASD and arrow keys
        verticalInput = Input.GetAxis("Vertical"); // works with WASD and arrow keys

        // move the player(sphere)
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed); // controls forward and backward movements
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed); // controls right and left movements
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            SetScoreText();
            Destroy(other.gameObject);
        }

        else if (other.tag == "Trap")
        {
            SetHealthText();
        }

        else if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }

        // else if (other.tag == "Teleporter")
        // {
        //     // Find the other teleporter
        //     GameObject[] teleporters = GameObject.FindGameObjectsWithTag("Teleporter");

        //     foreach (GameObject teleporter in teleporters)
        //     {
        //         // Move the player to the other teleporter (even if it's the one they just came from)
        //         if (teleporter.transform != other.transform || teleporter.transform == lastTeleporter)
        //         {
        //             // Teleport the player to the position of the other teleporter
        //             transform.position = teleporter.transform.position;

        //             // Update the last teleporter used to allow back-and-forth teleportation
        //             lastTeleporter = teleporter.transform;

        //             break;
        //         }
        //     }
        // }
    }
    void SetScoreText()
    {
        score++;
        scoreText.text = $"Score: {score.ToString()}";
    }

    void SetHealthText()
    {
        health--;
        healthText.text = $"Health: {health.ToString()}";
    }
}
