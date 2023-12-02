using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderTabManager : MonoBehaviour
{
    public GameObject[] folders; // Assign your folder objects in the inspector
    public Dialogue dialogueScript;

    public void BringToFront(int folderIndex)
    {
        Debug.Log("BringToFront called with index: " + folderIndex);

        if (folderIndex >= 0 && folderIndex < folders.Length)
        {
            folders[folderIndex].transform.SetAsLastSibling();
            Debug.Log(folders[folderIndex].name + " brought to front.");
        }
    }
    public void OnTab0Clicked()
    {
        // Assuming you have a reference to the Dialogue script named dialogueScript
        dialogueScript.RestartDialogue();
    }

}


