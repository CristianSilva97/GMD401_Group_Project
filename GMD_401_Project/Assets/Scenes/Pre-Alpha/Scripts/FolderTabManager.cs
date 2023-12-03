using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderTabManager : MonoBehaviour
{
    public GameObject[] folders; // Assign folder objects in the inspector
    public Dialogue dialogueScript; // Assign the dialogue script in the inspector

    public void BringToFront(int folderIndex)
    {
        if (folderIndex >= 0 && folderIndex < folders.Length)
        {
            folders[folderIndex].transform.SetAsLastSibling();

            // Restart the dialogue if the dialogue tab is clicked
            if (folderIndex == 0) // Assuming the dialogue tab is at index 0
            {
                dialogueScript.RestartDialogueFromBeginning();
            }
        }
    }
}
