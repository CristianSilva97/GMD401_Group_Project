using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public Text contextText;
    public GameObject continueButton;
    public GameObject continueButton2;
    public float delay = 0.05f;
    private string fullText;

    private void Start()
    {
        continueButton.SetActive(false);
        continueButton2.SetActive(false);
        fullText = contextText.text;
        contextText.text = "";
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1); // Wait 1 or 2 seconds before starting

        for (int i = 0; i <= fullText.Length; i++)
        {
            contextText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }

        continueButton.SetActive(true);
        continueButton2.SetActive(true);// Enable the continue button after the text is shown
    }
}

