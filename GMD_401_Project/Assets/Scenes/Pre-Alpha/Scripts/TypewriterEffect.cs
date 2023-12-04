using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public Text contextText;
    public GameObject continueButton;
    public GameObject continueButton2;
    public Animator yourAnimation; // Assign this in the Inspector
    public float delay = 0.05f;
    private string fullText;

    private void Start()
    {
        continueButton.SetActive(false);
        continueButton2.SetActive(false);
        fullText = contextText.text;
        contextText.text = "";

        // Start the sequence after transitioning to the scene
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        // Wait for 1 second after scene transition
        yield return new WaitForSeconds(1.0f);

        // Play the animation
        yourAnimation.Play("MenuFolder"); // Replace with your animation name

        // Wait for the animation to complete, adjust based on animation length
        yield return new WaitForSeconds(1.0f); // Adjust this time as needed

        // Start showing the text
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            contextText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }

        continueButton.SetActive(true);
        continueButton2.SetActive(true); // Enable the continue buttons after the text is shown
    }
}