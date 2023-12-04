using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingTestPuzzle : MonoBehaviour
{
    [System.Serializable]
    public class WordDefinitionPair
    {
        public string word;
        public string correctDefinition;
    }

    public List<WordDefinitionPair> wordDefinitionPairs; // Assign words with correct definitions
    public List<Dropdown> definitionDropdowns; // Assign the definition dropdowns
    public GameObject correctIndicator;
    public GameObject incorrectIndicator;

    void Start()
    {
        correctIndicator.SetActive(false);
        incorrectIndicator.SetActive(false);
        InitializeDropdowns();
    }

    void InitializeDropdowns()
    {
        List<string> definitions = new List<string>();
        foreach (var pair in wordDefinitionPairs)
        {
            definitions.Add(pair.correctDefinition);
        }
        foreach (var dropdown in definitionDropdowns)
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(definitions);
        }
    }

    public void CheckAnswers()
    {
        for (int i = 0; i < wordDefinitionPairs.Count; i++)
        {
            if (definitionDropdowns[i].options[definitionDropdowns[i].value].text != wordDefinitionPairs[i].correctDefinition)
            {
                incorrectIndicator.SetActive(true);
                Invoke("ResetPuzzle", 2); // Reset after 2 seconds
                return;
            }
        }
        correctIndicator.SetActive(true);
    }

    void ResetPuzzle()
    {
        incorrectIndicator.SetActive(false);
        correctIndicator.SetActive(false);
        foreach (var dropdown in definitionDropdowns)
        {
            dropdown.value = 0;
        }
    }
}

