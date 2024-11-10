using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private bool timerStarted = false;  // To make sure the timer only starts once

    // Reference to the Timer script attached to the player
    public Timer playerTimer;

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the player
        if (other.CompareTag("Player") && !timerStarted)
        {
            // Start the timer only once when the player exits the trigger
            playerTimer.StartTimer();
            timerStarted = true;
        }
    }
}
