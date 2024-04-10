using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions;
    public Text questionText;
    public Button[] answerButtons;
    public Image correctImage;
    public Image incorrectImage;
    public Button submitButton;
    public GameObject endButton; // Assuming you have a GameObject for the end button

    private Question currentQuestion;
    private int currentQuestionIndex;
    private int selectedAnswer = -1; // -1 means no answer is selected

    // Start is called before the first frame update
    void Start()
    {
        correctImage.gameObject.SetActive(false);
        incorrectImage.gameObject.SetActive(false);
        endButton.SetActive(false);
        currentQuestionIndex = 0;
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        correctImage.gameObject.SetActive(false); // Ensure correct/incorrect images are reset
        incorrectImage.gameObject.SetActive(false);

        if (currentQuestionIndex >= questions.Count)
        {
            // If there are no more questions, show the end button
            endButton.SetActive(true);
            return;
        }

        currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.questionText;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Update button text and reset visual state
            answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];
            SetButtonState(answerButtons[i], true, Color.white);
            int buttonIndex = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(buttonIndex));
        }
        submitButton.onClick.RemoveAllListeners();
        submitButton.onClick.AddListener(OnSubmit);
        selectedAnswer = -1; // Reset selected answer
    }

    void OnAnswerSelected(int index)
    {
        selectedAnswer = index;
        // Highlight the selected button and unhighlight others
        for (int i = 0; i < answerButtons.Length; i++)
        {
            SetButtonState(answerButtons[i], i != selectedAnswer, i == selectedAnswer ? Color.green : Color.white);
        }
    }

    void OnSubmit()
    {
        if (selectedAnswer < 0 || selectedAnswer >= currentQuestion.answers.Length)
        {
            Debug.LogError("Invalid answer selected");
            return;
        }

        bool isCorrect = selectedAnswer == currentQuestion.correctAnswerIndex;
        correctImage.gameObject.SetActive(isCorrect);
        incorrectImage.gameObject.SetActive(!isCorrect);

        // Disable buttons after submission
        foreach (Button btn in answerButtons)
        {
            SetButtonState(btn, false, Color.gray);
        }

        // If the answer is correct, prepare for the next question
        if (isCorrect)
        {
            if (++currentQuestionIndex >= questions.Count)
            {
                endButton.SetActive(true);
            }
            else
            {
                submitButton.gameObject.SetActive(true); // Re-enable the submit button for the next question
                Invoke("DisplayQuestion", 2); // Wait 2 seconds before displaying next question
            }
        }
        else
        {
            // If the answer is incorrect, restart the question
            Invoke("RestartCurrentQuestion", 2); // Wait 2 seconds before restarting the question
        }
    }

    void RestartCurrentQuestion()
    {
        correctImage.gameObject.SetActive(false);
        incorrectImage.gameObject.SetActive(false);
        DisplayQuestion(); // Redisplay the current question
    }

    void SetButtonState(Button button, bool interactable, Color color)
    {
        button.interactable = interactable;
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        // Update the highlighted color as well to ensure it stays highlighted
        colors.highlightedColor = color;
        button.colors = colors;
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}