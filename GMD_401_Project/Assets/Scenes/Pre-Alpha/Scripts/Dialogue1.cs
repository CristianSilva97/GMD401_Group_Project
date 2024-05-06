using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject continuePrompt; // Assign in the inspector
    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject readyButton; // Assign this button in the Inspector
    private bool buttonShown = false; // Flag to track if the button has been shown

    void Start()
    {
        textComponent.text = string.Empty;
        continuePrompt.SetActive(false); // Hide the continue prompt initially
        readyButton.SetActive(false); // Ensure the ready button is initially hidden
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                continuePrompt.SetActive(true); // Show the continue prompt immediately
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        continuePrompt.SetActive(true); // Show the continue prompt when the line is complete

        // Show the ready button only if it hasn't been shown before
        if (index == lines.Length - 1 && !buttonShown)
        {
            readyButton.SetActive(true);
            buttonShown = true;
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            continuePrompt.SetActive(false); // Hide the continue prompt when starting a new line
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        if (!buttonShown)
        {
            readyButton.SetActive(true);
            buttonShown = true;
        }
    }

    public void ResetDialogue()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        index = 0;
        buttonShown = false; // Reset the buttonShown flag
        continuePrompt.SetActive(false);
        readyButton.SetActive(false); // Hide the ready button
        StartDialogue();
    }
    public void RestartDialogueFromBeginning()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        index = 0; // Reset the index to the start
        continuePrompt.SetActive(false); // Hide the continue prompt
        StartCoroutine(TypeLine());
    }
}





