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
    public Text winLoseText;
    public Image WinLoseBG;

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            WinLoseBG.color = Color.red;
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3f));
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
            WinLoseBG.color = Color.green;
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3f));
        }
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

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
