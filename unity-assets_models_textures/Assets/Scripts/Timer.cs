using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime;  // Time tracker
    private bool timerActive;   // To know if the timer is running or not

    void Start()
    {
        elapsedTime = 0f;            // Set elapsed time to 0
        timerActive = false;         // Disable timer by default
    }

    void Update()
    {
        // If the timer is active, update the timer
        if (timerActive)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    // Method to start the timer
    public void StartTimer()
    {
        timerActive = true;
    }

    // Method to update the timer display on the UI
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        float milliseconds = elapsedTime * 1000;
        milliseconds = (milliseconds % 1000) / 10;

        timerText.text = string.Format("{0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
