using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IsAnswerCorrect : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField]
    private FloatSO scoreSO;

    //When the button is pressed adds 1 to the value
    public void CorrectButtonPressed()
    {
        scoreSO.publicValue++;
        scoreText.text = scoreSO.publicValue + "";
        Debug.Log("You pressed the correct button!");
    }

    //When the button is pressed subtracts 1 from the value
    public void IncorrectButtonPressed()
    {
        scoreSO.publicValue--;
        scoreText.text = scoreSO.publicValue + "";
        Debug.Log("Uh Oh! You pressed the incorrect button!");
    }
}
