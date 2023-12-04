using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyButtonScript : MonoBehaviour
{
    public Animator animationToTrigger; // Assign the Animator of the object to animate

    void Start()
    {
        // Optional: Ensure the animation is in its default state at start
        animationToTrigger.Play("New State"); // Replace with your idle state name
    }

    public void OnReadyButtonPressed()
    {
        // Play the animation
        animationToTrigger.Play("open_folder_match_quiz"); // Replace with your animation name

        // Disable the button to prevent re-use
        gameObject.SetActive(false);
    }
}


