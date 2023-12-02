using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject continuePrompt; // Assign in the inspector
    [TextArea(3, 10)]
    public string[] lines;
    public float textSpeed;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        continuePrompt.SetActive(false); // Hide the continue prompt initially
        StartDialogue();
    }

    void Update()
    {
        // Change to listen for the space bar instead of mouse click
        if (Input.GetKeyDown(KeyCode.Space))
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

    public void RestartDialogue()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void EndDialogue()
    {
        continuePrompt.SetActive(false); // Deactivate dialogue GameObject
        // Additional actions for the end of the dialogue can be added here
    }
}
