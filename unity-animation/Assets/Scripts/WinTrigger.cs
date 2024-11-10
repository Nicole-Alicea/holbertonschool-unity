using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    // Reference to the Timer script attached to the player
    public Timer playerTimer;
    public Text timerText;  // Reference to the timer Text UI element

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Stop the timer
            playerTimer.enabled = false;

            // Change the text color to green
            timerText.color = Color.green;

            // Increase the font size
            timerText.fontSize = 60;
        }
    }
}
