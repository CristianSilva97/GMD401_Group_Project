using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDictionary()
    {
        Application.OpenURL("https://www.dictionary.com/");
    }
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/CristianSilva97/GMD401_Group_Project/tree/main#readme");
    }
    public void OpenWilmu()
    {
        Application.OpenURL("https://www.wilmu.edu/academics/health-nursing.aspx");
    }
}
