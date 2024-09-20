using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat; // Trap material
    public Material goalMat; // Goal material
    public Toggle colorblindMode; // Toggle to switch between normal and colorblind mode for the colors in the maze
    
    public void PlayMaze()
    {
        if (colorblindMode.isOn) // Checks if colorblind mode is selected
        {
            trapMat.color = new Color32(255, 112, 0, 1); // Changes red to orange
            goalMat.color = Color.blue; // changes green to blue
        }
        else
        {
            trapMat.color = Color.red; // changes orange to red
            goalMat.color = Color.green; // changes blue to green
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Menu scene is at build index 0 so this adds 1 to it to load the maze scene
    }

    public void QuitMaze()
    {
        Application.Quit(); // Quits the game
        Debug.Log("Quit Game");
    }
}
