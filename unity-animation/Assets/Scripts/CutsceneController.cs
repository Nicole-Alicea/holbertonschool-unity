using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;               // Reference to the Main Camera
    public GameObject cutsceneCamera;
    public GameObject player;               // Reference to the Player GameObject
    public GameObject timerCanvas;          // Reference to the Timer Canvas
    public Animator cutsceneAnimator;       // Animator component for cutscene animations

    private PlayerController playerController;  // Player Controller script reference
    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the PlayerController script on the player
        playerController = player.GetComponent<PlayerController>();
        
        // Ensure the main gameplay elements are disabled during the cutscene
        mainCamera.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);

        // Start the Intro01 animation
        cutsceneAnimator.Play("Intro01");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the cutscene animation has finished
        if (cutsceneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !cutsceneAnimator.IsInTransition(0))
        {
            // Enable main gameplay elements when the animation is complete
            mainCamera.SetActive(true);
            playerController.enabled = true;
            timerCanvas.SetActive(true);

            // Disable CutsceneController
            cutsceneCamera.SetActive(false);
        }
    }
}
