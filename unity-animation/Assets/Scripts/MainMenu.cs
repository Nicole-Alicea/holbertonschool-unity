using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        // Will load the level corresponding to the level integer provided
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Level01");
                break;
            case 2:
                SceneManager.LoadScene("Level02");
                break;
            case 3:
                SceneManager.LoadScene("Level03");
                break;
            default:
                Debug.LogError("Invalid level number");
                return; // Exits if invalid level is selected
        }
    }

    // This function will load the Options menu
    public void Options()
    {
        // Saves the current scene name as the previous scene
        PlayerPrefs.SetString("PreviousScene", "MainMenu");
        SceneManager.LoadScene("Options");
    }

    // This function closes the game and prints to console
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
