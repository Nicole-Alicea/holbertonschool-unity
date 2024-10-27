using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseCanvas;

    // Update is called once per frame
    void Update()
    {
        // Checks if Esc is pressed and toggles between Pause and Resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // If paused, resume the game
            }
            else
            {
                Pause(); // If not paused, pause the game
            }
        }
    }

    public void Pause()
    {
        isPaused = true; // Set pause state to true
        pauseCanvas.SetActive(true); // Show PauseCanvas
        Time.timeScale = 0f; // Pause the game time
    }

    public void Resume()
    {
        isPaused = false; // Set pause state to false
        pauseCanvas.SetActive(false); // Hide PauseCanvas
        Time.timeScale = 1f; // Resume game time
    }
}
