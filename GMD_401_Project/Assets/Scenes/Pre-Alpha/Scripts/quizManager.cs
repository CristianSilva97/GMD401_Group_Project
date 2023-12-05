using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI resultText;

    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        InitializeQuestions();
        ShowQuestion();
    }

    void InitializeQuestions()
    {
        // Add your questions and correct answers here
        questions.Add(new Question("What is the capital of France?", "Paris"));
        questions.Add(new Question("What is the largest planet in our solar system?", "Jupiter"));
        // Add more questions as needed
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionText.text = questions[currentQuestionIndex].QuestionText;
            resultText.text = "";
        }
        else
        {
            EndQuiz();
        }
    }

    public void CheckAnswer(string userAnswer)
    {
        if (userAnswer.ToLower() == questions[currentQuestionIndex].CorrectAnswer.ToLower())
        {
            resultText.text = "Correct!";
            score++;
        }
        else
        {
            resultText.text = $"Incorrect! Please try again!" ;
        }

        currentQuestionIndex++;
        ShowQuestion();
    }

    void EndQuiz()
    {
        questionText.text = "Quiz Completed!";
        resultText.text = $"Your Score: {score}/{questions.Count}";
    }
}

[System.Serializable]
public class Question
{
    public string QuestionText;
    public string CorrectAnswer;

    public Question(string questionText, string correctAnswer)
    {
        QuestionText = questionText;
        CorrectAnswer = correctAnswer;
    }
}
