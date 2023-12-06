using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;
   
    [SerializeField]
    private FloatSO scoreSO;

    //When the button is pressed adds 1 to the value and prompts player to proceed
    public void CorrectButtonPressed()
    {

        scoreSO.publicValue++;
        if (scoreSO.publicValue >= 10)
        {
            scoreSO.publicValue = 10;
        }
        scoreText.text = scoreSO.publicValue + "";
        correctText.text = "Correct! \n Proceed to the next question.";
        Debug.Log("You pressed the correct button!");
    }

    //When the button is pressed prompts player to try again
    public void IncorrectButtonPressed()
    {
        if (scoreSO.publicValue <= 0)
        {
            scoreSO.publicValue = 0;
        }
        scoreText.text = scoreSO.publicValue + "";
        incorrectText.text = "Incorrect! \n Please press redo to try again.";
        Debug.Log("Uh Oh! You pressed the incorrect button!");
    }
}
