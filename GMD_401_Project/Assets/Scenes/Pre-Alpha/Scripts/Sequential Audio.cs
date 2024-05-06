using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    private int currentIndex = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if any audio clips are assigned
        if (audioClips.Length == 0)
        {
            
            enabled = false; // Disable the script if no audio clips are assigned
        }

        // Start playing the first audio clip
        PlayNextAudioClip();
    }

    void Update()
    {
        // Check if the current audio clip has finished playing
        if (!audioSource.isPlaying)
        {
            // Move to the next audio clip
            currentIndex++;

            // If we've reached the end of the array, stop the script
            if (currentIndex >= audioClips.Length)
            {
                enabled = false;
                return;
            }

            // Play the next audio clip
            PlayNextAudioClip();
        }
    }

    void PlayNextAudioClip()
    {
        audioSource.clip = audioClips[currentIndex];
        audioSource.Play();
    }
}
